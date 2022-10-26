using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Unity;

namespace HouseholdManager.DAO
{
    public class AccountDAO : IAccountDAO
    {
        private AccountDAO() { }

        private static readonly IAccountDAO instance = Config.Container.Resolve<IAccountDAO>();

        public static IAccountDAO Instance => instance;

        public Account Login(string username, string password)
        {

            if (!string.IsNullOrEmpty(password))
            {
                //Các ký tự ngoài khoảng U+007F (phím Delete) đều bị convert thành U+003F (dấu ?)
                byte[] bytePassWord = ASCIIEncoding.ASCII.GetBytes(password);

                byte[] sha256PassWord = SHA256.Create().ComputeHash(bytePassWord);

                password = "";
                foreach (var item in sha256PassWord)
                {
                    password += Convert.ToString(item);
                }
            }

            var query = "SELECT Username, DisplayName, Type, Note, Setting FROM Account WHERE Username = @username AND Password = @password";

            var data = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });

            if (data.Rows.Count == 1) return new Account(data.Rows[0]);

            return null;
        }

        public List<Account> GetListAccount()
        {
            string query = "SELECT [Username], [DisplayName], [Type], [Setting] FROM [Account];";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            List<Account> listAccount = new List<Account>();

            foreach (DataRow row in data.Rows)
            {
                listAccount.Add(new Account(row));
            }

            return listAccount;
        }

        public List<string> GetListUser()
        {
            var query = "SELECT Username FROM Account";

            var data = DataProvider.Instance.ExecuteQuery(query);

            var listUser = new List<string>();

            foreach (DataRow row in data.Rows)
            {
                listUser.Add(row[0].ToString());
            }

            return listUser;
        }

        public Account InsertAccount(string username)
        {
            string query = $"SELECT count(*) FROM [Account] WHERE [Username] = @username ;";

            //Kiểm tra xem đã có username này trong database chưa
            var result = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query, new object[] { username }));

            //Nếu đã có thì return null
            if (result > 0) return null;

            query = "INSERT INTO [Account] ([Username]) VALUES ( @username );";

            result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { username });

            if (result == 1) return Login(username, "0");

            return null;
        }

        public bool DeleteAccount(string username)
        {
            string query = $"DELETE FROM [Account] WHERE [Username] = @username ;";

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { username });

            if (result == 1) return true;

            return false;
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
            var result1 = 0;
            if (!string.IsNullOrEmpty(displayname))
            {
                string query = $"UPDATE [Account] SET [DisplayName] = @displayname WHERE [Username] = @username ;";
                result1 = DataProvider.Instance.ExecuteNonQuery(query, new object[] { displayname, username });
            }

            var result2 = 0;
            if (!string.IsNullOrEmpty(password))
            {
                byte[] bytePassword = ASCIIEncoding.ASCII.GetBytes(password);

                byte[] sha256Password = SHA256.Create().ComputeHash(bytePassword);

                password = "";
                foreach (var item in sha256Password)
                {
                    password += Convert.ToString(item);
                }

                string query = $"UPDATE [Account] SET [Password] = @password WHERE [Username] = @username ;";

                result2 = DataProvider.Instance.ExecuteNonQuery(query, new object[] { password, username });
            }

            var result3 = 0;
            if (!string.IsNullOrEmpty(note))
            {
                string query = $"UPDATE [Account] SET [Note] = @note WHERE [Username] = @username ;";
                result3 = DataProvider.Instance.ExecuteNonQuery(query, new object[] { note, username });
            }

            var result4 = 0;
            if (!string.IsNullOrEmpty(setting))
            {
                string query = $"UPDATE [Account] SET [Setting] = @setting WHERE [Username] = @username ;";
                result4 = DataProvider.Instance.ExecuteNonQuery(query, new object[] { setting, username });
            }

            bool item1 = false, item2 = false, item3 = false, item4 = false;
            if (result1 == 1) item1 = true;
            if (result2 == 1) item2 = true;
            if (result3 == 1) item3 = true;
            if (result4 == 1) item4 = true;

            return (item1, item2, item3, item4);

        }
    }
}
