<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CourseReport.aspx.cs" Inherits="CourseReport" Title="Untitled Page" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p align="center">
    <br />
</p>
<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
    AutoDataBind="True" Height="793px" ReportSourceID="CrystalReportSource1" 
    Width="1270px" />
<CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
    <Report FileName="CourseReport.rpt">
    </Report>
</CR:CrystalReportSource>
</asp:Content>

