<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeedbackInfo.aspx.cs" Inherits="FeedbackInfo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 401px;
            margin-right: 2px;
          
            margin-bottom: 0px;
        }
        .style8
        {
            height: 53px;
        }
        .style9
        {
            height: 73px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    f<table align="left" class="style6" 
        style="border: medium solid #ff6699; height: 199px;">
        <tr>
            <td class="style8" colspan="2" align="center">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" 
                    Text="FEEDBACK INFO"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style9">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="Subject Feedback:"></asp:Label>
            </td>
            <td class="style9">
                <asp:DropDownList ID="ddlSubFeedback" runat="server" Height="19px" 
                    style="margin-top: 24px" Width="149px" 
                    onselectedindexchanged="ddlSubFeedback_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr align="center">
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Font-Bold="False" Font-Size="Large" 
                    Text="Feedbackthis&gt;&gt;&gt;" onclick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

