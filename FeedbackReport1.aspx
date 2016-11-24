<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeedbackReport1.aspx.cs" Inherits="FeedbackReport1" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style9
        {
            height: 374px;
            width: 781px;
        }
        .style10
        {
            width: 360px;
        }
        .style12
        {
            width: 498px;
        }
        .style13
        {
            width: 676px;
        }
    </style>
    
     <script type="text/javascript">

function PrintGridView() {
var PGrid = document.getElementById('<%=GridView1.ClientID %>');
PGrid.border = 1;
var Pwin = window.open('', 'PrintGrid', 'left=100,top=100,width=1024,height=768,tollbar=0,scrollbars=1,status=0,resizable=1');
          Pwin.document.write("      S.E.S. Polytechnic,Solapur<Br>");
         Pwin.document.write("        Student Feedback<br>");

         var yr = document.getElementById('<%=   ddlACYR.ClientID %>');
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
<table align="center" class="style9" style="border: thin solid #000000">
        <tr align="center">
            <td colspan="2">
                <asp:Label ID="Label4" runat="server" Text="FEEDBACK REPORT" 
                    style="font-size: xx-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label6" runat="server" Text="Academic Year"></asp:Label>
            </td>
            <td class="style13">
                <asp:DropDownList ID="ddlACYR" runat="server" Height="26px" Width="109px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label7" runat="server" Text="Semester:"></asp:Label>
            </td>
            <td class="style13">
                <asp:DropDownList ID="ddlSem" runat="server" Height="26px" Width="109px" 
                    AutoPostBack="True" onselectedindexchanged="ddlSem_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style10" colspan="2">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    Text="Actual Report&gt;&gt;" />
                <br />
                <br />
                
        <asp:GridView ID="GridView1" runat="server">
        
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" onclientclick="PrintGridView()" 
            Text="Print"  />
    
                <br />
                <br />
                <asp:Label ID="Label8" runat="server" 
                    style="color: #FFFF00; font-size: large; font-style: italic" 
                    Text="Student Feedback Report According to his Attendance"></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                    Text="Attendance Based Report &gt;&gt;" />
                <br />
                <br />
                <br />
                <asp:GridView ID="GridView2" runat="server">
                </asp:GridView>
                <br />
                <asp:Label ID="lblmsg1" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

