<%@ Page Title="" Language="C#" MasterPageFile="~/Setup/SetupMaster.master" AutoEventWireup="true" CodeBehind="Type.aspx.cs" Inherits="Cooperatiove.Setup.Type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header2" runat="server">
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
        <div class="col-md-6 col-xs-6">
            <h3>
                <i class="fa fa-group"></i>&nbsp;Type
            </h3>
        </div>
         <div id="alert" class="col-md-6 col-xs-6">
            <div id="divMsg" runat="server" class="alert alert-info pull-right">
                <button type="button" class="close" data-dismiss="alert">
                    &times;</button>
                <strong>
                    <asp:Label runat="server" ID="lblMsgType" CssClass="pull-left" Text="Message Type"></asp:Label>
                    &nbsp;!
                    &nbsp; </strong>

                <asp:Label runat="server" ID="lblMsg" Text="Message"></asp:Label>
            </div>
        </div>
    </div>


    <hr />
    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-12" style="position:inherit">
                <div id="entry-form" class="entry-form">
                    <div class="row">
                        <div class="form-group">
                            <label class="col-sm-3 control-label">TypeName:</label>
                            <div class="col-sm-3">
                                <asp:TextBox runat="server" ID="txtTypeName" PlaceHolder="Name" CssClass="form-control"></asp:TextBox>
                                </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Alias:</label>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" ID="txtAlias" placeholder="Alias" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Description:</label>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" ID="txtDescription" placeholder="Expiry Date" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-5">
                            <asp:Button runat="server" ID="btnsave" CssClass="btn btn-primary pull-right" Text="Save" OnClick="btnsave_Click" ></asp:Button>
                            <asp:Button runat="server" ID="btnsearch" CssClass="btn btn-primary pull-right" Text="Search" OnClick="btnsearch_Click"  />
                        </div>
                    </div>
                </div>
            </div>
        </div>
         <div class="row">
            <div class="col-sm-12">
            <asp:GridView ID="gdvTypeList" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="table" DataKeyNames="TypeId" PagerStyle-CssClass="pagination" PageSize="5"
                EmptyDataText="NO DATA FOUND !!" 
                onpageindexchanging="gdvTypeList_PageIndexChanging" AllowPaging="True">
                <Columns>
                     <asp:BoundField DataField="TypeId" ReadOnly="True" HeaderText="TypeId" />
                    <asp:BoundField DataField="TypeName" ReadOnly="True" HeaderText="TypeName" />
                     <asp:BoundField DataField="Alias" ReadOnly="True" HeaderText="Alias" />
                     <asp:BoundField DataField="Description" ReadOnly="True" HeaderText="Description" />
                     <asp:TemplateField ShowHeader="False" HeaderStyle-Width="60px" HeaderText="Delete"
                        ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                        <ItemTemplate>
                   
                    <a href="<%# String.Format("Type.aspx?act=edit&TypeId={0}", Eval("TypeId")) %>";><i class="fa fa-edit"></i></a>
                    <a href="javascript:confirmAction('<%# String.Format("Type.aspx?act=del&TypeId={0}", Eval("TypeId")) %>','')"><i class=" fa fa-trash-o"></i></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
        </div>
    </div>
    
</asp:Content>
