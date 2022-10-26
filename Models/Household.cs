using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Models
{
    public class Household
    {
        public Household()
        {

        }
        public Household(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            Owner = row["Owner"].ToString();
            Address = row["Address"].ToString();
            MemberCount = Convert.ToInt32(row["MemberCount"]);
        }

        public Household(int id, string owner, string address, int memberCount)
        {
            ID = id;
            Owner = owner;
            Address = address;
            MemberCount = memberCount;
        }

        //int id;
        //string owner;
        //string address;
        //int memberCount;

        public int ID { get; set; }
        public string Owner { get; set; } = "Chủ hộ";
        public string Address { get; set; } = "Địa chỉ";
        public int MemberCount { get; set; } = 0;

        public virtual ICollection<Person> People { get; set; } = new HashSet<Person>();
        public virtual ICollection<DonateInfo> DonateInfos { get; set; } = new HashSet<DonateInfo>(); 
        public virtual ICollection<FeeInfo> FeeInfos { get; set; } = new HashSet<FeeInfo>();
    }
}
