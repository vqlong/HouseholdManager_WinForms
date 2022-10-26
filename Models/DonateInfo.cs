using System;
using System.Data;

namespace Models
{
    public class DonateInfo
    {
        public DonateInfo()
        {

        }
        public DonateInfo(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            HouseholdID = Convert.ToInt32(row["HouseholdID"]);
            DonateID = Convert.ToInt32(row["DonateID"]);
            DateContribute = Convert.ToDateTime(row["DateContribute"]);
            Value = Convert.ToDouble(row["Value"]);
        }

        public DonateInfo(int id, int householdID, int donateID, DateTime dateContribute, double value)
        {
            ID = id;
            HouseholdID = householdID;
            DonateID = donateID;
            DateContribute = dateContribute;
            Value = value;
            
        }

        //int id;
        //int householdID;
        //int donateID;
        //DateTime dateContribute;
        //double value;

        public int ID { get; set; }
        public int HouseholdID { get; set; }
        public int DonateID { get; set; }
        public DateTime DateContribute { get; set; } = DateTime.Today;
        public double Value { get; set; } = 1000;

        public virtual Household Household { get; set; }
        public virtual Donate Donate { get; set; }

    }
}
