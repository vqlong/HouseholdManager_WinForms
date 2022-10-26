using HouseholdManager.DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HouseholdManager.BUS
{
    public class HouseholdBUS
    {
        private HouseholdBUS() { }

        private static readonly HouseholdBUS instance = new HouseholdBUS();

        public static HouseholdBUS Instance => instance;

        public List<Household> GetListHousehold() => HouseholdDAO.Instance.GetListHousehold();

        public Household GetHouseholdByID(int id) => HouseholdDAO.Instance.GetHouseholdByID(id);

        public bool DeleteHousehold(int id)
        {
            var result = false;

            try
            {
                result = HouseholdDAO.Instance.DeleteHousehold(id);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return result;
        }

        public bool UpdateHousehold(int id, string owner, string address)
        {
            if (!owner.IsVietnamese(50) || !address.IsVietnamese(50))
            {
                MessageBox.Show("Họ tên và quê quán chỉ được sử dụng tối đa 50 ký tự Latin.\nGiữa các từ chỉ có 1 dấu cách.\nTrong 1 từ có nhiều nhất 1 dấu nháy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return HouseholdDAO.Instance.UpdateHousehold(id, owner, address);
        }

        public Household InsertHousehold( string owner, string address)
        {
            if (!owner.IsVietnamese(50) || !address.IsVietnamese(50))
            {
                MessageBox.Show("Họ tên và quê quán chỉ được sử dụng tối đa 50 ký tự Latin.\nGiữa các từ chỉ có 1 dấu cách.\nTrong 1 từ có nhiều nhất 1 dấu nháy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            return HouseholdDAO.Instance.InsertHousehold(owner, address);
        }

    }
}
