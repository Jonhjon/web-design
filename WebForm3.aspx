<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Demo3_1.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">





    <asp:Panel ID="Panel1" runat="server" Height="600px" BorderColor="Fuchsia">
        <br />
        請選擇你要新增檢驗類別:&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="16px">
            <asp:ListItem Selected="True">請選擇</asp:ListItem>
            <asp:ListItem>尿液檢驗</asp:ListItem>
            <asp:ListItem>生化檢驗</asp:ListItem>
        </asp:DropDownList>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" Height="600px" style="margin-top: 0px" Visible="False" CssClass="bg-danger">
        <br />
        <br />
        身分證字號:<asp:TextBox ID="Id" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Id" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        姓名:<asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Name" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        醫師:<asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource1" DataTextField="Doctor" DataValueField="Doctor">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT [Doctor] FROM [Doctor] WHERE ([Department] = @Department)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="Department" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        日期:<asp:TextBox ID="date" runat="server" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="date" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        血型:
        <asp:RadioButtonList ID="blood_type" runat="server" RepeatColumns="4" RepeatLayout="Flow">
            <asp:ListItem>A</asp:ListItem>
            <asp:ListItem>B</asp:ListItem>
            <asp:ListItem>AB</asp:ListItem>
            <asp:ListItem>O</asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="blood_type" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        PH:<asp:TextBox ID="PH" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="PH" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Protein:
        <asp:TextBox ID="Protein" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Protein" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Sugar:<asp:TextBox ID="Sugar" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Sugar" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="URE_patient_detail_add" Text="上傳" />
        <br />
        <asp:GridView ID="GridView1" runat="server" Width="798px" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回" Visible="False" />
    </asp:Panel>

    <asp:Panel ID="Panel3" runat="server" Height="634px" Visible="False" CssClass="bg-danger">
        <br />
        <br />
        身分證字號:
        <asp:TextBox ID="Id_Name" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Id_Name" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        姓名 :
        <asp:TextBox ID="Name2" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Name2" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        血型:
        <asp:RadioButtonList ID="blood_type2" runat="server" RepeatColumns="4" RepeatLayout="Flow">
            <asp:ListItem>A</asp:ListItem>
            <asp:ListItem>B</asp:ListItem>
            <asp:ListItem>AB</asp:ListItem>
            <asp:ListItem>O</asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="blood_type2" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        醫師 :
        <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource2" DataTextField="Doctor" DataValueField="Doctor">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Doctor] FROM [Doctor] WHERE ([Department] = @Department)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="Department" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        Cholesterol :
        <asp:TextBox ID="Cholesterol" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="Cholesterol" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Triglyceride :
        <asp:TextBox ID="Triglyceride" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="Triglyceride" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        BUN :
        <asp:TextBox ID="BUN" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="BUN" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Creatinin：<asp:TextBox ID="Creatinine" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="Creatinine" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Glucose :
        <asp:TextBox ID="Glucose" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="Glucose" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Na :
        <asp:TextBox ID="Na" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="Na" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        K :
        <asp:TextBox ID="K" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="K" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        GPT :
        <asp:TextBox ID="GPT" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="GPT" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        GOT:
        <asp:TextBox ID="GOT" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="GOT" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Date :&nbsp;
        <asp:TextBox ID="date2" runat="server" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="date2" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="BHMT_Patient_detail_Add" Text="上傳" />
        <br />
        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Width="1025px">
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
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="返回" Visible="False" />
    </asp:Panel>

</asp:Content>
