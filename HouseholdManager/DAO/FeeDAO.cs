using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdManager.DAO
{
    public class FeeDAO
    {
        private FeeDAO() { }

        private static readonly FeeDAO instance = new FeeDAO();

        public static FeeDAO Instance => instance;

        public DataTable GetListFee()
        {
            string query = "SELECT * FROM Fee ORDER BY ID ASC";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetFeeByID(int id)
        {
            string query = $"SELECT * FROM [Fee] WHERE [ID] = {id};";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool DeleteFee(int id)
        {
            string query = $"DELETE FROM Fee WHERE ID = {id}";

            var result = DataProvider.Instance.ExecuteNonQuery(query);

            if (result == 1) return true;

            return false;
        }

        public bool UpdateFee(int id, string name, string dateArise, double value, int factor)
        {
            string query = $@"UPDATE [Fee] 
                                 SET [Name] = @name,   
                                     [DateArise] = @dateArise,   
                                     [Value] = @value,  
                                     [Factor] = @factor   
                               WHERE [ID] = @id ";

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, dateArise, value, factor, id });

            if (result == 1) return true;

            return false;
        }

        public DataTable InsertFee(string name, string dateArise, double value, int factor)
        {
            string query =
          $@"INSERT INTO [Fee] (
                         [Name],
                         [DateArise],
                         [Value],  
                         [Factor]   
                     )
                     VALUES ( 
                         @name,     
                         @dateArise,  
                         @value,  
                         @factor   
                     );";

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, dateArise, value, factor });

            var data = new DataTable();

            if (result == 1)
                data = DataProvider.Instance.ExecuteQuery(@"SELECT * FROM [Fee] WHERE [ID] = (SELECT max([ID]) FROM [Fee]);");

            return data;
        }

        public DataTable InsertFeeInfo(int householdID, int feeID, string datePay, double value)
        {
            string query =
          $@"INSERT INTO [FeeInfo] ( 
                         [HouseholdID],  
                         [FeeID],  
                         [DatePay],  
                         [Value]  
                     )
                     VALUES ( 
                         @householdID,     
                         @feeID,  
                         @datePay,  
                         @value 
                     );";

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { householdID, feeID, datePay, value });

            var data = new DataTable();

            if (result == 1)
                data = DataProvider.Instance.ExecuteQuery(@"SELECT * FROM [FeeInfo] WHERE [ID] = (SELECT max([ID]) FROM [FeeInfo]);");

            return data;
        }

        public DataTable GetListFeeInfo()
        {
            string query =
                @"SELECT [FeeInfo].[ID],
                         [FeeInfo].HouseholdID,
                         [Household].[Owner],
                         [FeeInfo].[FeeID],
                         [Fee].[Name],
                         [FeeInfo].[DatePay],
                         [FeeInfo].[Value]
                    FROM [FeeInfo]
                    JOIN
                         [Household] ON [FeeInfo].[HouseholdID] = [Household].[ID]
                    JOIN
                         [Fee] ON [FeeInfo].[FeeID] = [Fee].[ID];";

            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
