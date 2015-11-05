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
        ServiceLayer.ProductionCurrentService pcs = new ServiceLayer.ProductionCurrentService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }
     

        protected void btn_click(object sender, EventArgs e)
        {
            //Series series1 = Chart.Series["Series1"];
            //Series series2 = Chart.Series["Series2"];

            //ChartFormat();

            //List<ServiceLayer.RainRecord> rrList = retrieveRainRecords();
            //List<ServiceLayer.FarmProductionCurrentRecord> curList = retrieveCurRecords();
            List<int> rainInts = new List<int>();
            List<int> farmInts = new List<int>();
            List<int> l1YearInts = new List<int>();
            List<int> l2YearInts = new List<int>();

            if (sender.Equals(btnRain))
            {                     
                foreach (ServiceLayer.RainRecord rec in retrieveRainRecords())
                {
                    rainInts.Add(rec.rainFullYear);
                    l1YearInts.Add(rec.yearRef);
                }

                foreach (ServiceLayer.FarmProductionCurrentRecord rec in retrieveCurRecords())
                {
                    farmInts.Add(rec.cattle);
                    l2YearInts.Add(rec.farmingYear);
                }
                Dset(rainInts, farmInts, l1YearInts, l2YearInts);

            }
            else if (sender.Equals(btnOutflow))
            {
                foreach (ServiceLayer.RainRecord rec in retrieveRainRecords())
                {
                    rainInts.Add(rec.outflowFullYear);
                    l1YearInts.Add(rec.yearRef);
                }

                foreach (ServiceLayer.FarmProductionCurrentRecord rec in retrieveCurRecords())
                {
                    farmInts.Add(rec.cattle);
                    l2YearInts.Add(rec.farmingYear);
                }
                Dset(rainInts, farmInts, l1YearInts, l2YearInts);
            }
        }

        protected List<ServiceLayer.RainRecord> retrieveRainRecords()
        {
            List<ServiceLayer.RainRecord> list = new List<ServiceLayer.RainRecord>();

            list = rs.RetrieveAllRainrecords();

            return list;
        }

        protected List<ServiceLayer.FarmProductionCurrentRecord> retrieveCurRecords()
        {
            List<ServiceLayer.FarmProductionCurrentRecord> list = new List<ServiceLayer.FarmProductionCurrentRecord>();

            list = pcs.retrieveAllCurProd();

            return list;
        }

        public void RainSet(int i1, int i2)
        {
            //ChartFormat();
            //Two series on one chart
            Series series1 = Chart.Series["Series1"];
            Series series2 = Chart.Series["Series2"];

            //totals for getting average
            double total1 = 0, total2 = 0;

            //growth rate variables
            double growthRate1 = 0, growthRate2 = 0;
            double averageGrowthRate1 = 0, averageGrowthRate2 = 0;

            //Randomly assigned arrays for plot points

            int[] randomInts2 = new int[20];
        }

        //Steve Changes
        public void Dset(List<int> l1, List<int> l2, List<int> l1Year, List<int> l2Year)
        {
            ChartFormat();
            //Two series on one chart
            Series series1 = Chart.Series["Series1"];
            Series series2 = Chart.Series["Series2"];

            //totals for getting average
            double total1 = 0, total2 = 0;

            //growth rate variables
            double growthRate1 = 0, growthRate2 = 0;
            double averageGrowthRate1 = 0, averageGrowthRate2 = 0;

            
            int[] list1 = l1.ToArray();
            int[] list2 = l2.ToArray();
            int[] curYear = l1Year.ToArray();
            int[] curYear2 = l2Year.ToArray();
            int yearIncrementer = -1;


            foreach (int plot in l1)
            {
                yearIncrementer++;
                Chart.Series["Series1"]
                    .Points.AddXY(curYear[yearIncrementer], list1[yearIncrementer]);

                total1 += list1[yearIncrementer];

                //check no nulls are taken for the growth rate formula
                if ((yearIncrementer - 1 >= 0))
                {
                    growthRate1 = (double)((list1[yearIncrementer] - list1[yearIncrementer - 1]) / (double)list1[yearIncrementer - 1]);
                }

                //total growth rate variables first
                averageGrowthRate1 += growthRate1;
            }

            yearIncrementer = -1;

            foreach (int plot in l2)
            {
                yearIncrementer++;
                Chart.Series["Series2"]
                    .Points.AddXY(curYear2[yearIncrementer], list2[yearIncrementer]);

                total2 += list2[yearIncrementer];

                //check no nulls are taken for the growth rate formula
                if ((yearIncrementer - 1 >= 0))
                {
                    growthRate2 = (double)((list2[yearIncrementer] - list2[yearIncrementer - 1]) / (double)list2[yearIncrementer - 1]);
                }
                averageGrowthRate2 += growthRate2;

            }


            //get average and convert to percent
            averageGrowthRate1 = (averageGrowthRate1 / list1.Length) * 100;
            averageGrowthRate2 = (averageGrowthRate2 / list2.Length) * 100;

            //Average values for each series
            double seriesAverage1 = (double)total1 / list1.Length;
            double seriesAverage2 = (double)total2 / list2.Length;



            //Spearman's Rank correlation for each random set of integers
            double spearmansRankValue = SpearmansCoeff(list1, list2);
            Label_Spearmans_Rank_Value.Text = Math.Round(spearmansRankValue, 2).ToString();

            //Calculates the Degrees of Freedom needed to test for significance
            //in the final version, this value will be the number of points - 2
            //i.e. DoF = n - 2;
            double DoF = DegreesOfFreedom(list1, list2);

            string isSignificant;

            if (SignificanceTest(DoF, spearmansRankValue))
            {
                isSignificant = "There is at least a 95% chance that the relationship between these two datasets are significant";
            }
            else
            {
                isSignificant = "It is not certain that the relationship between these two datasets are statistically significant";
            }

            //Create DataTable to insert all these values into Gridview
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Series Name");
            dt.Columns.Add("Sample Size");
            dt.Columns.Add("Overall Average");
            dt.Columns.Add("Growth Rate");
            dt.Columns.Add("Spearman's Rank Correlation and Significance");
            DataRow row1 = dt.NewRow();
            row1["Series Name"] = "Rainfall Full Year";
            row1["Sample Size"] = list1.Length.ToString();
            row1["Overall Average"] = Math.Round(seriesAverage1).ToString();
            row1["Growth Rate"] = Math.Round(averageGrowthRate1, 2).ToString() + "%";
            row1["Spearman's Rank Correlation and Significance"] = "Correlation: " + Math.Round(spearmansRankValue, 2).ToString() + ".  " + CorrelationTest(spearmansRankValue);
            dt.Rows.Add(row1);
            DataRow row2 = dt.NewRow();
            row2["Series Name"] = "Outflow Full Year";
            row2["Sample Size"] = list2.Length.ToString();
            row2["Overall Average"] = Math.Round(seriesAverage2).ToString();
            row2["Growth Rate"] = Math.Round(averageGrowthRate2, 2).ToString() + "%";
            row2["Spearman's Rank Correlation and Significance"] = "Significance: " + isSignificant;
            dt.Rows.Add(row2);

            //Bind these values to the gridview
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }


        public double DegreesOfFreedom(IEnumerable<int> current, IEnumerable<int> other)
        {
            double[] ranksX;
            if (current.Count() > other.Count())
            {
                ranksX = GetRanking(current.Skip(current.Count() - other.Count()));
            }
            else if (current.Count() < other.Count())
            {
                ranksX = GetRanking(current.Skip(other.Count() - current.Count()));
            }
            else
            {
                ranksX = GetRanking(current);
            }
            return ranksX.Length - 2;
        }

        //Spearman's Rank methods
        public double SpearmansCoeff(IEnumerable<int> current, IEnumerable<int> other)
        {
            double[] ranksX;
            if (current.Count() > other.Count())
            {
                ranksX = GetRanking(current.Skip(current.Count() - other.Count()));
            }
            else if (current.Count() < other.Count())
            {
                ranksX = GetRanking(current.Skip(other.Count() - current.Count()));
            }
            else
            {
                ranksX = GetRanking(current);
            }
                     
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

        //Spearman's Rank significance test using the (DoF) degrees of freedom 
        public bool SignificanceTest(double DoF, double spRV)
        {
            bool isSignificant = false;
            if (spRV < 0)
            {
                spRV *= -1;
            }
            if (DoF == 4 && spRV >= 1.0) { isSignificant = true; }
            if (DoF == 5 && spRV >= 0.9) { isSignificant = true; }
            if (DoF == 6 && spRV >= 0.829) { isSignificant = true; }
            if (DoF == 7 && spRV >= 0.714) { isSignificant = true; }
            if (DoF == 8 && spRV >= 0.643) { isSignificant = true; }
            if (DoF == 9 && spRV >= 0.6) { isSignificant = true; }
            if (DoF == 10 && spRV >= 0.564) { isSignificant = true; }
            if (DoF == 11 && spRV >= 0.523) { isSignificant = true; }
            if (DoF == 12 && spRV >= 0.497) { isSignificant = true; }
            if (DoF == 13 && spRV >= 0.475) { isSignificant = true; }
            if (DoF == 14 && spRV >= 0.457) { isSignificant = true; }
            if (DoF == 15 && spRV >= 0.441) { isSignificant = true; }
            if (DoF == 16 && spRV >= 0.425) { isSignificant = true; }
            if (DoF == 17 && spRV >= 0.410) { isSignificant = true; }
            if (DoF == 18 && spRV >= 0.399) { isSignificant = true; }
            if (DoF == 19 && spRV >= 0.388) { isSignificant = true; }
            if (DoF == 20 && spRV >= 0.377) { isSignificant = true; }
            return isSignificant;
        }

        public string CorrelationTest(double spRV)
        {
            string isCorrelated;
            if (spRV < 0.4 && spRV > 0)
            {
                isCorrelated = "There is a slight positive correlation between these two datasets";
            }
            else if (spRV >= 0.4 && spRV <= 1)
            {
                isCorrelated = "There is a strong positive correlation between these two datasets";
            }
            else if (spRV < -0.4 && spRV >= -1)
            {
                isCorrelated = "There is a strong negative correlation between these two datasets";
            }
            else if (spRV >= -0.4 && spRV < 0)
            {
                isCorrelated = "There is a slight negative correlation between these two datasets";
            }
            else
            {
                isCorrelated = "There is a no correlation between these two datasets";
            }
            return isCorrelated;
        }

        //Chart Formatting
        public void ChartFormat()
        {
            Series series1 = Chart.Series["Series1"];
            Series series2 = Chart.Series["Series2"];

            ChartArea chartArea1 = Chart.ChartAreas["ChartArea1"];           

            Chart.Legends.Add(new Legend("Legend2"));
            //Chart.Titles.Add(new Title("String Build Comparison: Series1 & Series2 against the Year", Docking.Top, new Font("Arial", 14f, FontStyle.Bold), Color.Black));
            chartArea1.AxisX.Interval = 3;

            series1.BorderWidth = 2;
            Chart.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            Chart.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

            chartArea1.AxisX.Title = "Year";
            //chartArea1.AxisY.Title = "Rainfall per Year";

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
                //chartArea1.AxisY2.Title = "Outflow per Year";
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