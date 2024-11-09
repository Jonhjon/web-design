using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo3_1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\張銘傑\\source\\repos\\Demo3-1\\Demo3-1\\App_Data\\Database1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<title>醫療檢查系統 - 資料查詢</title>");
            Label5.Visible= false;
            Label6.Visible= false;
            Label7.Visible= false;
            Panel5.Visible= false;
            Panel6.Visible= false;
            Panel7.Visible= false;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(DropDownList1.SelectedValue)
            {
                case "尿液檢驗":
                    Response.Write("<title>尿液檢驗病例查詢</title>");
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                   // Title = "尿液檢驗查詢";
                    break;
                case "生化檢驗":
                    Panel3.Visible = true;
                    Panel1.Visible = false;
                    //Title = "生化檢驗查詢";
                    Response.Write("<title>生化檢驗病例查詢</title>");
                    break;
                case "基本資料":
                    Panel4.Visible= true;
                    Panel1.Visible= false;
                    Response.Write("<title>基本資料查詢</title>");
                    break;
            }
            DropDownList1.Items[0].Selected = true;
            DropDownList1.Items[1].Selected = false;
            DropDownList1.Items[2].Selected = false;
            DropDownList1.Items[3].Selected = false;
        }//下拉式選單

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible= true;
            Panel2.Visible= false;
            GridView4.Visible= false;
        }//返回

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel3.Visible= false;
            Panel1.Visible= true;
        }//返回

        protected void Select_URE(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [URE]", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[URE]");
            DataTable table = ds.Tables["[URE]"];
            DataRow[] row = table.Select("Id_Name = '"+TextBox1.Text+"'");
            if (row.Length>0)
            {
                DataView view = new DataView(table, "Id_Name='" + TextBox1.Text + "'", "Id", DataViewRowState.CurrentRows);
                GridView4.DataSource = view;
                GridView4.DataBind();
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('查無尿液檢驗')</script>");
                GridView4.DataSource = null;
                GridView4.DataBind();
                Label5.Visible  = true;
            }
        }//查詢尿液檢驗的病歷資料

        protected void Select_BHMT(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [BHMT] ", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[BHMT]");
            DataTable table = ds.Tables["[BHMT]"];
            DataRow[] row = table.Select("Id_Name='" + TextBox2.Text + "'");
            if (row.Length > 0)
            {
                DataView view=new DataView(table, "Id_Name='" + TextBox2.Text + "'","Id",DataViewRowState.CurrentRows);
                GridView5.DataSource = view;
                GridView5.DataBind();
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('查無生化檢驗')</script>");
                GridView5.DataSource = null;
                GridView5.DataBind();
                Label6.Visible= true;
            }
        }//查詢生化檢驗的病歷資料

        protected void Button6_Click(object sender, EventArgs e)
        {
            Panel4.Visible= false;
            Panel1.Visible = true;
            GridView5.Visible= false;
        }//返回

        protected void Select_Patient(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Patient] where Id='" + TextBox3.Text + "'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Patient]");
            DataTable table = ds.Tables["[Patient]"];
            if (table.Rows.Count > 0)
            {
                GridView3.DataSource = table;
                GridView3.DataBind();
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('查無基本資料')</script>");
                GridView3.DataSource = null;
                GridView3.DataBind();
                Label7.Visible = true;
            }
        }//查詢病人基本資料
        protected void URE_Command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "修改")
            {
                Panel5.Visible = true;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView4.Rows[index];
                string productName = selectedRow.Cells[1].Text;
                SqlDataAdapter da = new SqlDataAdapter("Select * from URE", conn);
                SqlCommandBuilder cmdb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "URE");
                DataTable table = ds.Tables["URE"];
                DataRow[] dataRow = table.Select("Id=" + productName);
                Label8.Text = dataRow[0]["Id"].ToString();
                TextBox9.Text = dataRow[0]["Id_Name"].ToString();
                TextBox4.Text = dataRow[0]["Name"].ToString();
                TextBox8.Text = dataRow[0]["date"].ToString();
                TextBox5.Text = dataRow[0]["PH"].ToString();
                TextBox6.Text = dataRow[0]["Protein"].ToString();
                TextBox7.Text = dataRow[0]["Sugar"].ToString();
                Label12.Text = dataRow[0]["Department"].ToString();

            }
        }//選取尿液資料到編輯區
        protected void Button7_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from URE", conn);
            SqlCommandBuilder cmbd = new SqlCommandBuilder(da);
            DataSet ds=new DataSet();
            da.Fill(ds, "URE");
            DataTable table = ds.Tables["URE"];
            DataRow[] dataRow = table.Select("Id="+Label8.Text);
            table.Rows[table.Rows.IndexOf(dataRow[0])].Delete();
            DataRow row=table.NewRow();
            row["Id"] = Label8.Text;
            row["Id_Name"] = TextBox9.Text;
            row["blood_type"] = RadioButtonList1.SelectedItem.Text;    
            row["Name"] = TextBox4.Text;
            row["date"] = TextBox8.Text;
            row["PH"]=TextBox5.Text;
            row["Protein"] = TextBox6.Text;
            row["Sugar"]= TextBox7.Text;
            row["Department"]=Label12.Text;
            row["Doctor"]=DropDownList2.SelectedItem.Text;
            table.Rows.Add(row);
            da.Update(table);
            DataView view = new DataView(table, "Id_Name='" + TextBox9.Text + "'", "Id", DataViewRowState.CurrentRows);
            if (view.Count > 0)
            {
                GridView4.DataSource = view;
                GridView4.DataBind();
                Response.Write("<script type='text/javascript'>alert('尿液檢驗資料更新成功')</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('尿液檢驗資料更新失敗')</script>");
            }
        }//把編輯區的資料更新到資料庫
        protected void BHMT_Command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "修改")
            {
                Panel6.Visible = true;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView5.Rows[index];
                string productName = selectedRow.Cells[1].Text;
                SqlDataAdapter da = new SqlDataAdapter("Select * from [BHMT] ", conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "[BHMT]");
                DataTable table = ds.Tables["[BHMT]"];
                DataRow[] dataRow = table.Select("Id='" + productName + "'");
                Label9.Text = dataRow[0]["Id"].ToString();
                Label10.Text = dataRow[0]["Id_Name"].ToString();
                TextBox10.Text = dataRow[0]["Name"].ToString();
                TextBox11.Text = dataRow[0]["Cholesterol"].ToString();
                TextBox12.Text = dataRow[0]["Triglyceride"].ToString();
                TextBox13.Text = dataRow[0]["BUN"].ToString();
                TextBox14.Text = dataRow[0]["Creatinine"].ToString();
                TextBox15.Text = dataRow[0]["Glucose"].ToString();
                TextBox16.Text = dataRow[0]["Na"].ToString();
                TextBox17.Text = dataRow[0]["K"].ToString();
                TextBox18.Text = dataRow[0]["GPT"].ToString();
                TextBox19.Text = dataRow[0]["GOT"].ToString();
                TextBox20.Text = dataRow[0]["date"].ToString();
                Label13.Text= dataRow[0]["Department"].ToString();
            }
        }//選取生化檢驗資料到編輯區
        protected void Button8_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da=new SqlDataAdapter("Select * from BHMT",conn);
            SqlCommandBuilder cmbd= new SqlCommandBuilder(da);
            DataSet ds= new DataSet();
            da.Fill(ds,"BHMT");
            DataTable table = ds.Tables["BHMT"];
            DataRow[] dataRow = table.Select("Id=" + Label9.Text);
            table.Rows[table.Rows.IndexOf(dataRow[0])].Delete();
            DataRow row = table.NewRow();
            row["Id"] = Label9.Text;
            row["Id_Name"] = Label10.Text;
            row["Name"] = TextBox10.Text;
            row["Cholesterol"] = TextBox11.Text;
            row["Triglyceride"]= TextBox12.Text;
            row["BUN"]=TextBox13.Text;
            row["Creatinine"] =TextBox14.Text;
            row["Glucose"]=TextBox15.Text;
            row["Na"] = TextBox16.Text;
            row["K"]=TextBox17.Text;
            row["GPT"]=TextBox18.Text;
            row["GOT"]=TextBox19.Text;
            row["date"] = TextBox20.Text;
            row["blood_type"] = RadioButtonList2.SelectedItem.Text;
            row["Department"] = Label13.Text;
            row["Doctor"] = DropDownList3.SelectedItem.Text;
            table.Rows.Add(row);
            da.Update(table);
            DataView view = new DataView(table, "Id_Name='" + Label10.Text + "'", "Id", DataViewRowState.CurrentRows);
            if (view.Count > 0)
            {
                GridView5.DataSource = view;
                GridView5.DataBind();
                Response.Write("<script type='text/javascript'>alert('生化檢驗資料更新成功')</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('生化檢驗資料更新失敗')</script>");
            }
        }//把編輯區的資料更新到資料庫
        protected void PAtient_Command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "修改")
            {
                Panel7.Visible = true;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView3.Rows[index];
                string productName = selectedRow.Cells[1].Text;
                SqlDataAdapter da = new SqlDataAdapter("Select * from Patient", conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Patient");
                DataTable table = ds.Tables["Patient"];
                DataRow[] dataRow = table.Select("Id='" + productName + "'");
                Label11.Text = dataRow[0]["Id"].ToString();
                TextBox21.Text = dataRow[0]["Name"].ToString();
                TextBox22.Text = dataRow[0]["Birth"].ToString();
                TextBox23.Text = dataRow[0]["Phone"].ToString();
                TextBox24.Text = dataRow[0]["備註"].ToString();
            }
        }//把病人基本資料放到編輯區
        protected void Button9_Click(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("Select * from Patient", conn);
            SqlCommandBuilder cmbd = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Patient");
            DataTable table = ds.Tables["Patient"];
            DataRow[] dataRow = table.Select("Id='" + Label11.Text+"'");
            table.Rows[table.Rows.IndexOf(dataRow[0])].Delete();
            DataRow row = table.NewRow();
            row["Id"]=Label11.Text; 
            row["Name"]=TextBox21.Text;
            row["blood_type"] = RadioButtonList3.SelectedItem.Text;
            row["Birth"] = TextBox22.Text;
            row["Phone"]=TextBox23.Text;
            row["gender"]=RadioButtonList4.SelectedItem.Text;
            row["備註"]= TextBox24.Text;
            table.Rows.Add(row);
            da.Update(table);
            DataView view = new DataView(table, "Id='" + Label11.Text + "'", "Id", DataViewRowState.CurrentRows);
            if (view.Count > 0)
            {
                GridView3.DataSource = view;
                GridView3.DataBind();
                Response.Write("<script type='text/javascript'>alert('基本資料更新成功')</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('基本檢驗資料更新失敗')</script>");
            }
        }//更新病人基本資料
        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Select_URE(sender,e);
            GridView4.PageIndex = e.NewPageIndex;
            GridView4.DataBind();
        }//分頁設定
        protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Select_BHMT(sender, e);
            GridView5.PageIndex = e.NewPageIndex;
            GridView5.DataBind();
        }//分頁設定
        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Select_Patient(sender, e);
            GridView3.PageIndex = e.NewPageIndex;
            GridView3.DataBind();
        }//分頁設定
    }
}