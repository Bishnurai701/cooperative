using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cooperatiove.Report
{
    public partial class rptAccountType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowReport();
            
            }

        }

        public void ShowReport()
        {
            DataTable dt = Cooperative.Layer.BLL.Report.ReportBLL.GetAccountType();
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("ReportAccountType.rdlc");
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet", dt));
            ReportViewer1.DataBind();
        }


    }

}