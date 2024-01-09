using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cooperative.Layer.DLL.Setup;

namespace Cooperative.Layer.BLL.Setup
{
   public class TypeBLL
    {

        public int LoginId { get; set; }

        public DateTime LogDateTime { get; set; }

        public bool Delete(int TypeId)
        {
            return TypeDLL.Delete(TypeId, this);
        }

        public DataTable GetforDGV(string TypeName)
        {
            return TypeDLL.GetforDGV(TypeName);
        }

        public DataTable GetforEdit(int TypeId)
        {
            return TypeDLL.GetforEdit(TypeId);
        }

        public bool Save(TypeBLL data)
        {
            return TypeDLL.Save(data);
        }

        public int TypeId { get; set; }

        public string TypeName { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public char Status { get; set; }
    }
}
