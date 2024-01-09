using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cooperatiove.Report
{
    public partial class rptOccupation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowReport();
            }
        }

        private void ShowReport()
        {
            DataTable dt = Cooperative.Layer.BLL.Report.ReportBLL.GetOccupation();
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("ROccupation.rdlc");
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("OccupationDataSet", dt));
            ReportViewer1.DataBind();
        }
    }
}