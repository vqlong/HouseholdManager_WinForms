using System;
using System.Data;

namespace HouseholdManager.DTO
{
    /// <summary>
    /// Lớp DonateInfo bổ sung thêm thuộc tính.
    /// </summary>
    public class DonateInfo2
    {
        public DonateInfo2(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            HouseholdID = Convert.ToInt32(row["HouseholdID"]);
            DonateID = Convert.ToInt32(row["DonateID"]);
            Owner = Convert.ToString(row["Owner"]);
            Name = Convert.ToString(row["Name"]);
            DateContribute = Convert.ToDateTime(row["DateContribute"]);
            Value = Convert.ToDouble(row["Value"]);
        }

        public DonateInfo2(int id, int householdID, int donateID, string owner, string name, DateTime dateContribute, double value)
        {
            ID = id;
            HouseholdID = householdID;
            DonateID = donateID;
            Owner = owner;
            Name = name;
            DateContribute = dateContribute;
            Value = value;

        }

        int id;
        int householdID;
        int donateID;
        string owner;
        string name;
        DateTime dateContribute;
        double value;

        public int ID { get => id; set => id = value; }
        public int HouseholdID { get => householdID; set => householdID = value; }
        public int DonateID { get => donateID; set => donateID = value; }
        public string Owner { get => owner; set => owner = value; }
        public string Name { get => name; set => name = value; }
        public DateTime DateContribute { get => dateContribute; set => dateContribute = value; }
        public double Value { get => value; set => this.value = value; }
    }
}
