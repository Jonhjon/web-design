<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="Demo3_1.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="400px">
        <br />
        <asp:Label ID="Label1" runat="server" Text="慶輸入你要刪除的資料  : "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="margin-top: 6">
            <asp:ListItem Selected="True">請選擇</asp:ListItem>
            <asp:ListItem>尿液檢驗資料</asp:ListItem>
            <asp:ListItem>生化檢驗資料</asp:ListItem>
            <asp:ListItem>基本資料</asp:ListItem>
        </asp:DropDownList>
         </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" Height="400px" Visible="False">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="尿液檢驗(URE)資料刪除  "></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="請輸入身份證字號  :"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            <asp:Button ID="Button3" runat="server" OnClick="Delete_URE_detail_Select" Text="查詢" style="height: 26px" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCommand="GridView1_RowCommand" Width="600px">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="刪除" HeaderText="刪除" Text="刪除" />
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="width: 42px" Text="返回" />

        </asp:Panel>

        <asp:Panel ID="Panel3" runat="server" Height="400px" Visible="False">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="生化檢驗(BHMT)資料刪除 :"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="請輸入身份證字號 : "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Button ID="Button4" runat="server" OnClick="Delete_BHMT_detail_Select" style="height: 26px" Text="查詢" />
            <br />
            <br />
            <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="800px" ForeColor="Black" OnRowCommand="GridView2_RowCommand">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:ButtonField ButtonType="Button" Text="刪除" CommandName="刪除" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="返回" />


        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" Height="400px" Visible="False">
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server" Text="基本資料刪除"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="請輸入身分證字號 : "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Button ID="Button6" runat="server" OnClick="Delet_Patient" Text="刪除" />



            <br />
            <br />



        </asp:Panel>
   
</asp:Content>
