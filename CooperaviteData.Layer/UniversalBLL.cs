using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeData.Layer
{
    public interface UniversalBLL<T>
    {
          bool Save(T data);

        bool Update(T data);

        bool Delete(int Id,int loginId,DateTime logDateTime);
        public static DataTable GetNameId();
        public static DataTable GetDataById(int Id);
        public static DataTable GetAllData();

        //System.Collections.Generic.List<IdName> GetIdName();
        //System.Collections.Generic.List<T> GetDataById(int id);
        //System.Collections.Generic.List<T> GetAllData();
    }
    public class IdName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
