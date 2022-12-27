using BusinessLayer;
using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Pages
{
    public partial class Test : System.Web.UI.Page
    {
        public List<BusType> BustypeList;
        protected void Page_Load(object sender, EventArgs e)
        {
            BustypeList = HRFunctions.Instance.SelectAllBusType();
        }
    }
}