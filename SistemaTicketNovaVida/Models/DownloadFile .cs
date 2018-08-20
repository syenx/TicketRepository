using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


namespace SistemaTicketNovaVida.Models
{
    public class DownloadFile : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition","attachment; filename=" + "Nome" + ";");

            response.TransmitFile(HttpContext.Current.Server.MapPath("FileDownload.csv"));
            response.Flush();
            response.End();
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