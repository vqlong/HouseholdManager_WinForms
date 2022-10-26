using System;
using System.Data;

namespace Models
{
    public class FeeInfo
    {
        public FeeInfo()
        {

        }

        public FeeInfo(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            HouseholdID = Convert.ToInt32(row["HouseholdID"]);
            FeeID = Convert.ToInt32(row["FeeID"]);
            DatePay = Convert.ToDateTime(row["DatePay"]);
            Value = Convert.ToDouble(row["Value"]);
        }

        public FeeInfo(int id, int householdID, int feeID, DateTime datePay, double value)
        {
            ID = id;
            HouseholdID = householdID;
            FeeID = feeID;
            DatePay = datePay;
            Value = value;

        }

        //int id;
        //int householdID;
        //int feeID;
        //DateTime datePay;
        //double value;

        public int ID { get; set; }
        public int HouseholdID { get; set; }
        public int FeeID { get; set; }
        public DateTime DatePay { get; set; } = DateTime.Today;
        public double Value { get; set; } = 1000;

        public virtual Household Household { get; set; }
        public virtual Fee Fee { get; set; }
    }
}
