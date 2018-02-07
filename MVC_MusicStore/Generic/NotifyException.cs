using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MusicStore.Generic
{
    public class NotifyException : FilterAttribute, IExceptionFilter
    {
        private static string logFileName = @"C:\Users\admin\source\repos\MVC_MusicStore\MVC_MusicStore\Content\Log.txt";

        public void OnException(ExceptionContext filterContext)
        {
            var exceptionname = filterContext.Exception;

            using (StreamWriter writer = File.AppendText(logFileName))
            {
                Log("Exception Name " + exceptionname + " " + "DateTime " + DateTime.Now, writer); 
                writer.Close();
            }

        }

        public static void Log(String logMessage, TextWriter writer)
        {
            writer.Write("\r\nLog Entry : ");
            writer.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            writer.WriteLine("  :");
            writer.WriteLine("  :{0}", logMessage);
            writer.WriteLine("-------------------------------");
            // Update the underlying file.
            writer.Flush();
        }
    }
}