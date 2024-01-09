using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeData.Layer
{
    public interface UniversalDLL<T>
    {
        bool Save(T data);

        bool Update(T data);

        bool Delete(int Id, int loginId, DateTime logDateTime);

        public  DataTable GetNameId();
        public  DataTable GetDataById(int Id);
        public DataTable GetAllData();
        //System.Collections.Generic.List<IdName> GetIdName();
        //System.Collections.Generic.List<T> GetDataById(int courseId);
        //System.Collections.Generic.List<T> GetAllData();
    }
}
