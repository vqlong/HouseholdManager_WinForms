using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataAccess
{
    public class HouseholdDAO : IHouseholdDAO
    {
        private HouseholdDAO() { }

        public bool DeleteHousehold(int id)
        {
            if (id == 1) throw new Exception("Không được xoá.\n" +
                                            "Hộ khẩu [Đăng ký tạm trú][ID = 1] dùng để lưu các đối tượng tạm trú.");

            using (var context = new HouseholdManagerContext())
            {
                var household = context.Households
                    .Where(d => d.ID == id)
                    .FirstOrDefault();

                if (household.MemberCount > 0) throw new Exception("Không được xoá hộ khẩu đang có người.");

                context.Households.Remove(household);

                context.SaveChanges();

                return true;
            }

            
        }

        public Household GetHouseholdByID(int id)
        {
            using (var context = new HouseholdManagerContext())
            {
                var household = context.Households
                    .Where(d => d.ID == id)
                    .FirstOrDefault();

                return household;
            }
        }

        public List<Household> GetListHousehold()
        {
            using (var context = new HouseholdManagerContext())
            {
                return context.Households.ToList();
            }
        }

        public Household InsertHousehold(string owner, string address)
        {
            using (var context = new HouseholdManagerContext())
            {
                var household = new Household
                {
                    Owner = owner,
                    Address = address,
                };

                context.Households.Add(household);

                context.SaveChanges();

                //LINQ To Entities not support LastOrDefault
                return context.Households.OrderByDescending(h => h.ID).FirstOrDefault();
            }
        }

        public bool UpdateHousehold(int id, string owner, string address)
        {
            using (var context = new HouseholdManagerContext())
            {
                var household = context.Households.SingleOrDefault(h => h.ID == id);

                if (household == null) return false;

                household.Owner = owner;
                household.Address = address;

                context.SaveChanges();

                return true;
            }
        }
    }
}
