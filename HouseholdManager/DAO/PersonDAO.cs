using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Unity;

namespace HouseholdManager.DAO
{
    public class PersonDAO : IPersonDAO
    {
        private PersonDAO() { }

        private static readonly IPersonDAO instance = Config.Container.Resolve<IPersonDAO>();

        public static IPersonDAO Instance => instance;

        public List<Person> GetListPerson(string columnOrder = "ID")
        {
            string query = $"SELECT * FROM Person ORDER BY [{columnOrder}] ASC";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            //Đặt trước capacity cho List
            List<Person> listPerson = new List<Person>(data.Rows.Count);

            foreach (DataRow row in data.Rows)
            {
                listPerson.Add(new Person(row));
            }

            return listPerson;
        }

        public Person GetNewPerson()
        {
            string query = @"SELECT * FROM [Person] WHERE [ID] = (SELECT max([ID]) FROM [Person]);";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0) return new Person(data.Rows[0]);

            return null;
        }

        public Person GetPersonByID(int id)
        {
            string query = $@"SELECT * FROM [Person] WHERE [ID] = {id};";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0) return new Person(data.Rows[0]);

            return null;
        }

        public Person InsertPerson(string name, int gender, string dateOfBirth, string cmnd, string address, int householdID, int relation)
        {
            string query =
          $@"INSERT INTO [Person] (
                         [Name],
                         [Gender],
                         [DateOfBirth],
                         [CMND],
                         [Address],
                         [HouseholdID],
                         [Relation]
                     )
                     VALUES ( 
                         @name, 
                         @gender,  
                         @dateOfBirth, 
                         @cmnd, 
                         @address, 
                         @householdID, 
                         @relation  
                     );";

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, gender, dateOfBirth.ToDate(), cmnd, address, householdID, relation });

            if (result == 1) return GetNewPerson();

            return null;
        }

        public bool DeletePerson(int id)
        {
            string query = $"DELETE FROM Person WHERE ID = {id}";

            var result = DataProvider.Instance.ExecuteNonQuery(query);

            if (result == 1) return true;

            return false;
        }

        public bool UpdatePerson(int id, string name, int gender, string dateOfBirth, string cmnd, string address, int householdID, int relation)
        {
            string query = $@"UPDATE [Person]
                                 SET [Name] = @name,   
                                     [Gender] = @gender, 
                                     [DateOfBirth] = @dateOfBirth, 
                                     [CMND] = @cmnd, 
                                     [Address] = @address, 
                                     [HouseholdID] = @householdID, 
                                     [Relation] = @relation 
                               WHERE [ID] = @id ";

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, gender, dateOfBirth.ToDate(), cmnd, address, householdID, relation, id });

            if (result == 1) return true;

            return false;
        }

        public bool LoadFileExcel(List<(string Name, int Gender, DateTime DateOfBirth, string Cmnd, string Address)> listInput)
        {
            string query = "";

            foreach (var item in listInput)
            {
                query += $"INSERT INTO [Person] ( [Name], [Gender], [DateOfBirth], [CMND], [Address]) VALUES ( '{item.Name.Replace("'", "''")}', {item.Gender}, '{item.DateOfBirth.ToString("dd/MM/yyyy").ToDate()}', '{item.Cmnd}', '{item.Address.Replace("'", "''")}');\n";

            }

            var result = DataProvider.Instance.ExecuteNonQuery(query);

            if (result > 0) return true;

            return false;
        }

    }
}
