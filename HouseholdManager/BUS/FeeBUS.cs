using HouseholdManager.DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HouseholdManager.BUS
{
    public class FeeBUS
    {
        private FeeBUS() { }

        private static readonly FeeBUS instance = new FeeBUS();

        public static FeeBUS Instance => instance;

        public List<Fee> GetListFee() => FeeDAO.Instance.GetListFee();

        public Fee GetFeeByID(int id) => FeeDAO.Instance.GetFeeByID(id);

        public bool DeleteFee(int id)
        {
            var result = false;

            try
            {
                result = FeeDAO.Instance.DeleteFee(id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return result;
        }

        public bool UpdateFee(int id, string name, string dateArise, double value, int factor)
        {
            if (!name.IsVietnamese(50))
            {
                MessageBox.Show("Tên khoản thu phí chỉ được sử dụng tối đa 50 ký tự Latin.\nGiữa các từ chỉ có 1 dấu cách.\nTrong 1 từ có nhiều nhất 1 dấu nháy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (!dateArise.IsDate())
            {
                MessageBox.Show("Ngày tháng phải có dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return FeeDAO.Instance.UpdateFee(id, name, dateArise, value, factor);
        }

        public Fee InsertFee(string name, string dateArise, double value, int factor)
        {
            if (!name.IsVietnamese(50))
            {
                MessageBox.Show("Tên khoản thu phí chỉ được sử dụng tối đa 50 ký tự Latin.\nGiữa các từ chỉ có 1 dấu cách.\nTrong 1 từ có nhiều nhất 1 dấu nháy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            if (!dateArise.IsDate())
            {
                MessageBox.Show("Ngày tháng phải có dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }           

            return FeeDAO.Instance.InsertFee(name, dateArise, value, factor);
        }

        public FeeInfo InsertFeeInfo(int householdID, int feeID, string datePay, double value)
        {

            if (!datePay.IsDate())
            {
                MessageBox.Show("Ngày tháng phải có dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            return FeeDAO.Instance.InsertFeeInfo(householdID, feeID, datePay, value);
        }

        public List<FeeInfo2> GetListFeeInfo2() => FeeDAO.Instance.GetListFeeInfo2();

    }
}
