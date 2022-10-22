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
    public class FeeBUS
    {
        private FeeBUS() { }

        private static readonly FeeBUS instance = new FeeBUS();

        public static FeeBUS Instance => instance;

        public List<Fee> GetListFee()
        {
            
            DataTable data = FeeDAO.Instance.GetListFee();

            List<Fee> listFee = new List<Fee>(data.Rows.Count);

            foreach (DataRow row in data.Rows)
            {
                listFee.Add(new Fee(row));
            }

            return listFee;
        }

        public Fee GetFeeByID(int id)
        {
            DataTable data = FeeDAO.Instance.GetFeeByID(id);

            if (data.Rows.Count > 0) return new Fee(data.Rows[0]);

            return null;
        }

        public bool DeleteFee(int id)
        {
            return FeeDAO.Instance.DeleteFee(id);
        }

        public bool UpdateFee(int id, string name, string dateArise, double value, int factor)
        {
            if (!name.IsVietnamese())
            {
                MessageBox.Show("Tên khoản thu phí chỉ được sử dụng ký tự Latin.\nGiữa các từ chỉ có 1 dấu cách.\nTrong 1 từ có nhiều nhất 1 dấu nháy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (!dateArise.IsDate())
            {
                MessageBox.Show("Ngày tháng phải có dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return FeeDAO.Instance.UpdateFee(id, name, dateArise.ToDate(), value, factor);
        }

        public Fee InsertFee(string name, string dateArise, double value, int factor)
        {
            if (!name.IsVietnamese())
            {
                MessageBox.Show("Tên khoản thu phí chỉ được sử dụng ký tự Latin.\nGiữa các từ chỉ có 1 dấu cách.\nTrong 1 từ có nhiều nhất 1 dấu nháy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            if (!dateArise.IsDate())
            {
                MessageBox.Show("Ngày tháng phải có dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            var data = FeeDAO.Instance.InsertFee(name, dateArise.ToDate(), value, factor);

            if (data.Rows.Count > 0) return new Fee(data.Rows[0]);

            return null;
        }

        public FeeInfo InsertFeeInfo(int householdID, int feeID, string datePay, double value)
        {

            if (!datePay.IsDate())
            {
                MessageBox.Show("Ngày tháng phải có dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            var data = FeeDAO.Instance.InsertFeeInfo(householdID, feeID, datePay.ToDate(), value);

            if (data.Rows.Count > 0) return new FeeInfo(data.Rows[0]);

            return null;
        }

        public List<FeeInfo2> GetListFeeInfo()
        {
            List<FeeInfo2> list = new List<FeeInfo2>();

            DataTable data = FeeDAO.Instance.GetListFeeInfo();

            foreach (DataRow row in data.Rows)
            {
                list.Add(new FeeInfo2(row));
            }

            return list;
        }
    }
}
