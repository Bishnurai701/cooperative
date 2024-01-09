using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cooperative.Layer.DLL.Setup;
using System.Data;

namespace Cooperative.Layer.BLL.Setup
{
    public class RelationBLL
    {
       
        public DataTable GetforDGV(string RelationName)
        {
            return RelationDLL.GetforDGV(RelationName);
        }

        public bool Delete(int RelationId)
        {
            return RelationDLL.Delete(RelationId,this);
        }

        public System.Data.DataTable GetforEdit(int RelationId)
        {
            return RelationDLL.GetforEdit(RelationId);
        }

        public int RelationId { get; set; }

        public string RelationName { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public char Status { get; set; }

        public bool IsActive { get; set; }

        public bool Save(RelationBLL data)
        {
            return RelationDLL.Save(data);
        }
    }
}


