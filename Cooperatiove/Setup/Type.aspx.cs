using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cooperative.Layer.BLL.Setup;

namespace Cooperatiove.Setup
{
    public partial class Type : System.Web.UI.Page
    {
        TypeBLL data = new TypeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["EditdivMsg"]) == true)
            {
                divMsg.Visible = true;
                lblMsg.Text = "Data Updated Successfully";
                lblMsgType.Text = "Well Done";
                divMsg.Attributes["Class"] = "divMsg divMsg Sucess.";
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

                GetforDGV();
            }
        }

        private void GetforDGV()
        {
           try
           {
               TypeBLL data = new TypeBLL();
               string TypeName = txtTypeName.Text;
               gdvTypeList.DataSource = data.GetforDGV(TypeName);
               gdvTypeList.DataBind();
           }
            catch (System.Data.SqlClient.SqlException sql)
           {
               divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsgType.Text = "Oh!";
                lblMsg.Text = "Unexpected SQL Error.Please contact Administrator";
                divMsg.Visible = true;
            }
            catch (Exception ex)
           {
               divMsg.Attributes["Class"] = "divMsg divMsg-error";
               lblMsgType.Text = "Oh!";
               lblMsg.Text = ex.Message + " " + ex.Source;
               divMsg.Visible = true;
           }
  
        }


        private void Delete()
        {
            try
            {
                TypeBLL data = new TypeBLL();
                int TypeId = Convert.ToInt16(Request.QueryString["TypeId"].ToString());
                data.LoginId = Convert.ToInt32(Session["LoginId"]);
                data.LogDateTime = DateTime.Now;
                data.Delete(TypeId);
                divMsg.Attributes["Class"] = "divMsg divMsg-success";
                lblMsgType.Text = "Well done";
                divMsg.Visible = true;
                lblMsg.Text = "Data Delete Successfully.";
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

        private void SetDataToField()
        {
            try
            {
                DataTable dt = new DataTable();
                int TypeId = Convert.ToInt32(Request.QueryString["TypeId"]);
                dt = data.GetforEdit(TypeId);
                foreach (DataRow dr in dt.Rows)
                {
                    txtTypeName.Text = dr["txtTypeName"].ToString();
                    txtAlias.Text = dr["txtAlais"].ToString();
                    txtDescription.Text = dr["Description"].ToString();
                    break;
                }
                btnsave.Text = "Update";
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTypeName.Text))
            {
                divMsg.Visible = true;
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsg.Text = "Please enter your Type Name";
                lblMsgType.Text = "Warning";
                txtTypeName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAlias.Text))
            {
                divMsg.Visible = true;
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsg.Text = "Please enter your Alias";
                lblMsgType.Text = "Warning";
                txtAlias.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                divMsg.Visible = true;
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsg.Text = "Please enter your Description";
                txtDescription.Focus();
                return;
            }
            else
            {
                Save();
                GetforDGV();
            }
        }

        private void Save()
        {
            try
            {
                TypeBLL data = setData();
                if (data.Save(data))
                {
                    Clear();
                    divMsg.Attributes["Class"] = "divMsg divMsg-Success";
                    lblMsgType.Text = "Well done";
                    divMsg.Visible = true;

                    if (data.TypeId == 0)
                    {
                        lblMsg.Text = "Data Saved Successfully";
                    }
                    else
                    {
                        Session["EditdivMsg"] = true;
                        Response.Redirect("TypeId.aspx");
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
            GetforDGV();
        }

        private void Clear()
        {
            txtTypeName.Text = "";
            txtAlias.Text = "";
            txtDescription.Text = "";
        }

        private TypeBLL setData()
        {
            TypeBLL data = new TypeBLL();
            string act = Request.QueryString["act"];
            int TypeId = Convert.ToInt32(Request.QueryString["TypeId"]);
            if (act == "edit")
            {
                data.TypeId = TypeId;
            }
            else { }
            data.TypeName = txtTypeName.Text.Trim().Replace("'", "'");
            data.Alias = txtAlias.Text.Trim().Replace("'", "'");
            data.Description = txtDescription.Text.Trim().Replace("'", "'");
            data.Status = 'A';
            return data;
         }
        protected void gdvTypeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvTypeList.PageIndex = e.NewPageIndex;
            GetforDGV();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            GetforDGV();
        }
    }
}