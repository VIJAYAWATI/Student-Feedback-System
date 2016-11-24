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
using CrystalDecisions.CrystalReports.Engine;

public partial class AdmissionReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select semCode from semMaster", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2, "semMaster");
        ddlSemCode.Items.Clear();
        ddlSemCode.DataSource = ds2;
        ddlSemCode.DataTextField = "semCode";
        ddlSemCode.DataValueField = "semCode";
        ddlSemCode.DataBind();
        ddlSemCode.Items.Insert(0, "-Select-");
       


    }
    protected void ddlSemCode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from admissionMaster where semCode='" + ddlSemCode.SelectedItem.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "admissionMaster");
            SqlDataAdapter da1 = new SqlDataAdapter("select * from admissionMaster where inStudyYear='" + Convert.ToInt32(ddlStudyInYear.SelectedItem.Text)+ "'", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "admissionMaster");


            //  GridView1.DataSource = ds;
            // GridView1.DataBind();


            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("AdmissionReport.rpt"));

            rd.SetDataSource(ds);
            rd.SetDataSource(ds1);
            CrystalReportViewer1.ReportSource = rd;

        }
        catch (Exception ex)
        {
        }
    }
}
