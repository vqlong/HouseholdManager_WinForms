using HouseholdManager.DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HouseholdManager.BUS
{
    public class DonateBUS
    {
        private DonateBUS() { }

        private static readonly DonateBUS instance = new DonateBUS();

        public static DonateBUS Instance => instance;

        public List<Donate> GetListDonate() => DonateDAO.Instance.GetListDonate();

        public Donate GetDonateByID(int id) => DonateDAO.Instance.GetDonateByID(id);

        public bool DeleteDonate(int id)
        {
            bool result;
            try
            {
                result = DonateDAO.Instance.DeleteDonate(id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Help.Log.ErrorFormat($"Delete Donate - Exception - {e.Message}");

                return false;
            }

            Help.Log.InfoFormat($"Delete Donate - ID: {id}, result: {result}");

            return result;
        }

        public bool UpdateDonate(int id, string name, string dateArise, double minValue)
        {
            if (!name.IsVietnamese(50))
            {
                MessageBox.Show("Tên khoản đóng góp chỉ được sử dụng tối đa 50 ký tự Latin.\nGiữa các từ chỉ có 1 dấu cách.\nTrong 1 từ có nhiều nhất 1 dấu nháy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (!dateArise.IsDate())
            {
                MessageBox.Show("Ngày tháng phải có dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            var result = DonateDAO.Instance.UpdateDonate(id, name, dateArise, minValue);

            Help.Log.InfoFormat($"Update Donate - ID: {id}, Name: {name}, result: {result}");

            return result;
        }

        public Donate InsertDonate(string name, string dateArise, double minValue)
        {
            if (!name.IsVietnamese(50))
            {
                MessageBox.Show("Tên khoản đóng góp chỉ được sử dụng tối đa 50 ký tự Latin.\nGiữa các từ chỉ có 1 dấu cách.\nTrong 1 từ có nhiều nhất 1 dấu nháy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            if (!dateArise.IsDate())
            {
                MessageBox.Show("Ngày tháng phải có dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            var donate = DonateDAO.Instance.InsertDonate(name, dateArise, minValue);

            var result = donate != null;

            Help.Log.InfoFormat($"Insert Donate - ID: {donate?.ID}, Name: {name}, result: {result}");

            return donate;
        }

        public DonateInfo InsertDonateInfo(int householdID, int donateID, string dateContribute, double value)
        {

            if (!dateContribute.IsDate())
            {
                MessageBox.Show("Ngày tháng phải có dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            var donateInfo = DonateDAO.Instance.InsertDonateInfo(householdID, donateID, dateContribute, value);

            var result = donateInfo != null;

            Help.Log.InfoFormat($"Insert DonateInfo - ID: {donateInfo?.ID}, Household.ID: {householdID}, Donate.ID: {donateID}, result: {result}");

            return donateInfo;
        }

        public List<DonateInfo2> GetListDonateInfo2() => DonateDAO.Instance.GetListDonateInfo2();

    }
}
