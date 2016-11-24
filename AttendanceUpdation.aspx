<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AttendanceUpdation.aspx.cs" Inherits="AttendanceUpdation" Title="Untitled Page" %>

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
        .style32
        {
            height: 32px;
            width: 346px;
        }
        .style33
        {
    }
        .style34
        {
            height: 32px;
            width: 250px;
        }
        .style36
        {
            height: 34px;
        }
        .style37
        {
            height: 10px;
            width: 199px;
        }
            
    
    .style39
    {
        font-size: x-large;
    }
    .style40
    {
        }
    .style41
    {
        font-size: large;
        font-weight: bold;
        height: 84px;
    }
    
    
        .style42
        {
            height: 10px;
            width: 107px;
        }
        .style43
        {
            height: 10px;
            width: 144px;
        }
    
    
        .style44
        {
            height: 10px;
            width: 346px;
        }
    
    
        .style45
        {
            height: 17px;
            width: 346px;
        }
        .style46
        {
            height: 17px;
            width: 199px;
        }
        .style47
        {
            height: 17px;
            width: 107px;
        }
        .style48
        {
            height: 17px;
            width: 144px;
        }
        .style49
        {
            height: 40px;
        }
        .style50
        {
            width: 346px;
        }
        .style51
        {
            height: 30px;
            width: 346px;
        }
        .style52
        {
            height: 34px;
            width: 346px;
        }
        .style53
        {
            height: 52px;
            width: 346px;
        }
        .style54
        {
            height: 40px;
            width: 346px;
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
    <table cellpadding="4" cellspacing="0" class="style4" 
        
        style="border: thin solid #000000; width: 49%; margin-left: 78px; height: 518px;">

     

        <tr>
            <td class="style41" colspan="6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="style39">&nbsp;<span class="style40">&nbsp;&nbsp; ATTENDENCE&nbsp; 
                UPDATION</span></span></td>
        </tr>
        <tr valign="top">
            <td class="style45">
                <asp:Label ID="Label19" runat="server" Text="Date:" Font-Bold="True"></asp:Label>
            
            </td>
            <td class="style46">
                <asp:DropDownList ID="ddlAttendanceDate" runat="server" 
                    Height="24px" onselectedindexchanged="ddlAttendanceDate_SelectedIndexChanged" 
                    Width="159px">
                </asp:DropDownList>
            
            </td>
            <td class="style47" colspan="2">
                <asp:DropDownList ID="ddlSubCode" runat="server" 
                    onselectedindexchanged="ddlSubCode_SelectedIndexChanged" Height="33px" 
                    Width="167px">
                </asp:DropDownList>
            </td>
            <td class="style48">
                <asp:DropDownList ID="ddlSubType" runat="server" AutoPostBack="True" 
                    Height="26px" Width="119px" 
                    onselectedindexchanged="ddlSubType_SelectedIndexChanged">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem>TH</asp:ListItem>
                    <asp:ListItem>PR</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style48">
                <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlBatch_SelectedIndexChanged" Height="21px" 
                    Width="169px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr valign="top">
            <td class="style44">
                <asp:Label ID="Label8" runat="server" Text="Time From:" Font-Bold="True"></asp:Label>
            
            </td>
            <td class="style37">
                <asp:TextBox ID="txtTimeFrom" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtTimeFrom" ErrorMessage="*"></asp:RequiredFieldValidator>
                <br />
                [eg:11:00 am]</td>
            <td class="style42" colspan="2">
                <asp:Label ID="Label9" runat="server" Text="Time To:" Font-Bold="True"></asp:Label>
            
            </td>
            <td class="style43" colspan="2">
                <asp:TextBox ID="txtTimeTo" runat="server" 
                    ontextchanged="txtTimeTo_TextChanged"></asp:TextBox>
                [eg:12:30 pm]<asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate="txtTimeTo" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr valign="top">
            <td class="style50">
                <asp:Label ID="Label18" runat="server" Text="SemisterCode:" Font-Bold="True"></asp:Label>
            
            </td>
            <td colspan="5">
                 <asp:DropDownList ID="ddlSemCode" runat="server" AutoPostBack="True" 
                     onselectedindexchanged="ddlSemCode_SelectedIndexChanged1" Height="17px" 
                    Width="169px">
                     <asp:ListItem>-Select-</asp:ListItem>
                 </asp:DropDownList>
            
            </td>
        </tr>
        <tr>
            <td class="style51">
                <asp:Label ID="Label14" runat="server" Text="SubjectCode:" Font-Bold="True"></asp:Label>
            </td>
            <td class="style10" colspan="5">
                <asp:DropDownList ID="ddlSubCode1" runat="server" 
                    onselectedindexchanged="ddlSubCode_SelectedIndexChanged" Height="18px" 
                    Width="169px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style50">
                <asp:Label ID="Label12" runat="server" Text="SubjectType:" Font-Bold="True"></asp:Label>
            </td>
            <td colspan="5">
                <asp:DropDownList ID="ddlSubType1" runat="server" 
                    Height="26px" Width="171px" 
                    onselectedindexchanged="ddlSubType_SelectedIndexChanged">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem>TH</asp:ListItem>
                    <asp:ListItem>PR</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="Label15" runat="server" Text="RoomNo" Font-Bold="True"></asp:Label>
            </td>
            <td class="style30" colspan="2">
                <asp:TextBox ID="txtRoomNo" runat="server" Height="25px" Width="160px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtRoomNo" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="style30">
                &nbsp;</td>
            <td class="style30" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style50">
                <asp:Label ID="Label5" runat="server" Text="AcademicYear:" Font-Bold="True"></asp:Label>
            </td>
            <td colspan="5">
                <asp:DropDownList ID="ddlAcademicYear" runat="server" Height="34px" 
                    Width="165px" 
                    onselectedindexchanged="ddlAcademicYear_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr align="left">
            <td class="style50">
                <asp:Label ID="Label11" runat="server" Text="Absent Roll no:" Font-Bold="True"></asp:Label>
            </td>
            <td class="style6" colspan="5">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow" 
                    onselectedindexchanged="CheckBoxList1_SelectedIndexChanged" >
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="style32">
                <asp:Label ID="Label7" runat="server" Text="Date:" Font-Bold="True"></asp:Label>
            
            </td>
            <td class="style34" colspan="5">
                    <asp:TextBox ID="txtDate" runat="server" 
                    ontextchanged="txtDate_TextChanged" ReadOnly="True"></asp:TextBox>
                    <img alt="" src="calender.png" style="height: 16px; width: 16px;" />
            
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtDate" ErrorMessage="*"></asp:RequiredFieldValidator>
            
            </td>
        </tr>
        <tr align="left">
            <td class="style54">
                <asp:Label ID="Label17" runat="server" Text="Comments" Font-Bold="True"></asp:Label>
            </td>
            <td class="style49" colspan="5">
                <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Width="168px" 
                    Height="31px" ontextchanged="txtComments_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr align="center" valign="top">
            <td class="style33" colspan="6" style="#CCFFCC">
                <asp:Button ID="Button1" runat="server" Font-Size="Large" Height="28px" 
                    Text="Update" Width="100px" onclick="Button1_Click" Font-Bold="False" />
                <asp:Button ID="Button2" runat="server" Font-Size="Large" Height="28px" 
                    Text="Delete" Width="74px" Font-Bold="False" onclick="Button2_Click" />
                <br />
                <br />
                <asp:Label ID="lblmsg" runat="server" Font-Size="X-Large"></asp:Label>
                <br />
            </td>
        </tr>
    </table>

</asp:Content>

