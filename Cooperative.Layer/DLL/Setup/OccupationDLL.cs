using Cooperative.Layer.BLL.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CooperativeData.Layer;
using Cooperative.Layer.BLL.Setup;

namespace Cooperative.Layer.DLL.Setup
{
     public class OccupationDLL
    {
        internal static bool Save(OccupationBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("OccupationId", data.OccupationId);
            da.AddParameter("OccupationName", data.OccupationName);
            da.AddParameter("Alias", data.Alias);
            da.AddParameter("Description", data.Description);
            da.AddParameter("IsActive", data.IsActive);
            int row = 0;
            if (data.OccupationId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_Occupation", System.Data.CommandType.StoredProcedure);
            }
            else
            { 
                
            }
        }
    }
}
