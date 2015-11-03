using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ServiceLayer
{
    public class RainService : IRainServices
    {
        //Declare the ref I will use
        private DAL.LiveDBEntities _entities;
        
        //Constructor
        public RainService()
        {
            _entities = new DAL.LiveDBEntities();
        }

        public RainRecord getRecord(int year)
        {
            DAL.RainTableLive rain = (from cool in _entities.RainTableLive
                                        where cool.Year_Ref == year
                                        select cool).FirstOrDefault();

            RainRecord ret = new RainRecord(rain);
            //ret.rainID = rain.Record_ID;
            //ret.outflowFullYear = (int)rain.Outflow_Full_Year;
            //ret.outflowSummer = (int)rain.Outflow_Summer;
            //ret.outflowWinter = (int)rain.Outflow_Winter;
            //ret.rainFullYear = (int)rain.Rain_Full_Year;
            //ret.rainSummer = (int)rain.Rain_Summer;
            //ret.rainWinter = (int)rain.Rain_Winter;

            return ret;
        }

        public List<RainRecord> RetrieveAllRainrecords()
        {
            List<RainRecord> allRecords = new List<RainRecord>();

            foreach (DAL.RainTableLive dbAddr in _entities.RainTableLive)
            {
                RainRecord rr = new RainRecord(dbAddr);
                allRecords.Add(rr);
            }
            return allRecords;
        }
    }

    public class ProductionCurrentService
    {
        //Declare the ref I will use
        private DAL.LiveDBEntities _entities;

        //Constructor
        public ProductionCurrentService()
        {
            _entities = new DAL.LiveDBEntities();
        }

        public List<FarmProductionCurrentRecord> retrieveAllCurProd() 
        {
            List<FarmProductionCurrentRecord> allRecords = new List<FarmProductionCurrentRecord>();

            foreach (DAL.FarmCurrentProductionLive cpl in _entities.FarmCurrentProductionLive)
            {
                FarmProductionCurrentRecord rr = new FarmProductionCurrentRecord(cpl);
                allRecords.Add(rr);
            }
            return allRecords;
        }

        
    }
}
