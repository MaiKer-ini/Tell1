﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace computer2011
{
    public partial class IndexPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cn=new SqlConnection("Server=0c88271c-fdd3-49c7-9b3d-a26800e5cc00.sqlserver.sequelizer.com;Database=db0c88271cfdd349c79b3da26800e5cc00;User ID=azefycnhafeeukyh;Password=aL6wpXdRyJSgqh4FJDhyfKBB6D3XiURZa6aRWgSPKD8TmYx2ge2HjSXxjBzS4nGL;");
            string loginIP = Request.UserHostAddress;

            SqlCommand cmd1 = new SqlCommand("select * from Visite_Recorder where OPIP='" + loginIP + "' and OPTime='" + System.DateTime.Today.Date.ToShortDateString() + "'", cn);
            try
            {
                cn.Open();
                if (cmd1.ExecuteScalar() == null)
                {
                    SqlCommand cmd = new SqlCommand("insert into Visite_Recorder(opip,optime)values('" + loginIP + "','" + System.DateTime.Today.Date.ToShortDateString() + "') ", cn);
                    cmd.ExecuteNonQuery();
                }

                SqlCommand cmd2 = new SqlCommand("select count(*) from Visite_Recorder ", cn);
                this.Label5.Text = "你是第" + cmd2.ExecuteScalar().ToString() + "位访问者";
            }
            catch { }
            finally
            {
                cn.Close();
            }
        }
    }
}