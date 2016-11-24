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

public partial class CourseMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();
           
                //parameterized sql
                string sql = "insert into courseMaster values(@courseCode,@courseName,@estabYear,@flag)";
                SqlCommand cmd = new SqlCommand(sql, con);

                //add parametr
                cmd.Parameters.Add(new SqlParameter("@courseCode", SqlDbType.VarChar,20));
                cmd.Parameters.Add(new SqlParameter("@courseName", SqlDbType.VarChar,20));
                cmd.Parameters.Add(new SqlParameter("@estabYear", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit,0));


                //pass alues
                cmd.Parameters["@courseCode"].Value = txtCourseCode.Text;
                cmd.Parameters["@courseName"].Value = txtCourseName.Text;
                cmd.Parameters["@estabYear"].Value = Convert.ToInt32(txtEstablishedYear.Text);
                cmd.Parameters["@flag"].Value =Convert.ToBoolean(0);

                int cnt = cmd.ExecuteNonQuery();

                if (cnt > 0)
                {
                    lblmsg.Text = "Course added Successfully!..";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    //Response.Write("<script language='javascript'>alert('Course Added Successfully!!!')</script>");


                }
                else
                {
                    lblmsg.Text = "Course not added..";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    //Response.Write("<script language='javascript'>alert('Course Not Added')</script>");
                }

                con.Close();
            }
        
        catch (Exception ex)
        {
            lblmsg.Text = "Error:- " + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            // Response.Write("<script language='javascript'>alert("Error: " + ex.Message.ToString();)</script>");
        }
    

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        txtCourseCode.Text = "";
        txtCourseName.Text = "";
        txtEstablishedYear.Text = "";
    }
}
