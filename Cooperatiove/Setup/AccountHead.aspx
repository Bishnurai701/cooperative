<%@ Page Title="" Language="C#" MasterPageFile="~/Setup/SetupMaster.master" AutoEventWireup="true" CodeBehind="AccountHead.aspx.cs" Inherits="Cooperatiove.Setup.AccountHead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header2" runat="server">
    <script src="../Javascript/additional-methods.js"></script>
    <script src="../Javascript/jquery-1.9.1.min.js"></script>
    <script src="../Javascript/jquery.validate.js"></script>
    <script src="../Javascript/jquery.validate.unobtrusive.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             $("#ctl01").validate({
                 rules: {
                     ctl00$ctl00$MainContent$MainContent$txtAccountTypeName: {
                         minlength: 2,
                         required: true
                     }
                 }, messages: {
                     ctl00$ctl00$MainContent$MainContent$txtAccountTypeName: {
                         required: "* Required Field *",
                         minlength: "* Please enter atleast 2 characters *"
                     }
                 }
             });
         });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function confirmAction(path, noPath) {
            if (confirm('Are you sure, you want to execute this action???')) {
                window.location = path;
            }
            else {
                window.location = noPath;
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $("#liUserGroup").addClass("active");
            $('#MainContent_MainContent_close').click(function (e) {
                $('#new').removeClass('active')
                $('.nav-custom li').removeClass('active')
            })
        });
    </script>
    <div class="row">
        <div class="colg-md-6 col-xs-6">
            <h3>
                <i class="fa ">&nbsp;&nbsp;</i> Account Head
            </h3>
            <div id="alert" class="col-md-6 col-xs-6">
            <div id="divMsg" runat="server" class="alert alert-info pull-right">
                <button type="button" class="close" data-dismiss="alert">
                    &times;</button>
                <strong>
                    <asp:Label runat="server" ID="lblMsgType" CssClass="pull-right" Text="Message Type"></asp:Label>
                    &nbsp;!
                    &nbsp; </strong>

                <asp:Label runat="server" ID="lblMsg" Text="Message"></asp:Label>
            </div>
        </div>
        </div>
    </div>
    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-12" style="position:inherit">
                <div id="entry-form" class="entry-form">
                    <div class="row">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">AccountHeadName:</label>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" ID="txtAccountHeadName" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                
          
                    
                    <div class="row">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Alias:</label>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" ID="txtAlias" CssClass="form-control"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                      <div class="row">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Description:</label>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                    <div class="row">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Account Group:</label>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="DdlAccountGroup" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        </div>
                    </div>
                     <div class="row">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Opening Balance:</label>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" ID="txtOpeningBalance" CssClass="form-control"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                    <div class="row">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">DrCr:</label>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="ddlDrCr" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        </div>
                    </div>
                     <div class="form-group">
                        <label class="col-sm-2 control-label">
                            IsActive:</label>
                          <div class="col-sm-3">
                        <label class="radio-inline" for="rbYes">
                            <asp:RadioButton ID="rbYes" runat="server" GroupName="rbIsActive" Checked="true" />Yes
                        </label>
                        <label class="radio-inline" for="rbYes">
                            <asp:RadioButton ID="rbNo" runat="server" GroupName="rbIsActive" Checked="false"/>No</label>
                              <div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2"></label>
                        <div class="col-sm-3" style="margin-left: 15%;"> &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary"  Text="Save"   ></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
     </div>
    <%--<div class="row">
             <div class="col-md-12">
            <asp:GridView ID="gdvAccountTypeList" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="custom-table" DataKeyNames="AccountTypeID" PagerStyle-CssClass="pagination" PageSize="5"
                EmptyDataText="NO DATA FOUND !!" 
                AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="AccountTypeName" ReadOnly="True" HeaderText="AccountTypeName" />
                    <asp:BoundField DataField="Alias" ReadOnly="True" HeaderText="Alias" />
                     <asp:BoundField DataField="Description" ReadOnly="True" HeaderText="Description" />
                    
                     <asp:TemplateField ShowHeader="False" HeaderStyle-Width="60px" HeaderText="Action"
                        ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                        <ItemTemplate>
                    <a href="<%# String.Format("AccountType.aspx?act=edit&AuthorID={0}", Eval("AccountTypeID")) %>";><i class="fa fa-edit"></i></a>
                    <a href="javascript:confirmAction('<%# String.Format("AccountType.aspx?act=del&AuthorID={0}", Eval("AccountTypeID")) %>','')"><i class=" fa fa-trash-o"></i></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
             </div>
        </div>--%>
        </div>
        </div>
</asp:Content>
