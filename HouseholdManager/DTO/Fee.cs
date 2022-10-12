using System;
using System.ComponentModel;
using System.Data;

namespace HouseholdManager.DTO
{
    public class Fee
    {
        public Fee(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            Name = Convert.ToString(row["Name"]);
            DateArise = Convert.ToDateTime(row["DateArise"]);
            Value = Convert.ToDouble(row["Value"]);
            Factor = (FeeFactor)Convert.ToInt32(row["Factor"]);
        }

        int id;
        string name;
        DateTime dateArise;
        double value;
        FeeFactor factor;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime DateArise { get => dateArise; set => dateArise = value; }
        public double Value { get => value; set => this.value = value; }
        public FeeFactor Factor { get => factor; set => factor = value; }
    }

    /// <summary>
    /// Hệ số dùng khi tính một khoản phí mà hộ gia đình phải trả.
    /// </summary>
    [TypeConverter(typeof(MyCustomConverter))]
    public enum FeeFactor
    {
        /// <summary>
        /// Tính theo số người mỗi hộ.
        /// </summary>
        [Description("Tính theo số người mỗi hộ")]
        ByPerson = 1,

        /// <summary>
        /// Tính theo từng hộ.
        /// </summary>
        [Description("Tính theo hộ")]
        ByHousehold = 2,
    }
}
