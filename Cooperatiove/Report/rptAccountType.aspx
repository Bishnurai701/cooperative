<%@ Page Title="" Language="C#" MasterPageFile="~/Report/Report.master" AutoEventWireup="true" CodeBehind="rptAccountType.aspx.cs" Inherits="Cooperatiove.Report.rptAccountType" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">
    <rsweb:ReportViewer ID="ReportViewer1" ShowPrintButton="true" runat="server" Width="100%" Font-Names="Verdana" Font-Size="18pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportEmbeddedResource="Cooperatiove.Report.ReportAccountType.rdlc">
         </LocalReport>
</rsweb:ReportViewer>
    </asp:Content>
