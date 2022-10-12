using System;
using System.Data;

namespace HouseholdManager.DTO
{
    public class FeeInfo2
    {
        public FeeInfo2(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            HouseholdID = Convert.ToInt32(row["HouseholdID"]);
            FeeID = Convert.ToInt32(row["FeeID"]);
            Owner = Convert.ToString(row["Owner"]);
            Name = Convert.ToString(row["Name"]);
            DatePay = Convert.ToDateTime(row["DatePay"]);
            Value = Convert.ToDouble(row["Value"]);
        }

        public FeeInfo2(int id, int householdID, int feeID, string owner, string name, DateTime datePay, double value)
        {
            ID = id;
            HouseholdID = householdID;
            FeeID = feeID;
            Owner = owner;
            Name = name;
            DatePay = datePay;
            Value = value;

        }

        int id;
        int householdID;
        int feeID;
        string owner;
        string name;
        DateTime datePay;
        double value;

        public int ID { get => id; set => id = value; }
        public int HouseholdID { get => householdID; set => householdID = value; }
        public int FeeID { get => feeID; set => feeID = value; }
        public string Owner { get => owner; set => owner = value; }
        public string Name { get => name; set => name = value; }
        public DateTime DatePay { get => datePay; set => datePay = value; }
        public double Value { get => value; set => this.value = value; }
    }
}
