<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            width: 100%;
            margin-top: -20px;
        }
        .style9
        {
        	            height: 278px;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style5">
        <tr>
            <td rowspan="2">
   
   
    
    </td>
            <td class="style9">
   
                <div id="sliderFrame" align="center">
        <div id="slider">
            
            <img src="images/1 (1).jpg" />
            <img src="images/1 (1).jpeg" />
            <img src="images/1 (2).jpeg" />
            <img src="images/1 (2).jpg" />
            <img src="images/1 (3).jpg" />
            <img src="images/1 (4).jpg" />
            <img src="images/1 (5).jpg" />
           
            
        </div>
        <!--Custom navigation buttons on both sides-->
        <div class="group1-Wrapper">
            <a onClick="imageSlider.previous()" class="group1-Prev"></a>
            <a onClick="imageSlider.next()" class="group1-Next"></a>
        </div>
        <!--nav bar-->
        <div style="text-align:center;padding:20px;z-index:20; height: 7px;">
            <a onClick="imageSlider.previous()" class="group2-Prev"></a>
            <a id='auto' onClick="switchAutoAdvance()"></a>
            <a onClick="imageSlider.next()" class="group2-Next"></a>
        </div>
    </div>


    <script type="text/javascript">
        //The following script is for the group 2 navigation buttons.
        function switchAutoAdvance() {
            imageSlider.switchAuto();
            switchPlayPauseClass();
        }
        function switchPlayPauseClass() {
            var auto = document.getElementById('auto');
            var isAutoPlay = imageSlider.getAuto();
            auto.className = isAutoPlay ? "group2-Pause" : "group2-Play";
            auto.title = isAutoPlay ? "Pause" : "Play";
        }
        switchPlayPauseClass();
    </script>&nbsp;</td>
            <td valign="middle" rowspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Font-Size="X-Large" Text="Events.."></asp:Label>
                <asp:GridView ID="gvDetails" runat="server" 
                    CellPadding="3" Height="290px" 
                    Width="283px" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" 
                    BorderWidth="1px" CellSpacing="2">
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
    
    </td>
        </tr>
        <tr>
            <td>
   
                &nbsp;</td>
        </tr>
        </table>
   

    <br />
    

    <br />
    

</asp:Content>

