using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cooperative.Layer.BLL.Setup;

namespace Cooperative.Setup
{
    public partial class Relation : System.Web.UI.Page
    {
        RelationBLL data = new RelationBLL();
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
                RelationBLL data = new RelationBLL();
                string RelationName = txtRelationName.Text;
                gdvRelationList.DataSource = data.GetforDGV(RelationName);
                gdvRelationList.DataBind();
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

        private void Delete()
        {
            try
            {

                RelationBLL data = new RelationBLL();
                int RelationId = Convert.ToInt16(Request.QueryString["RelationId"].ToString());
                data.Delete(RelationId);
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
                int RelationId = Convert.ToInt32(Request.QueryString["RelationId"]);
                dt = data.GetforEdit(RelationId);
                foreach (DataRow dr in dt.Rows)
                {
                    txtRelationName.Text = dr["RelationName"].ToString();
                    txtAlias.Text = dr["Alias"].ToString();
                    txtDescription.Text = dr["Description"].ToString();
                    rbnTrue.Text = dr["rbnFalse"].ToString();
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
            if (string.IsNullOrWhiteSpace(txtRelationName.Text))
            {
                divMsg.Visible = true;
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsg.Text = "Please Enter RelationName.";
                lblMsgType.Text = "Warning !";
                txtRelationName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAlias.Text))
            {
                divMsg.Visible = true;
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsg.Text = "Please Enter Alias.";
                lblMsgType.Text = "Warning !";
                txtAlias.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                divMsg.Visible = true;
                divMsg.Attributes["Class"] = "divMsg divMsg-error";
                lblMsg.Text = "Please Enter Description.";
                lblMsgType.Text = "Warning !";
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
                RelationBLL data = SetData();
                if (data.Save(data))
                {
                    Clear();
                    divMsg.Attributes["Class"] = "divMsg divMsg-success";
                    lblMsgType.Text = "Well done";
                    divMsg.Visible = true;

                    if (data.RelationId == 0)
                    {
                        lblMsg.Text = "Data Saved Successfully.";
                    }
                    else
                    {
                        Session["EditdivMsg"] = true;
                        Response.Redirect("Relation.aspx");
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

        private RelationBLL SetData()
        {
            RelationBLL data = new RelationBLL();
            string act = Request.QueryString["act"];
            int RelationId = Convert.ToInt32(Request.QueryString["RelationId"]);
            if (act == "edit")
            {
                data.RelationId = RelationId;
            }
            else { }
            data.RelationName = txtRelationName.Text.Trim().Replace("'", "'");
            data.Alias = txtAlias.Text.Trim().Replace("'", "'");
            data.Description = txtDescription.Text.Trim().Replace("'", "'");
            data.Status = 'A';
            if (rbnTrue.Checked == true)
            {
                data.IsActive = true;
            }
            else
            {
                data.IsActive = false;
            }
            return data;
        }

      


        private void Clear()
        {
            txtRelationName.Text = "";
            txtAlias.Text = "";
            txtDescription.Text = "";
            rbnTrue.Text = "";
            rbnFlase.Text = "";
        }

        protected void gdvRelationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvRelationList.PageIndex = e.NewPageIndex;
            GetforDGV();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
         GetforDGV();
        }
        
    }
   
}