using System;
using System.Collections.Generic;
using System.Web;
using getweb1;

namespace getweb1
{
    /// <summary>
    /// Summary description for hola1
    /// </summary>
    public class hola1 : IHttpHandler
    {
        getweb1.Class1 codehp = new getweb1.Class1();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";           
            string para1 = context.Request.QueryString["stocknum"];
            string authcode = context.Request.QueryString["auth"];
            string str = codehp.auth(authcode, codehp.get_stock1(para1));
            context.Response.Write(str);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
