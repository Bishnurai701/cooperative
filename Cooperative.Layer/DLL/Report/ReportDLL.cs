using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CooperativeData.Layer;

namespace Cooperative.Layer.DLL.Report
{
    public class ReportDLL
    {

        public static DataTable GetAccountType()
        {
            DataAccess da = new DataAccess();
            string query = @" SELECT AccountTypeId, AccountTypeName, Alias, Description, IsActive
                            FROM Tbl_AccountType";

            System.Data.DataTable dt = da.ExecuteDataTable(query, System.Data.CommandType.Text);
            da.CloseConnection();
            return dt;
        }
        public static DataTable GetOccupation()
        {
            DataAccess da = new DataAccess();
            string sql = @"select OccupationId, OccupationName,Alias,Description,IsActive from Tbl_Occupation";
            DataTable dt = da.ExecuteDataTable(sql, CommandType.Text);
            da.CloseConnection();
            return dt;
        }



    }
}
