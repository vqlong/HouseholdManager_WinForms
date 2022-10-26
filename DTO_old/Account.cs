using System.ComponentModel;
using System.Data;

namespace HouseholdManager.DTO
{
    public class Account
    {
        public Account(string userName, string displayName, AccountType type, string note = null, string setting = null, string passWord = null)
        {
            Username = userName;
            DisplayName = displayName;
            Type = type;
            Note = note;
            Setting = setting;
            Password = passWord;
        }

        public Account(DataRow row)
        {
            Username = row["Username"].ToString();
            DisplayName = row["DisplayName"].ToString();
            Type = (AccountType)row["Type"];
            Note = row.Table.Columns.Contains("Note") ? row["Note"].ToString() : null;
            Setting = row.Table.Columns.Contains("Setting") ? row["Setting"].ToString() : null;
            //this.Password = row["Password"].ToString();
        }

        private string username;
        private string displayName;
        private string password;
        private AccountType type;
        private string note;
        private string setting;

        public string Username { get => username; set => username = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string Password { get => password; set => password = value; }
        public AccountType Type { get => type; set => type = value; }
        public string Note { get => note; set => note = value; }
        public string Setting { get => setting; set => setting = value; }
    }

    public enum AccountType:long
    {
        [Description("Quản lý")]
        Admin = 1,
        [Description("Nhân viên")]
        Staff = 0
    }
}
