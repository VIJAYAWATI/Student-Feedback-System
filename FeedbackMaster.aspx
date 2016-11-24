<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeedbackMaster.aspx.cs" Inherits="FeedbackMaster" Title="Untitled Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style8
        {
            height: 55px;
        }
        .style9
        {
            height: 26px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
    
    
    <asp:Label ID="lblWelCome" runat="server" Font-Size="Large" 
        style="color: #FFFF00; font-style: italic"></asp:Label>
    <br />
    <br />
    <br />
     
    <table align="center" 
        style="border: thin solid #000000; height: 329px; width: 793px">
        <tr>
            <td align="center" class="style8">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Large" 
                    Text="FEEDBACK MASTER"></asp:Label>
                                </td>
            <td align="center" class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9" colspan="2">
                Academic Year :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlAcademicYear" runat="server" Height="28px" 
                    Width="151px">
                </asp:DropDownList>
                                </td>
        </tr>
        <tr>
            <td colspan="2">
                Select Semister Code :&nbsp;
                <asp:DropDownList ID="ddlSemCode" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlSemCode_SelectedIndexChanged" Height="33px" 
                    Width="152px" style="margin-top: 0px">
                </asp:DropDownList>
                                </td>
        </tr>
        <tr>
            <td colspan="2">
                Select Subject Code :&nbsp;&nbsp;                 
                <asp:DropDownList ID="ddlSubCode" 
                    runat="server" Height="30px" 
                    onselectedindexchanged="DropDownList3_SelectedIndexChanged" Width="154px">
                </asp:DropDownList>
                                </td>
        </tr>
        <tr>
            <td colspan="2">
                Your Response below are for the purpose of Evaluation.</tr>
        <tr>
            <td colspan="2">
                Please Select&nbsp; the Marks for every staff to the question given below</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                    Text="Start FeedBack" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvDetails" runat="server" DataKeyNames="questionNo" AutoGenerateColumns="false">
                   
                 <Columns>
               
            <asp:TemplateField HeaderText="Question No">               
               <ItemTemplate>
                 <asp:Label ID="lblqueno" runat="server" Text='<%#Eval("questionNo") %>'/>
              </ItemTemplate>
           </asp:TemplateField>        
        
            <asp:TemplateField HeaderText="Question">               
               <ItemTemplate>
                 <asp:Label ID="lblquestion" runat="server" Text='<%#Eval("Question") %>'/>
              </ItemTemplate>
           </asp:TemplateField>        
           
            <asp:TemplateField HeaderText="Rating">               
               <ItemTemplate>
                   <asp:DropDownList ID="DropDownList1" runat="server">
                       <asp:ListItem Value="1" Text="1" />
                       <asp:ListItem Value="2" Text="2" />
                       <asp:ListItem Value="3" Text="3" />
                       <asp:ListItem Value="4" Text="4" />
                       <asp:ListItem Value="5" Text="5" />
                   </asp:DropDownList>
              </ItemTemplate>
           </asp:TemplateField>        
        
        
</Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;<asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                <asp:Label ID="lbltest" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" 
                    Height="33px" Width="89px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="X-Large" 
                    ForeColor="#33CCFF" onclick="LinkButton1_Click">Logout</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
&nbsp;
</asp:Content>

