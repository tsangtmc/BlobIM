# BlobIM
Azure Blob Storage Integrity Monitoring and Security Alerting

Please read the readme.docx or readme.pdf for functionality details

-Compiling Code-

The resource and package files can be found here https://github.com/tsangtmc/Resources_BIM.
I was not able to publish the binaries with this code, however i happened to find the matching files in a offically unrelated repo.
Once you pull down https://github.com/tsangtmc/Resources_BIM copy and paste the files into the BIM project files by matching up the directory structure.
e.g: all file in BlobStorage_IDS\packages\ from "Resources_BIM" should go into BlobStorage_IDS\packages\ from "BlobIM".

-About BIM-

This is essentially a File Integrity Monitoring (FIM) tool for azure blob storage.

Blob Integrity Monitor (BIM) is a client side tool for monitoring blob storage. For any blobs which change in blob storage, BIM will be able to detect and alert upon. This includes any introduction of new blobs and the removal of blobs as well as any changes in data. Further functionality for monitoring unauthorized access to blob storage is in the development roadmap of the tool. BIM has been designed to have a small foot print on system resources, to this goal many design choices were made. Additionally BIM does not persist sensitive information in memory, information such as blob storage keys or other information are only in memory during the time of the actual check and then disposed of after.

Copyright 
MIT
Blob Integrity Monitor
Copyright (c) Microsoft Corporation

All rights reserved. 
MIT License
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the ""Software""), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
