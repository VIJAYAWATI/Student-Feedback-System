<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AttendanceReport.aspx.cs" Inherits="AttendanceReport" Title="Untitled Page" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style9
        {
            width: 100%;
        }
        .style11
        {
            width: 176px;
        }
        .style12
        {
            width: 249px;
        }
        .style13
        {
            width: 181px;
        }
    </style>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
<link href="calendar-blue.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtFromDate.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%d/%m/%Y",
            daFormat: "%l;%M %p, %e %m,  %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
    });
    $(document).ready(function () {
        $("#<%=txtToDate.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%d/%m/%Y",
            daFormat: "%l;%M %p, %e %m,  %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
    });
    
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;&nbsp;&nbsp; <table class="style9" style="border: thin solid #000000">
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="Label4" runat="server" Text="Attendance Report" 
                    Font-Size="XX-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="justify" class="style12">
                <asp:Label ID="Label11" runat="server" Text="AcademicYear"></asp:Label>
            </td>
            <td align="justify">
                <asp:DropDownList ID="ddlAcademicYear" runat="server" Height="18px" 
                    Width="154px">
                </asp:DropDownList>
            </td>
            <td align="justify" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label5" runat="server" Text="FromDate"></asp:Label>
            </td>
            <td class="style11">
                    <asp:TextBox ID="txtFromDate" runat="server" 
                    ontextchanged="txtFromDate_TextChanged" Height="20px" Width="141px"></asp:TextBox>
                    <img alt="" src="calender.png" style="height: 16px; width: 16px;" /></td>
            <td class="style13">
                <asp:Label ID="Label7" runat="server" Text="ToDate"></asp:Label>
            </td>
            <td>
                    <asp:TextBox ID="txtToDate" runat="server" 
                    ontextchanged="txtToDate_TextChanged" Height="20px" Width="141px"></asp:TextBox>
                    <img alt="" src="calender.png" style="height: 16px; width: 16px;" /></td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label6" runat="server" Text="Semcode"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSemCode" runat="server" Height="30px" Width="156px" 
                    onselectedindexchanged="ddlSemCode_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label8" runat="server" Text="SubNumber"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubNumber" runat="server" Height="26px" Width="155px" 
                    onselectedindexchanged="ddlSubNumber_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label9" runat="server" Text="Subject Type"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubType" runat="server" Height="34px" Width="159px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlSubType_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label10" runat="server" Text="Batches"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlBatches" runat="server" Height="23px" Width="158px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlBatches_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style13">
                <asp:Label runat="server" Text="Sudent Roll Numbers"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlRollNo" runat="server" AutoPostBack="True" 
                    Height="16px" onselectedindexchanged="ddlRollNo_SelectedIndexChanged" 
                    Width="148px">
                </asp:DropDownList>
&nbsp;
                <asp:Label ID="lblres" runat="server" Font-Bold="True" Font-Size="Larger" 
                    ForeColor="#33CC33" style="color: #FF9900"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="style12">
                <asp:Button ID="Button1" runat="server" Text="Report&gt;&gt;" 
                    onclick="Button1_Click" />
            </td>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr align="center">
            <td colspan="4" align="center">
                &nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                    AutoDataBind="true" oninit="CrystalReportViewer1_Init" />
            </td>
        </tr>
    </table>
</asp:Content>

