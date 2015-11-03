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

    public class FarmProductionRealRecord
    {
        public int farmRecordID { get; set; }
        public int farmingYear { get; set; }
        public int outputOfCereals { get; set; }
        public int wheat { get; set; }
        public int barley { get; set; }
        public int oats { get; set; }
        public int industrialCrops { get; set; }
        public int oilseedRape { get; set; }
        public int proteinCrops { get; set; }
        public int sugarBeet { get; set; }
        public int foragePlants { get; set; }
        public int vegAndHorticultural { get; set; }
        public int freshVeg { get; set; }
        public int flowers { get; set; }
        public int potatoes { get; set; }
        public int fruit { get; set; }
        public int cropProducts { get; set; }
        public int totalLivestock { get; set; }
        public int livestockForMeat { get; set; }
        public int cattle { get; set; }
        public int pigs { get; set; }
        public int sheep { get; set; }
        public int poultry { get; set; }
        public int grossCaptialFormation { get; set; }
        //public int cattle2;
        //public int pigs2;
        //public int Sheep2;
        //public int Poultry2;
        public int livestockProducts { get; set; }
        public int milk { get; set; }
        public int eggs { get; set; }
        public int otherAgri { get; set; }
        public int inseperableNonAgri { get; set; }
        public int subsidies { get; set; }
        public int totalIncome { get; set; }
    }

    public class FarmProductrionCurrentRecord
    {
        public int farmRecordID { get; set; }
        public int farmingYear { get; set; }
        public int outputOfCereals { get; set; }
        public int wheat { get; set; }
        public int barley { get; set; }
        public int oats { get; set; }
        public int industrialCrops { get; set; }
        public int oilseedRape { get; set; }
        public int proteinCrops { get; set; }
        public int sugarBeet { get; set; }
        public int foragePlants { get; set; }
        public int vegAndHorticultural { get; set; }
        public int freshVeg { get; set; }
        public int flowers { get; set; }
        public int potatoes { get; set; }
        public int fruit { get; set; }
        public int cropProducts { get; set; }
        public int totalLivestock { get; set; }
        public int livestockForMeat { get; set; }
        public int cattle { get; set; }
        public int pigs { get; set; }
        public int sheep { get; set; }
        public int poultry { get; set; }
        public int grossCaptialFormation { get; set; }
        //public int cattle2;
        //public int pigs2;
        //public int Sheep2;
        //public int Poultry2;
        public int livestockProducts { get; set; }
        public int milk { get; set; }
        public int eggs { get; set; }
        public int otherAgri { get; set; }
        public int inseperableNonAgri { get; set; }
        public int subsidies { get; set; }
    }

    public class FarmConsumptionRealRecord
    {

    }

    public class FarmConsumptionCurrentRecord
    {

    }

    public class ExportMilsRecord
    {

    }
}
