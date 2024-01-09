using Cooperative.Layer.BLL.Setup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cooperatiove.Setup
{
    public partial class AccountType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HtmlGenericControl li = (HtmlGenericControl)this.Page.Master.FindControl("list").FindControl("liAuthor");
            //li.Attributes["class"] = "active";
            if (Convert.ToBoolean(Session["EditdivMsg"]) == true)
            {
                divMsg.Visible = true;
                lblMsg.Text = "Data Updated Successfully.";
                lblMsgType.Text = "Well Done";
                divMsg.Attributes["Class"] = "divMsg divMsg-success";
                Session["EditdivMsg"] = false;

            }
            if (!IsPostBack)
            {
                string act = Request.QueryString["act"];

                if (act == "edit")
                {
                    SetDataToField();
                }
                if (act == "del")
                {
                    Delete();
                }

                GetfroDGV();
            }
        }

        private void Delete()
        {
            try
            {
                AccountTypeBLL data = new AccountTypeBLL();
                int AccountTypeID = Convert.ToInt16(Request.QueryString["AuthorID"].ToString());
                data.Delete(AccountTypeID);
                divMsg.Attributes["Class"] = "divMsg divMsg-success";
                lblMsgType.Text = "Well done";
                divMsg.Visible = true;
                lblMsg.Text = "Data Delete Successfully.";
            }
            catch (System.Data.SqlClient.SqlException)
            {
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact Administrator";
                divMsg.Visible = true;
            }
            catch (Exception ex)
            {
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = ex.Message + " " + ex.Source;
                divMsg.Visible = true;
            }
        }

        private void SetDataToField()
        {
            try
            {
                DataTable dt = new DataTable();
                int AuthorID = Convert.ToInt32(Request.QueryString["AccountTypeID"]);
                dt = GetforEdit(AccountTypeID);
                foreach (DataRow dr in dt.Rows)
                {
                    txtAccountTypeName.Text = dr["FirstName"].ToString();
                    txtAlias.Text = dr["Alias"].ToString();
                    txtDescription.Text = dr["Description"].ToString();
                    break;
                }
                btnSave.Text = "Update";
            }
            catch (System.Data.SqlClient.SqlException sql)
            {
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact Administrator";
                divMsg.Visible = true;
            }
            catch (Exception ex)
            {
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = ex.Message + " " + ex.Source;
                divMsg.Visible = true;
            }
        }

        private DataTable GetforEdit(int AccountTypeID)
        {
            throw new NotImplementedException();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtAccountTypeName.Text))
            {
               
                divMsg.Visible = true;
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsg.Text = "Please Enter your First Name.";
                lblMsgType.Text = "Warning !";
                txtAccountTypeName.Focus();
                return;
            }
           
            if (string.IsNullOrWhiteSpace(txtAlias.Text))
            {
                 divMsg.Visible = true;
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsg.Text = "Please Enter your First Name.";
                lblMsgType.Text = "Warning !";
                txtAlias.Focus();
                return;
            }
           
           
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                divMsg.Visible = true;
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsg.Text = "Please Enter your First Name.";
                lblMsgType.Text = "Warning !";
                txtDescription.Focus();
                return;
            }            
            
             else
            {
                Save();
                GetfroDGV();
            }
 }

        private void Save()
        {
            try
            {
                AccountTypeBLL data = SetData();
                if (data.Save(data))
                {
                    Clear();
                    divMsg.Attributes["Class"] = "divMsg divMsg-success";
                    lblMsgType.Text = "Well done";
                    divMsg.Visible = true;

                    if (data.AccountTypeID == 0)
                    {
                        lblMsg.Text = "Data Saved Successfully.";
                    }
                    else
                    {
                        Session["EditdivMsg"] = true;
                        Response.Redirect("AccountType.aspx");
                    }
                }
                else
                {
                    divMsg.Attributes["Class"] = "divMsg divMsg-error";
                    lblMsgType.Text = "Oh";
                    lblMsg.Text = "Error accured while saving data.";
                    divMsg.Visible = true;
                }
            }
            catch (System.Data.SqlClient.SqlException sql)
            {
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                switch (sql.Number)
                {
                    case 2627:
                        lblMsgType.Text = "Duplication Error";
                        lblMsg.Text = "Duplicate User Group.";
                        break;
                    default:
                        lblMsgType.Text = "Oh!";
                        lblMsg.Text = sql.Message + " " + sql.Source;
                        break;
                }

                divMsg.Visible = true;
            }
            catch (Exception ex)
            {
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = ex.Message + " " + ex.Source;
                divMsg.Visible = true;
            }
            GetfroDGV();
        }

        private void Clear()
        {
            txtAccountTypeName.Text = "";
            txtAlias.Text = "";
            txtDescription.Text = "";
            rbYes.Text = "";
            rbNo.Text = "";
        }

        private AccountTypeBLL SetData()
        {
            AccountTypeBLL data = new AccountTypeBLL();
            string act = Request.QueryString["act"];
            int AccountTypeID = Convert.ToInt32(Request.QueryString["AccountTypeID"]);
            if (act == "edit")
            {
                data.AccountTypeID = AccountTypeID;
            }
            else { }
            data.AccountTypeName = txtAccountTypeName.Text.Trim().Replace("'", "''");
            data.Alias = txtAlias.Text.Trim().Replace("'", "''");
            data.Description = txtDescription.Text.Trim().Replace("'", "''");
            if(rbYes.Checked == true)
            {
                data.IsActive = true;
            }
            else
            {
                data.IsActive = false;
            }

            data.Status = 'A';
            return data;
        }
        private void GetfroDGV()
        {
            try
            {
                AccountTypeBLL data = new AccountTypeBLL();
               
                gdvAccountTypeList.DataSource = data.GetfroDGV();
                gdvAccountTypeList.DataBind();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact Administrator";
                divMsg.Visible = true;
            }
            catch (Exception ex)
            {
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = ex.Message + " " + ex.Source;
                divMsg.Visible = true;
            }
        }
        
        protected void gdvAccountTypeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvAccountTypeList.PageIndex = e.NewPageIndex;
            GetfroDGV();
        }


        public int AccountTypeID { get; set; }
    }
}