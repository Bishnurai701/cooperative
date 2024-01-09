using Cooperative.Layer.BLL.Setup;
using CooperativeData.Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperative.Layer.DLL.Setup
{
     public class AccountTypeDLL//:UniversalDLL<AccountTypeBLL>
     {
        public static bool Save(AccountTypeBLL data)
        {
            DataAccess dbm = new DataAccess();
            dbm.AddParameter("@AccountTypeID", data.AccountTypeID);
            dbm.AddParameter("@AccountTypeName", data.AccountTypeName);
            dbm.AddParameter("@Alias", data.Alias);
            dbm.AddParameter("@Description", data.Description);
            dbm.AddParameter("@IsActive", data.IsActive);
            dbm.AddParameter("@Mode", "I");
            int row = dbm.ExecuteNonQuery("sp_AccountType",System.Data.CommandType.StoredProcedure);
            dbm.CloseConnection();

            if( row > 0)
                return true;
            else
                return false;
        }

        public bool Update(AccountTypeBLL data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id, int loginId, DateTime logDateTime)
        {
            throw new NotImplementedException();
        }

        internal static DataTable GetforDGV(string AccountTypeName)
        {
            DataAccess da = new DataAccess();
            string query = @" select AccountTypeID,AccountTypeName,Alias,Description from tbl_AccountType where Status!='D' and 1=1";
            string where = "";
            if (AccountTypeName != "")
            {
                where += " and AccountTypeName like '" + AccountTypeName + "'";
            }
            
            System.Data.DataTable dt = da.ExecuteDataTable(query + where, System.Data.CommandType.Text);
            da.CloseConnection();
            return dt;
        }
    }
}
