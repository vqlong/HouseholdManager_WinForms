using HouseholdManager.DAO;
using HouseholdManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseholdManager.BUS
{
    public class HouseholdBUS
    {
        private HouseholdBUS() { }

        private static readonly HouseholdBUS instance = new HouseholdBUS();

        public static HouseholdBUS Instance => instance;

        public List<Household> GetListHousehold()
        {           
            DataTable data = HouseholdDAO.Instance.GetListHousehold();

            List<Household> listHousehold = new List<Household>(data.Rows.Count);

            foreach (DataRow row in data.Rows)
            {
                listHousehold.Add(new Household(row));
            }

            return listHousehold;
        }

        public Household GetHouseholdByID(int id)
        {
            DataTable data = HouseholdDAO.Instance.GetHouseholdByID(id);

            if (data.Rows.Count > 0) return new Household(data.Rows[0]);

            return null;
        }

        public bool DeleteHousehold(int id)
        {
            return HouseholdDAO.Instance.DeleteHousehold(id);
        }

        public bool UpdateHousehold(int id, string owner, string address)
        {
            if (!owner.IsVietnamese() || !address.IsVietnamese())
            {
                MessageBox.Show("Họ tên và quê quán chỉ được sử dụng ký tự Latin.\nGiữa các từ chỉ có 1 dấu cách.\nTrong 1 từ có nhiều nhất 1 dấu nháy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return HouseholdDAO.Instance.UpdateHousehold(id, owner, address);
        }

        public Household InsertHousehold( string owner, string address)
        {
            if (!owner.IsVietnamese() || !address.IsVietnamese())
            {
                MessageBox.Show("Họ tên và quê quán chỉ được sử dụng ký tự Latin.\nGiữa các từ chỉ có 1 dấu cách.\nTrong 1 từ có nhiều nhất 1 dấu nháy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            var data = HouseholdDAO.Instance.InsertHousehold(owner, address);

            if (data.Rows.Count > 0) return new Household(data.Rows[0]);

            return null;
        }

    }
}
