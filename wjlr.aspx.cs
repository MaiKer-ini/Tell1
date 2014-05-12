﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
namespace WJDC
{
    public partial class wjlr : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(new computer2011.ConnectDatabase().conn);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Mcbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Mctxt.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Mctxt不可为空!')");
                return;
            }
            if (string.IsNullOrEmpty(snotxt.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('snotxt不可为空!')");
                return;
            }
        
            SqlCommand cmd = new SqlCommand("INSERT INTO Wj (Wjm,Sno) VALUES ('" + Mctxt.Text.Trim() + "','" + snotxt.Text.Trim() + "')", cn);
            try
            {
                    cn.Open();
                 
                    int val = cmd.ExecuteNonQuery();
                  
                    cn.Close();
                    if (val <= 0)
                        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('插入数据失败!')");
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('插入数据成功!')");
                
            }
            //捕获异常 
            catch (Exception exp)
            {
                //处理异常....... 
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('插入数据失败! 详情:" + exp.Message + "')");
               
                    
            }
        }

        protected void Tmbtn_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("select MAX(wjh) from wj", cn);
            cn.Open();
            cmd.ExecuteScalar();  
            SqlCommand com = new SqlCommand("INSERT INTO Tm(Wjh,Tm,Tixing) VALUES (" +cmd.ExecuteScalar()+ ",'" + Tmtxt.Text.Trim() + "','" + TXDropDownList.Text.Trim() + "')", cn);
            
            try
            {
                cn.Open();
                int val = cmd.ExecuteNonQuery();
                this.NRListBox.Items.Add(this.Tmtxt.Text);
                if (val <= 0)
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('插入数据失败!')");
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('插入数据成功!')");
            }
            //捕获异常 
            catch (Exception exp)
            {
                //处理异常....... 
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('插入数据失败! 详情:" + exp.Message + "')");


            }
        }
       

        protected void XXbtn_Click(object sender, EventArgs e)
        {
       
            SqlCommand cmd = new SqlCommand("select MAX(Th) from Tm", cn);
            cn.Open();
            cmd.ExecuteScalar();           
            SqlCommand com = new SqlCommand("INSERT INTO Choice(Th,choice) VALUES (" + cmd.ExecuteScalar() + ",'" + XXtxt.Text.Trim() + "')", cn);                     
            try
            {
                cn.Open();
                int val = cmd.ExecuteNonQuery();
                this.NRListBox.Items.Add(this.XXtxt.Text);              
                if (val <= 0)
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('插入数据失败!')");
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('插入数据成功!')");

            }
            //捕获异常 
            catch (Exception exp)
            {
                //处理异常....... 
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('插入数据失败! 详情:" + exp.Message + "')");


            }
        }
        protected void homeLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MCXS.aspx");
        }

        protected void delLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WJSC.aspx");
        }

        
    }
}