<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="Demo3_1.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="400px">
        <br />
    <asp:Label ID="Label1" runat="server" Text="請選擇你要查詢的資料   :"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>請選擇</asp:ListItem>
        <asp:ListItem>尿液檢驗</asp:ListItem>
        <asp:ListItem>生化檢驗</asp:ListItem>
        <asp:ListItem>基本資料</asp:ListItem>
    </asp:DropDownList>
</asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="600px" Visible="False" CssClass="bg-danger">
        <asp:Label ID="Label2" runat="server" Text="請輸入您的身分證字號  :"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" OnClick="Select_URE" style="height: 26px" Text="查詢" />
        <br />
        <br />
        <asp:GridView ID="GridView4" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="1000px" OnRowCommand="URE_Command" OnPageIndexChanging="GridView4_PageIndexChanging" PageSize="3" AllowPaging="True" Height="114px">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="修改" Text="修改" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" VerticalAlign="Bottom" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <br />
        <asp:Panel ID="Panel5" runat="server" Height="328px" Visible="False">
            ID:
            <asp:Label ID="Label8" runat="server"></asp:Label>
            <br />
            身分證:<asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            姓名:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            檢驗項目:<asp:Label ID="Label12" runat="server"></asp:Label>
            <br />
            醫師 :
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="Doctor" DataValueField="Doctor">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Doctor] FROM [Doctor] WHERE ([Department] = @Department)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label12" Name="Department" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DropDownList2" ErrorMessage="必填" ForeColor="#3366FF"></asp:RequiredFieldValidator>
            <br />
            血型:<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="4" RepeatLayout="Flow">
                <asp:ListItem>A</asp:ListItem>
                <asp:ListItem>B</asp:ListItem>
                <asp:ListItem>O</asp:ListItem>
                <asp:ListItem>AB</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="必填" ForeColor="#3366FF"></asp:RequiredFieldValidator>
            <br />
            日期:<asp:TextBox ID="TextBox8" runat="server" TextMode="DateTime"></asp:TextBox>
            <br />
            PH:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            Protein:<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            Sugar:<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="修改" />
        </asp:Panel>
        <asp:Label ID="Label5" runat="server" Text="查無資料" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回" />
    </asp:Panel>

    <asp:Panel ID="Panel3" runat="server" Height="855px" Visible="False" CssClass="bg-danger">
        <asp:Label ID="Label3" runat="server" Text="請輸入您的身分證字號  :"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="Button4" runat="server" OnClick="Select_BHMT" Text="查詢" />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView5" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="1000px" OnRowCommand="BHMT_Command" AllowPaging="True" OnPageIndexChanging="GridView5_PageIndexChanging" PageSize="5">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="修改" Text="修改" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <br />
        <asp:Panel ID="Panel6" runat="server" Height="503px" style="margin-top: 0px" Visible="False">
            Id:<asp:Label ID="Label9" runat="server"></asp:Label>
            <br />
            身份證字號:<asp:Label ID="Label10" runat="server"></asp:Label>
            <br />
            姓名:<asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            <br />
            檢驗項目 :
            <asp:Label ID="Label13" runat="server"></asp:Label>
            <br />
            醫師 :
            <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource2" DataTextField="Doctor" DataValueField="Doctor">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Doctor] FROM [Doctor] WHERE ([Department] = @Department)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label13" Name="Department" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DropDownList3" ErrorMessage="必填" ForeColor="#0099FF"></asp:RequiredFieldValidator>
            <br />
            血型:<asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatColumns="4" RepeatLayout="Flow">
                <asp:ListItem>A</asp:ListItem>
                <asp:ListItem>B</asp:ListItem>
                <asp:ListItem>O</asp:ListItem>
                <asp:ListItem>AB</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonList2" ErrorMessage="必填" ForeColor="#0099FF"></asp:RequiredFieldValidator>
            <br />
            Cholesterol:<asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
            <br />
            Triglyceride:<asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
            <br />
            BUN:<asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
            <br />
            Creatinine:<asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
            <br />
            Glucose:<asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
            <br />
            Na:<asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
            <br />
            K:<asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
            <br />
            GPT:<asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
            <br />
            GOT:<asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
            <br />
            日期:<asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="修改" />
        </asp:Panel>
        <asp:Label ID="Label6" runat="server" Text="查無資料" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回" />
</asp:Panel>
    <asp:Panel ID="Panel4" runat="server" Height="600px" Visible="False" CssClass="bg-danger">
        <br />
        <asp:Label ID="Label4" runat="server" Text="請輸入您的身分證字號  :"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Button ID="Button5" runat="server" OnClick="Select_Patient" Text="查詢" />
        <br />
        <br />
        <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" Width="1005px" OnRowCommand="PAtient_Command" AllowPaging="True" OnPageIndexChanging="GridView3_PageIndexChanging" PageSize="5">
            <Columns>
                <asp:ButtonField ButtonType="Button" Text="修改" CommandName="修改" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
        <asp:Panel ID="Panel7" runat="server" Height="303px" Visible="False">
            Id:<asp:Label ID="Label11" runat="server"></asp:Label>
            <br />
            姓名:<asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
            <br />
            血型:<asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatColumns="4" RepeatLayout="Flow">
                <asp:ListItem>A</asp:ListItem>
                <asp:ListItem>B</asp:ListItem>
                <asp:ListItem>O</asp:ListItem>
                <asp:ListItem>AB</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RadioButtonList3" ErrorMessage="必填" ForeColor="#6666FF"></asp:RequiredFieldValidator>
            <br />
            生日:<asp:TextBox ID="TextBox22" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox22" ErrorMessage="必填" ForeColor="#003399"></asp:RequiredFieldValidator>
            <br />
            電話:<asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
            <br />
            性別:<asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatColumns="2" RepeatLayout="Flow">
                <asp:ListItem>男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="RadioButtonList4" ErrorMessage="必填" ForeColor="#FF6699"></asp:RequiredFieldValidator>
            <br />
            備註:<asp:TextBox ID="TextBox24" runat="server" Height="98px" TextMode="MultiLine" Width="207px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="修改" />
            <br />
        </asp:Panel>
        <asp:Label ID="Label7" runat="server" Text="查無資料" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="返回" />




    </asp:Panel>
</asp:Content>
