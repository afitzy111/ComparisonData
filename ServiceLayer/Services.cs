using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ServiceLayer
{
    //Services used here basically just create a list of relevent record objects from the DAL
    public class RainService
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

            RainRecord rec = new RainRecord(rain);

            return rec;
        }

        public List<RainRecord> RetrieveAllRainrecords()
        {
            List<RainRecord> allRecords = new List<RainRecord>();

            foreach (DAL.RainTableLive rr in _entities.RainTableLive)
            {
                RainRecord rec = new RainRecord(rr);
                allRecords.Add(rec);
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

            foreach (DAL.FarmCurrentProductionLive pl in _entities.FarmCurrentProductionLive)
            {
                FarmProductionCurrentRecord rec = new FarmProductionCurrentRecord(pl);
                allRecords.Add(rec);
            }
            return allRecords;
        }
    }

    public class ProductionRealService
    {
        //Declare the ref I will use
        private DAL.LiveDBEntities _entities;

        //Constructor
        public ProductionRealService()
        {
            _entities = new DAL.LiveDBEntities();
        }

        public List<FarmProductionRealRecord> retrieveAllRealProd()
        {
            List<FarmProductionRealRecord> allRecords = new List<FarmProductionRealRecord>();

            foreach (DAL.FarmRealProductionLive pl in _entities.FarmRealProductionLive)
            {
                FarmProductionRealRecord rec = new FarmProductionRealRecord(pl);
                allRecords.Add(rec);
            }
            return allRecords;
        }
    }

    public class ConsumptionCurrentService
    {
        //Declare the ref I will use
        private DAL.LiveDBEntities _entities;

        //Constructor
        public ConsumptionCurrentService()
        {
            _entities = new DAL.LiveDBEntities();
        }

        public List<FarmConsumptionCurrentRecord> retrieveAllRealProd()
        {
            List<FarmConsumptionCurrentRecord> allRecords = new List<FarmConsumptionCurrentRecord>();

            foreach (DAL.FarmCurrentConsumptionLive pl in _entities.FarmCurrentConsumptionLive)
            {
                FarmConsumptionCurrentRecord rec = new FarmConsumptionCurrentRecord(pl);
                allRecords.Add(rec);
            }
            return allRecords;
        }
    }

    public class ConsumptionRealService
    {
        //Declare the ref I will use
        private DAL.LiveDBEntities _entities;

        //Constructor
        public ConsumptionRealService()
        {
            _entities = new DAL.LiveDBEntities();
        }

        public List<FarmConsumptionRealRecord> retrieveAllRealProd()
        {
            List<FarmConsumptionRealRecord> allRecords = new List<FarmConsumptionRealRecord>();

            foreach (DAL.FarmRealConsumptionLive pl in _entities.FarmRealConsumptionLive)
            {
                FarmConsumptionRealRecord rec = new FarmConsumptionRealRecord(pl);
                allRecords.Add(rec);
            }
            return allRecords;
        }
    }

    public class ExportService
    {
        //Declare the ref I will use
        private DAL.LiveDBEntities _entities;

        //Constructor
        public ExportService()
        {
            _entities = new DAL.LiveDBEntities();
        }

        public List<ExportMilsRecord> retrieveAllExports()
        {
            List<ExportMilsRecord> allRecords = new List<ExportMilsRecord>();

            foreach (DAL.ExportMilsTableLive pl in _entities.ExportMilsTableLive)
            {
                ExportMilsRecord rec = new ExportMilsRecord(pl);
                allRecords.Add(rec);
            }
            return allRecords;
        }
    }
}
