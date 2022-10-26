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
    public class FeeDAO : IFeeDAO
    {
        private FeeDAO() { }

        private static readonly IFeeDAO instance = Config.Container.Resolve<IFeeDAO>();

        public static IFeeDAO Instance => instance;

        public List<Fee> GetListFee()
        {
            string query = "SELECT * FROM Fee ORDER BY ID ASC";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            List<Fee> listFee = new List<Fee>(data.Rows.Count);

            foreach (DataRow row in data.Rows)
            {
                listFee.Add(new Fee(row));
            }

            return listFee;

        }

        public Fee GetFeeByID(int id)
        {
            string query = $"SELECT * FROM [Fee] WHERE [ID] = {id};";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0) return new Fee(data.Rows[0]);

            return null;
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

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, dateArise.ToDate(), value, factor, id });

            if (result == 1) return true;

            return false;
        }

        public Fee InsertFee(string name, string dateArise, double value, int factor)
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

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, dateArise.ToDate(), value, factor });

            if (result == 1)
            {
                var data = DataProvider.Instance.ExecuteQuery(@"SELECT * FROM [Fee] WHERE [ID] = (SELECT max([ID]) FROM [Fee]);");

                if (data.Rows.Count > 0) return new Fee(data.Rows[0]);
            }

            return null;
        }

        public FeeInfo InsertFeeInfo(int householdID, int feeID, string datePay, double value)
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

            var result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { householdID, feeID, datePay.ToDate(), value });

            if (result == 1)
            {
                var data = DataProvider.Instance.ExecuteQuery(@"SELECT * FROM [FeeInfo] WHERE [ID] = (SELECT max([ID]) FROM [FeeInfo]);");

                if (data.Rows.Count > 0) return new FeeInfo(data.Rows[0]);
            }

            return null;
        }

        public List<FeeInfo2> GetListFeeInfo2()
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

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            List<FeeInfo2> list = new List<FeeInfo2>();

            foreach (DataRow row in data.Rows)
            {
                list.Add(new FeeInfo2(row));
            }

            return list;
        }
    }
}
