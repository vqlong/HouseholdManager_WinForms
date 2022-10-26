using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IHouseholdDAO
    {
        bool DeleteHousehold(int id);
        Household GetHouseholdByID(int id);
        List<Household> GetListHousehold();
        Household InsertHousehold(string owner, string address);
        bool UpdateHousehold(int id, string owner, string address);
    }
}