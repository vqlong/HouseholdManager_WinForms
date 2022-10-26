using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IFeeDAO
    {
        bool DeleteFee(int id);
        Fee GetFeeByID(int id);
        List<Fee> GetListFee();
        List<FeeInfo2> GetListFeeInfo2();
        Fee InsertFee(string name, string dateArise, double value, int factor);
        FeeInfo InsertFeeInfo(int householdID, int feeID, string datePay, double value);
        bool UpdateFee(int id, string name, string dateArise, double value, int factor);
    }
}