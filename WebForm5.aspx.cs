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
    public partial class WebForm5 : System.Web.UI.Page
    {
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\張銘傑\\source\\repos\\Demo3-1\\Demo3-1\\App_Data\\Database1.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
          //  GridView1.DataSource=null; GridView1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownList1.SelectedValue)
            {
                case "尿液檢驗資料":
                    // Response.Write("<title>尿液檢驗病例查詢</title>");
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    // Title = "尿液檢驗查詢";
                    break;
                case "生化檢驗資料":
                    Panel3.Visible = true;
                    Panel1.Visible = false;
                    //Title = "生化檢驗查詢";
                    // Response.Write("<title>生化檢驗病例查詢</title>");
                    break;
                case "基本資料":
                    Panel1.Visible = false;
                    Panel4.Visible = true;
                    break;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible=false;
        }
        protected void Delete_URE_detail_Select(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from [URE] ", conn);
           // SqlCommandBuilder cmb= new SqlCommandBuilder(da);
            DataSet ds=new DataSet();
            da.Fill(ds, "[URE]");
            DataTable table= ds.Tables["[URE]"];
            DataRow[] row = table.Select("Id_Name='"+TextBox1.Text+"'");
            if (row.Length>0)
            {
                GridView1.DataSource = table;
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('查無此病人的尿意檢驗資料')</script>");

            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "刪除")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView1.Rows[index];
                string productName = selectedRow.Cells[1].Text;
                // Rows[index].Cells[1].Text;
                SqlDataAdapter da = new SqlDataAdapter("Select * from [URE] ", conn);
                SqlCommandBuilder cmb = new SqlCommandBuilder(da);
               
                DataTable table = new DataTable();
                da.Fill(table);
                DataRow[] drs = table.Select(" Id=" + productName );
                table.Rows[table.Rows.IndexOf(drs[0])].Delete();
                da.Update(table);
                if (table.Select("Id_Name='" + TextBox1.Text + "'").Length ==0)
                {
                    GridView1.DataSource = table.Select("Id_Name='" + TextBox1.Text + "'");
                    GridView1.DataBind();
                    Response.Write("<script type='text/javascript'>alert('資料刪除成功')</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('查無資料')</script>");
                }
            }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel3.Visible= false;
        }
        protected void Delete_BHMT_detail_Select(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from [BHMT] ", conn);
            // SqlCommandBuilder cmb= new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "[BHMT]");
            DataTable table = ds.Tables["[BHMT]"];
            DataRow[] row = table.Select("Id_Name='" + TextBox2.Text + "'");
            if (row.Length > 0)
            {
                DataView view = new DataView(table, "Id_Name='" + TextBox2.Text + "'", "date", DataViewRowState.CurrentRows);
                GridView2.DataSource = view;
                GridView2.DataBind();
            }else
            {
                Response.Write("<script type='text/javascript'>alert('查無此病人的生化檢驗資料')</script>");

            }
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "刪除")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView2.Rows[index];
                string productName = selectedRow.Cells[1].Text;
                // Rows[index].Cells[1].Text;
                SqlDataAdapter da = new SqlDataAdapter("Select * from [BHMT] ", conn);
                SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                DataTable table = new DataTable();
                da.Fill(table);
                DataRow[] drs = table.Select(" Id=" + productName);
                table.Rows[table.Rows.IndexOf(drs[0])].Delete();
                da.Update(table);
                if (table.Select("Id_Name='" + TextBox1.Text + "'").Length == 0)
                {
                    GridView2.DataSource = table.Select("Id_Name='" + TextBox1.Text + "'");
                    GridView2.DataBind();
                    Response.Write("<script type='text/javascript'>alert('資料刪除成功')</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('查無資料')</script>");
                }
            }
        }
        protected void Delet_Patient(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Patient", conn);
            SqlCommandBuilder cmbd = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Patient]");
            DataTable table = ds.Tables["[Patient]"];
            DataRow[] dataRow = table.Select("Id='" + TextBox3.Text+"'");
            if (dataRow.Length == 0)
            {
                Response.Write("<script type='text/javascript'>alert('此個人資料已經刪除')</script>");
                return;
            }
            else
            {
                table.Rows[table.Rows.IndexOf(dataRow[0])].Delete();
                da.Update(table);
            }

            da = new SqlDataAdapter("Select * from [URE]", conn);
            cmbd = new SqlCommandBuilder(da);
            da.Fill(ds, "[URE]");
            table = ds.Tables["[URE]"];
            dataRow = table.Select("Id_Name='" + TextBox3.Text + "'");
            SqlCommand deleteCommand = da.DeleteCommand;
            for(int i=0;i<dataRow.Length;i++)
            {
                table.Rows[table.Rows.IndexOf(dataRow[i])].Delete();
                da.Update(table);
            }
            

            da = new SqlDataAdapter("Select * from [BHMT]", conn);
            cmbd = new SqlCommandBuilder(da);
            da.Fill(ds, "[BHMT]");
            table = ds.Tables["[BHMT]"];
            dataRow = table.Select("Id_Name='" + TextBox3.Text + "'");
            foreach (DataRow row in dataRow)
            {
                table.Rows[table.Rows.IndexOf(row)].Delete();
                da.Update(table); 
            }
            if (ds.Tables["[BHMT]"].Select("Id='" + TextBox3.Text + "'") == null)
            {
                Response.Write("<script type='text/javascript'>alert('生化檢驗資料刪除成功')</script>");
                
            }
            if (ds.Tables["[URE]"].Select("Id_Name='" + TextBox3.Text + "'") == null)
            {
                Response.Write("<script type='text/javascript'>alert('尿液檢驗資料刪除成功')</script>");

            }
            if (ds.Tables["[Patient]"].Select("Id='" + TextBox3.Text + "'") == null)
            {
                Response.Write("<script type='text/javascript'>alert('個人資料刪除成功')</script>");
            }

            // SqlConnection conn1 = new SqlConnection(conn);
            // conn1.Open();
            // SqlCommand cmd = new SqlCommand("Delete * from [Patient] where Id=@Id", conn1);
            // cmd.Parameters.Add("@Id", SqlDbType.NVarChar, 10).Value = TextBox3.Text;
            // cmd.ExecuteNonQuery();
            // cmd.Cancel();
            //SqlCommand cmd2 = new SqlCommand("Delete * from [BHMT] where Id_Name=@Id", conn1);
            // cmd2.Parameters.Add("@Id", SqlDbType.NVarChar, 10).Value = TextBox3.Text; cmd2.ExecuteNonQuery();
            // cmd2.Cancel();
            // SqlCommand cmd3 = new SqlCommand("Delete * from [URE] where Id_Name=@Id", conn1);
            // cmd3.Parameters.Add("@Id",SqlDbType.NVarChar,10).Value=TextBox3.Text; cmd3.ExecuteNonQuery();
            // cmd3.Cancel();



        }
    }
}