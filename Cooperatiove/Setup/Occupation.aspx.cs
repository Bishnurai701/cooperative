using Cooperative.Layer.BLL.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cooperative.Setup
{
    public partial class Occupation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region even
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOccupationName.Text))
            {
                divMsg.Visible = true;
                divMsg.Attributes["Class"] = "alert alert-error";
                lblMsg.Text = "Please enter Ocupation Name";
                lblMsgType.Text = "Warning";
                txtOccupationName.Focus();
                return;
            }
            else
            {
                Save();
            }
        }
        #endregion
        #region Method and function
        private void Save()
        {
            try
            {
                OccupationBLL data = SetData();
                if (data.Save(data))
                {
                    Clear();
                    divMsg.Visible = true;
                    lblMsg.Text = "Data Saved Successfully.";
                    lblMsgType.Text = "Well Done";
                    divMsg.Attributes["Class"] = "alert alert-success";
                    Session["EditAlert"] = false;
                    if (data.OccupationId > 0)
                    {
                        Session["EditAlert"] = true;
                        Response.Redirect("Occupation.aspx");
                    }
                  }
                    else
                    {
                        btnSave.Text = "Save";
                        divMsg.Attributes["Class"] = "alert alert-error";
                        lblMsgType.Text = "Oh";
                        lblMsg.Text = "Error Occured While Saving Data";
                        divMsg.Visible = true;
                        Response.Redirect("Occupation.aspx");  
                    }
                 }
            catch (System.Data.SqlClient.SqlException sql)
            {
                divMsg.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact Administrator";
                divMsg.Visible = true;
            }
            catch (Exception ex)
            {
                divMsg.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = ex.Message + " " + ex.Source;
                divMsg.Visible = true;
            }
        }

        private OccupationBLL SetData()
        {
            OccupationBLL data = new OccupationBLL();
            string act = Request.QueryString["act"];
            int OccupationId = Convert.ToInt32(Request.QueryString["OccupationId"]);
            if (act == "edit")
                data.OccupationId = OccupationId;
                data.OccupationName = txtOccupationName.Text.Trim().Replace("'", "''");
                data.Alias = txtAlies.Text.Trim().Replace("'", "''");
                data.Description = txtDescription.Text.Trim().Replace("'", "''");
                string IsActive = Convert.ToInt32(rbActive.Checked).ToString();
                if (IsActive == "A")
                {
                    rbActive.Checked = true;
                    rbInActive.Checked = false;
                }
                if (IsActive == "N")
                {
                    rbInActive.Checked = true;
                    rbActive.Checked = false;
                }
                return data;
        }

        private void Clear()
        {
            txtOccupationName.Text = "";
            txtDescription.Text = "";
            txtAlies.Text = "";
        }
        #endregion
    }
}