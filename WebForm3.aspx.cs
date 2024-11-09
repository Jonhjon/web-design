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
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\張銘傑\\source\\repos\\Demo3-1\\Demo3-1\\App_Data\\Database1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Panel1.Visible == true) { Response.Write("<title>醫療檢查系統 - 病例新增</title>"); }
           

            //Panel2.Visible = false;
            //Panel3.Visible = false;
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(DropDownList1.SelectedValue){
                case "尿液檢驗":
                    Response.Write("<title>尿液檢驗病例新增</title>");
                    Panel2.Visible = true;
                   Panel1.Visible = false;
                    break;
                case "生化檢驗":
                    Response.Write("<title>生化檢驗病例新增</title>");
                    Panel3.Visible = true;
                    Panel1.Visible = false;
                    break;
            }
        }//下拉是選單，選擇你要得檢驗項目

        protected void URE_patient_detail_add(object sender, EventArgs e)
        {
            if (Check(Id.Text))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [URE]", conn);
                SqlCommandBuilder cmdb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "[URE]");
                DataTable table = ds.Tables["[URE]"];
                DataRow row = table.NewRow();
                row["Id_Name"] = Id.Text;
                row["Name"] = Name.Text;
                row["Department"] = DropDownList1.SelectedItem.Text;
                row["Doctor"] = DropDownList4.SelectedItem.Text;
                row["blood_type"] = blood_type.SelectedItem.Text;
                row["PH"] = PH.Text;
                row["Protein"] = Protein.Text;
                row["Sugar"] = Sugar.Text;
                row["date"] = date.Text;
                table.Rows.Add(row);
                da.Update(table);
                DataView view = new DataView(table, "Id_Name='" + Id.Text + "'", "", DataViewRowState.CurrentRows);
                if (view.Count > 0)
                {
                    GridView1.DataSource = view;
                    GridView1.DataBind();
                    Response.Write("<script type='text/javascript'>alert('尿液檢驗資料新增成功')</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('尿液檢驗資料新增失敗')</script>");
                }
            }
            else {
                Response.Write("<script type='text/javascript'>alert('此身分證查無基本資料，請先新增基本資料')</script>");
            }
        }//尿液檢驗的資料新增

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<title>病例新增</title>");
            Panel1.Visible = true;
            Panel2.Visible = false;
        }//返回

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Write("<title>病例新增</title>");
            Panel3.Visible = false;
            Panel1.Visible = true;
        }//返回

        protected void BHMT_Patient_detail_Add(object sender, EventArgs e)
        {
           if(Check(Id_Name.Text))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From BHMT", conn);
                SqlCommandBuilder cmdb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "BHMT");
                DataTable table = ds.Tables["BHMT"];
                DataRow row = table.NewRow();
                row["Id_Name"] = Id_Name.Text;
                row["Name"] = Name2.Text;
                row["blood_type"] = blood_type2.SelectedItem.Text;
                row["Department"] = DropDownList1.SelectedItem.Text;
                row["Doctor"] = DropDownList5.SelectedItem.Text;
                row["Cholesterol"] = Cholesterol.Text;
                row["Triglyceride"] = Triglyceride.Text;
                row["BUN"] = BUN.Text;
                row["Creatinine"] = Creatinine.Text;
                row["Glucose"] = Glucose.Text;
                row["Na"] = Na.Text;
                row["K"] = K.Text;
                row["GPT"] = GPT.Text;
                row["GOT"] = GOT.Text;
                row["date"] = date2.Text;
                table.Rows.Add(row);
                da.Update(table);
                DataView view = new DataView(table, "Id_Name='" + Id_Name.Text + "'", "", DataViewRowState.CurrentRows);
                if (view.Count > 0)
                {
                    GridView2.DataSource = view;
                    GridView2.DataBind();
                    Response.Write("<script type='text/javascript'>alert('生化檢驗資料新增成功')</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('生化檢驗資料新增失敗')</script>");
                }
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('此身分證查無基本資料，請先新增基本資料')</script>");
            }
        }//生化檢驗的資料新增

        protected Boolean Check(string ID) 
        {
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT [id] FROM [Patient] ", conn);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "[Patienr]");
            DataTable table1 = ds1.Tables["[Patienr]"];
            DataRow[] dataRow = table1.Select("Id='" + ID + "'");
            if (dataRow.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//查看是否有重複

        
    }
}