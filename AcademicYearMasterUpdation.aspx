<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AcademicYearMasterUpdation.aspx.cs" Inherits="AcademicYearMasterUpdation" Title="Untitled Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
<link href="calendar-blue.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtTermStarts.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%d/%m/%Y ",
            daFormat: "%l;%M %p, %e %m,  %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
    });
    $(document).ready(function () {
        $("#<%=txtTermEnds.ClientID %>").dynDateTime({
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
    <style type="text/css">
        .style8
        {}
        .style9
        {
            width: 319px;
        }
        .style10
        {
            height: 55px;
        }
        .style11
        {
        width: 417px;
    }
    
        .style13
        {
            width: 417px;
            height: 27px;
        }
        .style14
        {
            width: 319px;
            height: 27px;
        }
        .style15
        {
            width: 147px;
            height: 27px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <br />
<table align="center" 
        style="border: thin solid #000000; width: 45%; height: 322px;">
        <tr>
            <td class="style10" colspan="4" align="justify">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Large" 
                    Font-Underline="True" Text="Academic Year Updation"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="Label5" runat="server" Text="Select AcademicYear"></asp:Label>
            </td>
            <td class="style12">
                <asp:DropDownList ID="ddlAcademicStartYear" runat="server" 
                    onselectedindexchanged="ddlAcademicStartYear_SelectedIndexChanged1" 
                    Height="30px" Width="123px">
                </asp:DropDownList>
                </td>
            <td class="style15">
                 <asp:DropDownList ID="ddlForYear" runat="server" Height="29px" Width="128px" 
                     onselectedindexchanged="ddlForYear_SelectedIndexChanged">
                     <asp:ListItem>-SELECT-</asp:ListItem>
                     <asp:ListItem>1</asp:ListItem>
                     <asp:ListItem>2</asp:ListItem>
                     <asp:ListItem>3</asp:ListItem>
                 </asp:DropDownList>
            </td>
            <td class="style14">
                 <asp:DropDownList ID="ddlSemType" runat="server" Width="134px" Height="30px" 
                    AutoPostBack="True" 
                     onselectedindexchanged="ddlSemType_SelectedIndexChanged" 
                     style="margin-left: 0px">
                        <asp:ListItem>-Select-</asp:ListItem>
                        <asp:ListItem>Winter</asp:ListItem>
                        <asp:ListItem>Summer</asp:ListItem>
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label10" runat="server" Text="For Year"></asp:Label>
            </td>
            <td class="style9" colspan="3">
                 <asp:DropDownList ID="ddlForYear1" runat="server" Height="27px" Width="126px">
                     <asp:ListItem>-SELECT-</asp:ListItem>
                     <asp:ListItem>1</asp:ListItem>
                     <asp:ListItem>2</asp:ListItem>
                     <asp:ListItem>3</asp:ListItem>
                 </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label9" runat="server" Text="Sem Type"></asp:Label>
            </td>
            <td class="style9" colspan="3">
                 <asp:DropDownList ID="ddlSemType1" runat="server" Width="124px" 
                     Height="20px">
                        <asp:ListItem>-Select-</asp:ListItem>
                        <asp:ListItem>Winter</asp:ListItem>
                        <asp:ListItem>Summer</asp:ListItem>
                    </asp:DropDownList><br />
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label7" runat="server" Text="Term Starts"></asp:Label>
            </td>
            <td class="style9" colspan="3">
                <asp:TextBox ID="txtTermStarts" runat="server" Width="127px" Height="29px"></asp:TextBox>
                    &nbsp;<img alt="" src="calender.png" style="height: 16px; width: 16px;" />

                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtTermStarts" ErrorMessage="*Please enter Date"></asp:RequiredFieldValidator>

                </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label8" runat="server" Text="Term Ends"></asp:Label>
            </td>
            <td class="style9" colspan="3">
                <asp:TextBox ID="txtTermEnds" runat="server" Width="130px" Height="25px"></asp:TextBox>
                    &nbsp;<img alt="" src="calender.png" style="height: 16px; width: 16px;" />

                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtTermEnds" ErrorMessage="*Please enter Date"></asp:RequiredFieldValidator>

                </td>
        </tr>
        <tr align="center">
            <td class="style8" colspan="4" align="justify">
                <asp:Button ID="Button1" runat="server" Height="36px" onclick="Button1_Click" 
                    Text="Update" Width="80px" />
                <asp:Button ID="Button2" runat="server" Height="35px" Text="Delete" 
                    Width="72px" onclick="Button2_Click" />
                <br />
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Size="Larger"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>

