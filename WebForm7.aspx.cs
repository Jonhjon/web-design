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
    public partial class WebForm7 : System.Web.UI.Page
    {
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\張銘傑\\source\\repos\\Demo3-1\\Demo3-1\\App_Data\\Database1.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
            Label3.Visible = false;
            //DetailsView1.DataSource = null;
            //DetailsView1.DataBind();
            DetailsView1.Visible = false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select Id,Id_Name,Name,date,Department from BHMT", conn);
            DataSet ds=new DataSet();
            da.Fill(ds,"BHMT");
            da =new SqlDataAdapter("Select Id,Id_Name,Name,date,Department from URE", conn);
            da.Fill(ds, "URE");
            DataTable table = ds.Tables["BHMT"];
            //DataRow[] dataRow= table.Select("Select date="+TextBox1.Text);
            DateTime date = DateTime.Parse(TextBox1.Text);
            DataView view = new DataView(table, "date='"+date+"'","", DataViewRowState.CurrentRows);
            if (view.Count > 0)
            {
                Label2.Visible = true;
                GridView1.DataSource = view;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            table = ds.Tables["URE"];
            view = new DataView(table, "date='" + date+"'", "", DataViewRowState.CurrentRows);
            if (view.Count > 0)
            {
                Label3.Visible = true;
                GridView2.DataSource = view;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
        }//依據時間去查詢相對應的資料

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "選取")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView1.Rows[index];
                string productName = selectedRow.Cells[1].Text;
                SqlDataAdapter da = new SqlDataAdapter("Select * from BHMT", conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "BHMT");
                DataTable table = ds.Tables["BHMT"];
                DataView view = new DataView(table, "Id=" + productName, "", DataViewRowState.CurrentRows);
                if(view.Count> 0)
                {
                    DetailsView1.Visible = true;
                    DetailsView1.DataSource= view;
                    DetailsView1.DataBind();

                }
                else
                {
                    DetailsView1.Visible = false;
                    Response.Write("<script type='text/javascript'>alert('發生錯誤')</script>");
                }
            }
        }//Detailview選取

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "選取")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView2.Rows[index];
                string productName = selectedRow.Cells[1].Text;
                SqlDataAdapter da = new SqlDataAdapter("Select * from URE", conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "URE");
                DataTable table = ds.Tables["URE"];
                DataView view = new DataView(table, "Id='" + productName + "'", "", DataViewRowState.CurrentRows);
                if (view.Count > 0)
                {
                    DetailsView1.Visible = true;
                    DetailsView1.DataSource = view; DetailsView1.DataBind();
                }
                else
                {
                    DetailsView1.Visible = false;
                    Response.Write("<script type='text/javascript'>alert('發生錯誤')</script>");
                }
            }
        }//Detailview選取

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Button1_Click(sender, e);
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }//分頁的設定

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Button1_Click(sender, e);
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataBind();
        }//分頁的設定
    }
}