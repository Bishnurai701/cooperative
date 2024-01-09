using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Cooperative.Layer.BLL.Report
{
    public class ReportBLL
    {
        public static DataTable GetAccountType()
        {
            return DLL.Report.ReportDLL.GetAccountType();
        }
        public static DataTable GetOccupation()
        {
            return DLL.Report.ReportDLL.GetOccupation();
        }
    }
}
