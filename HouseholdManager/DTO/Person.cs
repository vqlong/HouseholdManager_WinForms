using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdManager.DTO
{
    public class Person
    {
        public Person(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            Name = Convert.ToString(row["Name"]);
            Gender = (PersonGender)Convert.ToInt32(row["Gender"]);
            DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
            Cmnd = row["CMND"].ToString();
            Address = row["Address"].ToString();
            HouseholdID = Convert.ToInt32(row["HouseholdID"]);
            Relation = (HouseholdRelation)Convert.ToInt32(row["Relation"]);
        }

        public Person(int id, string name, PersonGender gender, DateTime dateOfBirth, string cmnd, string address, int householdID, HouseholdRelation relation)
        {
            ID = id;
            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Cmnd = cmnd;
            Address = address;
            HouseholdID = householdID;
            Relation = relation;
        }

        private int id;
        private string name;
        private PersonGender gender;
        private DateTime dateOfBirth;
        private string cmnd;
        private string address;
        private int householdID;
        private HouseholdRelation relation;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public PersonGender Gender { get => gender; set => gender = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string Address { get => address; set => address = value; }
        public int HouseholdID { get => householdID; set => householdID = value; }
        public HouseholdRelation Relation { get => relation; set => relation = value; }
    }

    [TypeConverter(typeof(MyCustomConverter))]
    public enum PersonGender
    {
        [Description("Nam")]
        Male = 1,
        [Description("Nữ")]
        Female = 0
    }

    [TypeConverter(typeof(MyCustomConverter))]
    public enum HouseholdRelation
    {       
        [Description("Chủ hộ")]
        Owner = 1,
        [Description("Vợ")]
        Wife = 2,
        [Description("Chồng")]
        Husband = 3,
        [Description("Con trai")]
        Son = 4,
        [Description("Con gái")]
        Daughter = 5,
        [Description("Cha")]
        Father = 6,
        [Description("Mẹ")]
        Mother = 7,
        [Description("Ông")]
        Grandfather = 8,
        [Description("Bà")]
        Grandmother = 9,
        [Description("Cháu trai")]
        Grandson = 10,
        [Description("Cháu gái")]
        Granddaughter = 11,
        [Description("Tạm trú")]
        TemporaryResident = 12

    }

    public class MyCustomConverter : EnumConverter
    {
        public MyCustomConverter(Type type) : base(type)
        {
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if(destinationType == typeof(string))
            {
                FieldInfo info = value.GetType().GetField(value.ToString());
                DescriptionAttribute description = info.GetCustomAttribute<DescriptionAttribute>();
                return description.Description;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
