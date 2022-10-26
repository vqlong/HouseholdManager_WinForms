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
    public class DonateDAO : IDonateDAO
    {
        private DonateDAO() { }

        public bool DeleteDonate(int id)
        {
            using (var context = new HouseholdManagerContext())
            {
                var donate = new Donate { ID = id };

                context.Donates.Attach(donate);

                context.Donates.Remove(donate);

                context.SaveChanges();

                return true;
            }
        }

        public Donate GetDonateByID(int id)
        {
            using (var context = new HouseholdManagerContext())
            {
                var donate = context.Donates
                    .Where(d => d.ID == id)
                    .FirstOrDefault();

                return donate;
            }
        }

        public List<Donate> GetListDonate()
        {
            using (var context = new HouseholdManagerContext())
            {
                return context.Donates.ToList();
            }
        }

        public List<DonateInfo2> GetListDonateInfo2()
        {
            using (var context = new HouseholdManagerContext())
            {
                var donateInfoes = context.DonateInfos
                    .Include(di => di.Household )
                    .Include(di => di.Donate)
                    .ToList();

                var donateInfo2s = new List<DonateInfo2>();
                foreach (var donateInfo in donateInfoes)
                {
                    donateInfo2s.Add(new DonateInfo2(
                        donateInfo.ID, 
                        donateInfo.HouseholdID, 
                        donateInfo.DonateID, 
                        donateInfo.Household.Owner, 
                        donateInfo.Donate.Name, 
                        donateInfo.DateContribute, 
                        donateInfo.Value));
                }

                return donateInfo2s;
            }
        }

        public Donate InsertDonate(string name, string dateArise, double minValue)
        {
            using (var context = new HouseholdManagerContext())
            {
                var donate = new Donate
                {
                    Name = name,
                    DateArise = (DateTime)dateArise.ToDateTime(),
                    MinValue = minValue,
                };

                context.Donates.Add(donate);

                context.SaveChanges();

                return context.Donates.OrderByDescending(d => d.ID).FirstOrDefault();
            }
        }

        public DonateInfo InsertDonateInfo(int householdID, int donateID, string dateContribute, double value)
        {
            using (var context = new HouseholdManagerContext())
            {
                var donateInfo = new DonateInfo
                {
                    HouseholdID = householdID,
                    DonateID = donateID,
                    DateContribute = (DateTime)dateContribute.ToDateTime(),
                    Value = value,
                };

                context.DonateInfos.Add(donateInfo);

                context.SaveChanges();

                return context.DonateInfos.OrderByDescending(di => di.ID).FirstOrDefault();
            }
        }

        public bool UpdateDonate(int id, string name, string dateArise, double minValue)
        {
            using (var context = new HouseholdManagerContext())
            {
                var donate = context.Donates.SingleOrDefault(d => d.ID == id);

                if (donate == null) return false;

                donate.Name = name;
                donate.DateArise = (DateTime)dateArise.ToDateTime();
                donate.MinValue = minValue;

                context.SaveChanges();

                return true;
            }
        }
    }
}
