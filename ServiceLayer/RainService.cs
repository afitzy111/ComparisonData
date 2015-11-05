using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace ServiceLayer
{
    //Entity classes that correspond with the database objects

    public class RainRecord
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
            this.yearRef = (int)dbRain.Year_Ref;
            this.outflowFullYear = (int)dbRain.Outflow_Full_Year;
            this.outflowSummer = (int)dbRain.Outflow_Summer;
            this.outflowWinter = (int)dbRain.Outflow_Winter;
            this.rainFullYear = (int)dbRain.Rain_Full_Year;
            this.rainSummer = (int)dbRain.Rain_Summer;
            this.rainWinter = (int)dbRain.Rain_Winter;
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
        public int cereals { get; set; }
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
        public int grossCapitalFormation { get; set; }
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

        public FarmProductionRealRecord(FarmRealProductionLive pl)
        {
            this.farmRecordID = pl.Farm_Record_ID;
            this.farmingYear = (int)pl.Farming_Year;
            this.cereals = (int)pl.Output_of_Cereals;
            this.wheat = (int)pl.Wheat;
            this.barley = (int)pl.Barley;
            this.oats = (int)pl.Oats;
            this.industrialCrops = (int)pl.Output_of_Industrial_Crops;
            this.oilseedRape = (int)pl.Oilseed_Rape;
            this.proteinCrops = (int)pl.Protein_Crops;
            this.sugarBeet = (int)pl.Sugar_Beet;
            this.foragePlants = (int)pl.Output_of_Forage_Plants;
            this.vegAndHorticultural = (int)pl.Output_of_Vegetables_and_Horticultural;
            this.freshVeg = (int)pl.Fresh_Vegetables;
            this.flowers = (int)pl.Plants_and_Flowers;
            this.potatoes = (int)pl.Output_of_Potatoes;
            this.fruit = (int)pl.Output_of_Fruit;
            this.cropProducts = (int)pl.Output_of_Crop_Products;
            this.totalLivestock = (int)pl.Output_of_Livestock;
            this.livestockForMeat = (int)pl.Primarily_for_meat;
            this.cattle = (int)pl.Cattle;
            this.pigs = (int)pl.Pigs;
            this.sheep = (int)pl.Sheep;
            this.poultry = (int)pl.Poultry;
            this.grossCapitalFormation = (int)pl.Gross_Fixed_Captial_Formation;
            //public int cattle2;
            //public int pigs2;
            //public int Sheep2;
            //public int Poultry2;
            this.livestockProducts = (int)pl.Output_of_Livestock_Products;
            this.milk = (int)pl.Milk;
            this.eggs = (int)pl.Eggs;
            this.otherAgri = (int)pl.Other_Agricultural_Activities;
            this.inseperableNonAgri = (int)pl.Inseperable_NonAgricultural_Activities;
            this.subsidies = (int)pl.Total_Subsidies_less_taxes;
            this.totalIncome = (int)pl.Total_Income;
        }
    }

    public class FarmProductionCurrentRecord
    {
        public int farmRecordID { get; set; }
        public int farmingYear { get; set; }
        public int cereals { get; set; }
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
        public int grossCapitalFormation { get; set; }
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

        public FarmProductionCurrentRecord(FarmCurrentProductionLive pl)
        {
            this.farmRecordID = pl.Farm_Record_ID;
            this.farmingYear = (int)pl.Farming_Year;
            this.cereals = (int)pl.Output_of_Cereals;
            this.wheat = (int)pl.Wheat;
            this.barley = (int)pl.Barley;
            this.oats = (int)pl.Oats;
            this.industrialCrops = (int)pl.Output_of_Industrial_Crops;
            this.oilseedRape = (int)pl.Oilseed_Rape;
            this.proteinCrops = (int)pl.Protein_Crops;
            this.sugarBeet = (int)pl.Sugar_Beet;
            this.foragePlants = (int)pl.Output_of_Forage_Plants;
            this.vegAndHorticultural = (int)pl.Output_of_Vegetables_and_Horticultural;
            this.freshVeg = (int)pl.Fresh_Vegetables;
            this.flowers = (int)pl.Plants_and_Flowers;
            this.potatoes = (int)pl.Output_of_Potatoes;
            this.fruit = (int)pl.Output_of_Fruit;
            this.cropProducts = (int)pl.Output_of_Crop_Products;
            this.totalLivestock = (int)pl.Output_of_Livestock;
            this.livestockForMeat = (int)pl.Primarily_for_meat;
            this.cattle = (int)pl.Cattle;
            this.pigs = (int)pl.Pigs;
            this.sheep = (int)pl.Sheep;
            this.poultry = (int)pl.Poultry;
            this.grossCapitalFormation = (int)pl.Gross_Fixed_Captial_Formation;
            //public int cattle2;
            //public int pigs2;
            //public int Sheep2;
            //public int Poultry2;
            this.livestockProducts = (int)pl.Output_of_Livestock_Products;
            this.milk = (int)pl.Milk;
            this.eggs = (int)pl.Eggs;
            this.otherAgri = (int)pl.Other_Agricultural_Activities;
            this.inseperableNonAgri = (int)pl.Inseperable_NonAgricultural_Activities;
            this.subsidies = (int)pl.Total_Subsidies_less_taxes;
        }

    }

    public class FarmConsumptionRealRecord
    {
        public int Farm_Record_ID { get; set; }
        public int Farming_Year { get; set; }
        public int seeds { get; set; }
        public int energy { get; set; }
        public int electricity { get; set; }
        public int machineFuels { get; set; }
        public int fertilisers { get; set; }
        public int plantProtection { get; set; }
        public int veterinary { get; set; }
        public int animalFeed { get; set; }
        public int compounds { get; set; }
        public int straights { get; set; }
        //public int IC_Feed_Produced_and_used_on_Farm_or_Purchased_from_other_farms { get; set; }
        public int maintenance { get; set; }
        public int materials { get; set; }
        public int buildings { get; set; }
        public int agriServices { get; set; }
        public int mediationServices { get; set; }
        public int other { get; set; }
        public int fixedCapital { get; set; }
        public int equipment { get; set; }
        public int buildingTax { get; set; }
        public int livestock { get; set; }
        public int cattle { get; set; }
        public int pigs { get; set; }
        public int sheep { get; set; }
        public int poultry { get; set; }
        public int othertaxes { get; set; }
        public int otherSubsities { get; set; }
        public int employeeCompensation { get; set; }
        public int rent { get; set; }
        public int interest { get; set; }

        public FarmConsumptionRealRecord(FarmRealConsumptionLive cl)
        {
            this.Farm_Record_ID = cl.Farm_Record_ID;
            this.Farming_Year = (int)cl.Farming_Year;
            this.seeds = (int)cl.IC_Seeds;
            this.energy = (int)cl.IC_Energy;
            this.electricity = (int)cl.IC_Electricity_and_Fuels_for_Heating;
            this.machineFuels = (int)cl.IC_Motor_and_Machinery_Fuels;
            this.fertilisers = (int)cl.IC_Fertilisers;
            this.plantProtection = (int)cl.IC_Plant_Protection_Products;
            this.veterinary = (int)cl.IC_Veterinary_Expenses;
            this.animalFeed = (int)cl.IC_Animal_Feed;
            this.compounds = (int)cl.IC_Compounds;
            this.straights = (int)cl.IC_Straights;
            //public int IC_Feed_Produced_and_used_on_Farm_or_Purchased_from_other_farms { get; set; }
            this.maintenance = (int)cl.IC_Total_Maintenance;
            this.materials = (int)cl.IC_Materials;
            this.buildings = (int)cl.IC_Buildings;
            this.agriServices = (int)cl.IC_Agricultural_Services;
            this.mediationServices = (int)cl.IC_FISIM;
            this.other = (int)cl.IC_Other_Goods_and_Services;
            this.fixedCapital = (int)cl.IC_Total_Consumption_of_Fixed_Capital;
            this.equipment = (int)cl.IC_Equipment;
            this.buildingTax = (int)cl.IC_Buildings_Tax;
            this.livestock = (int)cl.IC_Livestock;
            this.cattle = (int)cl.IC_Cattle;
            this.pigs = (int)cl.IC_Pigs;
            this.sheep = (int)cl.IC_Sheep;
            this.poultry = (int)cl.IC_Poultry;
            this.othertaxes = (int)cl.IC_Other_Taxes_on_Production;
            this.otherSubsities = (int)cl.IC_Other_Subsidies_on_Production;
            this.employeeCompensation = (int)cl.IC_Compensation_of_Employees;
            this.rent = (int)cl.IC_Rent;
            this.interest = (int)cl.IC_Interest;
        }
    }

    public class FarmConsumptionCurrentRecord
    {
        public int farmRecordId { get; set; }
        public int farmingYear { get; set; }
        public int seeds { get; set; }
        public int energy { get; set; }
        public int electricity { get; set; }
        public int machineFuels { get; set; }
        public int fertilisers { get; set; }
        public int plantProtection { get; set; }
        public int veterinary { get; set; }
        public int animalFeed { get; set; }
        public int compounds { get; set; }
        public int straights { get; set; }
        //public int IC_Feed_Produced_and_used_on_Farm_or_Purchased_from_other_farms { get; set; }
        public int maintenance { get; set; }
        public int materials { get; set; }
        public int buildings { get; set; }
        public int agriServices { get; set; }
        public int mediationServices { get; set; }
        public int other { get; set; }
        public int fixedCapital { get; set; }
        public int equipment { get; set; }
        public int buildingTax { get; set; }
        public int livestock { get; set; }
        public int cattle { get; set; }
        public int pigs { get; set; }
        public int sheep { get; set; }
        public int poultry { get; set; }
        public int othertaxes { get; set; }
        public int otherSubsities { get; set; }
        public int employeeCompensation { get; set; }
        public int rent { get; set; }
        public int interest { get; set; }

        public FarmConsumptionCurrentRecord(FarmCurrentConsumptionLive cl)
        {
            this.farmRecordId = cl.Farm_Record_ID;
            this.farmingYear = (int)cl.Farming_Year;
            this.seeds = (int)cl.IC_Seeds;
            this.energy = (int)cl.IC_Energy;
            this.electricity = (int)cl.IC_Electricity_and_Fuels_for_Heating;
            this.machineFuels = (int)cl.IC_Motor_and_Machinery_Fuels;
            this.fertilisers = (int)cl.IC_Fertilisers;
            this.plantProtection = (int)cl.IC_Plant_Protection_Products;
            this.veterinary = (int)cl.IC_Veterinary_Expenses;
            this.animalFeed = (int)cl.IC_Animal_Feed;
            this.compounds = (int)cl.IC_Compounds;
            this.straights = (int)cl.IC_Straights;
            //public int IC_Feed_Produced_and_used_on_Farm_or_Purchased_from_other_farms { get; set; }
            this.maintenance = (int)cl.IC_Total_Maintenance;
            this.materials = (int)cl.IC_Materials;
            this.buildings = (int)cl.IC_Buildings;
            this.agriServices = (int)cl.IC_Agricultural_Services;
            this.mediationServices = (int)cl.IC_FISIM;
            this.other = (int)cl.IC_Other_Goods_and_Services;
            this.fixedCapital = (int)cl.IC_Total_Consumption_of_Fixed_Capital;
            this.equipment = (int)cl.IC_Equipment;
            this.buildingTax = (int)cl.IC_Buildings_Tax;
            this.livestock = (int)cl.IC_Livestock;
            this.cattle = (int)cl.IC_Cattle;
            this.pigs = (int)cl.IC_Pigs;
            this.sheep = (int)cl.IC_Sheep;
            this.poultry = (int)cl.IC_Poultry;
            this.othertaxes = (int)cl.IC_Other_Taxes_on_Production;
            this.otherSubsities = (int)cl.IC_Other_Subsidies_on_Production;
            this.employeeCompensation = (int)cl.IC_Compensation_of_Employees;
            this.rent = (int)cl.IC_Rent;
            this.interest = (int)cl.IC_Interest;
        }
    }

    public class ExportMilsRecord
    {
        public int tradeYearId { get; set; }
        public int tradeYear { get; set; }
        public int eu { get; set; }
        public int asiaOceania { get; set; }
        public int easternEurope { get; set; }
        public int latinAmerica { get; set; }
        public int middleEastNorthAfrica { get; set; }
        public int northAmerica { get; set; }
        public int southernAfrica { get; set; }
        public int westernEurope { get; set; }
        public int nonEUTotal { get; set; }
        public int grandTotal { get; set; }

        public ExportMilsRecord(ExportMilsTableLive et)
        {
            this.tradeYearId = et.Trade_YEAR_ID;
            this.tradeYear = (int)et.Trade_Year;
            this.eu = (int)et.EU_Total;
            this.asiaOceania = (int)et.Asia_Oceania;
            this.easternEurope = (int)et.Eastern_Europe;
            this.latinAmerica = (int)et.Latin_America;
            this.middleEastNorthAfrica = (int)et.Middle_East_N_Africa;
            this.northAmerica = (int)et.N_America;
            this.southernAfrica = (int)et.Southern_Africa;
            this.westernEurope = (int)et.Western_Europe;
            this.nonEUTotal = (int)et.Non_EU_Eotal;
            this.grandTotal = (int)et.Grand_Total;
        }
    }
}
