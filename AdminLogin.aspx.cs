using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class AdminLogin : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter da;
    SqlCommand cmd;
    SqlCommand cmd1;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string un = txtAdminID.Text;
            string ps = txtPassword.Text;

            //if (un == "admin" && ps == "password")
            //{
            //    Session["adminid"] = "admin";
            //    Response.Redirect("AdminTasks.aspx");
            //}
            //else
            //{
            //    Response.Write("<script language='javascript'>alert('Invalid username or password!')</script>");
            //}

            con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

            cmd = new SqlCommand("select * from adminLogin where adminId=@adminId and password=@password", con);
            cmd.Parameters.Add(new SqlParameter("@adminId", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 20));
            //cmd.Parameters.Add(new SqlParameter("@stdDOB", SqlDbType.DateTime));

            cmd.Parameters["@adminId"].Value = txtAdminID.Text;
            cmd.Parameters["@password"].Value = txtPassword.Text;
            // cmd.Parameters["@stdDOB"].Value = txtdob.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                Session["adminName"] = dr["adminName"];
                Session["adminId"] = dr["adminId"];
                Session["password"] = dr["password"];

                Response.Redirect("AdminTasks.aspx");
            }

            else
            {
                Response.Write("<script language='javascript'>alert('Login Fail')</script>");
            }

            dr.Close();
            con.Close();

        }
        catch (Exception ex)
        {
            lblmsg.Text = "error" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }
        //SqlDataReader readerStaffTeachesSubject = (SqlDataReader)Session["R_StaffTeachesSubject"] ;

        //Response.Redirect("FeedbackInfo.aspx");

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}
    