<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SemesterReport.aspx.cs" Inherits="SemesterReport" Title="Untitled Page" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

	.adb77c8c27-2a6d-4ece-b35b-afd8cbbffeb1-0 {border-color:#000000;border-left-width:0;border-right-width:0;border-top-width:0;border-bottom-width:0;}
	.fc7af2643d-2754-4e2c-b075-7d1dd1f6c906-0 {font-size:9pt;color:#000000;font-family:Arial;font-weight:normal;text-decoration:underline;}
	.fc7af2643d-2754-4e2c-b075-7d1dd1f6c906-1 {font-size:9pt;color:#000000;font-family:Arial;font-weight:normal;}
	.fc7af2643d-2754-4e2c-b075-7d1dd1f6c906-2 {font-size:19pt;color:#000000;font-family:Arial;font-weight:bold;}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Current Semester:"></asp:Label>
<asp:DropDownList ID="DropDownList1" runat="server" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    <asp:ListItem>Yes</asp:ListItem>
    <asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
<br />
<br />
<br />
    <asp:Button ID="Button1" runat="server" Text="Report&gt;&gt;" 
        onclick="Button1_Click1" />
<br />
<br />
    <br />
    <br />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="True" Height="793px" ReportSourceID="CrystalReportSource1" 
        Width="1270px"></CR:CrystalReportViewer>
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="SemesterReport.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

