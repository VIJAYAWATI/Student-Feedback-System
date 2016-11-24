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

public partial class StafReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from staffMaster where flag='" + DropDownList1.SelectedItem.Text + "'",con);
            DataSet ds = new DataSet();
            da.Fill(ds, "staffMaster");


          //  GridView1.DataSource = ds;
           // GridView1.DataBind();


            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("StaffReport.rpt"));

            rd.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rd;

        }
        catch (Exception ex)
        {
        }
    }

    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
