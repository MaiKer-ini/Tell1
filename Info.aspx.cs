using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace liuyanban
{
    public partial class Info : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(new computer2011.ConnectDatabase().conn);
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    this.Showdata();
                }
                Button2.Attributes.Add("onclick", "return confirm('你确定要删除所选择的记录么?')");
            }
        }

        private void Showdata()
        {
            DataAccess.GetData GD = new DataAccess.GetData();
            DataTable xx = GD.GetDataTable("select *  from Guest order by ID desc");
            this.GridView1.DataSource = xx;
            this.GridView1.DataBind();
        }

        protected void btn全选_Click(object sender, EventArgs e)
        {
            CheckBox chk;
            //如果全选
            if (btn全选.Text == "全选")
            {    //扫描DataView的项
                foreach (GridViewRow dgi in GridView1.Rows)
                {    //查找到模板列中的CheckBox控件
                    chk = (CheckBox)dgi.FindControl("checkBox1");
                    //选中
                    chk.Checked = true;
                }
                btn全选.Text = "全不选";
            }
            //如果全不选
            else
            {
                foreach (GridViewRow dgi in GridView1.Rows)
                {    //查找到模板列中的CheckBox控件
                    chk = (CheckBox)dgi.FindControl("checkBox1");
                    //不选
                    chk.Checked = false;
                }
                btn全选.Text = "全选";
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //SqlConnection sqlcon = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString());
            SqlCommand sqlcom;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (cbox.Checked == true)
                {
                    
                    string sqlstr = "delete from Guest where ID='" + GridView1.DataKeys[i].Value + "'";
                    sqlcom = new SqlCommand(sqlstr, cn);
                    cn.Open();
                    sqlcom.ExecuteNonQuery();
                    cn.Close();
                }
            }
            Showdata();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["ID"] = ((LinkButton)sender).CommandName;
            Response.Redirect("~/Rely.aspx");
            Response.End();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Guest.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Showdata(); //重新绑定GridView数据的函数
        }
    }
}