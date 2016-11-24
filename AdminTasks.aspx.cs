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

public partial class AdminTasks : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminId"] == null || Session["adminId"].ToString() == "")
        {
            Response.Redirect("AdminLogin.aspx");
        }
        lblwelcome.Text = "Welcome , " + Session["adminName"].ToString();

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("semesterMaster.aspx");

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("StaffMaster.aspx");

    }
   
    protected void lnkStudentMsbteMaster_Click(object sender, EventArgs e)
    {

    }
    protected void lnkStudMsbteMast_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentMSBTEMaster.aspx");
    }
    protected void lnkStaffDept_Click(object sender, EventArgs e)
    {
        Response.Redirect("StaffDepartment.aspx");
    }
    protected void lnkStaffDept0_Click(object sender, EventArgs e)
    {
        Response.Redirect("StaffDepartmentUpdation.aspx");
    }
    protected void lnkStudentMaster0_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentUpdate.aspx");
    }
    protected void lnkstudentMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentMaster.aspx");
    }
    protected void lnkAcademicYear_Click(object sender, EventArgs e)
    {
        Response.Redirect("AcademicYearMasterUpdation.aspx");
    }
    protected void lnkAcademicYearMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("AcademicYearMaster.aspx");
    }
    protected void lnkAdmissionManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdmissionUpdation.aspx");
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
      Response.Redirect("AdmissionMaster.aspx");
    }
    protected void lnkStaffManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("StaffUpdation.aspx");
    }
    protected void lnkSemManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("SemisterUpdation.aspx");
    }
    protected void lnbsubjectmngmt_Click(object sender, EventArgs e)
    {
        Response.Redirect("SubjectMaster.aspx");
    }
    protected void lnkSubjectManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("SubjectUpdation.aspx");
    }
    protected void lnkCoursemngmt_Click(object sender, EventArgs e)
    {
        Response.Redirect("courseMaster.aspx");
    }
    protected void lnkCourseManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("courseUpdation.aspx");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {

        Session.Abandon();
        Session.Clear();
        Response.Redirect("AdminLogin.aspx");
    }
    protected void LinkButton5_Click1(object sender, EventArgs e)
    {
        Response.Redirect("staffIDPassAllocation.aspx");
    }
    protected void lnkEvents_Click(object sender, EventArgs e)
    {
        Response.Redirect("Events.aspx");
    }
    protected void lnkPhotoGallery_Click(object sender, EventArgs e)
    {
        Response.Redirect("PhotoGallery.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        string sql1 = "update studentMaster set flag='False'";
        SqlCommand cmd3 = new SqlCommand(sql1, con);
        cmd3.ExecuteNonQuery();
        con.Close();
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminPassIdInfo.aspx");
    }
}
