using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataAccess
{
    public class PersonDAO : IPersonDAO
    {
        public bool DeletePerson(int id)
        {
            using (var context = new HouseholdManagerContext())
            {
                var person = context.People.Where(p => p.ID == id).FirstOrDefault();

                context.Entry<Person>(person).State = System.Data.Entity.EntityState.Deleted;

                //Cập nhật lại MemberCount mỗi khi có 1 thành viên bị xoá 
                var household = context.Households.Where(h => h.ID == person.HouseholdID).FirstOrDefault();
                household.MemberCount--;

                context.SaveChanges();

                return true;
            }
        }

        public List<Person> GetListPerson(string columnOrder = "ID")
        {
            using (var context = new HouseholdManagerContext())
            {
                switch (columnOrder)
                {
                    case "ID": return context.People.OrderBy(p => p.ID).ToList();
                    case "Name": return context.People.OrderBy(p => p.Name).ToList();
                    case "Gender": return context.People.OrderBy(p => p.Gender).ToList();
                    case "DateOfBirth": return context.People.OrderBy(p => p.DateOfBirth).ToList();
                    case "CMND": return context.People.OrderBy(p => p.Cmnd).ToList();
                    case "Address": return context.People.OrderBy(p => p.Address).ToList();
                    case "HouseholdID": return context.People.OrderBy(p => p.HouseholdID).ToList();
                    case "Relation": return context.People.OrderBy(p => p.Relation).ToList();
                    default: return context.People.OrderBy(p => p.ID).ToList();
                }
 
            }
        }

        public Person GetNewPerson()
        {
            using (var context = new HouseholdManagerContext())
            {
                var maxId = context.People.Max(p => p.ID);

                var person = context.People
                    .Where(p => p.ID == maxId)
                    .FirstOrDefault();

                return person;
            }
        }

        public Person GetPersonByID(int id)
        {
            using (var context = new HouseholdManagerContext())
            {
                var person = context.People
                    .Where(p => p.ID == id)
                    .FirstOrDefault();

                return person;
            }
        }

        public Person InsertPerson(string name, int gender, string dateOfBirth, string cmnd, string address, int householdID, int relation)
        {
            using (var context = new HouseholdManagerContext())
            {
                //Nếu hộ khẩu không tồn tại
                if(context.Households.Count(h => h.ID == householdID) <= 0)
                {
                    throw new Exception("Hộ khẩu không tồn tại.");
                }

                //Nếu insert 1 người làm chủ hộ vào trong 1 hộ khẩu đã có chủ hộ
                if(relation == 1 && context.People.Count(p => p.HouseholdID == householdID && p.Relation == HouseholdRelation.Owner) > 0)
                {
                    throw new Exception("Nhà này đã có 1 chủ hộ.");
                }

                if(relation == 12 && householdID != 1)
                {
                    throw new Exception("Hộ khẩu bình thường [ID > 1] không thể lưu các đối tượng tạm trú.");
                }

                if (relation != 12 && householdID == 1)
                {
                    throw new Exception("Hộ khẩu [Đăng ký tạm trú][ID = 1] chỉ dùng để lưu các đối tượng tạm trú.");
                }

                var person = new Person
                {
                    Name = name,
                    Gender = (PersonGender)gender,
                    DateOfBirth = (DateTime)dateOfBirth.ToDateTime(),
                    Cmnd = cmnd,
                    Address = address,
                    HouseholdID = householdID,
                    Relation = (HouseholdRelation)relation,
                };

                context.People.Add(person);

                //Cập nhật lại MemberCount mỗi khi có 1 thành viên mới được thêm vào gia đình
                //Nếu người này là chủ hộ thì update lại địa chỉ và tên chủ hộ cuả hộ khẩu theo
                var household = context.Households.Where(h => h.ID == householdID).FirstOrDefault();
                household.MemberCount++;

                if(relation == 1)
                {
                    household.Owner = name;
                    household.Address = address;
                }

                context.SaveChanges();

                return context.People.OrderByDescending(p => p.ID).FirstOrDefault();
            }
        }

        public bool LoadFileExcel(List<(string Name, int Gender, DateTime DateOfBirth, string Cmnd, string Address)> listInput)
        {
            using (var context = new HouseholdManagerContext())
            {
                var people = new List<Person>(listInput.Count);

                foreach (var item in listInput)
                {
                    people.Add(new Person
                    {
                        Name = item.Name,
                        Gender = (PersonGender)item.Gender,
                        DateOfBirth = item.DateOfBirth,
                        Cmnd = item.Cmnd,
                        Address = item.Address,
                    });
                }

                context.People.AddRange(people);

                context.SaveChanges();

                return true;
            }
                
        }

        public bool UpdatePerson(int id, string name, int gender, string dateOfBirth, string cmnd, string address, int householdID, int relation)
        {
            using (var context = new HouseholdManagerContext())
            {
                //Lấy ra quan hệ hiện tại với chủ hộ của người được update
                var oldRelation = context.People.Where(p => p.ID == id).Select(p => p.Relation).FirstOrDefault();

                //Lấy ra số người là chủ hộ trong hộ khẩu người này chuyển tới
                var count = context.People.Count(p => p.HouseholdID == householdID && p.Relation == HouseholdRelation.Owner);

                //Khi người này update từ bình thường thành chủ hộ mà trong hộ khẩu đã có chủ hộ
                if (oldRelation != HouseholdRelation.Owner && relation == 1 && count > 0)
                {
                    throw new Exception("Nhà này đã có 1 chủ hộ.");
                }

                //Lấy ra hộ khẩu hiện tại của người được update
                var oldHouseholdID = context.People.Where(p => p.ID == id).Select(p => p.HouseholdID).FirstOrDefault();

                //Khi người bên ngoài là chủ hộ chuyển vào hộ khẩu này
                if (oldRelation == HouseholdRelation.Owner && relation == 1 && count > 0 && oldHouseholdID != householdID) 
                {
                    throw new Exception("Nhà này đã có 1 chủ hộ.");
                }

                if (relation == 12 && householdID != 1)
                {
                    throw new Exception("Hộ khẩu bình thường [ID > 1] không thể lưu các đối tượng tạm trú.");
                }

                if (relation != 12 && householdID == 1)
                {
                    throw new Exception("Hộ khẩu [Đăng ký tạm trú][ID = 1] chỉ dùng để lưu các đối tượng tạm trú.");
                }

                var person = context.People.SingleOrDefault(p => p.ID == id);

                if (person == null) return false;

                person.Name = name;
                person.Gender = (PersonGender)gender;
                person.DateOfBirth = (DateTime)dateOfBirth.ToDateTime();
                person.Cmnd = cmnd;
                person.Address = address;
                person.HouseholdID = householdID;
                person.Relation = (HouseholdRelation)relation;

                //Cập nhật lại MemberCount mỗi khi có 1 thành viên mới được update vào gia đình
                //Nếu người này là chủ hộ thì update lại địa chỉ và tên chủ hộ cuả hộ khẩu theo
                var household = context.Households.Where(h => h.ID == householdID).FirstOrDefault();                
                var oldHousehold = context.Households.Where(h => h.ID == oldHouseholdID).FirstOrDefault();

                if (oldHouseholdID != householdID)
                {
                    household.MemberCount++;
                    oldHousehold.MemberCount--;
                }

                if (oldRelation != HouseholdRelation.Owner && relation == 1)
                {
                    household.Owner = name;
                    household.Address = address;
                }

                context.SaveChanges();

                return true;
            }
        }
    }
}
