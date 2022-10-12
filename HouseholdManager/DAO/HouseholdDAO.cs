using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdManager.DAO
{
    public class HouseholdDAO
    {
        private HouseholdDAO() { }

        private static readonly HouseholdDAO instance = new HouseholdDAO();

        public static HouseholdDAO Instance => instance;

        public DataTable GetListHousehold()
        {
            string query = "SELECT * FROM Household ORDER BY ID ASC";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetHouseholdByID(int id)
        {
            string query = $@"SELECT * FROM [Household] WHERE [ID] = {id};";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool DeleteHousehold(int id)
        {
            string query = $"DELETE FROM Household WHERE ID = {id}";

            var result = DataProvider.Instance.ExecuteNonQuery(query);

            if (result == 1) return true;

            return false;
        }

        public bool UpdateHousehold(int id, string owner, string address)
        {
            string query = $@"UPDATE [Household]
                                 SET [Owner] = @owner,   
                                     [Address] = @address   
                               WHERE [ID] = @id ";

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { owner, address, id });

            if (result == 1) return true;

            return false;
        }

        public DataTable InsertHousehold(string owner, string address)
        {
            string query =
          $@"INSERT INTO [Household] (
                         [Owner],
                         [Address]
                     )
                     VALUES ( 
                         @Owner,    
                         @Address                  
                     );";

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { owner, address });

            var data = new DataTable();

            if (result == 1)
                data = DataProvider.Instance.ExecuteQuery(@"SELECT * FROM [Household] WHERE [ID] = (SELECT max([ID]) FROM [Household]);");

            return data;
        }
    }
}
