using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CooperativeData.Layer;

namespace Cooperative.Layer.DLL.Setup
{
   public class RelationDLL
    {

        internal static DataTable GetforDGV(string RelationName)
        {
            DataAccess da = new DataAccess();
            string query = @"select RelationId,RelationName,Alias,Description,IsActive
		                        from Tbl_Relation where IsActive=1 and 1=1";
            string where = "";
            if (RelationName!="")
            {
                where += " and RelationName Like '" + RelationName + "'";
 
            }
            System.Data.DataTable dt = da.ExecuteDataTable(query + where, CommandType.Text);
            da.CloseConnection();
            return dt;
        }


      

        internal static System.Data.DataTable GetforEdit(int RelationId)
        {
            DataAccess da = new DataAccess();
            string query = @"select RelationId,RelationName,Alias,Description,IsActive
		                        from Tbl_Relation where Status!='D' and RelationId='" + RelationId + "'";
            System.Data.DataTable dt = da.ExecuteDataTable(query, CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static bool Delete(int RelationId, BLL.Setup.RelationBLL relationBLL)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("RelationId", RelationId);
            da.AddParameter("Mode", "D");
            int flag = da.ExecuteNonQuery("Sp_Relation", CommandType.StoredProcedure);
            da.CloseConnection();
            if (flag > 0)
                return true;
            else
                return false;
        }

        internal static bool Save(BLL.Setup.RelationBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("RelationName", data.RelationName);
            da.AddParameter("Alias", data.Alias);
            da.AddParameter("Description", data.Description);
            da.AddParameter("IsActive", data.IsActive);
            da.AddParameter("Status", data.Status);
            int row = 0;
            if(data.RelationId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_Relation", CommandType.StoredProcedure);

            }
       
            else
            {
                 da.AddParameter("RelationID", data.RelationId);
                da.AddParameter("Mode", "U");
                row = da.ExecuteNonQuery("Sp_Relation", CommandType.StoredProcedure);
            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
        }
    }
}
