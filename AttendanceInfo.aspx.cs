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

public partial class AttendanceInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("select semCode from semMaster", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "semMaster");
                ddlSemCode.Items.Clear();
                ddlSemCode.DataSource = ds;
                ddlSemCode.DataTextField = "semCode";
                ddlSemCode.DataValueField = "semCode";
                ddlSemCode.DataBind();
                SqlDataAdapter da1 = new SqlDataAdapter("select StudentID from studentMaster", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "studentMaster");
                ddlstudentId.Items.Clear();
                ddlstudentId.DataSource = ds1;
                ddlstudentId.DataTextField = "StudentID";
                ddlstudentId.DataValueField = "StudentID";
                ddlstudentId.DataBind();
                ddlCourseCode.Items.Insert(0, "-Select-");
                ddlstudentId.Items.Insert(0, "-Select-");
                con.Close();
            }
            catch (Exception ex)
            {
                //lblmsg2.Text = "Error " + ex.Message.ToString();
                Response.Write("<script language='javascript'>alert('Error')</script>");
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlAcademicYear == "-Select-" || ddlSemCode == "--Select Batch Name--" || ddlSubCode == "-Select-" || ddlSubType == "-Select-" || ddlSubType.Text == "-Select-")
        {
            Response.Write("<script language='javascript'>alert(' Please select Option!')</script>");
        }
        else
        Response.Redirect("AttendanceMaster.aspx");
    }
protected void  ddlSemCode_SelectedIndexChanged(object sender, EventArgs e)
{
     try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select subNumber from R_StaffTeachesSubject where semCode=@semCode", con);
            da.SelectCommand.Parameters.Add(new SqlParameter("@semCode", SqlDbType.NVarChar, 50));
            da.SelectCommand.Parameters["@semCode"].Value = txtUserID.Text;

            DataSet ds = new DataSet();
            da.Fill(ds, " R_StaffTeachesSubject");

            ddlSubCode.Items.Clear();
            ddlSubCode.DataSource = ds;
            ddlSubCode.DataTextField = "sub";
            ddlSubCode.DataValueField = "semCode";
            ddlSubCode.DataBind();
            con.Close();
        }
        catch (Exception ex)
        {
            //lblmsg2.Text = "Error " + ex.Message.ToString();
            Response.Write("<script language='javascript'>alert('Error!!')</script>");
        }
}
protected void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
{

}
}
