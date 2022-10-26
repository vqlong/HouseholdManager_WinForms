using Interfaces;
using Models;
using System.Collections.Generic;
using System.Data;
using Unity;

namespace HouseholdManager.DAO
{
    public class DonateDAO : IDonateDAO
    {
        private DonateDAO() { }

        private static readonly IDonateDAO instance = Config.Container.Resolve<IDonateDAO>();

        public static IDonateDAO Instance => instance;

        public List<Donate> GetListDonate()
        {
            string query = "SELECT * FROM Donate ORDER BY ID ASC";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            List<Donate> listDonate = new List<Donate>(data.Rows.Count);

            foreach (DataRow row in data.Rows)
            {
                listDonate.Add(new Donate(row));
            }

            return listDonate;
        }

        public Donate GetDonateByID(int id)
        {
            string query = $"SELECT * FROM [Donate] WHERE [ID] = {id};";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0) return new Donate(data.Rows[0]);

            return null;
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

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, dateArise.ToDate(), minValue, id });

            if (result == 1) return true;

            return false;
        }

        public Donate InsertDonate(string name, string dateArise, double minValue)
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

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, dateArise.ToDate(), minValue });

            if (result == 1)
            {
                var data = DataProvider.Instance.ExecuteQuery(@"SELECT * FROM [Donate] WHERE [ID] = (SELECT max([ID]) FROM [Donate]);");

                if (data.Rows.Count > 0) return new Donate(data.Rows[0]);
            }

            return null;
        }

        public DonateInfo InsertDonateInfo(int householdID, int donateID, string dateContribute, double value)
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

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { householdID, donateID, dateContribute.ToDate(), value });

            if (result == 1)
            {
                var data = DataProvider.Instance.ExecuteQuery(@"SELECT * FROM [DonateInfo] WHERE [ID] = (SELECT max([ID]) FROM [DonateInfo]);");

                if (data.Rows.Count > 0) return new DonateInfo(data.Rows[0]);
            }

            return null;
        }

        public List<DonateInfo2> GetListDonateInfo2()
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

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            List<DonateInfo2> list = new List<DonateInfo2>();

            foreach (DataRow row in data.Rows)
            {
                list.Add(new DonateInfo2(row));
            }

            return list;
        }
    }
}
