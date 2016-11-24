<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AttendanceMaster.aspx.cs" Inherits="AttendanceMaster" Title="Untitled Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
        }
        .style10
        {
            height: 30px;
        }
               
       
    
        .style30
        {
            height: 52px;
        }
        .style33
        {
    }
        .style37
        {
            height: 42px;
            width: 226px;
        }
            
    
    .style39
    {
        font-size: x-large;
    }
    .style40
    {
        text-decoration: underline;
    }
    .style41
    {
        font-size: large;
        font-weight: bold;
        height: 84px;
    }
    
    
        .style42
        {
            height: 42px;
            width: 107px;
        }
        .style43
        {
            height: 42px;
            width: 144px;
        }
    
    
        .style44
        {
            height: 42px;
        }
    
    
    .style45
    {
        height: 30px;
        width: 118px;
    }
    .style46
    {
        width: 118px;
    }
    
    
    </style>
    

<script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
<link href="calendar-blue.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtDate.ClientID %>").dynDateTime({
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
   
    <br />
    <br />
    <br />
   
    <table cellpadding="4" cellspacing="0" class="style4" 
        style="border: thin solid #000000; width: 828px; height: 464px;" 
    align="center">

     

        <tr>
            <td class="style41" colspan="5">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <span class="style39"><span class="style40">ATTENDENCE&nbsp; MASTER</span></span></td>
        </tr>
        <tr valign="top">
            <td class="style44">
                <asp:Label ID="Label8" runat="server" Text="Time From:" Font-Bold="True"></asp:Label>
            
            </td>
            <td class="style37">
                <asp:DropDownList ID="ddlTimeFrom" runat="server" Height="18px" 
                    onselectedindexchanged="ddlTimeFrom_SelectedIndexChanged" Width="97px">
                    <asp:ListItem>--SELECT--</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                </asp:DropDownList>
                <br />
                [eg:11:00 am]</td>
            <td class="style42" colspan="2">
                <asp:Label ID="Label9" runat="server" Text="Time To:" Font-Bold="True"></asp:Label>
            
            </td>
            <td class="style43">
                <asp:DropDownList ID="ddlTimeTo" runat="server">
                    <asp:ListItem>--SELECT--</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                </asp:DropDownList>
                [eg:12:30 pm]</td>
        </tr>
        <tr valign="top">
            <td>
                <asp:Label ID="Label18" runat="server" Text="SemisterCode:" Font-Bold="True"></asp:Label>
            
            </td>
            <td colspan="4">
                 <asp:DropDownList ID="ddlSemCode" runat="server" AutoPostBack="True" 
                     onselectedindexchanged="ddlSemCode_SelectedIndexChanged" Height="17px" 
                    Width="169px">
                     <asp:ListItem>-Select-</asp:ListItem>
                 </asp:DropDownList>
            
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                     ControlToValidate="ddlSemCode" ErrorMessage="*"></asp:RequiredFieldValidator>
            
            </td>
        </tr>
        <tr>
            <td class="style10">
                <asp:Label ID="Label14" runat="server" Text="SubjectNumber:" Font-Bold="True"></asp:Label>
            </td>
            <td class="style10" colspan="2">
                <asp:DropDownList ID="ddlSubNumber" runat="server" 
                    onselectedindexchanged="ddlSubNumber_SelectedIndexChanged" 
                    AutoPostBack="True" Height="18px" Width="169px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="ddlSubNumber" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="style45">
                <asp:Label ID="Label12" runat="server" Text="SubjectType:" Font-Bold="True"></asp:Label>
            </td>
            <td class="style10">
                <asp:DropDownList ID="ddlSubType" runat="server" AutoPostBack="True" 
                    Height="25px" Width="157px" 
                    onselectedindexchanged="ddlSubType_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="ddlSubType" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style30">
                <asp:Label ID="Label15" runat="server" Text="RoomNo" Font-Bold="True"></asp:Label>
            </td>
            <td class="style30" colspan="4">
                <asp:TextBox ID="txtRoomNo" runat="server" Height="25px" Width="169px"></asp:TextBox>
                [eg:223,Lab-1]<asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                    runat="server" ControlToValidate="txtRoomNo" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label16" runat="server" Text="Batch" Font-Bold="True"></asp:Label>
            </td>
            <td colspan="4">
                <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlBatch_SelectedIndexChanged" Height="21px" 
                    Width="169px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="ddlBatch" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="AcademicYear:" Font-Bold="True"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlAcademicYear" runat="server" Height="34px" 
                    Width="171px" 
                    onselectedindexchanged="ddlAcademicYear_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="ddlAcademicYear" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="style46">
                <asp:Label ID="Label7" runat="server" Text="Date:" Font-Bold="True"></asp:Label>
            
            </td>
            <td>
                    <asp:TextBox ID="txtDate" runat="server" 
                    ontextchanged="txtDate_TextChanged" Height="20px" Width="141px"></asp:TextBox>
                    <img alt="" src="calender.png" style="height: 16px; width: 16px;" /><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                        ControlToValidate="txtDate" ErrorMessage="*"></asp:RequiredFieldValidator>
            
            </td>
        </tr>
        <tr align="left">
            <td class="style33">
                <asp:Label ID="Label11" runat="server" Text="AbsentRoll_no:" Font-Bold="True"></asp:Label>
            </td>
            <td class="style6" colspan="4">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow" 
                    onselectedindexchanged="CheckBoxList1_SelectedIndexChanged" >
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr align="left">
            <td class="style33">
                <asp:Label ID="Label17" runat="server" Text="Comments" Font-Bold="True"></asp:Label>
            </td>
            <td class="style6" colspan="4">
                <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Width="168px" 
                    Height="31px"></asp:TextBox>
            </td>
        </tr>
        <tr align="center" valign="top">
            <td class="style33" colspan="5" style="#CCFFCC">
                <asp:Button ID="Button1" runat="server" Font-Size="Large" Height="28px" 
                    Text="Submit" Width="100px" onclick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Font-Size="Large" Height="28px" 
                    Text="Logout" Width="74px" onclick="Button2_Click1" />
                <br />
                <br />
                <asp:Label ID="lblmsg" runat="server" Font-Size="Larger"></asp:Label>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

