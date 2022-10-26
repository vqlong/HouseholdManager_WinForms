using System;
using System.Data;

namespace HouseholdManager.DTO
{
    public class Donate
    {
        public Donate(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            Name = Convert.ToString(row["Name"]);
            DateArise = Convert.ToDateTime(row["DateArise"]);
            MinValue = Convert.ToDouble(row["MinValue"]);
        }

        public Donate(int id, string name, DateTime dateArise, double minValue)
        {
            ID = id;
            Name = name;
            DateArise = dateArise;
            MinValue = minValue;
        }

        int id;
        string name;
        DateTime dateArise;
        double minValue;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime DateArise { get => dateArise; set => dateArise = value; }
        public double MinValue { get => minValue; set => minValue = value; }
    }
}
