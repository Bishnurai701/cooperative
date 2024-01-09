using Cooperative.Layer.DLL.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperative.Layer.BLL.Setup
{
   public class OccupationBLL
    {
#region properties
       private int _OccupationId;

public int OccupationId
{
  get { return _OccupationId; }
  set { _OccupationId = value; }
}
       private string _OccupationName;

public string OccupationName
{
  get { return _OccupationName; }
  set { _OccupationName = value; }
}
       private string _Alias;

public string Alias
{
  get { return _Alias; }
  set { _Alias = value; }
}
       private string _Description;

public string Description
{
  get { return _Description; }
  set { _Description = value; }
}
       private Boolean _IsActive;

public Boolean IsActive
{
  get { return _IsActive; }
  set { _IsActive = value; }
}
#endregion

public bool Save(OccupationBLL data)
{
    return OccupationDLL.Save(data);
}
    }
}
