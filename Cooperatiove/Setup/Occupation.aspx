<%@ Page Title="" Language="C#" MasterPageFile="~/Setup/SetupMaster.master" AutoEventWireup="true" CodeBehind="Occupation.aspx.cs" Inherits="Cooperative.Setup.Occupation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row" style="margin-top:30px">
        <div class="col-md-6 col-xs-6">
            <h3>
                <i class="fa fa-folder-open"></i>&nbsp; Occupation 
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
            <div class="col-md-12"  style="position:inherit">
                <div class="entry-form" id="entry-form">
                    <div class="row">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Occupation Name</label>
                            <div class="col-sm-4">
                                <asp:TextBox runat="server" ID="txtOccupationName" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">Alies</label>
                            <div class="col-sm-4">
                                <asp:TextBox runat="server" ID="txtAlies" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">Description</label>
                            <div class="col-sm-4">
                                <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">Is Active</label>
                            <div class="col-sm-4">
                                    <label class="radio-inline">
                                        <asp:RadioButton ID="rbActive" runat="server" GroupName="rbActive" Checked="true" />True
                                    </label>
                                    <label class="radio-inline">
                                        <asp:RadioButton ID="rbInActive" runat="server" GroupName="rbActive" />&nbsp;&nbsp;&nbsp;False
                                    </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-3">
                                <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary pull-right" Text="Save" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
