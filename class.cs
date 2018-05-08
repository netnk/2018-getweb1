using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using HtmlAgilityPack;
using Newtonsoft.Json;
using getweb1;

namespace getweb1
{
    public class Class1
    {
        public string get_stock1(string stock_num)
        {
            string url = "https://tw.stock.yahoo.com/q/q?s=" + stock_num;
            string result = get_url(url, 1);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(result);
            var title = htmlDoc.DocumentNode.SelectNodes(@"//td[@align='center']");  //Title
            string title2 = title[0].InnerText;
            string price = title[2].InnerText;

            Stock1 stock1 = new Stock1();
            stock1.stock_name = title2;
            stock1.stock_price = price;

            string result2 = JsonConvert.SerializeObject(stock1);

            return result2;

        }  //Yahoo Stock

        public string get_url(string url,int lang)
        {
            switch(lang)
            {
                case 0:
                    {
                        using (WebClient wc = new WebClient())
                        {
                            wc.Encoding = System.Text.Encoding.UTF8;
                            string result = wc.DownloadString(url);
                            return result;
                        }
                        
                    }
                case 1:
                    {
                        using (WebClient wc = new WebClient())
                        {
                            wc.Encoding = System.Text.Encoding.GetEncoding("big5");
                            string result = wc.DownloadString(url);
                            return result;
                        }
                        
                    }
                default:
                    {
                        using (WebClient wc = new WebClient())
                        {
                            wc.Encoding = System.Text.Encoding.UTF8;
                            string result = wc.DownloadString(url);
                            return result;
                        }
                    }
            }
           
        }

        public string auth(string authcode, string result)
        {
            switch (authcode)
            {
                case "#####-#####":
                    {
                        return result; 
                    }
                default:
                    {
                        return "ERROR";                      
                    }
            }
        }

    }
}
