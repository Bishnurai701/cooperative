using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cooperative.Layer.BLL.Setup;
using CooperativeData.Layer;

namespace Cooperative.Layer.DLL.Setup
{
   public class TypeDLL
    {

      

        internal static DataTable GetforDGV(string TypeName)
        {
            DataAccess da = new DataAccess();
            string query = @"TypeId,TypeName,Alias,Description
		from Tbl_Type where Status!='D' and 1=1";
            string where = "";
            if (TypeName != "")
            {
                where += " and TypeName like '" + TypeName + "'";
            }
            System.Data.DataTable dt = da.ExecuteDataTable(query+where, CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static DataTable GetforEdit(int TypeId)
        {
            DataAccess da = new DataAccess();
            string query = @"TypeId,TypeName,Alias,Description
		from Tbl_Type where Status!='D' and TypeId='" + TypeId + "'";
            System.Data.DataTable dt = da.ExecuteDataTable(query, CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static bool Save(BLL.Setup.TypeBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("TypeName", data.TypeName);
            da.AddParameter("Alias", data.Alias);
            da.AddParameter("Description", data.Description);
            da.AddParameter("LoginId", data.LoginId);
            da.AddParameter("LogDateTime", DateTime.Now);
            da.AddParameter("Status", data.Status);
            int row = 0;
                if (data.TypeId == 0)
                {
                    da.AddParameter("Mode","I");
                    row = da.ExecuteNonQuery("Sp_Type", CommandType.StoredProcedure);

                }
            else
                {
                    da.AddParameter("TypeId", data.TypeId);
                    da.AddParameter("Mode","U");
                    row = da.ExecuteNonQuery("Sp_TypeId", CommandType.StoredProcedure);
                }
                    da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
        }





        internal static bool Delete(int TypeId,TypeBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("TypeId", TypeId);
            da.AddParameter("LoginId", data.LoginId);
            da.AddParameter("LogDateTime", DateTime.Now);
            da.AddParameter("Mode", "D");
            int flag = da.ExecuteNonQuery("Sp_Type", CommandType.StoredProcedure);
            da.CloseConnection();
            if (flag > 0)
                return true;
            else
                return false;
        }
    }
}
