using System;
using System.Data;

namespace HouseholdManager.DTO
{
    public class FeeInfo
    {
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

        int id;
        int householdID;
        int feeID;
        DateTime datePay;
        double value;

        public int ID { get => id; set => id = value; }
        public int HouseholdID { get => householdID; set => householdID = value; }
        public int FeeID { get => feeID; set => feeID = value; }
        public DateTime DatePay { get => datePay; set => datePay = value; }
        public double Value { get => value; set => this.value = value; }
    }
}
