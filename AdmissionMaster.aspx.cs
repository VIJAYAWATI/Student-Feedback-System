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
using System;
using System.Data.SqlClient;
using System.IO;

public partial class Admission : System.Web.UI.Page

{
    SqlConnection con = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        //txtACYR.Text = yr3 + '-' + nxtyr3;
        //Response.Write(Math.Ceiling((1 / 2.0)));
        if (Page.IsPostBack == false)
        {
            try
            {
                con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("select courseCode,courseCode+'-'+courseName as course_Code from courseMaster", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "courseMaster");
                ddlCourseCode.Items.Clear();
                ddlCourseCode.DataSource = ds;
                ddlCourseCode.DataTextField = "course_Code";
                ddlCourseCode.DataValueField = "courseCode";
                ddlCourseCode.DataBind();
                SqlDataAdapter da1 = new SqlDataAdapter("select StudentID,str(StudentID)+' '+stdName as std_Name from studentMaster where flag='False'", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "studentMaster");
                ddlstudentId.Items.Clear();
                ddlstudentId.DataSource = ds1;
                ddlstudentId.DataTextField = "std_Name";
                ddlstudentId.DataValueField = "StudentID";
                ddlstudentId.DataBind();
                SqlDataAdapter da2 = new SqlDataAdapter("select semCode from semMaster", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2, "semMaster");
                ddlCurrentSem.Items.Clear();
                ddlCurrentSem.DataSource = ds2;
                ddlCurrentSem.DataTextField = "semCode";
                ddlCurrentSem.DataValueField = "semCode";
                SqlDataAdapter da3 = new SqlDataAdapter("select distinct forAcademicYear from AcademicYearMaster", con);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3, "AcademicYearMaster");
                ddlAcademicYear.Items.Clear();
                ddlAcademicYear.DataSource = ds3;
                ddlAcademicYear.DataTextField = "forAcademicYear";
                ddlAcademicYear.DataValueField = "forAcademicYear";
                ddlAcademicYear.DataBind();
                ddlAcademicYear.DataBind();
                ddlAcademicYear.Items.Insert(0, "-Select-");
                ddlstudentId.Items.Insert(0, "-Select-");
                ddlCourseCode.Items.Insert(0, "-Select-");
                ddlCurrentSem.Items.Insert(0, "-Select-");
                con.Close();
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error " + ex.Message.ToString();
                lblmsg.ForeColor = System.Drawing.Color.Red;
                //Response.Write("<script language='javascript'>alert('Error')</script>");
            }

        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            if (ddlstudentId.Text == "-Select-" || ddlAcademicYear.Text == "-Select-" || ddlCourseCode.Text == "-Select-" || ddlCurrentSem.Text == "-Select-" || ddlStudentCollege.Text == "--choose college--")
            {
                Response.Write("<script language='javascript'>alert(' Please select Option!')</script>");
            }
            else
            {
                con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from AdmissionMaster where StudentID='" + Convert.ToInt32(ddlstudentId.Text) + "' and forAcademicYear='" + ddlAcademicYear.Text + "'", con);
                SqlDataReader dr = cmd1.ExecuteReader();

                if (dr.Read())
                {
                    //lblmsg.Text = "Student Id already Exist! ";
                    //lblmsg.ForeColor = System.Drawing.Color.Red;
                    Response.Write("<script language='javascript'>alert(' Student Id already Exist!')</script>");
                    dr.Close();
                }
                else
                {
                    dr.Close();

                    SqlCommand cmd2 = new SqlCommand("select * from AdmissionMaster where Rollno='" + txtRollNumber.Text + "' and forAcademicYear='" + ddlAcademicYear.Text + "'", con);
                    SqlDataReader dr2 = cmd2.ExecuteReader();

                    if (dr2.Read())
                    {
                        //lblmsg.Text = "Roll Number already exist in this Aacademic Year! ";
                        //lblmsg.ForeColor = System.Drawing.Color.Red;
                         Response.Write("<script language='javascript'>alert(' Roll Number already exist in this Aacademic Year !')</script>");
                        dr2.Close();
                    }
                    else
                    {
                        dr2.Close();

                        string yr = ddlAcademicYear.SelectedValue;
                        string yr1 = yr.Substring(2, 2);
                        string nxtyr = yr.Substring(5, 2);
                        string curYr = txtAdmissionDate.Text;
                        string curNxtYr = curYr.Substring(8, 2);
                        //lblmsg.Text = yr1;
                        if (yr1 == curNxtYr || nxtyr == curNxtYr)
                        {
                            //parameterized sql
                            string sql = "insert into AdmissionMaster values(@StudentID,@RollNo,@forAcademicYear,@admissionDate,@courseCode,@admissionType,@inStudyYear,@studyInCollege,@semCode,@img,@flag)";
                            SqlCommand cmd = new SqlCommand(sql, con);

                            //add parametr
                            cmd.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int));
                            cmd.Parameters.Add(new SqlParameter("@RollNo", SqlDbType.VarChar, 4));
                            cmd.Parameters.Add(new SqlParameter("@forAcademicYear", SqlDbType.VarChar, 10));
                            cmd.Parameters.Add(new SqlParameter("@admissionDate", SqlDbType.DateTime));
                            cmd.Parameters.Add(new SqlParameter("@courseCode", SqlDbType.VarChar, 10));
                            cmd.Parameters.Add(new SqlParameter("@admissionType", SqlDbType.VarChar, 20));
                            cmd.Parameters.Add(new SqlParameter("@inStudyYear", SqlDbType.Int));
                            cmd.Parameters.Add(new SqlParameter("@studyInCollege", SqlDbType.VarChar, 16));
                            cmd.Parameters.Add(new SqlParameter("@semCode", SqlDbType.VarChar, 10));
                            cmd.Parameters.Add(new SqlParameter("@img", SqlDbType.Image));
                            cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit, 0));


