using Cooperative.Layer.DLL.Security;
using CooperativeData.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperative.Layer.BLL.Security
{
    public class UserGroupBLL//:UniversalBLL<UserGroupBLL>
    {
          string conStr = "";
        public UserGroupBLL()
        {
            
        }
        public int UserGroupId { get; set; }
        public string UserGroupName { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public bool IsInbuilt { get; set; }
        public bool IsActive { get; set; }
        public int LoginId { get; set; }
        public DateTime LogDateTime { get; set; }
        public UserGroupBLL(string connectionStr)
        {
            this.conStr = connectionStr;
        }
        public bool Save(UserGroupBLL data)
        {
            return new UserGroupDLL(conStr).Save(data);
        }

        public bool Update(UserGroupBLL data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id, int loginId, DateTime logDateTime)
        {
            throw new NotImplementedException();
        }

     
    }
}
