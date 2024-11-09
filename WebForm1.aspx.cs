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
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection conn =new SqlConnection( "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\張銘傑\\source\\repos\\Demo3-1\\Demo3-1\\App_Data\\Database1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<title>醫療檢查系統 - 基本資料新增</title>");
            GridView1.DataSource = "";
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Patient]", conn);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();

            da.Fill(ds, "Patient");
            DataTable table = ds.Tables["Patient"];

            DataRow dataRow = table.NewRow();

            dataRow["Id"] = Id.Text;
            dataRow["Name"] = Name.Text;
            dataRow["blood_type"] = blood_type.SelectedItem.Text;
            dataRow["Birth"] = Birth.Text;
            dataRow["Phone"]=Phone.Text;
            dataRow["gender"]=gender.SelectedItem.Text;
            dataRow["備註"]=Illnes.Text;
            table.Rows.Add(dataRow);
            da.Update(table);
            DataView view= new DataView(table, "Id='" + Id.Text+"'","", DataViewRowState.CurrentRows);
            if(view.Count> 0)
            {
                GridView1.DataSource= view;
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('新增失敗')</script>");
            }
        }
    }
}