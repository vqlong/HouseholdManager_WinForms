using HouseholdManager.DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HouseholdManager.BUS
{
    public class AccountBUS
    {
        private AccountBUS() { }

        private static readonly AccountBUS instance = new AccountBUS();

        public static AccountBUS Instance => instance;

        public Account Login(string username, string password) => AccountDAO.Instance.Login(username, password);

        public List<Account> GetListAccount() => AccountDAO.Instance.GetListAccount();

        public List<string> GetListUser() => AccountDAO.Instance.GetListUser();

        public Account InsertAccount(string username)
        {
            var match = Regex.Match(username, @"^[a-zA-Z][a-zA-Z0-9]{4,50}");

            if (match.Value.Equals(username) == false)
            {
                MessageBox.Show("Tên đăng nhập gồm 5 - 50 ký tự a - z, A - Z, 0 - 9.\n" +
                                "Ký tự đầu tiên không được là chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return AccountDAO.Instance.InsertAccount(username);
        }

        public bool DeleteAccount(string username)
        {
            var result = false;

            try
            {
                result = AccountDAO.Instance.DeleteAccount(username);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return result;
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
            if (!string.IsNullOrEmpty(displayname))
            {
                if(displayname.Length > 50)
                {
                    MessageBox.Show("Tên hiển thị tối đa 50 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return (false, false, false, false);
                }
            }
            return AccountDAO.Instance.UpdateAccount(username, displayname, password, note, setting);
        }
    }
}
