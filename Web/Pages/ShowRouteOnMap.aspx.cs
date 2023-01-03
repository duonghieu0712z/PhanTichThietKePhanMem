using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Description;
using Web.Model;
using WebGrease.Css.Extensions;

namespace Web.Pages
{
    public partial class ShowRouteOnMap : System.Web.UI.Page
    {
        


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string update(string userdata)
        {
            Console.WriteLine("test");
            return "Posted";
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<BusStopModel> GetAllBusStop()
        {
            List<BusStopModel> list = new List<BusStopModel>();
            HRFunctions.Instance.SelectAllBusStop().ForEach(item =>
            {
                list.Add(new BusStopModel(item));
            });
            return list;
        }


      
    }

}