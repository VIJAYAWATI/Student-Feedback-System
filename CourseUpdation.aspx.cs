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

public partial class CourseUpdation : System.Web.UI.Page
{
   SqlConnection con = new SqlConnection("Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
        if (!IsPostBack)
        {
            BindEmployeeDetails();
        }

     
    }

    protected void BindEmployeeDetails()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from courseMaster where flag='False'", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
       
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCourseCode.DataSource = ds;
            ddlCourseCode.DataTextField = "courseCode";
            ddlCourseCode.DataValueField = "courseCode";
            ddlCourseCode.DataBind();
            ddlCourseCode.Items.Insert(0, "-Select-");
        }

   
        SqlDataAdapter da1 = new SqlDataAdapter("select courseCode from courseMaster", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1, "courseMaster");
        ddlCourseCode.Items.Clear();
        ddlCourseCode.DataSource = ds1;
        ddlCourseCode.DataTextField = "courseCode";
        ddlCourseCode.DataValueField = "courseCode";
        ddlCourseCode.DataBind();
        ddlCourseCode.Items.Insert(0, "-Select-");
        con.Close();

          
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCourseCode.Text == "-Select-")
            {
                Response.Write("<script language='javascript'>alert(' Please select Option!')</script>");
            }
            else
            {

                con.Open();

                //parameterized sql
                string sql = "update courseMaster set courseCode=@courseCode,courseName=@courseName,estabYear=@estabYear,flag=@flag where courseCode=@courseCode1";
                SqlCommand cmd = new SqlCommand(sql, con);


                //add parameter
                cmd.Parameters.Add(new SqlParameter("@courseCode1", SqlDbType.VarChar, 20));
                cmd.Parameters.Add(new SqlParameter("@courseCode", SqlDbType.VarChar, 20));
                cmd.Parameters.Add(new SqlParameter("@courseName", SqlDbType.VarChar, 20));
                cmd.Parameters.Add(new SqlParameter("@estabYear", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit,0));



                //pass values
                cmd.Parameters["@courseCode1"].Value = ddlCourseCode.Text;
                cmd.Parameters["@courseCode"].Value = txtCourseCode.Text;
                cmd.Parameters["@courseName"].Value = txtCourseName.Text;
                cmd.Parameters["@estabYear"].Value = Convert.ToInt32(txtEstablishedYear.Text);
                cmd.Parameters["@flag"].Value = Convert.ToBoolean(0);


                int cnt = cmd.ExecuteNonQuery();
                con.Close();
                if (cnt > 0)
                {
                    BindEmployeeDetails();
                    lblmsg.Text = "Course Updated Successfully!..";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    //Response.Write("<script language='javascript'>alert('Course Updated Successfully!!')</script>");


                }
                else
                {
                    lblmsg.Text = "Course not Updated..";
                    lblmsg.ForeColor = System.Drawing.Color.Red; ;
                    //Response.Write("<script language='javascript'>alert('Course Not Updated')</script>");
                }

            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error:"+ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            //Response.Write("<script language='javascript'>alert('Error')</script>");
        }

    }
protected void  txtCourseCode_TextChanged(object sender, EventArgs e)
{
   
}
protected void Button2_Click(object sender, EventArgs e)
{
    try
    {
        con.Open();
        //parameterized sql
        string sql = "update courseMaster set flag=@flag where courseCode=@courseCode";
        SqlCommand cmd = new SqlCommand(sql, con);

        //add parametr

        cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit,0));
        cmd.Parameters.Add(new SqlParameter("@courseCode", SqlDbType.VarChar,20));

        //pass alues
        cmd.Parameters["@flag"].Value =Convert.ToBoolean(1);
        cmd.Parameters["@courseCode"].Value = ddlCourseCode.Text;

        int cnt = cmd.ExecuteNonQuery();
        con.Close();
        if (cnt > 0)
        {
            BindEmployeeDetails();
            lblmsg.Text = "Course Deleted Successfully!..";
            lblmsg.ForeColor = System.Drawing.Color.Green;
           // Response.Write("<script language='javascript'>alert('Course Deleted Successfully!!')</script>");


        }
        else
        {
            lblmsg.Text = "Course Not Deleted.";
            lblmsg.ForeColor = System.Drawing.Color.Red;
           // Response.Write("<script language='javascript'>alert('Course Not Deleted')</script>");
        }


    }
    catch (Exception ex)
    {
        lblmsg.Text = "Error:"+ex.Message.ToString();
        lblmsg.ForeColor = System.Drawing.Color.Red; 
        //Response.Write("<script language='javascript'>alert('Error')</script>");
    }


}
protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
{
    con.Open();
    SqlCommand cmd = new SqlCommand("Select * from courseMaster where courseCode='" + ddlCourseCode.SelectedItem.Text+"'", con);
    SqlDataReader dr = cmd.ExecuteReader();

    dr.Read();
    txtCourseCode.Text = dr["courseCode"].ToString();
    txtCourseName.Text = dr["courseName"].ToString();
    txtEstablishedYear.Text = dr["estabYear"].ToString();

    dr.Close();
    con.Close();
}
}
