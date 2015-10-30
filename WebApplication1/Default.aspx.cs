using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void retrieveRain(int year)
        {
            ServiceLayer.RainRecord rcrd = new ServiceLayer.RainRecord();

        }
    }
}