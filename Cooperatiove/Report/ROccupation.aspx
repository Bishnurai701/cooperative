<%@ Page Title="" Language="C#" MasterPageFile="~/Report/Report.master" AutoEventWireup="true" CodeBehind="ROccupation.aspx.cs" Inherits="Cooperative.Report.ROccupation" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
</asp:Content>
