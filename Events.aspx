<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Events.aspx.cs" Inherits="Events" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

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
    <table align="center" 
        style="border: thin solid #000000; height: 225px; width: 499px">
        <tr>
            <td colspan="2" align="justify">
                <asp:Label ID="Label4" runat="server" Font-Size="XX-Large" Text="EVENTS"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Event Title"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtETitle" runat="server" Height="25px" Width="165px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Event Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" Height="24px" 
                    ontextchanged="txtDate_TextChanged" Width="158px"></asp:TextBox>
                <img alt="" src="calender.png" style="height: 16px; width: 16px;" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Event Venue"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEVenue" runat="server" Height="22px" Width="166px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Conducted By"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtConducted" runat="server" Height="22px" Width="168px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDiscription" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Height="42px" onclick="Button1_Click" 
                    Text="Save" Width="95px" />
                <asp:Button ID="Button2" runat="server" Height="42px" Text="Cancel" 
                    Width="95px" />
                <br />
                <asp:Label ID="lblmsg" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

