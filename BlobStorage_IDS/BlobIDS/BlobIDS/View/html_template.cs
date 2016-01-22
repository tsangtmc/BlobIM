using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobIDS.View
{
    class html_template
    {
        public static string Get_StartOfHTMLTemplate()
        {
            string header = "\r\n<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                            "\r\n" +
                            "\r\n<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">" +
                            "\r\n" +
                            "\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"en\" lang=\"en\">" +
                            "\r\n<head>" +
                            "\r\n  <meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\" />" +
                            "\r\n  <title>Snapshot</title>" +
                            "\r\n" +
                            "\r\n  <style type=\"text/css\">" +
                            "\r\nul.Parent{" +
                            "\r\nlist-style-type: none;" +
                            "\r\npadding: 0;" +
                            "\r\nmargin: 0;" +
                            "\r\nline-height: 40px;" +
                            "\r\n}" +
                            "\r\nli{ background:url('data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAQK0lEQVRYCQEgEN/vAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABbbrIQOlGdYDJKl6EwSJbPMEeV8y5Glf8uRpX/MEeV8zBIls8ySpehOlGdYFpushIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR12mKjNKl6MsQ5P3KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ytDk/kzSpelRlylLAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAFtusww1TJmRKkKS+ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KkKS/TVMmZVZbbIMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQ1mkKC9GldcpQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8vRpXZQlijKgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABDWKE2LEST7SlBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/LEST70JYoTgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAENZpCgsRJPtKUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/yxEk+9CWKQqAAAAAAAAAAAAAAAAAAAAAAAAAAAAW26zDC9GldcpQZH/KUGR/y1Ek/9Za6j/YHKs/2ByrP9gcqz/YHKs/2ByrP9PY6T/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8uRpXZWW2zDAAAAAAAAAAAAAAAAAAAAAAANUyZkSlBkf8pQZH/KUGR/8HI3v/+/v7///////7+/v/+/v7//v7+//7+/v/+/v7/jZnD/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/NUyZlQAAAAAAAAAAAAAAAABHXaYqKkKS+ylBkf8pQZH/KUGR//7+/v////////////7+/v/////////////////+/v7/y9Hj/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KkKS/UVbpSwAAAAAAAAAAAAzSpejKUGR/ylBkf8pQZH/KUGR//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7/+Pn7/+jq8f/o6vH/6Orx/+jq8f/o6vH/6Orx/+jq8f/GzOH/OlCZ/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/zNKmKkAAAAAAFtushAsQ5P3KUGR/ylBkf8pQZH/KUGR///////+/v7///////7+/v/////////////////+/v7//v7+///////+/v7///////7+/v///////v7+//7+/v//////ipfC/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ytDk/lYbLAUADpRnWApQZH/KUGR/ylBkf8pQZH/KUGR////////////////////////////////////////////////////////////////////////////////////////////k5/H/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf85UJxiADJKl6EpQZH/KUGR/ylBkf8pQZH/KUGR//7+/v/+/v7///////7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7///////7+/v///////v7+//7+/v//////kp7G/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8ySZelADBIls8pQZH/KUGR/ylBkf8pQZH/KUGR////////////////////////////////////////////////////////////////////////////////////////////kp7G/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8wR5bTADBHlfMpQZH/KUGR/ylBkf8pQZH/KUGR//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7/kp7G/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8wR5b3AC5Glf8pQZH/KUGR/ylBkf8pQZH/KUGR///////+/v7///////7+/v/////////////////+/v7//v7+///////+/v7///////7+/v/o6/L/pa7P/4aTv/+NmsP/aXmx/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8sRJT/AC5Glf8pQZH/KUGR/ylBkf8pQZH/KUGR//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//Pz9/5ahyP8vRpP/K0OS/0Zan/89U5r/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8sRJT/ADBHlfMpQZH/KUGR/ylBkf8pQZH/KUGR//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7/ipbB/ypCkf+KlsH/7e/1//7+/v/+/v7/0tfm/1Zpp/8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8wR5b3ADBIls8pQZH/KUGR/ylBkf8pQZH/KUGR///////////////////////////////////////////////////////Q1eb/KkKR/5eiyP///////////8/V5v/d4Oz///////X2+f9PY6T/KUGR/ylBkf8pQZH/KUGR/ylBkf8vR5bTADJKl6EpQZH/KUGR/ylBkf8pQZH/KUGR//////////////////////////////////////////////////////9+jLv/QFac//r7/P///////////3aFt/+eqcv////////////Axt3/KUGR/ylBkf8pQZH/KUGR/ylBkf8ySpenADpRnWApQZH/KUGR/ylBkf8pQZH/KUGR///////+/v7///////7+/v/////////////////+/v7///////////9WaKf/dIS3//7+/v/M0uT/maTK/1Jmpf9neLD/maTK/+Dj7v/3+Pr/KUGR/ylBkf8pQZH/KUGR/ylBkf85UJxkAFpushIrQ5P5KUGR/ylBkf8pQZH/KUGR/+Xo8f/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v9UZ6b/dYW3//7+/v+7wtv/eYi6/0Zan/9VaKf/eYi6/9Xa6P/6+/z/KUGR/ylBkf8pQZH/KUGR/ytDkvlXa7AUAAAAAAAzSpelKUGR/ylBkf8pQZH/KUGR/05ho/+dqMz/oKrN/6Cqzf+gqs3/oKrN/6Cqzf+gqs3/oKrN/6Cqzf9QY6T/RVqf//z8/f///////v7+/3aFt/+eqcv//v7+///////IzuH/KUGR/ylBkf8pQZH/KUGR/zNKmKkAAAAAAAAAAABGXKUsKkKS/SlBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/6aw0P///////////7vC2//P1eb///////r7/P9ZbKn/KUGR/ylBkf8pQZH/KkKS/URapC4AAAAAAAAAAAAAAAAANUyZlSlBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/yxDkv+eqMz/+Pn7////////////4+bw/2V2r/8pQZH/KUGR/ylBkf8pQZH/NEuZlwAAAAAAAAAAAAAAAAAAAAAAWW2yDC9GldkpQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/N02X/1ttqf9RZKT/K0OS/ylBkf8pQZH/KUGR/ylBkf8uRpXbVmuxDgAAAAAAAAAAAAAAAAAAAAAAAAAAAEJYoyosRJPvKUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/yxEk/FBV6IsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABCWKE4LEST7ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/LEST8UBXojoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQlikKi5GldkpQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8uRpXbQVeiLAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAFltsww1TJmVKkKS/SlBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KkKS/TRLmZdWa7EOAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAARVulLDNKmKkrQ5P5KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ytDkvkzSpipRFqkLgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABYbLAUOVCcYjJJl6UwR5bTMEeW9yxElP8sRJT/MEeW9y9HltMySpenOVCcZFdrsBQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAALhN8mKg9O9EAAAAASUVORK5CYII=') no-repeat 0 0; " +
                            "\r\npadding-left:40px;  // according to your image with" +
                            "\r\nmin-height:40px; // according to your image height" +
                            "\r\n" +
                            "\r\n}.HandCursorStyle { cursor: pointer; cursor: hand; }" +
                            "\r\n" +
                            "\r\nul.Child {" +
                            "\r\nlist-style-type: none;" +
                            "\r\npadding: 2;" +
                            "\r\nmargin-bottom: 10px;" +
                            "\r\nlist-style-position: inside;" +
                            "\r\nline-height: 26px;" +
                            "\r\n}" +
                            "\r\n" +
                            "\r\n#ChildList li" +
                            "\r\n{ " +
                            "\r\n    background:url('data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAJI0lEQVRIDQEYCef2AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABBmdskMY3afCyK2r8sidnpLIra/yyK2v8sidnrLIravzGN2n5AmNsmAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD+X2yIui9mtKIbZ/SaG2f8mhtn/J4XZ/yaG2f8mhdn/J4XY/yaG2f8mhdn/KIbZ/S6L2a8/l9skAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADSQ214ph9n1JoXZ/yeG2f8mhdn/JoXZ/yeG2f8mhdn/JobZ/yeG2P8mhtn/JobZ/yeG2P8mhtn/KYfZ9TSP22IAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADOO2Xonhtn/J4bZ/yeG2P8nhtj/J4bY/yeG2P8nhtj/J4bY/yeF2P8nhtj/J4bY/yeF2P8nhtj/J4bY/yeF2P8nhtn/M47YfgAAAAAAAAAAAAAAAAAAAAAAAAAAADSQ214nhtn/JobZ/yaG2P8mhtn/J4XZ/yaG2f8mhtn/J4XZ/yaG2f8mhtn/J4bY/yaF2f8mhtn/J4bY/yaF2f8mhtn/J4bY/yeG2f80j9tiAAAAAAAAAAAAAAAAAD+X2yIph9n1J4bZ/yaG2f8nhtj/lcPr//7+/v/+/v7//v7+//7+/v/+/v7/pszt/2Gl4P9PnN//JoXZ/yeF2P8mhtn/JoXZ/yeF2P8mhtn/KYfZ9T6X2yQAAAAAAAAAAAAui9mtJoXZ/yaF2f8mhdn/JoXZ/5XD6//+/v7///////7+/v///////////6bM7f9xr+T/8Pb7/1Kd3/8mhtn/JobZ/yaF2f8mhtn/JobZ/yaF2f8ui9qvAAAAAABBmdskKIbZ/SeG2P8nhtj/J4XY/yeG2P+Ww+v//v7+//7+/v/+/v7//v7+//7+/v+mzO3/ca/k//7+/v/y9/v/V6Df/yeG2f8nhtj/J4bY/yeG2f8nhtj/KIbZ/UGY2ygAMY3afCaG2f8nhtn/J4XZ/yaG2f8nhtn/lcPr////////////////////////////pszt/2Wo4f/c6/f/3Ov3/9Lk9P9Eld3/JobZ/yeG2P8mhdn/JobZ/yeG2P8wjdqBACyK2r8mhtj/JoXZ/yaF2f8mhdn/JoXZ/5XD6//+/v7//v7+//7+/v/+/v7//v7+/63Q7/83j9v/N4/b/zeO2/83j9v/Lora/yaF2f8mhtn/JobZ/yaF2f8mhtn/LIrZwQAsidnpJ4XY/yeG2P8nhtj/J4XY/yeG2P+Ww+v//v7+///////+/v7//v7+//7+/v/+/v7//v7+//7+/v///////v7+/4y+6v8nhtj/J4bY/yeG2f8nhtj/J4bY/yyJ2e0ALIra/yaG2f8nhtn/J4XZ/yaG2f8nhtn/lcPr//7+/v///////v7+//////////////////7+/v/+/v7///////7+/v+Mvur/JobZ/yeG2P8mhdn/JobZ/yeG2P8qidr/ACyK2v8nhtj/J4bZ/yeG2f8mhdj/J4bY/5bD6//+/v7///////7+/v///////////////////////v7+////////////jb/q/yeF2P8nhdj/J4bY/yeF2P8nhdj/Koja/wAsidnrJobY/yaG2f8nhtn/JobY/yaG2f+Vw+v////////////+/v7//////////////////////////////////////4y+6v8mhtn/J4bZ/yaG2f8mhtn/J4bZ/yyJ2e0ALIravyaF2P8nhtn/J4bZ/yaG2f8nhtn/lcPr//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v+Mvur/JobZ/yeG2P8mhtn/JobZ/yeG2P8sitnBADGN2n4nhtj/J4bZ/yeG2f8mhdj/J4bY/5bD6///////////////////////////////////////////////////////jb/q/yeF2P8nhdj/J4bY/yeF2P8nhdj/MI3agQBAmNsmKIbZ/SaG2f8nhtn/JobY/yaG2f+Vw+v//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+/4y/6v8mhtn/J4bZ/yaG2f8mhtn/J4bZ/UCY2ygAAAAAAC6L2a8nhtn/J4bZ/yaG2f8nhtn/lcPr//7+/v///////v7+//7+/v/+/v7//v7+//7+/v/+/v7///////7+/v+Mvur/JobZ/yeG2P8mhtn/JobZ/y6L2rEAAAAAAAAAAAA/l9skKYfZ9SeG2f8mhdj/J4bY/5bD6//+/v7///////7+/v/////////////////+/v7//v7+///////+/v7/jL7p/yeF2P8nhdj/J4bY/yiH2fU+ltsmAAAAAAAAAAAAAAAAADSP22Inhtn/JobY/yaG2f8mhtn/J4bY/yaF2f8mhtn/J4bY/yaF2f8mhtn/J4bZ/yaG2f8mhtn/J4bZ/yaG2f8mhtn/J4bZ/yeG2f80j9pkAAAAAAAAAAAAAAAAAAAAAAAAAAAAM47YfieG2f8nhtn/JoXZ/yeG2f8mhdj/JoXZ/yeG2f8mhdj/JobZ/yeG2P8mhtn/JobZ/yeG2P8mhtn/JobZ/yeG2f8zjtiBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA0j9tiKYfZ9SeG2P8nhtn/J4bZ/yeG2P8nhtn/J4bZ/yeF2P8nhdj/J4bY/yeF2P8nhdj/J4bY/yiH2fU0j9pkAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD6X2yQui9qvKIbZ/SaF2f8mhtn/J4bY/yaF2f8mhtn/J4bZ/yaG2f8mhtn/J4bZ/S6L2rE+ltsmAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEGY2ygwjdqBLIrZwSyJ2e0qiNr/Koja/yyJ2e0sitnBMI3agUCY2ygAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH5x2ZbVRG8AAAAASUVORK5CYII=')no-repeat 0 0; " +
                            "\r\n	padding-left:40px;  // according to your image with" +
                            "\r\n	min-height:40px; // according to your image height" +
                            "\r\n	" +
                            "\r\n	}.HandCursorStyle { cursor: pointer; cursor: hand; }" +
                            "\r\n	" +
                            "\r\n	.hover{" +
                            "\r\n    border:1px solid white;" +
                            "\r\n    text-align:left;" +
                            "\r\n    width:350px;" +
                            "\r\n    position:relative;" +
                            "\r\n	cursor: pointer; cursor: help;" +
                            "\r\n}" +
                            "\r\n" +
                            "\r\n.tooltip{" +
                            "\r\n    display:none;" +
                            "\r\n    position:absolute;"+
                            "\r\n    border:1px solid red;" +
                            "\r\n    background-color: white;" +
                            "\r\n    text-wrap:normal;" +
                            "\r\n    word-wrap: break-word;" +
                            "\r\n    border-radius: 5px;"+
                            "\r\n    padding:5px;"+
                            "\r\n    top:-10px;"+
                            "\r\n    left:400px;"+
                            "\r\n    width: 400px;"+
                            "\r\n    z-index: 99;" +
                            "\r\n}"+
                            "\r\n.hover:hover .tooltip{"+
                            "\r\n    display:block;"+
                            "\r\n}​"+
                            "\r\n"+
                            "\r\n#lightbox{"+
                            "\r\n    visibility:hidden;"+
                            "\r\n    position:absolute;"+
                            "\r\n    background:red;"+
                            "\r\n    border:2px solid #3c3c3c;"+
                            "\r\n    color:white;"+
                            "\r\n    z-index:100;"+
                            "\r\n    width: 200px;"+
                            "\r\n    height:100px;"+
                            "\r\n    padding:20px;"+
                            "\r\n}\r\n\r\n"+
                            "\r\n.detailsbox {"+
                            "\r\n border: 1px solid green ;"+
                            "\r\n }  </style>"+
                            "\r\n"+
                            "\r\n  <script type=\"text/JavaScript\">"+
                            "\r\n    // Add this to the onload event of the BODY element\r\n"+
                            "\r\n    function addEvents() {"+
                            "\r\n      activateTree(document.getElementById(\"LinkedList1\"));"+
                            "\r\n    }"+
                            "\r\n"+
                            "\r\n    // This function traverses the list and add links "+
                            "\r\n    // to nested list items"+
                            "\r\n    function activateTree(oList) {"+
                            "\r\n      // Collapse the tree"+
                            "\r\n      for (var i=0; i < oList.getElementsByTagName(\"ul\").length; i++) {"+
                            "\r\n        oList.getElementsByTagName(\"ul\")[i].style.display=\"none\";            "+
                            "\r\n      }"+
                            "\r\n" +
                            "\r\n      // Add the click-event handler to the list items"+
                            "\r\n      if (oList.addEventListener) {"+
                            "\r\n        oList.addEventListener(\"click\", toggleBranch, false);"+
                            "\r\n      } else if (oList.attachEvent) { // For IE"+
                            "\r\n        oList.attachEvent(\"onclick\", toggleBranch);"+
                            "\r\n      }"+
                            "\r\n      // Make the nested items look like links"+
                            "\r\n      addLinksToBranches(oList);"+
                            "\r\n    }"+
                            "\r\n"+
                            "\r\n    // This is the click-event handler"+
                            "\r\n    function toggleBranch(event) {"+
                            "\r\n      var oBranch, cSubBranches;"+
                            "\r\n      if (event.target) {"+
                            "\r\n        oBranch = event.target;"+
                            "\r\n      } else if (event.srcElement) { // For IE"+
                            "\r\n        oBranch = event.srcElement;"+
                            "\r\n      }"+
                            "\r\n      cSubBranches = oBranch.getElementsByTagName(\"ul\");"+
                            "\r\n      if (cSubBranches.length > 0) {"+
                            "\r\n        if (cSubBranches[0].style.display == \"block\") {"+
                            "\r\n          cSubBranches[0].style.display = \"none\";"+
                            "\r\n        } else {"+
                            "\r\n          cSubBranches[0].style.display = \"block\";"+
                            "\r\n        }"+
                            "\r\n      }"+
                            "\r\n    }"+
                            "\r\n"+
                            "\r\n    // This function makes nested list items look like links"+
                            "\r\n    function addLinksToBranches(oList) {"+
                            "\r\n      var cBranches = oList.getElementsByTagName(\"li\");"+
                            "\r\n      var i, n, cSubBranches;"+
                            "\r\n      if (cBranches.length > 0) {"+
                            "\r\n        for (i=0, n = cBranches.length; i < n; i++) {"+
                            "\r\n          cSubBranches = cBranches[i].getElementsByTagName(\"ul\");"+
                            "\r\n          if (cSubBranches.length > 0) {"+
                            "\r\n            addLinksToBranches(cSubBranches[0]);"+
                            "\r\n            cBranches[i].className = \"HandCursorStyle\";"+
                            "\r\n            cBranches[i].style.color = \"blue\";"+
                            "\r\n            cSubBranches[0].style.color = \"black\";"+
                            "\r\n            cSubBranches[0].style.cursor = \"auto\";"+
                            "\r\n          }"+
                            "\r\n        }"+
                            "\r\n      }"+
                            "\r\n    }"+
                            "\r\n"+
                            "\r\n	function popupBlobData(blobname,containername,LastModified,MonitorThisFile,Size,MD5,SHA512,ContentType,AnonymousAccessEnabled,DownloadLocation){"+
                            "\r\n	var w = window.open('', '', 'width=500,height=400,resizeable,scrollbars');"+
                            "\r\n	w.document.write('<div style=\"word-wrap:break-word;width:470px;\">');" +
                            "\r\n	w.document.write('<b>Blob Name:</b> ' + blobname + \"<br>\");"+
                            "\r\n	w.document.write('<b>Container of Blob:</b> ' + containername + \"<br>\");"+
                            "\r\n	w.document.write('<b>ContentType:</b> ' + ContentType + \"<br>\");"+
                            "\r\n	w.document.write('<b>Blob Is Monitored:</b> ' + MonitorThisFile + \"<br>\");"+
                            "\r\n	w.document.write('<b>LastModified:</b> ' + LastModified + \"<br>\");"+
                            "\r\n	w.document.write('<b>Size:</b> ' + Size + \"<br>\");"+
                            "\r\n	w.document.write('<b>MD5:</b> ' + MD5 + \"<br>\");"+
                            "\r\n	w.document.write('<b>SHA512:</b> ' + SHA512 + \"<br>\");"+
                            "\r\n	w.document.write('<b>AnonymousAccessEnabled:</b> ' + AnonymousAccessEnabled + \"<br>\");"+
                            "\r\n	w.document.write('<b>DownloadLocation:</b> ' + DownloadLocation + \"<br></div>\");"+
                            "\r\n	w.document.close(); // needed for chrome and safari"+
                            "\r\n	}"+
                            "\r\n"+
                            "\r\n"+
                            "\r\n  </script>"+
                            "\r\n</head>"+
                            "\r\n"+
                            "\r\n<body onload=\"addEvents();\"><div class=\"detailsbox\">"+
                            "\r\n<img src=\"data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAQK0lEQVRYCQEgEN/vAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABbbrIQOlGdYDJKl6EwSJbPMEeV8y5Glf8uRpX/MEeV8zBIls8ySpehOlGdYFpushIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR12mKjNKl6MsQ5P3KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ytDk/kzSpelRlylLAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAFtusww1TJmRKkKS+ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KkKS/TVMmZVZbbIMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQ1mkKC9GldcpQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8vRpXZQlijKgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABDWKE2LEST7SlBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/LEST70JYoTgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAENZpCgsRJPtKUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/yxEk+9CWKQqAAAAAAAAAAAAAAAAAAAAAAAAAAAAW26zDC9GldcpQZH/KUGR/y1Ek/9Za6j/YHKs/2ByrP9gcqz/YHKs/2ByrP9PY6T/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8uRpXZWW2zDAAAAAAAAAAAAAAAAAAAAAAANUyZkSlBkf8pQZH/KUGR/8HI3v/+/v7///////7+/v/+/v7//v7+//7+/v/+/v7/jZnD/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/NUyZlQAAAAAAAAAAAAAAAABHXaYqKkKS+ylBkf8pQZH/KUGR//7+/v////////////7+/v/////////////////+/v7/y9Hj/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KkKS/UVbpSwAAAAAAAAAAAAzSpejKUGR/ylBkf8pQZH/KUGR//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7/+Pn7/+jq8f/o6vH/6Orx/+jq8f/o6vH/6Orx/+jq8f/GzOH/OlCZ/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/zNKmKkAAAAAAFtushAsQ5P3KUGR/ylBkf8pQZH/KUGR///////+/v7///////7+/v/////////////////+/v7//v7+///////+/v7///////7+/v///////v7+//7+/v//////ipfC/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ytDk/lYbLAUADpRnWApQZH/KUGR/ylBkf8pQZH/KUGR////////////////////////////////////////////////////////////////////////////////////////////k5/H/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf85UJxiADJKl6EpQZH/KUGR/ylBkf8pQZH/KUGR//7+/v/+/v7///////7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7///////7+/v///////v7+//7+/v//////kp7G/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8ySZelADBIls8pQZH/KUGR/ylBkf8pQZH/KUGR////////////////////////////////////////////////////////////////////////////////////////////kp7G/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8wR5bTADBHlfMpQZH/KUGR/ylBkf8pQZH/KUGR//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7/kp7G/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8wR5b3AC5Glf8pQZH/KUGR/ylBkf8pQZH/KUGR///////+/v7///////7+/v/////////////////+/v7//v7+///////+/v7///////7+/v/o6/L/pa7P/4aTv/+NmsP/aXmx/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8sRJT/AC5Glf8pQZH/KUGR/ylBkf8pQZH/KUGR//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//Pz9/5ahyP8vRpP/K0OS/0Zan/89U5r/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8sRJT/ADBHlfMpQZH/KUGR/ylBkf8pQZH/KUGR//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7/ipbB/ypCkf+KlsH/7e/1//7+/v/+/v7/0tfm/1Zpp/8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8wR5b3ADBIls8pQZH/KUGR/ylBkf8pQZH/KUGR///////////////////////////////////////////////////////Q1eb/KkKR/5eiyP///////////8/V5v/d4Oz///////X2+f9PY6T/KUGR/ylBkf8pQZH/KUGR/ylBkf8vR5bTADJKl6EpQZH/KUGR/ylBkf8pQZH/KUGR//////////////////////////////////////////////////////9+jLv/QFac//r7/P///////////3aFt/+eqcv////////////Axt3/KUGR/ylBkf8pQZH/KUGR/ylBkf8ySpenADpRnWApQZH/KUGR/ylBkf8pQZH/KUGR///////+/v7///////7+/v/////////////////+/v7///////////9WaKf/dIS3//7+/v/M0uT/maTK/1Jmpf9neLD/maTK/+Dj7v/3+Pr/KUGR/ylBkf8pQZH/KUGR/ylBkf85UJxkAFpushIrQ5P5KUGR/ylBkf8pQZH/KUGR/+Xo8f/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v9UZ6b/dYW3//7+/v+7wtv/eYi6/0Zan/9VaKf/eYi6/9Xa6P/6+/z/KUGR/ylBkf8pQZH/KUGR/ytDkvlXa7AUAAAAAAAzSpelKUGR/ylBkf8pQZH/KUGR/05ho/+dqMz/oKrN/6Cqzf+gqs3/oKrN/6Cqzf+gqs3/oKrN/6Cqzf9QY6T/RVqf//z8/f///////v7+/3aFt/+eqcv//v7+///////IzuH/KUGR/ylBkf8pQZH/KUGR/zNKmKkAAAAAAAAAAABGXKUsKkKS/SlBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/6aw0P///////////7vC2//P1eb///////r7/P9ZbKn/KUGR/ylBkf8pQZH/KkKS/URapC4AAAAAAAAAAAAAAAAANUyZlSlBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/yxDkv+eqMz/+Pn7////////////4+bw/2V2r/8pQZH/KUGR/ylBkf8pQZH/NEuZlwAAAAAAAAAAAAAAAAAAAAAAWW2yDC9GldkpQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/N02X/1ttqf9RZKT/K0OS/ylBkf8pQZH/KUGR/ylBkf8uRpXbVmuxDgAAAAAAAAAAAAAAAAAAAAAAAAAAAEJYoyosRJPvKUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/yxEk/FBV6IsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABCWKE4LEST7ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/LEST8UBXojoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQlikKi5GldkpQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8uRpXbQVeiLAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAFltsww1TJmVKkKS/SlBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KkKS/TRLmZdWa7EOAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAARVulLDNKmKkrQ5P5KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ylBkf8pQZH/KUGR/ytDkvkzSpipRFqkLgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABYbLAUOVCcYjJJl6UwR5bTMEeW9yxElP8sRJT/MEeW9y9HltMySpenOVCcZFdrsBQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAALhN8mKg9O9EAAAAASUVORK5CYII=\"/>"+
                            "\r\nAzure Container (\"<b>Single Click</b>\" to show blobs in container)<br>"+
                            "\r\n"+
                            "\r\n<img src=\"data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAJI0lEQVRIDQEYCef2AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABBmdskMY3afCyK2r8sidnpLIra/yyK2v8sidnrLIravzGN2n5AmNsmAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD+X2yIui9mtKIbZ/SaG2f8mhtn/J4XZ/yaG2f8mhdn/J4XY/yaG2f8mhdn/KIbZ/S6L2a8/l9skAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADSQ214ph9n1JoXZ/yeG2f8mhdn/JoXZ/yeG2f8mhdn/JobZ/yeG2P8mhtn/JobZ/yeG2P8mhtn/KYfZ9TSP22IAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADOO2Xonhtn/J4bZ/yeG2P8nhtj/J4bY/yeG2P8nhtj/J4bY/yeF2P8nhtj/J4bY/yeF2P8nhtj/J4bY/yeF2P8nhtn/M47YfgAAAAAAAAAAAAAAAAAAAAAAAAAAADSQ214nhtn/JobZ/yaG2P8mhtn/J4XZ/yaG2f8mhtn/J4XZ/yaG2f8mhtn/J4bY/yaF2f8mhtn/J4bY/yaF2f8mhtn/J4bY/yeG2f80j9tiAAAAAAAAAAAAAAAAAD+X2yIph9n1J4bZ/yaG2f8nhtj/lcPr//7+/v/+/v7//v7+//7+/v/+/v7/pszt/2Gl4P9PnN//JoXZ/yeF2P8mhtn/JoXZ/yeF2P8mhtn/KYfZ9T6X2yQAAAAAAAAAAAAui9mtJoXZ/yaF2f8mhdn/JoXZ/5XD6//+/v7///////7+/v///////////6bM7f9xr+T/8Pb7/1Kd3/8mhtn/JobZ/yaF2f8mhtn/JobZ/yaF2f8ui9qvAAAAAABBmdskKIbZ/SeG2P8nhtj/J4XY/yeG2P+Ww+v//v7+//7+/v/+/v7//v7+//7+/v+mzO3/ca/k//7+/v/y9/v/V6Df/yeG2f8nhtj/J4bY/yeG2f8nhtj/KIbZ/UGY2ygAMY3afCaG2f8nhtn/J4XZ/yaG2f8nhtn/lcPr////////////////////////////pszt/2Wo4f/c6/f/3Ov3/9Lk9P9Eld3/JobZ/yeG2P8mhdn/JobZ/yeG2P8wjdqBACyK2r8mhtj/JoXZ/yaF2f8mhdn/JoXZ/5XD6//+/v7//v7+//7+/v/+/v7//v7+/63Q7/83j9v/N4/b/zeO2/83j9v/Lora/yaF2f8mhtn/JobZ/yaF2f8mhtn/LIrZwQAsidnpJ4XY/yeG2P8nhtj/J4XY/yeG2P+Ww+v//v7+///////+/v7//v7+//7+/v/+/v7//v7+//7+/v///////v7+/4y+6v8nhtj/J4bY/yeG2f8nhtj/J4bY/yyJ2e0ALIra/yaG2f8nhtn/J4XZ/yaG2f8nhtn/lcPr//7+/v///////v7+//////////////////7+/v/+/v7///////7+/v+Mvur/JobZ/yeG2P8mhdn/JobZ/yeG2P8qidr/ACyK2v8nhtj/J4bZ/yeG2f8mhdj/J4bY/5bD6//+/v7///////7+/v///////////////////////v7+////////////jb/q/yeF2P8nhdj/J4bY/yeF2P8nhdj/Koja/wAsidnrJobY/yaG2f8nhtn/JobY/yaG2f+Vw+v////////////+/v7//////////////////////////////////////4y+6v8mhtn/J4bZ/yaG2f8mhtn/J4bZ/yyJ2e0ALIravyaF2P8nhtn/J4bZ/yaG2f8nhtn/lcPr//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v+Mvur/JobZ/yeG2P8mhtn/JobZ/yeG2P8sitnBADGN2n4nhtj/J4bZ/yeG2f8mhdj/J4bY/5bD6///////////////////////////////////////////////////////jb/q/yeF2P8nhdj/J4bY/yeF2P8nhdj/MI3agQBAmNsmKIbZ/SaG2f8nhtn/JobY/yaG2f+Vw+v//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+/4y/6v8mhtn/J4bZ/yaG2f8mhtn/J4bZ/UCY2ygAAAAAAC6L2a8nhtn/J4bZ/yaG2f8nhtn/lcPr//7+/v///////v7+//7+/v/+/v7//v7+//7+/v/+/v7///////7+/v+Mvur/JobZ/yeG2P8mhtn/JobZ/y6L2rEAAAAAAAAAAAA/l9skKYfZ9SeG2f8mhdj/J4bY/5bD6//+/v7///////7+/v/////////////////+/v7//v7+///////+/v7/jL7p/yeF2P8nhdj/J4bY/yiH2fU+ltsmAAAAAAAAAAAAAAAAADSP22Inhtn/JobY/yaG2f8mhtn/J4bY/yaF2f8mhtn/J4bY/yaF2f8mhtn/J4bZ/yaG2f8mhtn/J4bZ/yaG2f8mhtn/J4bZ/yeG2f80j9pkAAAAAAAAAAAAAAAAAAAAAAAAAAAAM47YfieG2f8nhtn/JoXZ/yeG2f8mhdj/JoXZ/yeG2f8mhdj/JobZ/yeG2P8mhtn/JobZ/yeG2P8mhtn/JobZ/yeG2f8zjtiBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA0j9tiKYfZ9SeG2P8nhtn/J4bZ/yeG2P8nhtn/J4bZ/yeF2P8nhdj/J4bY/yeF2P8nhdj/J4bY/yiH2fU0j9pkAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD6X2yQui9qvKIbZ/SaF2f8mhtn/J4bY/yaF2f8mhtn/J4bZ/yaG2f8mhtn/J4bZ/S6L2rE+ltsmAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEGY2ygwjdqBLIrZwSyJ2e0qiNr/Koja/yyJ2e0sitnBMI3agUCY2ygAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH5x2ZbVRG8AAAAASUVORK5CYII=\"/>"+
                            "\r\nAzure Blob (\"<b>Double Click</b>\" blob for pop-up of details)<br></div> <br>" +
                            "\r\n"+
                            "\r\n<br><br>"+
                            "\r\n"+
                            "\r\n<ul id=\"LinkedList1\" class=\"Parent\">";
            return header;
        }

        public static string Get_EndOfHTMLTemplate()
        {
            string end = "</ul>\r\n</body>\r\n</html>";
            return end;
        }
    }
}
