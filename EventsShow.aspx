<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EventsShow.aspx.cs" Inherits="EventsShow" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label4" runat="server" Font-Size="X-Large" Text="EVENTS"></asp:Label>
    <br />
    <asp:GridView ID="gvDetails" runat="server" style="margin-right: 0px">
    </asp:GridView>
</asp:Content>

