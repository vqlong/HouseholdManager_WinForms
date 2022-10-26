using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Models
{
    public class Fee
    {
        public Fee() { }
        public Fee(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            Name = Convert.ToString(row["Name"]);
            DateArise = Convert.ToDateTime(row["DateArise"]);
            Value = Convert.ToDouble(row["Value"]);
            Factor = (FeeFactor)Convert.ToInt32(row["Factor"]);
        }

        //int id;
        //string name;
        //DateTime dateArise;
        //double value;
        //FeeFactor factor;

        public int ID { get; set; }
        public string Name { get; set; } = "Đóng tiền abc ngày x tháng y năm z";
        public DateTime DateArise { get; set; } = DateTime.Today;
        public double Value { get; set; } = 1000;
        public FeeFactor Factor { get; set; } = FeeFactor.ByPerson;

        public virtual ICollection<FeeInfo> FeeInfos { get; set; } = new HashSet<FeeInfo>();
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
