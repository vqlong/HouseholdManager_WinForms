using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IDonateDAO
    {
        bool DeleteDonate(int id);
        Donate GetDonateByID(int id);
        List<Donate> GetListDonate();
        List<DonateInfo2> GetListDonateInfo2();
        Donate InsertDonate(string name, string dateArise, double minValue);
        DonateInfo InsertDonateInfo(int householdID, int donateID, string dateContribute, double value);
        bool UpdateDonate(int id, string name, string dateArise, double minValue);
    }
}