using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdManager.DAO
{
    public class DonateDAO
    {
        private DonateDAO() { }

        private static readonly DonateDAO instance = new DonateDAO();

        public static DonateDAO Instance => instance;

        public DataTable GetListDonate()
        {
            string query = "SELECT * FROM Donate ORDER BY ID ASC";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetDonateByID(int id)
        {
            string query = $"SELECT * FROM [Donate] WHERE [ID] = {id};";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool DeleteDonate(int id)
        {
            string query = $"DELETE FROM Donate WHERE ID = {id}";

            var result = DataProvider.Instance.ExecuteNonQuery(query);

            if (result == 1) return true;

            return false;
        }

        public bool UpdateDonate(int id, string name, string dateArise, double minValue)
        {
            string query = $@"UPDATE [Donate] 
                                 SET [Name] = @name,   
                                     [DateArise] = @dateArise,   
                                     [MinValue] = @minValue       
                               WHERE [ID] = @id ";

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, dateArise, minValue, id });

            if (result == 1) return true;

            return false;
        }

        public DataTable InsertDonate(string name, string dateArise, double minValue)
        {
            string query =
          $@"INSERT INTO [Donate] (
                         [Name],
                         [DateArise],
                         [MinValue]   
                     )
                     VALUES ( 
                         @name,     
                         @dateArise,  
                         @minValue  
                     );";

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, dateArise, minValue });

            var data = new DataTable();

            if (result == 1)
                data = DataProvider.Instance.ExecuteQuery(@"SELECT * FROM [Donate] WHERE [ID] = (SELECT max([ID]) FROM [Donate]);");

            return data;
        }

        public DataTable InsertDonateInfo(int householdID, int donateID, string dateContribute, double value)
        {
            string query =
          $@"INSERT INTO [DonateInfo] ( 
                         [HouseholdID],  
                         [DonateID],  
                         [DateContribute],  
                         [Value]  
                     )
                     VALUES ( 
                         @householdID,     
                         @donateID,  
                         @dateContribute,  
                         @value 
                     );";

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { householdID, donateID, dateContribute, value });

            var data = new DataTable();

            if (result == 1)
                data = DataProvider.Instance.ExecuteQuery(@"SELECT * FROM [DonateInfo] WHERE [ID] = (SELECT max([ID]) FROM [DonateInfo]);");

            return data;
        }

        public DataTable GetListDonateInfo()
        {
            string query =
                @"SELECT [DonateInfo].[ID],
                         [DonateInfo].[HouseholdID],
                         [Household].[Owner],
                         [DonateInfo].[DonateID],
                         [Donate].[Name],
                         [DonateInfo].[DateContribute],
                         [DonateInfo].[Value]
                    FROM [DonateInfo]
                    JOIN
                         [Household] ON [DonateInfo].[HouseholdID] = [Household].[ID]
                    JOIN
                         [Donate] ON [DonateInfo].[DonateID] = [Donate].[ID];";

            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
