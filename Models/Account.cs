using System.ComponentModel;
using System.Data;

namespace Models
{
    public class Account
    {
        public Account() { }
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

        //private string username;
        //private string displayName;
        //private string password;
        //private AccountType type;
        //private string note;
        //private string setting;
       
        public string Username { get ; set ; }
        public string DisplayName { get ; set ; } = "Cán bộ";
        public string Password { get; set; } = "952362351022552001115621782120108109105108121194219194572217814518010341215583925187233"; //Pass mặc định: 0
        public AccountType Type { get; set; } = AccountType.Staff;
        public string Note { get; set; } = "Ghi chú...";
        public string Setting { get; set; } = "";
    }

    public enum AccountType:long
    {
        [Description("Quản lý")]
        Admin = 1,
        [Description("Nhân viên")]
        Staff = 0
    }
}
