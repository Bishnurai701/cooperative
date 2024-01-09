using Cooperative.Layer.BLL.Security;
using CooperativeData.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperative.Layer.DLL.Security
{
    public class UserGroupDLL//:UniversalDLL<UserGroupBLL>
    {
        private string conStr;

        public UserGroupDLL(string conStr)
        {
            DataAccess.constr = conStr;
            // TODO: Complete member initialization
            //this.conStr = conStr;
        }
        public bool Save(UserGroupBLL data)
        {
            DataAccess dbm = new DataAccess();
            dbm.AddParameter("@UserGroupId", data.UserGroupId);
            dbm.AddParameter("@UserGroupName", data.UserGroupName);
            dbm.AddParameter("@Alias", data.Alias);
            dbm.AddParameter("@Description", data.Description);
            dbm.AddParameter("@IsInBuilt", data.IsInbuilt);
            dbm.AddParameter("@IsActive", data.IsActive);
            dbm.AddParameter("@LoginId", data.LoginId);
            dbm.AddParameter("@LogDateTime", data.LogDateTime);
            dbm.AddParameter("@Mode", "I");
            int row = dbm.ExecuteNonQuery("Sp_UserGroup");
            dbm.CloseConnection();

            if (row > 0)
                return true;
            else
                return false;
        }

        public bool Update(UserGroupBLL data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id, int loginId, DateTime logDateTime)
        {
            throw new NotImplementedException();
        }

        //public List<IdName> GetIdName()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<UserGroupBLL> GetDataById(int courseId)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<UserGroupBLL> GetAllData()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
