using System;
using System.Data;

namespace HouseholdManager.DTO
{
    public class DonateInfo
    {
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

        int id;
        int householdID;
        int donateID;
        DateTime dateContribute;
        double value;

        public int ID { get => id; set => id = value; }
        public int HouseholdID { get => householdID; set => householdID = value; }
        public int DonateID { get => donateID; set => donateID = value; }
        public DateTime DateContribute { get => dateContribute; set => dateContribute = value; }
        public double Value { get => value; set => this.value = value; }
    }
}
