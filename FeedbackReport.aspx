<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeedbackReport.aspx.cs" Inherits="FeedbackReport" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style9
        {
            width: 100%;
        }
        .style10
        {
        }
        .style11
        {
            width: 165px;
        }
    </style>
    <script type="text/javascript">

function PrintGridView() {
var PGrid = document.getElementById('<%=GridView1.ClientID %>');
PGrid.border = 1;
var Pwin = window.open('', 'PrintGrid', 'left=100,top=100,width=1024,height=768,tollbar=0,scrollbars=1,status=0,resizable=1');
Pwin.document.write("S.E.S. Polytechnic<Br>");
Pwin.document.write("STudent Feed<br>");

var yr = document.getElementById('<%=ddlACYR.ClientID %>');
Pwin.document.write(yr.outerHTML);

Pwin.document.write(PGrid.outerHTML);
Pwin.document.close();
Pwin.focus();
Pwin.print();
Pwin.close();
}

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="style9">
        <tr align="center">
            <td colspan="2">
                <asp:Label ID="Label4" runat="server" Text="FEEDBACK REPORT"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label6" runat="server" Text="Academic Year"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlACYR" runat="server" Height="26px" Width="109px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label7" runat="server" Text="Semester:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSem" runat="server" Height="26px" Width="109px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label5" runat="server" Text="Subject:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSub" runat="server" Height="26px" Width="110px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style10" colspan="2">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    Text="Report&gt;&gt;" />
                <br />
                <br />
                
        <asp:GridView ID="GridView1" runat="server">
        
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" onclientclick="PrintGridView()" 
            Text="Print" onclick="Button2_Click" />
    
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

