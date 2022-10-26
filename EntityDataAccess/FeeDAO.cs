using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataAccess
{
    public class FeeDAO : IFeeDAO
    {
        private FeeDAO() { }

        public bool DeleteFee(int id)
        {
            using (var context = new HouseholdManagerContext())
            {
                var fee = new Fee { ID = id };

                context.Fees.Attach(fee);

                context.Fees.Remove(fee);

                context.SaveChanges();

                return true;
            }
        }

        public Fee GetFeeByID(int id)
        {
            using (var context = new HouseholdManagerContext())
            {
                var fee = context.Fees
                    .Where(d => d.ID == id)
                    .FirstOrDefault();

                return fee;
            }
        }

        public List<Fee> GetListFee()
        {
            using (var context = new HouseholdManagerContext())
            {
                return context.Fees.ToList();
            }
        }

        public List<FeeInfo2> GetListFeeInfo2()
        {
            using (var context = new HouseholdManagerContext())
            {
                var feeInfoes = context.FeeInfos
                    .Include(fi => fi.Household)
                    .Include(fi => fi.Fee)
                    .ToList();

                var feeInfo2s = new List<FeeInfo2>();
                foreach (var feeInfo in feeInfoes)
                {
                    feeInfo2s.Add(new FeeInfo2(
                        feeInfo.ID,
                        feeInfo.HouseholdID,
                        feeInfo.FeeID,
                        feeInfo.Household.Owner,
                        feeInfo.Fee.Name,
                        feeInfo.DatePay,
                        feeInfo.Value));
                }

                return feeInfo2s;
            }
        }

        public Fee InsertFee(string name, string dateArise, double value, int factor)
        {
            using (var context = new HouseholdManagerContext())
            {
                var fee = new Fee
                {
                    Name = name,
                    DateArise = (DateTime)dateArise.ToDateTime(),
                    Value = value,
                    Factor = (FeeFactor)factor
                };

                context.Fees.Add(fee);

                context.SaveChanges();

                return context.Fees.OrderByDescending(f => f.ID).FirstOrDefault();
            }
        }

        public FeeInfo InsertFeeInfo(int householdID, int feeID, string datePay, double value)
        {
            using (var context = new HouseholdManagerContext())
            {
                //Lấy ra hệ số và số tiền cần nộp của loại phí này
                var factor = context.Fees.Where(f => f.ID == feeID).Select(f => f.Factor).FirstOrDefault();
                var feeValue = context.Fees.Where(f => f.ID == feeID).Select(f => f.Value).FirstOrDefault();

                //Người dùng nhập value là bao nhiêu cũng sẽ được tính lại khi save xuống database
                value = feeValue;

                if (factor == FeeFactor.ByPerson)
                {
                    var memberCount = context.Households.Where(h => h.ID == householdID).Select(h => h.MemberCount).FirstOrDefault();

                    value = feeValue * memberCount;
                }

                var feeInfo = new FeeInfo
                {
                    HouseholdID = householdID,
                    FeeID = feeID,
                    DatePay = (DateTime)datePay.ToDateTime(),
                    Value = value,
                };

                context.FeeInfos.Add(feeInfo);

                context.SaveChanges();

                return context.FeeInfos.OrderByDescending(fi => fi.ID).FirstOrDefault();
            }
        }

        public bool UpdateFee(int id, string name, string dateArise, double value, int factor)
        {
            using (var context = new HouseholdManagerContext())
            {
                var fee = context.Fees.SingleOrDefault(f => f.ID == id);

                if (fee == null) return false;

                fee.Name = name;
                fee.DateArise = (DateTime)dateArise.ToDateTime();
                fee.Value = value;
                fee.Factor = (FeeFactor)factor;

                context.SaveChanges();

                return true;
            }
        }
    }
}
