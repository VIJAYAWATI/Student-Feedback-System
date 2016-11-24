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

public partial class Updation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("home.aspx");
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {

    }
    protected void lnkAdmissionManagement_Click(object sender, EventArgs e)
    {

    }
    protected void lnkSubjectManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("SubjectUpdation.aspx");

    }
    protected void lnkCourseManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("CourseUpdation.aspx");

    }
}
