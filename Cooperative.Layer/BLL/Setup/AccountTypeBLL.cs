using Cooperative.Layer.DLL.Setup;
using CooperativeData.Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperative.Layer.BLL.Setup
{
    public class AccountTypeBLL //: UniversalBLL<AccountTypeBLL>
    {
        
          string conStr = "";
        public AccountTypeBLL()
        {
            
        }
        public int AccountTypeID { get; set; }
        public string AccountTypeName { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
         public AccountTypeBLL(string connectionStr)
        {
            this.conStr = connectionStr;
        }
        public bool Save(AccountTypeBLL data)
        {
            return AccountTypeDLL.Save(data);
        }

        public bool Update(AccountTypeBLL data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id, int loginId, DateTime logDateTime)
        {
            throw new NotImplementedException();
        }


        public char Status { get; set; }

        public DataTable GetfroDGV()
        {
            return AccountTypeDLL.GetforDGV(AccountTypeName);
        }

        public void Delete(int AccountTypeID)
        {
            throw new NotImplementedException();
        }
    }




}