                            //pass alues
                            cmd.Parameters["@StudentID"].Value = ddlstudentId.SelectedItem.Value;
                            cmd.Parameters["@RollNo"].Value = txtRollNumber.Text;
                            cmd.Parameters["@forAcademicYear"].Value = ddlAcademicYear.SelectedItem.Text;
                            cmd.Parameters["@admissionDate"].Value = txtAdmissionDate.Text;
                            cmd.Parameters["@courseCode"].Value = ddlCourseCode.SelectedItem.Value;
                            cmd.Parameters["@admissionType"].Value = rblAdmisnType.Text;
                            cmd.Parameters["@inStudyYear"].Value = Convert.ToInt32(ddlStudyInYear.Text);
                            cmd.Parameters["@studyInCollege"].Value = ddlStudentCollege.SelectedItem.Text;
                            cmd.Parameters["@semCode"].Value = ddlCurrentSem.SelectedItem.Text;
                            cmd.Parameters["@img"].Value = (byte[])Session["bytes"];
                            cmd.Parameters["@flag"].Value = Convert.ToBoolean(0);
                            int cnt = cmd.ExecuteNonQuery();

                            if (cnt > 0)
                            {
                                lblmsg.Text = "Student admission successful..!";
                                lblmsg.ForeColor = System.Drawing.Color.Gold;
                                string sql1 = "update studentMaster set flag='True' where studentId="+Convert.ToInt32(ddlstudentId.Text);
                                SqlCommand cmd3 = new SqlCommand(sql1, con);
                                cmd3.ExecuteNonQuery();
                                //Response.Write("<script language='javascript'>alert(' Student admission successfully!')</script>");
                                //parameterized sql
                                
                                // string sql = "update admissionMaster  set flag='true' where studentId=@studentId";
                                // SqlCommand cmd = new SqlCommand(sql, con);
                                // con.Close();



                            }

                            else
                            {
                                lblmsg.Text = "Student admission Failed! ";
                                lblmsg.ForeColor = System.Drawing.Color.Red;
                                // Response.Write("<script language='javascript'>alert('Student admission Failed!')</script>");
                            }
                      

                        }

                        else
                        {
                            lblmsg.Text = "Invalid AcademicYear or currentDate!..";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    con.Close();
                   
                }
               
            }
           
        }

        catch (Exception ex)
        {
            lblmsg.Text = "Error " + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;

            // Response.Write("<script language='javascript'>alert('Invalid Values!!!')</script>");
        }

    }

    protected void ddlCourseCode_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select semCode from semMaster where courseCode=@courseCode", con);
            da.SelectCommand.Parameters.Add(new SqlParameter("@courseCode", SqlDbType.VarChar,10));
            da.SelectCommand.Parameters["@courseCode"].Value = ddlCourseCode.SelectedItem.Value;

            DataSet ds = new DataSet();
            da.Fill(ds, " semMaster");

            ddlCurrentSem.Items.Clear();

            ddlCurrentSem.DataSource = ds;
            ddlCurrentSem.DataTextField = "semCode";
            ddlCurrentSem.DataValueField = "semCode";
            ddlCurrentSem.DataBind();
            ddlCurrentSem.Items.Insert(0, "-Select-");
            con.Close();
        }

        catch (Exception ex)
        {
            lblmsg.Text = "Error " + ex.Message.ToString();
           // Response.Write("<script language='javascript'>alert('Error!!')</script>");
        }
 
    }
    protected void Upload(object sender, EventArgs e)
    {
        Stream fs = fileStdImage.PostedFile.InputStream;
        BinaryReader br = new BinaryReader(fs);
        byte[] bytes = br.ReadBytes((Int32)fs.Length);
        Session["bytes"] = bytes;
        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        Image1.ImageUrl = "data:image/png;base64," + base64String;

    }
    protected void ddlStudentCollege_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        txtAdmissionDate.Text = "";
        txtRollNumber.Text = "";
        txtStudId.Text = "";
        ddlCurrentSem.Text = "";
        ddlStudentCollege.Text = "";
        ddlStudyInYear.Text = "";
        ddlstudentId.Text = "";


    }
    protected void ddlstudentId_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlCurrentSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select distinct studyYear from semMaster where semCode=@semCode", con);
            da.SelectCommand.Parameters.Add(new SqlParameter("@semCode", SqlDbType.NVarChar, 50));
            da.SelectCommand.Parameters["@semCode"].Value = ddlCurrentSem.SelectedItem.Text;

            DataSet ds = new DataSet();
            da.Fill(ds, "semMaster");
            ddlStudyInYear.DataSource = ds;
            ddlStudyInYear.DataTextField = "studyYear";
            ddlStudyInYear.DataValueField = "studyYear";
            ddlStudyInYear.DataBind();
             con.Close();
        }


        catch (Exception ex)
        {
            //lblmsg2.Text = "Error " + ex.Message.ToString();
            Response.Write("<script language='javascript'>alert('Error')</script>");
        }
        
    }
    protected void ddlStudyInYear_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

