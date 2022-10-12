using HouseholdManager.DAO;
using HouseholdManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseholdManager.BUS
{
    public class AccountBUS
    {
        private AccountBUS() { }

        private static readonly AccountBUS instance = new AccountBUS();

        public static AccountBUS Instance => instance;

        public Account Login(string username, string password)
        {
            var data = AccountDAO.Instance.Login(username, password);

            if(data.Rows.Count == 1) return new Account(data.Rows[0]);

            return null;

        }
        public List<Account> GetListAccount()
        {
            List<Account> listAccount = new List<Account>();

            DataTable data = AccountDAO.Instance.GetListAccount();

            foreach (DataRow row in data.Rows)
            {
                listAccount.Add(new Account(row));
            }

            return listAccount;
        }



        public List<string> GetListUser()
        {
            var listUser = new List<string>();

            var data = AccountDAO.Instance.GetListUser();

            foreach (DataRow row in data.Rows)
            {
                listUser.Add(row[0].ToString());
            }

            return listUser;
        }

        public Account InsertAccount(string username)
        {
            var match = Regex.Match(username, @"^[a-zA-Z][a-zA-Z0-9]{4,}");

            if (match.Value.Equals(username) == false)
            {
                MessageBox.Show("Tên đăng nhập ít nhất phải có 5 ký tự a - z, A - Z, 0 - 9.\n" +
                                "Ký tự đầu tiên không được là chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var data = AccountDAO.Instance.InsertAccount(username);

            if (data.Rows.Count > 0) return new Account(data.Rows[0]);

            return null;
        }

        public bool DeleteAccount(string username)
        {
            return AccountDAO.Instance.DeleteAccount(username);
        }

        /// <summary>
        /// Cập nhật Account.
        /// </summary>
        /// <param name="username">Tên đăng nhập.</param>
        /// <param name="displayname">Tên hiển thị mới.</param>
        /// <param name="password">Mật khẩu mới.</param>
        /// <param name="note">Ghi chú mới.</param>
        /// <param name="setting">Setting mới.</param>
        /// <returns>
        /// Item1 - Kết quả cập nhật DisplayName.
        /// <br>Item2 - Kết quả cập nhật Password.</br>
        /// <br>Item3 - Kết quả cập nhật Note.</br>
        /// <br>Item4 - Kết quả cập nhật Setting.</br>
        /// </returns>
        public (bool, bool, bool, bool) UpdateAccount(string username, string displayname, string password, string note, string setting)
        {          
            return AccountDAO.Instance.UpdateAccount(username, displayname, password, note, setting);
        }
    }
}
