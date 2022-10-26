using System;
using System.Collections.Generic;
using System.Data;

namespace Models
{
    public class Donate
    {
        public Donate() { }
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

        //int id;
        //string name;
        //DateTime dateArise;
        //double minValue;

        public int ID {get; set;}
        public string Name { get; set; } = "Đóng góp phong trào abc";
        public DateTime DateArise { get; set; } = DateTime.Today;
        public double MinValue { get; set; } = 1000;

        public virtual ICollection<DonateInfo> DonateInfos { get; set; } = new HashSet<DonateInfo>();
    }
}
