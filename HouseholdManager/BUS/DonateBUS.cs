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
    public class DonateBUS
    {
        private DonateBUS() { }

        private static readonly DonateBUS instance = new DonateBUS();

        public static DonateBUS Instance => instance;

        public List<Donate> GetListDonate()
        {
            List<Donate> listDonate = new List<Donate>();

            DataTable data = DonateDAO.Instance.GetListDonate();

            foreach (DataRow row in data.Rows)
            {
                listDonate.Add(new Donate(row));
            }

            return listDonate;
        }

        public Donate GetDonateByID(int id)
        {
            DataTable data = DonateDAO.Instance.GetDonateByID(id);

            if(data.Rows.Count > 0) return new Donate(data.Rows[0]);

            return null;
        }

        public bool DeleteDonate(int id)
        {
            return DonateDAO.Instance.DeleteDonate(id);
        }

        public bool UpdateDonate(int id, string name, string dateArise, double minValue)
        {
            if (!name.IsVietnamese())
            {
                MessageBox.Show("Tên khoản đóng góp chỉ được sử dụng ký tự Latin.\nGiữa các từ chỉ có 1 dấu cách.\nTrong 1 từ có nhiều nhất 1 dấu nháy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (!dateArise.IsDate())
            {
                MessageBox.Show("Ngày tháng phải có dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return DonateDAO.Instance.UpdateDonate(id, name, dateArise.ToDate(), minValue);
        }

        public Donate InsertDonate(string name, string dateArise, double minValue)
        {
            if (!name.IsVietnamese())
            {
                MessageBox.Show("Tên khoản đóng góp chỉ được sử dụng ký tự Latin.\nGiữa các từ chỉ có 1 dấu cách.\nTrong 1 từ có nhiều nhất 1 dấu nháy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            if (!dateArise.IsDate())
            {
                MessageBox.Show("Ngày tháng phải có dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            var data = DonateDAO.Instance.InsertDonate(name, dateArise.ToDate(), minValue);

            if (data.Rows.Count > 0) return new Donate(data.Rows[0]);

            return null;
        }

        public DonateInfo InsertDonateInfo(int householdID, int donateID, string dateContribute, double value)
        {

            if (!dateContribute.IsDate())
            {
                MessageBox.Show("Ngày tháng phải có dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            var data = DonateDAO.Instance.InsertDonateInfo(householdID, donateID, dateContribute.ToDate(), value);

            if (data.Rows.Count > 0) return new DonateInfo(data.Rows[0]);

            return null;
        }

        public List<DonateInfo2> GetListDonateInfo()
        {
            List<DonateInfo2> list = new List<DonateInfo2>();

            DataTable data = DonateDAO.Instance.GetListDonateInfo();

            foreach (DataRow row in data.Rows)
            {
                list.Add(new DonateInfo2(row));
            }

            return list;
        }

    }
}
