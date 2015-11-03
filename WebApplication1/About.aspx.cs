using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            if (sender.Equals(btnRain))
            {
                Chart.Series.Add("Rain");
                Chart.Series["Rain"].ChartType = SeriesChartType.Line;
                Chart.Series["Rain"].ChartArea = "MainChartArea";

                foreach (ServiceLayer.RainRecord rec in retrieveRecords())
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

                foreach (ServiceLayer.RainRecord rec in retrieveRecords())
                {
                    Chart.Series["Outflow"]
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


        //Steve Changes
        public void Update()
        {
            //Two series on one chart
            Series series1 = Chart.Series["Series1"];
            Series series2 = Chart.Series["Series2"];

            //totals for getting average
            double total1 = 0, total2 = 0;

            //growth rate variables
            double growthRate1 = 0, growthRate2 = 0;
            double averageGrowthRate1 = 0, averageGrowthRate2 = 0;

            //Randomly assigned arrays for plot points
            Random random = new Random();
            int[] randomInts1 = new int[20];
            int[] randomInts2 = new int[20];


            for (int pointIndex = 0; pointIndex < randomInts1.Length; pointIndex++)
            {
                //create array of size 20 of random variables
                randomInts1[pointIndex] = random.Next(45, 95);
                randomInts2[pointIndex] = random.Next(5, 55);

                //plot them
                series1.Points.AddXY(pointIndex, randomInts1[pointIndex]);
                series2.Points.AddXY(pointIndex, randomInts2[pointIndex]);

                //assign totals for average
                total1 += randomInts1[pointIndex];
                total2 += randomInts2[pointIndex];

                //check no nulls are taken for the growth rate formula
                if ((pointIndex - 1 >= 0))
                {
                    growthRate1 = (double)((randomInts1[pointIndex] - randomInts1[pointIndex - 1]) / (double)randomInts1[pointIndex - 1]);
                    growthRate2 = (double)((randomInts2[pointIndex] - randomInts2[pointIndex - 1]) / (double)randomInts2[pointIndex - 1]);

                }

                //total growth rate variables first
                averageGrowthRate1 += growthRate1;
                averageGrowthRate2 += growthRate2;

            }

            //get average and convert to percent
            averageGrowthRate1 = (averageGrowthRate1 / randomInts1.Length) * 100;
            averageGrowthRate2 = (averageGrowthRate2 / randomInts2.Length) * 100;

            //Average values for each series
            double seriesAverage1 = (double)total1 / 16;
            double seriesAverage2 = (double)total2 / 16;


            //Create DataTable to insert all these values into Gridview
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Series Name");
            dt.Columns.Add("Average");
            dt.Columns.Add("Growth");
            DataRow row1 = dt.NewRow();
            row1["Series Name"] = "Rainfall Full Year";
            row1["Average"] = seriesAverage1.ToString();
            row1["Growth"] = Math.Round(averageGrowthRate1, 2).ToString() + "%";
            dt.Rows.Add(row1);
            DataRow row2 = dt.NewRow();
            row2["Series Name"] = "Outflow Full Year";
            row2["Average"] = seriesAverage2.ToString();
            row2["Growth"] = Math.Round(averageGrowthRate2, 2).ToString() + "%";
            dt.Rows.Add(row2);

            //Bind these values to the gridview
            GridView1.DataSource = dt;
            GridView1.DataBind();


            //Spearman's Rank correlation for each random set of integers
            double spearmansRankValue = SpearmansCoeff(randomInts1, randomInts2);
            Label_Spearmans_Rank_Value.Text = Math.Round(spearmansRankValue, 2).ToString();


        }

        //Spearman's Rank methods
        public double SpearmansCoeff(IEnumerable<int> current, IEnumerable<int> other)
        {
            if (current.Count() != other.Count())
                throw new ArgumentException("Both collections of data must contain an equal number of elements");

            double[] ranksX = GetRanking(current);
            double[] ranksY = GetRanking(other);

            var diffPair = ranksX.Zip(ranksY, (x, y) => new { x, y });
            double sigmaDiff = diffPair.Sum(s => Math.Pow(s.x - s.y, 2));
            int n = current.Count();

            // Spearman's Coefficient of Correlation
            // ρ = 1 - ((6 * sum of rank differences^2) / (n(n^2 - 1))
            double rho = 1 - ((6 * sigmaDiff) / (Math.Pow(n, 3) - n));

            return rho;
        }
        public double[] GetRanking(IEnumerable<int> values)
        {
            var groupedValues = values.OrderByDescending(n => n)
                                      .Select((val, i) => new { Value = val, IndexedRank = i + 1 })
                                      .GroupBy(i => i.Value);

            double[] rankings = (from n in values
                                 join grp in groupedValues on n equals grp.Key
                                 select grp.Average(g => g.IndexedRank)).ToArray();

            return rankings;
        }

        //Chart Formatting
        public void ChartFormat()
        {
            Series series1 = Chart.Series["Series1"];
            Series series2 = Chart.Series["Series2"];

            ChartArea chartArea1 = Chart.ChartAreas["ChartArea1"];

            Update();

            Chart.Legends.Add(new Legend("Legend2"));
            Chart.Titles.Add(new Title("String Build Comparison: Series1 & Series2 against the Year", Docking.Top, new Font("Arial", 14f, FontStyle.Bold), Color.Black));
            chartArea1.AxisX.Interval = 3;

            series1.BorderWidth = 2;
            Chart.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            Chart.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

            chartArea1.AxisX.Title = "Year";
            chartArea1.AxisY.Title = "Rainfall per Year";

            series1.ToolTip = "Data Point Rainfall per Year: #VALY{0}\n" +
                                       "Data Point Year: #VALX{0}\n";

            series1.YAxisType = AxisType.Primary;
            chartArea1.AxisY.LineColor = Color.DarkRed;
            chartArea1.AxisY.LineWidth = 2;


            //Chart Format
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = true;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.WordWrap;
            chartArea1.AxisX.IsLabelAutoFit = true;
            chartArea1.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            chartArea1.BackColor = Color.WhiteSmoke;
            if (series2.Points != null)
            {
                //Multiple Axis
                Chart.ChartAreas["ChartArea1"].AxisY2.TitleFont = new Font("Arial", 12, FontStyle.Bold);
                chartArea1.AxisY2.Title = "Outflow per Year";
                series2.BorderWidth = 2;
                series2.ToolTip = "Data Point" + "Outflow per Year" + ": #VALY{0}\n" + "Data Point" + "Year" + ": #VALX{0}\n";
                chartArea1.AxisY2.Enabled = AxisEnabled.True;
                series2.YAxisType = AxisType.Secondary;
                chartArea1.AxisY2.LineColor = Color.DarkBlue;
                chartArea1.AxisY2.IsStartedFromZero = chartArea1.AxisY.IsStartedFromZero;
                chartArea1.AxisY2.LineWidth = 2;
                chartArea1.AxisX.LineWidth = 2;
            }

        }


    }
}