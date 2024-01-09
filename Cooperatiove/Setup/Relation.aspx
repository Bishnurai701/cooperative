
<%@ Page Title="" Language="C#" MasterPageFile="~/Setup/SetupMaster.master" AutoEventWireup="true" CodeBehind="Relation.aspx.cs" Inherits="Cooperative.Setup.Relation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <div class="col-md-6 col-xs-6">
            <h3>
                <i class="fa fa-sitemap"></i>&nbsp; Relation
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

    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-12" style="position:inherit">
                <div id="entry-form" class="entry-form">
                    <div class="row">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">RelationName</label>
                            <div class="col-sm-2">
                                <asp:TextBox runat="server" ID="txtRelationName" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Alias</label>
                        <div class="col-sm-2">
                            <asp:TextBox runat="server" ID="txtAlias" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                        </div>
                    <div class="row">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Description</label>
                        <div class="col-sm-2">
                            <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                    <div class="row">
                    <div class="form-group">
                        <label class="col-sm-2 control-label" style="margin-left: 20px">IsActive:</label>
                        <label class="radio-inline" for="rbTrue">
                        <asp:RadioButton ID="rbnTrue"  runat="server" Checked="False" Text="True" GroupName="rbnIsActive" />
                        </label>
                        <label class="radio-inline" for="rdFalse">
                        <asp:RadioButton ID="rbnFlase" runat="server" Checked="False"  Text="False" GroupName="rbnIsActive"/> 
                        </label>
                        </div>
                    </div>
                   <div class="form-group">
                        <div class="col-sm-5">
                            <asp:Button runat="server" ID="btnsave" CssClass="btn btn-primary pull-right" Text="Save" OnClick="btnsave_Click" ></asp:Button>
                            <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-primary pull-right" Text="Search" OnClick="btnSearch_Click" />
                </div>
            </div>

        </div>
        </div>
            </div>
         <div class="row">
            <div class="col-sm-12">
           <%-- <asp:GridView ID="gdvRelationList" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="table" DataKeyNames="RelationID" PagerStyle-CssClass="pagination" PageSize="5"
                EmptyDataText="NO DATA FOUND !!" 
                onpageindexchanging="gdvRelationList_PageIndexChanging" AllowPaging="True">
                <Columns>
                     <asp:BoundField DataField="RelationId" ReadOnly="True" HeaderText="RelationId" />
                    <asp:BoundField DataField="RelationName" ReadOnly="True" HeaderText="RelationName" />
                     <asp:BoundField DataField="Alias" ReadOnly="True" HeaderText="Alias" />
                     <asp:BoundField DataField="Description" ReadOnly="True" HeaderText="Description" />
                    <asp:BoundField DataField="IsActive" ReadOnly="True" HeaderText="IsActive" />
                     <asp:TemplateField ShowHeader="False" HeaderStyle-Width="60px" HeaderText="Delete"
                        ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                        <ItemTemplate>
                    <a href="<%# String.Format("Relation.aspx?act=edit&RelationId={0}", Eval("RelationId")) %>";><i class="fa fa-edit"></i></a>
                    <a href="javascript:confirmAction('<%# String.Format("Relation.aspx?act=del&RelationId={0}", Eval("RelationId")) %>','')"><i class=" fa fa-trash-o"></i></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>
            </div>
        </div>
    </div>
</asp:Content>
