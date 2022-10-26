using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EntityDataAccess
{
    public class AccountDAO : IAccountDAO
    {
        private AccountDAO() { }

        public bool DeleteAccount(string username)
        {
            using (var context = new HouseholdManagerContext())
            {
                var account = new Account { Username = username };

                context.Accounts.Attach(account);

                context.Accounts.Remove(account);

                context.SaveChanges();

                return true;
            }
        }

        public List<Account> GetListAccount()
        {
            using (var context = new HouseholdManagerContext())
            {
                var accounts = context.Accounts.ToList();
                    
                accounts.ForEach(a => a.Password = "******");

                return accounts;
            }
        }

        public List<string> GetListUser()
        {
            using(var context = new HouseholdManagerContext())
            {
                return context.Accounts.Select(a => a.Username).ToList();
            }
        }

        public Account InsertAccount(string username)
        {
            using (var context = new HouseholdManagerContext())
            {
                var result = context.Accounts.Count(a => a.Username == username);

                if (result > 0) return null;

                var account = new Account { Username = username };

                context.Accounts.Add(account);

                context.SaveChanges();
            }

            return Login(username, "0");
        }

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

            using (var context = new HouseholdManagerContext())
            {
                var account = context.Accounts
                    .Where(a => a.Username == username)
                    .Where(a => a.Password == password)
                    .FirstOrDefault();
                account.Password = "******";
                return account;
            }

        }

        public (bool, bool, bool, bool) UpdateAccount(string username, string displayname, string password, string note, string setting)
        {
            using (var context = new HouseholdManagerContext())
            {
                var account = context.Accounts.Where(a => a.Username == username).SingleOrDefault();

                if (account == null) return (false, false, false, false);

                var result1 = false;
                if (!string.IsNullOrEmpty(displayname))
                {
                    account.DisplayName = displayname;

                    result1 = true;
                }

                var result2 = false;
                if (!string.IsNullOrEmpty(password))
                {
                    byte[] bytePassword = ASCIIEncoding.ASCII.GetBytes(password);

                    byte[] sha256Password = SHA256.Create().ComputeHash(bytePassword);

                    password = "";
                    foreach (var item in sha256Password)
                    {
                        password += Convert.ToString(item);
                    }

                    account.Password = password;

                    result2 = true;
                }

                var result3 = false;
                if (!string.IsNullOrEmpty(note))
                {
                    account.Note = note;

                    result3 = true;
                }

                var result4 = false;
                if (!string.IsNullOrEmpty(setting))
                {
                    account.Setting = setting;

                    result4 = true;
                }

                context.SaveChanges();

                return (result1, result2, result3, result4);
            }
               
        }
    }
}
