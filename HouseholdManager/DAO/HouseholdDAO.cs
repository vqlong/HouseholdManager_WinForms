using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace HouseholdManager.DAO
{
    public class HouseholdDAO : IHouseholdDAO
    {
        private HouseholdDAO() { }

        private static readonly IHouseholdDAO instance = Config.Container.Resolve<IHouseholdDAO>();

        public static IHouseholdDAO Instance => instance;

        public List<Household> GetListHousehold()
        {
            string query = "SELECT * FROM Household ORDER BY ID ASC";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            List<Household> listHousehold = new List<Household>(data.Rows.Count);

            foreach (DataRow row in data.Rows)
            {
                listHousehold.Add(new Household(row));
            }

            return listHousehold;
        }

        public Household GetHouseholdByID(int id)
        {
            string query = $@"SELECT * FROM [Household] WHERE [ID] = {id};";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0) return new Household(data.Rows[0]);

            return null;
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

        public Household InsertHousehold(string owner, string address)
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

            if (result == 1)
            {
                var data = DataProvider.Instance.ExecuteQuery(@"SELECT * FROM [Household] WHERE [ID] = (SELECT max([ID]) FROM [Household]);");

                if (data.Rows.Count > 0) return new Household(data.Rows[0]);
            }

            return null;
        }
    }
}
