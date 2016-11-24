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
using System.IO;

public partial class AdmissionUpdation : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (!IsPostBack)
        {
            BindEmployeeDetails();
        }
    }

    protected void BindEmployeeDetails()
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select distinct studentID from AdmissionMaster where flag='False'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SqlDataAdapter da5 = new SqlDataAdapter("select courseCode,courseCode+'-'+courseName as course_Code from courseMaster", con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5, "courseMaster");
            ddlCourseCode.Items.Clear();
            ddlCourseCode.DataSource = ds5;
            ddlCourseCode.DataTextField = "course_Code";
            ddlCourseCode.DataValueField = "courseCode";
            ddlCourseCode.DataBind();
            //SqlDataAdapter da1 = new SqlDataAdapter("select StudentID,str(StudentID)+' '+stdName as std_Name from studentMaster ", con);
            //DataSet ds1 = new DataSet();
            //da1.Fill(ds1, "studentMaster");
            //ddlstudentId.Items.Clear();

            SqlDataAdapter da2 = new SqlDataAdapter("select semCode from semMaster", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "semMaster");
            //ddlCurrentSem.Items.Clear();
            ddlCurrentSem1.DataSource = ds2;
            ddlCurrentSem1.DataTextField = "semCode";
            ddlCurrentSem1.DataValueField = "semCode";
            ddlCurrentSem1.DataBind();
            SqlDataAdapter da3 = new SqlDataAdapter("select distinct forAcademicYear from AcademicYearMaster", con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "AcademicYearMaster");
            ddlAcademicYear.Items.Clear();
            ddlAcademicYear.DataSource = ds3;
            ddlAcademicYear.DataTextField = "forAcademicYear";
            ddlAcademicYear.DataValueField = "forAcademicYear";
            ddlAcademicYear.DataBind();
            ddlAcademicYear.Items.Insert(0, "-Select-");
            ddlstudentId.Items.Insert(0, "-Select-");
            ddlCourseCode.Items.Insert(0, "-Select-");
            ddlCurrentSem1.Items.Insert(0, "-Select-");
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlstudentId.DataSource = ds;
                ddlstudentId.DataTextField = "StudentID";
                ddlstudentId.DataValueField = "StudentID";
                ddlstudentId.DataBind();
                ddlstudentId.Items.Insert(0, "-SELECT-");
                //ddlstudentId.DataSource = ds1;
                //ddlstudentId.DataTextField = "std_Name";
                //ddlstudentId.DataValueField = "StudentID";
                //ddlstudentId.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error:"+ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            // Response.Write("<script language='javascript'>alert('Error!!!')</script>");
        }
    }


    protected void ddlstudentId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select semCode from AdmissionMaster where studentId=@studentId", con);
            da.SelectCommand.Parameters.Add(new SqlParameter("@studentId", SqlDbType.Int));
            da.SelectCommand.Parameters["@studentId"].Value = ddlstudentId.SelectedItem.Value;

            DataSet ds = new DataSet();
            da.Fill(ds, " AdmissionMaster");

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
            lblmsg.ForeColor = System.Drawing.Color.Red;
            // Response.Write("<script language='javascript'>alert('Error!!')</script>");
        }
 
 
    }
    protected void Upload(object sender, EventArgs e)
    {
        Stream fs = FileUpload1.PostedFile.InputStream;
        BinaryReader br = new BinaryReader(fs);
        byte[] bytes = br.ReadBytes((Int32)fs.Length);
        Session["bytes"] = bytes;
        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        Image1.ImageUrl = "data:image/png;base64," + base64String;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            if (ddlAcademicYear.Text == "-Select-" || ddlCourseCode.Text == "-Select-" || ddlStudyInYear.Text == "-Select-" || ddlCurrentSem.Text == "-Select-"||ddlstudentId.Text=="-SELECT-")
            {
                Response.Write("<script language='javascript'>alert(' Please select Option!')</script>");
            }
            else
            {
                     string yr = ddlAcademicYear.SelectedValue;
                        string yr1 = yr.Substring(2, 2);
                        string nxtyr = yr.Substring(5, 2);
                        string curYr = txtAdmissionDate.Text;
                        string curNxtYr = curYr.Substring(8, 2);
                        //lblmsg.Text = yr1;
                        if (yr1 == curNxtYr || nxtyr == curNxtYr)
                        {

                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                            con.Open();

                            //parameterized sql
                            string sql = "update AdmissionMaster set StudentID=@StudentID,RollNo=@RollNo,forAcademicYear=@forAcademicYear,admissionDate=@admissionDate,courseCode=@courseCode,admissionType=@admissionType,inStudyYear=@inStudyYear,studyInCollege=@studyInCollege,semCode=@semCode,img=@img,flag=@flag where StudentID=@StudentID and semCode='" + ddlCurrentSem.Text + "'";
                            SqlCommand cmd = new SqlCommand(sql, con);
                            //add parametr
                            cmd.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int));
                            cmd.Parameters.Add(new SqlParameter("@RollNo", SqlDbType.VarChar, 10));
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
                            cmd.Parameters["@StudentID"].Value = ddlstudentId.SelectedItem.Text;
                            cmd.Parameters["@RollNo"].Value = Convert.ToInt32(txtRollNumber.Text);
                            cmd.Parameters["@forAcademicYear"].Value = ddlAcademicYear.SelectedItem.Text;
                            cmd.Parameters["@admissionDate"].Value = txtAdmissionDate.Text;
                            cmd.Parameters["@courseCode"].Value = ddlCourseCode.SelectedItem.Value;
                            cmd.Parameters["@admissionType"].Value = rblAdmisnType.Text;
                            cmd.Parameters["@inStudyYear"].Value = Convert.ToInt32(ddlStudyInYear.Text);
                            cmd.Parameters["@studyInCollege"].Value = ddlStudentCollege.SelectedItem.Text;
                            cmd.Parameters["@semCode"].Value = ddlCurrentSem1.SelectedItem.Text;
                            cmd.Parameters["@img"].Value = (byte[])Session["bytes"];
                            cmd.Parameters["@flag"].Value = Convert.ToBoolean(0);




                            int cnt = cmd.ExecuteNonQuery();

                            if (cnt > 0)
                            {
                                lblmsg.Text = "Student admission Updated successfully!..";
                                lblmsg.ForeColor = System.Drawing.Color.Gold;
                                BindEmployeeDetails();
                                //Response.Write("<script language='javascript'>alert(' Student admission updation successfully!')</script>");
                            }
                            else
                            {
                                lblmsg.Text = "Student admission updation Failed!..";
                                lblmsg.ForeColor = System.Drawing.Color.Red;
                                // Response.Write("<script language='javascript'>alert('Student admission updation Failed!')</script>");
                            }
                        }
                        else
                        {
                            lblmsg.Text = "Cannot updated because Invalid AcademicYear or currentDate!..";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                        }

                    }
                }

         
            
        
        catch (Exception ex)
        {
            lblmsg.Text = "Error:"+ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            // Response.Write("<script language='javascript'>alert('Error!!!')</script>");
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            //parameterized sql
            string sql = "update AdmissionMaster set flag=@flag where StudentID=@StudentID and semCode='"+ddlCurrentSem.Text+"'";
            SqlCommand cmd = new SqlCommand(sql, con);

            //add parametr

            cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit, 0));
            cmd.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int));

            //pass alues
            cmd.Parameters["@flag"].Value =Convert.ToBoolean(1);
            cmd.Parameters["@StudentID"].Value = Convert.ToInt32(ddlstudentId.Text);

            int cnt = cmd.ExecuteNonQuery();
            con.Close();
            if (cnt > 0)
            {
                BindEmployeeDetails();


                lblmsg.Text = "Student Admission removed Successfully!!..";
                lblmsg.ForeColor = System.Drawing.Color.Gold;        
                //Response.Write("<script language='javascript'>alert('Student Admission removed Successfully!!')</script>");


            }
            else
            {
                lblmsg.Text = "Student Admission Not removed !!..";
                lblmsg.ForeColor = System.Drawing.Color.Red;        
               // Response.Write("<script language='javascript'>alert('Student Admission Not Removed')</script>");
            }


        }
        catch (Exception ex)
        {
       
            lblmsg.Text = "Error:"+ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            // Response.Write("<script language='javascript'>alert('Error!!!')</script>");
        
           // Response.Write("<script language='javascript'>alert('Error')</script>");
        }
    }
    protected void ddlCourseCode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlCurrentSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from AdmissionMaster where StudentID=" + Convert.ToInt32(ddlstudentId.Text)+" and semCode='"+ddlCurrentSem.Text+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            txtRollNumber.Text = dr["RollNo"].ToString();
            txtAdmissionDate.Text = dr["admissionDate"].ToString();
            ddlStudyInYear.Text = dr["inStudyYear"].ToString();
            ddlStudentCollege.Text = dr["studyInCollege"].ToString();
            ddlCurrentSem1.Text = dr["semCode"].ToString();
            rblAdmisnType.Text = dr["admissionType"].ToString();
            ddlCourseCode.Text = dr["courseCode"].ToString();
            ddlAcademicYear.Text = dr["forAcademicYear"].ToString();
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error:" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            // Response.Write("<script language='javascript'>alert('Error!!!')</script>");
        }
    }
    protected void ddlStudyInYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlStudentCollege_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
