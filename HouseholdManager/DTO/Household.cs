using System;
using System.Data;

namespace HouseholdManager.DTO
{
    public class Household
    {
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

        int id;
        string owner;
        string address;
        int memberCount;

        public int ID { get => id; set => id = value; }
        public string Owner { get => owner; set => owner = value; }
        public string Address { get => address; set => address = value; }
        public int MemberCount { get => memberCount; set => memberCount = value; }
    }
}
