using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cooperatiove.Report
{
    public partial class testlalit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void ShowReport()
        {
            DataTable dt = null;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("");
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("", dt));
            ReportViewer1.DataBind();
        }
    }
}