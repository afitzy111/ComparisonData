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
        ServiceLayer.ProductionCurrentService pcr = new ServiceLayer.ProductionCurrentService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }
     

        protected void btn_click(object sender, EventArgs e)
        {           
            if (sender.Equals(btnRain))
            {
                Chart.Series.Add("Rain");
                Chart.Series["Rain"].ChartType = SeriesChartType.Line;
                Chart.Series["Rain"].ChartArea = "MainChartArea";

                foreach (ServiceLayer.RainRecord rec in retrieveRainRecords())
                {
                    Chart.Series["Rain"]
                        .Points.AddXY(rec.yearRef, rec.rainFullYear);
                }
            }
            else if (sender.Equals(btnOutflow))
            {
                Chart.Series.Add("Outflow");
                Chart.Series["Outflow"].ChartType = SeriesChartType.Line;
                Chart.Series["Outflow"].ChartArea = "MainChartArea";

                foreach (ServiceLayer.RainRecord rec in retrieveRainRecords())
                {
                    Chart.Series["Outflow"]
                        .Points.AddXY(rec.yearRef, rec.outflowFullYear);
                }
            }
            else if (sender.Equals(btnCattle))
            {
                Chart.Series.Add("Cattle");
                Chart.Series["Cattle"].ChartType = SeriesChartType.Line;
                Chart.Series["Cattle"].ChartArea = "MainChartArea";

                foreach (ServiceLayer.FarmProductionCurrentRecord rec in retrieveCurProdRecords())
                {
                    Chart.Series["Cattle"]
                        .Points.AddXY(rec.farmingYear, rec.cattle);
                }
            }
        }

        protected List<ServiceLayer.RainRecord> retrieveRainRecords()
        {
            List<ServiceLayer.RainRecord> list = new List<ServiceLayer.RainRecord>();

            list = rs.RetrieveAllRainrecords();

            return list;
        }

        protected List<ServiceLayer.FarmProductionCurrentRecord> retrieveCurProdRecords()
        {
            List<ServiceLayer.FarmProductionCurrentRecord> list = new List<ServiceLayer.FarmProductionCurrentRecord>();

            list = pcr.retrieveAllCurProd();

            return list;
        }
    }
}