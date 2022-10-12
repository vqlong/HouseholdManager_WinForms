using DevExpress.XtraEditors;
using HouseholdManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace HouseholdManager.DAO
{
    public class PersonDAO
    {
        private PersonDAO() { }

        private static readonly PersonDAO instance = new PersonDAO();

        public static PersonDAO Instance => instance;

        public DataTable GetListPerson(string columnOrder = "ID")
        {          
            string query = $"SELECT * FROM Person ORDER BY [{columnOrder}] ASC";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetNewPerson()
        {
            string query = @"SELECT * FROM [Person] WHERE [ID] = (SELECT max([ID]) FROM [Person]);";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetPersonByID(int id)
        {
            string query = $@"SELECT * FROM [Person] WHERE [ID] = {id};";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable InsertPerson(string name, int gender, string dateOfBirth, string cmnd, string address, int householdID, int relation)
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

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {name, gender, dateOfBirth, cmnd, address, householdID, relation});

            var data = new DataTable();

            if (result == 1)
                data = GetNewPerson();

            return data;
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

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {name, gender, dateOfBirth, cmnd, address, householdID, relation, id});

            if (result == 1) return true;

            return false;
        }

    }
}
