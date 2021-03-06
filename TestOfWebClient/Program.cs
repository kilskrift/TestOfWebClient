﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestOfWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string rainManURI = "http://rainman.leanpoker.org/rank";
            var webClient = new WebClient();
            var cardsData =
                @"cards=[{ ""rank"":""5"",""suit"":""diamonds""},
    { ""rank"":""6"",""suit"":""diamonds""},
    { ""rank"":""7"",""suit"":""diamonds""},
    { ""rank"":""7"",""suit"":""spades""},
    { ""rank"":""8"",""suit"":""diamonds""},
    { ""rank"":""9"",""suit"":""diamonds"" }]";

            webClient.Headers["Content-Type"] = "application/x-www-form-urlencoded";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(rainManURI);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            string postData = cardsData;
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData);
            request.ContentLength = byte1.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);            
            newStream.Close();
        }
    }
}
