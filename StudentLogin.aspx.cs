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

public partial class StudentLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string un = txtEnrollmentNumber.Text;
            string ps = txtMothersName.Text;
            string db = txtdob.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

            string sql = "select * from studentMaster where MSBTEEnrollmentNo='" + un + "' and motherName='" + ps + "' and stdDOB='" + db + "'";
            SqlCommand cmd = new SqlCommand(sql, con);


            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Session["StudentId"] = dr["StudentId"];
                Session["stdName"] = dr["stdName"];
                Response.Redirect("FeedbackMaster.aspx");
            }

            // Response.Redirect("AttendanceInfo.aspx");

            else
            {
                Response.Write("<script language='javascript'>alert('Login Fail')</script>");
            }
            // Response.Redirect("AttendanceInfo.aspx");

            dr.Close();
            con.Close();
            //Response.Redirect("FeedbackInfo.aspx");
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error:" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }

    }
}
