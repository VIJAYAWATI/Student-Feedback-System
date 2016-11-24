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

public partial class AttendanceReport : System.Web.UI.Page
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

                SqlDataAdapter da = new SqlDataAdapter("select distinct semCode from R_StaffTeachesSubject order by semCode", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "R_StaffTeachesSubject");
                ddlSemCode.Items.Clear();
                ddlSemCode.DataSource = ds;
                ddlSemCode.DataTextField = "semCode";
                ddlSemCode.DataValueField = "semCode";
                ddlSemCode.DataBind();



                SqlDataAdapter da2 = new SqlDataAdapter("select distinct forAcademicYear from AcademicYearMaster", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2, "AcademicYearMaster");
                ddlAcademicYear.Items.Clear();
                ddlAcademicYear.DataSource = ds2;
                ddlAcademicYear.DataTextField = "forAcademicYear";
                ddlAcademicYear.DataValueField = "forAcademicYear";
                ddlAcademicYear.DataBind();
                ddlSemCode.Items.Insert(0, "-Select-");
                ddlBatches.Items.Insert(0, "-Select-");
                ddlAcademicYear.Items.Insert(0, "-Select-");
                con.Close();



            }
            catch (Exception ex)
            {
                //lblmsg2.Text = "Error " + ex.Message.ToString();
                Response.Write("<script language='javascript'>alert('Error!!!')</script>");
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CrystalReportViewer1.Visible = true;
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

            string sql;

            if (ddlSubNumber.SelectedItem.Text == "ALL")
                sql = "select * from attendanceMaster where forAcademicYear=@forAcademicYear and attDate>=@frDate and attDate<=@toDate and semCode=@semCode  and subType=@subType and batch=@batch";
            else
            sql = "select * from attendanceMaster where forAcademicYear=@forAcademicYear and attDate>=@frDate and attDate<=@toDate and semCode=@semCode and subNumber=@subNumber and subType=@subType and batch=@batch";
            SqlDataAdapter da = new SqlDataAdapter( sql, con);
            
            da.SelectCommand.Parameters.AddWithValue("@forAcademicYear",ddlAcademicYear.Text);
            da.SelectCommand.Parameters.AddWithValue("@frDate",txtFromDate.Text);            
            da.SelectCommand.Parameters.AddWithValue("@toDate",txtToDate.Text);
            da.SelectCommand.Parameters.AddWithValue("@semCode", ddlSemCode.Text);
            da.SelectCommand.Parameters.AddWithValue("@subNumber", ddlSubNumber.Text);
            da.SelectCommand.Parameters.AddWithValue("@subType", ddlSubType.Text);
            da.SelectCommand.Parameters.AddWithValue("@batch", ddlBatches.Text);


           
            DataSet ds = new DataSet();
            da.Fill(ds, "attendanceMaster");


            //  GridView1.DataSource = ds;
            // GridView1.DataBind();


            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("AttendanceReport.rpt"));

            rd.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rd;

        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlSemCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select distinct subNumber,str(subNumber)+'-'+subName as Sub_Number from SubjectMaster where semCode=@semCode order by subNumber", con);
            da.SelectCommand.Parameters.Add(new SqlParameter("@semCode", SqlDbType.NVarChar, 50));
            da.SelectCommand.Parameters["@semCode"].Value = ddlSemCode.SelectedItem.Text;

            DataSet ds = new DataSet();
            da.Fill(ds, "SubjectMaster");

            ddlSubNumber.Items.Clear();

            ddlSubNumber.DataSource = ds;
            ddlSubNumber.DataTextField = "Sub_Number";
            ddlSubNumber.DataValueField = "subNumber";
            ddlSubNumber.DataBind();
            ddlSubNumber.Items.Insert(0, "-Select-");
            ddlSubNumber.Items.Insert(1, "ALL");


            SqlDataAdapter da1 = new SqlDataAdapter("select distinct batchName from StudentBatches where semCode=@semCode", con);
            da1.SelectCommand.Parameters.Add(new SqlParameter("@semCode", SqlDbType.NVarChar, 50));
            da1.SelectCommand.Parameters["@semCode"].Value = ddlSemCode.SelectedItem.Text;

            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "StudentBatches");

            ddlBatches.Items.Clear();

            ddlBatches.DataSource = ds1;
            ddlBatches.DataTextField = "batchName";
            ddlBatches.DataValueField = "batchName";
            ddlBatches.DataBind();
            ddlBatches.Items.Insert(0, "--Select Batch Name--");
            con.Close();
        }


        catch (Exception ex)
        {
            //lblmsg2.Text = "Error " + ex.Message.ToString();
            Response.Write("<script language='javascript'>alert('Error')</script>");
        }
    }
    protected void ddlSubNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string sql;
            if(ddlSubNumber.SelectedItem.Text=="ALL")
                sql="select distinct subType from R_sub_subType";
            else
                sql="select distinct subType from R_sub_subType where subNumber='" + ddlSubNumber.SelectedItem.Value +"'";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            
            DataSet ds = new DataSet();
            da.Fill(ds, " R_sub_subType");

            ddlSubType.Items.Clear();
            ddlSubType.DataSource = ds;
            ddlSubType.DataTextField = "subType";
            ddlSubType.DataValueField = "subType";
            ddlSubType.DataBind();
            ddlSubType.Items.Insert(0, "-Select-");
            con.Close();
        }

        catch (Exception ex)
        {
            //lblmsg2.Text = "Error " + ex.Message.ToString();
            Response.Write("<script language='javascript'>alert('Error!!')</script>");
        }
    }
    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlSubType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlBatches.Items.Clear();
        ddlBatches.Items.Insert(0, "-Select-");
        if (ddlSubType.Text == "TH")
        {
            ddlBatches.Items.Add("ALL");
        }
        else if (ddlSubType.Text == "PR")
        {
            //database code
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("select distinct batchname from StudentBatches where batchname<>'ALL'", con);

                DataSet ds = new DataSet();
                da.Fill(ds, "StudentBatches");

                ddlBatches.Items.Clear();

                ddlBatches.DataSource = ds;
                ddlBatches.DataTextField = "batchname";
                ddlBatches.DataValueField = "batchname";
                ddlBatches.DataBind();
                ddlBatches.Items.Insert(0, "-Select-");
            }
            catch (Exception ex)
            {
                //lblmsg2.Text = "Error " + ex.Message.ToString();
                Response.Write("<script language='javascript'>alert('Error')</script>");
            }
        }
    }
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
    protected void ddlRollNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();


            string sql;

            if(ddlSubNumber.SelectedItem.Text=="ALL")
            sql= "select * from attendanceMaster where forAcademicYear=@forAcademicYear and attDate>=@frDate and attDate<=@toDate and semCode=@semCode  and subType=@subType and batch=@batch";
            else
            sql= "select * from attendanceMaster where forAcademicYear=@forAcademicYear and attDate>=@frDate and attDate<=@toDate and semCode=@semCode and subNumber=@subNumber and subType=@subType and batch=@batch";
            
            SqlCommand da = new SqlCommand(sql, con);

            da.Parameters.AddWithValue("@forAcademicYear", ddlAcademicYear.Text);
            da.Parameters.AddWithValue("@frDate", txtFromDate.Text);
            da.Parameters.AddWithValue("@toDate", txtToDate.Text);
            da.Parameters.AddWithValue("@semCode", ddlSemCode.Text);
            da.Parameters.AddWithValue("@subNumber", ddlSubNumber.Text);
            da.Parameters.AddWithValue("@subType", ddlSubType.Text);
            da.Parameters.AddWithValue("@batch", ddlBatches.Text);

            SqlDataReader dr = da.ExecuteReader();
            string[] Num=new string[255];
            string[] Num1 = new string[255];
            string str;
           
            int j=0,m=0,tot=0;
            while (dr.Read())
            {
                tot++;
                Num = dr["PBrollNumbers"].ToString().Split(',');
                for (int k = 0; k < Num.Length; k++)
                {
                    Num1[m] = Num[k];
                    m++;
                }
            }

            dr.Close();

            int p = 0;

            for (int i = 0; i < m; i++)
            {
                if (ddlRollNo.Text == Num1[i])
                {
                   p++;
                   // Label12.Text += Num1[i].ToString();
                }
            }
            int per = p * 100 / tot;

            lblres.Text = "Total Attendance="+ per.ToString() + "%";
            CrystalReportViewer1.Visible = false;


        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlBatches_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();


            SqlCommand cmd = new SqlCommand("select * from StudentBatches where batchName=@batchName", con);
            cmd.Parameters.Add(new SqlParameter("@batchName", SqlDbType.NVarChar, 50));
            cmd.Parameters["@batchName"].Value = ddlBatches.SelectedItem.Text;

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            int startRoll = Convert.ToInt32(dr["startingRoll"].ToString());
            int endRoll = Convert.ToInt32(dr["endingRoll"].ToString());


            ddlRollNo.Items.Clear();
            ddlRollNo.Items.Insert(0, "-SELECT-");
            for (int i = startRoll; i <= endRoll; i++)
            {
                ddlRollNo.Items.Add(i.ToString());
            }

            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            //lblmsg2.Text = "Error " + ex.Message.ToString();
            Response.Write("<script language='javascript'>alert('Error!!')</script>");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

            string sql = "select * from attendanceMaster where forAcademicYear=@forAcademicYear and attDate>=@frDate and attDate<=@toDate and semCode=@semCode and subNumber=@subNumber and subType=@subType and batch=@batch";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            da.SelectCommand.Parameters.AddWithValue("@forAcademicYear", ddlAcademicYear.Text);
            da.SelectCommand.Parameters.AddWithValue("@frDate", txtFromDate.Text);
            da.SelectCommand.Parameters.AddWithValue("@toDate", txtToDate.Text);
            da.SelectCommand.Parameters.AddWithValue("@semCode", ddlSemCode.Text);
            da.SelectCommand.Parameters.AddWithValue("@subNumber", ddlSubNumber.Text);
            da.SelectCommand.Parameters.AddWithValue("@subType", ddlSubType.Text);
            da.SelectCommand.Parameters.AddWithValue("@batch", ddlBatches.Text);



            DataSet ds = new DataSet();
            da.Fill(ds, "attendanceMaster");


            //  GridView1.DataSource = ds;
            // GridView1.DataBind();


            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("AttendanceReport.rpt"));

            rd.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rd;

        }
        catch (Exception ex)
        {
        }
    }
}
