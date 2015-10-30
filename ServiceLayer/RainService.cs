using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace ServiceLayer
{
    public interface IRainServices
    {
        
    }

    public class RainRecord : IRainServices
    {
        public int rainID { get; set; }
        public int yearRef { get; set; }
        public int outflowFullYear { get; set; }
        public int outflowSummer { get; set; }
        public int outflowWinter { get; set; }
        public int rainFullYear { get; set; }
        public int rainSummer { get; set; }
        public int rainWinter { get; set; }

        public RainRecord() { }

        public RainRecord(RainTableLive dbRain)
        {
            this.rainID = dbRain.Record_ID;
            this.yearRef = (int) dbRain.Year_Ref;
            this.outflowFullYear = (int) dbRain.Outflow_Full_Year;
            this.outflowSummer = (int) dbRain.Outflow_Summer;
            this.outflowWinter = (int) dbRain.Outflow_Winter;
            this.rainFullYear = (int) dbRain.Rain_Full_Year;
            this.rainSummer = (int) dbRain.Rain_Summer;
            this.rainWinter = (int) dbRain.Rain_Winter;
        }

        public override string ToString()
        {
            return (this.rainID + " " + this.yearRef + " " + this.outflowFullYear);
        }
    }
}
