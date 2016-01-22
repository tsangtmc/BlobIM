using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobIDS.Information
{
    class BlobStorageBilling
    {
        /*
         Storage transactions (http://azure.microsoft.com/en-us/pricing/details/storage/)
        We charge $0.0036 per 100,000 transactions for all Standard storage types. 
        Transactions include both read and write operations to storage. 
        There are no storage transaction charges for Premium Storage.
         
        
        When using Windows Azure Blobs, Tables and Queues storage costs can consist of:

        Bandwidth – the amount of data transferred in and out of the location hosting the storage account
        Transactions – the number of requests performed against your storage account
        Storage Capacity – the amount of data being stored persistently
        Note, the content in this posting is subject to change as we add more features to the storage system. This posting is given as a guideline to allow services to be able to estimate their storage bandwidth, transactions and capacity usage before they go to production with their application.

        Pricing details can be found here.

        The following gives an overview of billing for these three areas:

        Bandwidth – Since applications need to compute over their stored data, we allow hosted services to be co-located with their storage. This allows us to provide free bandwidth between computation and storage that are co-located, and only charge bandwidth for storage when accessed from outside the location it is stored in.
        Transactions – Each individual Blob, Table and Queue REST request to the storage service is considered as a potential transaction for billing. Applications can then control their transaction costs by controlling how often and how many requests they send to the storage service. We analyze each request received and then classify it as billable or not billable based upon our ability to process the request and the request’s outcome.
        Capacity – We accumulate the size of the objects stored (blobs, entities and messages) as well as their application and system metadata in order to measure the storage capacity for billing.
        In the rest of this post we will explain how to understand these three areas for your application.

        When Bandwidth is Counted

        In order to access Blobs, Tables and Queues, you first need to create a storage account by going to the Windows Azure Developer Portal. When creating the storage account you can specify what location to store your storage account in. The six locations we currently offer are:

        US North Central
        US South Central
        Europe North
        Europe West
        Asia East
        Asia Southeast
        All of the data for that storage account will be stored and accessed from the location chosen. Some applications choose a location that is geographically closest to their client base, if possible, to potentially reduce latency to those customers. A key aspect here is that you will want to also choose in the Developer Portal the same location for your hosted service as the storage account that the service needs to access. The reason for this is that the bandwidth for the data transferred within the same location is free. In contrast, when transferring data in or out of the assigned location for the storage account, the bandwidth charges listed at the start of this post will accrue.

        Now it is important to note that bandwidth is free within the same location for access, but the transactions are not free. Every single access to the storage system is counted as a single transaction towards billing. In addition, bandwidth is only charged for transactions that are considered to be billable transactions as defined later in this posting.

        Another concept to touch on in terms of bandwidth is when you use blobs with the Windows Azure Content Delivery Network (CDN). If the blob is not found in the CDN (or the blob’s time-to-live (TTL) has expired) it is read from the storage account (origin) to cache it. When this occurs, the bandwidth consumed to cache the blob (transfer it from the origin to the CDN) is charged against the storage account (as well as a single transaction). This emphasizes that you should use a CDN for blobs that are referenced enough to get cache hits, before they expire in the cache due to the TTL, to offset the additional time and cost of transferring the blob from your storage account to the CDN.

        Here are a few examples:

        Your storage account and hosted service are both located in “US North Central”. All bandwidth for data accessed by your hosted service to that storage account is free, since they are in the same location.
        Your storage account is located in “US North Central” and your hosted service is located in “US South Central”. All bandwidth for data accessed by your hosted service to the storage account will incur the bandwidth charges listed at the start of this post.
        Your storage account is located in “US North Central”, and your blobs are cached and served by one of the Windows Azure CDN edge locations in Europe . Since the Windows Azure CDN edge location is not in the same location as your storage account, when the data is read from your storage account to the Windows Azure CDN for caching it will incur the above bandwidth charges.
        Your storage account is located in “US North Central” but accessed by websites and services around the world. Since it isn’t being accessed from a Windows Azure hosted service within the same location the standard bandwidth charges are applied.
        How Transactions are Counted

        The first area we would want to cover for transactions is what equals 1 transaction to Windows Azure Storage. Each and every REST call to Windows Azure Blobs, Tables and Queues counts as 1 transaction (whether that transaction is counted towards billing is determined by the billing classification discussed later in this posting). The REST calls are detailed here:

        Blobs
        Tables
        Queues
        Each one of the above REST calls counts as 1 transaction. This includes the following types of requests:

        Query/List Requests and Continuation Tokens – A Table Query, and Listing Blob Containers, Tables and Queues can return continuation tokens. This means that the query/listing must be continued to complete it. As described above, each REST request to the storage service counts as 1 transaction. Therefore, each continuation of the query/list counts as an additional 1 transaction, since it is another REST request to the storage service.
        Batch Operations– We currently support two types of batch operations:
        Get Messages - the ability to get up to 32 messages at once from a Queue.
        Entity Group Transactions – the ability to perform an atomic transaction across up to 100 entities with any combination of Insert, Update, or Delete for Azure Tables. The requirement is that all of the entities have to be in the same table and have the same PartitionKey value and the total request size must be under 4Mbytes.
        Both of these types of batch operations result in a single REST request to the storage service. Therefore, they count as a single transaction for each request.

        When using the Storage Client Library, there are a few function calls that can result in multiple REST requests to your storage account.

        Uploading Blobs – When uploading a blob greater than 32 Mbytes, the storage client library will break it into 4 Mbyte blocks by default. The block size can be changed by setting the CloudBlobClient.WriteBlockSizeInBytes field. When uploading a blob larger than 32MBs the client library will upload each block as a separate PutBlock REST request and then commit all of the blocks at the end with a PutBlockList. Each PutBlock will count as 1 transaction, and the final PutBlockList will also count as 1 transaction.
        Table Queries – When you query using CloudTableQuery it takes care of handling continuation tokens, so it reissues queries using the continuation token receieved in a previous query request to get remaining entities. As described above, each reissued continuation token query to the service counts as 1 transaction.
        Table SaveChanges – For the Table service, when you do an AddObject, UpdateObject or DeleteObject the entity gets added to a data context so that at some later point the changes can be flushed to your storage account when the program executes SaveChangesWithRetries. When SaveChangesWithRetries executes, all of the pending changes are then pushed to the Table service one at a time each using its own REST call. So each pending change counts as 1 transaction. 
        The one exception to this is the Entity Group Transaction. If you have batched up operations (AddObject, UpdateObject, DeleteObject) for a set of entities with the same PartitionKey value, you can execute a single SaveChangesWithRetries(SaveChangesOptions.Batch), and then this will send all of the changes to the table service as a single REST request and it will count as 1 transaction. The key is to make sure to pass in the SaveChangesOptions.Batch option to SaveChangesWithRetries method. We have seen services forget the SaveChangesOptions.Batch and this results in each pending change to be sent as a separate request leaving the customer wondering why the SaveChanges is taking a lot longer than it should, the operations would not be atomically performed as a single transaction (meaning they either all commit or none of them commit), and they would end up with a higher transaction count than expected.
        Here are a few examples:

        A single GetBlob request to the blob service = 1 transaction
        PutBlob with 1 request to the blob service = 1 transaction
        Large blob upload that results in 100 requests via PutBlock, and then 1 PutBlockList for commit = 101 transactions
        Listing through a lot of blobs using 5 requests total (due to 4 continuation markers) = 5 transactions
        Table single entity AddObject request = 1 transaction
        Table Save Changes (without SaveChangesOptions.Batch) with 100 entities = 100 transactions
        Table Save Changes (with SaveChangesOptions.Batch) with 100 entities = 1 transaction
        Table Query specifying an exact PartitionKey and RowKey match (getting a single entity) = 1 transaction
        Table query doing a single storage request to return 500 entities (with no continuation tokens encountered) = 1 transaction
        Table query resulting in 5 requests to table storage (due to 4 continuation tokens) = 5 transactions
        Queue put message = 1 transaction
        Queue get single message = 1 transaction
        Queue get message on empty queue = 1 transaction
        Queue batch get of 32 messages = 1 transaction
        Queue delete message = 1 transaction
        Now that we understand what a transaction is, let’s describe what transactions are counted towards billing and what transactions are not counted.

        When a transaction reaches our service, if it falls into one of the following classifications we do not count it towards billable transactions, and no bandwidth is charged for these transactions:

        Pre-Authentication Failure – If we do not even get the chance to authenticate the transaction then it does not count towards billable transactions. Examples here include malformed requests with bad http headers, badly formed URLs, the time range for the request is invalid, etc.
        Authentication Failure – if the transaction fails authentication we do not count it towards the billable transactions for the storage account.
        Quota Permission Failure – we have a 100TB quota per storage account. If a storage account hits that limit, then we put the storage account into a mode where it has only READ+DELETE permissions, but no WRITE permissions. This allows the storage account to perform Get and Delete operations, but not put/post operations. When in this mode, requests that require write permissions will fail, and we do not count these towards billable transactions.
        Incorrect Shared Access Signature (SAS) HTTP Verb/Permission – If the sent signature correctly validates (authenticates), but the REST operation keyword (PUT, POST, GET, DELETE) does not correctly match the permissions, then the request will not be counted towards billable transactions. For example, if the permissions specify that only PUT can be performed, but a GET verb is used with a valid SAS, the request will fail and not be counted towards billable transactions.
        Anonymous Request Failures – If a request comes in without a signature it will be treated as an anonymous request, and we classify the following 3 types of failures as transactions that do not count towards billable transactions:
        Incorrect Permissions – Anonymous requests can only be GET requests. If it is not a GET request, it is rejected and does not count towards billable transactions.
        Container Not Found – If the container does not exist for the anonymous GET request, then it is not counted towards billable transactions.
        Blob Not Found – If the blob trying to be accessed does not exist for the anonymous GET request, then it is not counted towards billable transactions.
        Unexpected Timeouts – If the request times out due to an issue in the storage system, it is not counted towards billable transactions.
        If any of the above conditions apply then the transaction is not counted towards billable transactions and no bandwidth is charged for the request. Then for the rest of the transactions we classify them as billable and they may or may not incur bandwidth charges as described in the bandwidth section.

        We categorize the billable transactions into the following buckets:

        Successful Transactions – Any successful transaction completed against the storage system.
        Expected Failures– The expected failures come from the following three areas:
        Transaction Errors – These are requests that are correctly authenticated with correct permissions that fail due to the transaction semantics being applied against the data in the storage account. Some examples are:
        Trying to get or delete an object that has already been deleted or never existed, which results in a NotFound error.
        Trying to create an object that already exists, which results in an AlreadyExists error. For example, we have seen applications that perform a CreateIfNotExist on a Queue before every put message into that queue. This results in two separate requests to the storage system for every message they want to enqueue, with the create queue failing. Make sure you only create your Blob Containers, Tables and Queues at the start of their lifetime to avoid these extra transaction costs.
        Doing a conditional operation with an ETag Match, Non-Match, Modified-Since, or Unmodified-Since, and having the operation fail (getting back a NotModified or PreconditionFailed) will count as a transaction.
        Trying to add a Table Entity that already exists will result in a failure (Conflict - 409). Similarly, trying to Update an entity that does not exist will result in a failure (Not Found - 404 ). These count towards transaction costs. This is actually an issue for applications that want to do an Upsert, which we are currently evaluating how to support for Windows Azure Tables. Until Upsert is provided, users should evaluate their usage scenario to decide if they should either do INSERT before UPDATE or UPDATE before INSERT in order to minimize the amount of expected failures and overall transactions to Windows Azure Tables.
        Valid Shared Access Signature (SAS) with a ContainerNotFound or BlobNotFound. If the SAS signature validates correctly, but the container is not found or the blob being accessed is not found, then this is counted as a billable transaction.
        Etc. The list is quite long, since there are many ways requests can encounter an expected failure based on the semantics exposed by the storage service (e.g., conditional operations, leases, sequence numbers, etc).
        Throttling – These are requests that are being throttled due to the transaction rate going over the per partition target throughput described in the post “Windows Azure Storage Abstractions and their Scalability Targets”. These throttled requests are counted as billable transactions. When this occurs, the client is expected to use exponential backoff and retry the request, which is provided by default with the storage client library. If it is a reoccurring event for the service, then the service should consider additional partitioning of its data structures as described in the upcoming posts on Blobs, Tables and Queues.
        Expected Timeouts – When you send a request to the service you can specify your own timeout and you can set it to be smaller than the SLA timeout. If the request has a timeout less than the SLA timeout, and the request times out, it is classified as an expected timeout and counted towards billable transactions.
        How to Estimate Capacity

        Customers have asked to understand more details about the cost of storing Blobs, Tables and Queues in order to estimate the amount of storage capacity used by their application before running it in production.

        The first thing to understand is how the monthly bill is accumulated for storage capacity. The storage capacity is calculated and aggregated at least once a day, and then averaged over the whole month to arrive at a GB/month charge. For example, if you used 10 GB the first half of the month and 0 GB the second half of the month, the monthly charge would be 5 GB.

        The following describes how the storage capacity is calculated for Blobs, Tables and Queues.  
        In the below Len(X) means the number of characters in the string.

        Blob Containers – The following is how to estimate the amount of storage consumed per blob container:

        48 bytes + Len(ContainerName) * 2 bytes + 
        For-Each Metadata[3 bytes + Len(MetadataName) + Len(Value)] + 
        For-Each Signed Identifier[512 bytes]

        The following is the breakdown:

        48 bytes of overhead for each container includes the Last Modified Time, Permissions, Public Settings, and some system metadata.
        The container name is stored as Unicode so take the number of characters and multiply by 2.
        For each blob container metadata stored, we store the length of the name (stored as ASCII), plus the length of the string value.
        The 512 bytes per Signed Identifier includes signed identifier name, start time, expiry time and permissions.
        Blobs – The following is how to estimate the amount of storage consumed per blob:

        For Block Blob (base blob or snapshot) we have: 
        124 bytes + Len(BlobName) * 2 bytes + 
        For-Each Metadata[3 bytes + Len(MetadataName) + Len(Value)] + 
        8 bytes + number of committed and uncommitted blocks * Block ID Size in bytes + 
        SizeInBytes(data in unique committed data blocks stored) + 
        SizeInBytes(data in uncommitted data blocks)

        For Page Blob (base blob or snapshot) we have: 
        124 bytes + Len(BlobName) * 2 bytes + 
        For-Each Metadata[3 bytes + Len(MetadataName) + Len(Value)] + 
        number of nonconsecutive page ranges with data * 12 bytes + 
        SizeInBytes(data in unique pages stored)

        The following is the breakdown:

        124 bytes of overhead for blob, which includes the Last Modified Time, Size, Cache-Control, Content-Type, Content-Language, Content-Encoding, Content-MD5, Permissions, Snapshot information, Lease, and some system metadata.
        The blob name is stored as Unicode so take the number of characters and multiple by 2.
        Then for each metadata stored, the length of the name (stored as ASCII), plus the length of the string value.
        Then for Block Blobs
        8 bytes for the block list
        Number of blocks times the block ID size in bytes
        Plus the size of the data in all of the committed and uncommitted blocks. Note, when snapshots are used, this size only includes the unique data for this base or snapshot blob. If the uncommitted blocks are not used after a week, they will be garbage collected, and then at that time they will no longer count towards billing after that.
        Then for Page Blobs
        Number of nonconsecutive page ranges with data times 12 bytes. This is the number of unique page ranges you see when calling the GetPageRanges API.
        Plus the size of the data in bytes of all of the stored pages. Note, when snapshots are used, this size only includes the unique pages for the base blob or snapshot blob being counted.
        Tables – The following is how to estimate the amount of storage consumed per Table:

        12 bytes + Len(TableName) * 2 bytes

        The following is the breakdown:

        12 bytes overhead for each Table, which includes the Last Modified Time and some system metadata.
        The table name is stored as Unicode so take the number of characters and multiple by 2.
        Entities – The following is how to estimate the amount of storage consumed per entity:

        4 bytes  + Len (PartitionKey + RowKey) * 2 bytes + 
        For-Each Property(8 bytes + Len(Property Name) * 2 bytes + Sizeof(.Net Property Type))

        The following is the breakdown:

        4 bytes overhead for each entity, which includes the Timestamp, along with some system metadata.
        The number of characters in the PartitionKey and RowKey values, which are stored as Unicode (times 2 bytes).
        Then for each property we have an 8 byte overhead, plus the name of the property * 2 bytes, plus the size of the property type as derived from the list below.
        The Sizeof(.Net Property Type) for the different types is:

        String – # of Characters * 2 bytes + 4 bytes for length of string
        DateTime – 8 bytes
        GUID – 16 bytes
        Double – 8 bytes
        Int – 4 bytes
        INT64 – 8 bytes
        Bool – 1 byte
        Binary – sizeof(value) in bytes + 4 bytes for length of binary array
        Queues – The following is how to estimate the amount of storage consumed per Queue:

        24 bytes + Len(QueueName) * 2 + 
        For-Each Metadata(4 bytes + Len(QueueName) * 2 bytes + Len(Value) * 2 bytes)

        The following is the breakdown:

        24 bytes overhead for each Queue, which includes the Last Modified Time, and some system metadata.
        Then for each queue metadata stored, the length of the name, and the value, which are both stored in Unicode, so times 2 bytes.
        Messages – The following is how to estimate the amount of storage consumed per message:

        12 bytes + Len(Message)

        The following is the breakdown:

        12 byte overhead for the Invisibility Time, Creation Time, Dequeue Count, Message ID, and some system metadata.
        Then the # of bytes to represent the message if you are using the REST interface. If you use the storage client library it stores the messages in the following format: UTF8(Base64(message)), and the storage used would be the length of that.

        Brad Calder
         */
    }
}
