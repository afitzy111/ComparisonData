using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class About : System.Web.UI.Page
    {
        ServiceLayer.RainService rs = new ServiceLayer.RainService();
        ServiceLayer.RainRecord rr = new ServiceLayer.RainRecord();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btn_click(object sender, EventArgs e)
        {
            //string tb = TextBox1.Text;
            //int asInt = Convert.ToInt32(tb);
            //rr = rs.getRecord(asInt);
            //Label1.Text = rr.ToString();
            if (sender.Equals(btnRain))
            {
                chtNBAChampionships.Series.Add("Rain");
                chtNBAChampionships.Series["Rain"].ChartType = SeriesChartType.Line;
                chtNBAChampionships.Series["Rain"].ChartArea = "MainChartArea";

                foreach (ServiceLayer.RainRecord rec in retrieveRecords())
                {
                    chtNBAChampionships.Series["Rain"]
                        .Points.AddXY(rec.yearRef, rec.rainFullYear);
                }
            }
            else
            {
                chtNBAChampionships.Series.Add("Outflow");
                chtNBAChampionships.Series["Outflow"].ChartType = SeriesChartType.Line;
                chtNBAChampionships.Series["Outflow"].ChartArea = "MainChartArea";

                foreach (ServiceLayer.RainRecord rec in retrieveRecords())
                {
                    chtNBAChampionships.Series["Outflow"]
                        .Points.AddXY(rec.yearRef, rec.outflowFullYear);
                }
            }
        }

        protected List<ServiceLayer.RainRecord> retrieveRecords()
        {
            List<ServiceLayer.RainRecord> list = new List<ServiceLayer.RainRecord>();

            list = rs.RetrieveAllRainrecords();

            return list;
        }
    }
}