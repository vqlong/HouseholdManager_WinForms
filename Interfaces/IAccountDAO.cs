using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IAccountDAO
    {
        bool DeleteAccount(string username);
        List<Account> GetListAccount();
        List<string> GetListUser();
        Account InsertAccount(string username);
        Account Login(string username, string password);
        (bool, bool, bool, bool) UpdateAccount(string username, string displayname, string password, string note, string setting);
    }
}