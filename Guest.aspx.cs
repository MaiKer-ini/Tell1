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
    public partial class Guest : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(new computer2011.ConnectDatabase().conn);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.btnINSER();
        }

        private void btnINSER()
        {
            if (string.IsNullOrEmpty(Contents.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>window.alert('请输入留言内容!')</script>");
                return;
            }
            //连接数据库字符串 
            //string dbConnString = System.Configuration.ConfigurationManager.AppSettings["Cng"].ToStringonnectionStri();
            string sql = " INSERT INTO Guest (Contents) VALUES ('" + Contents.Text.Trim() + "')";
            try
            {
                //using 是系统关键字, 作用是自动释放资源。
                using (cn)
                {
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    //打开数据库连接 
                    cn.Open();
                    //对数据进行插入操作, 返回影响行数 
                    int val = cmd.ExecuteNonQuery();
                    //关闭数据库连接;
                    cn.Close();
                    if (val <= 0)
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>window.alert('对不起，留言失败!')</script>");
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>window.alert('恭喜，留言成功!')</script>");
                }
            }
            //捕获异常 
            catch (Exception exp)
            {
                //处理异常....... 
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>window.alert('留言失败！详情：" + exp.Message + "')</script>");
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Info.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
