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

public partial class FeedbackReport : System.Web.UI.Page
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

                SqlDataAdapter da = new SqlDataAdapter("select distinct semCode from semMaster order by semCode", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "semMaster");
                ddlSem.Items.Clear();
                ddlSem.DataSource = ds;
                ddlSem.DataTextField = "semCode";
                ddlSem.DataValueField = "semCode";
                ddlSem.DataBind();
                SqlDataAdapter da1 = new SqlDataAdapter("select distinct subNumber,str(subNumber)+'-'+subName as Sub_Code from subjectMaster order by subNumber", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "subjectMaster");
                ddlSub.Items.Clear();
                ddlSub.DataSource = ds1;
                ddlSub.DataTextField = "Sub_Code";
                ddlSub.DataValueField = "subNumber";
                ddlSub.DataBind();


                SqlDataAdapter da2 = new SqlDataAdapter("select distinct forAcademicYear from AcademicYearMaster", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2, "AcademicYearMaster");
                ddlACYR.Items.Clear();
                ddlACYR.DataSource = ds2;
                ddlACYR.DataTextField = "forAcademicYear";
                ddlACYR.DataValueField = "forAcademicYear";
                ddlACYR.DataBind();
                ddlACYR.Items.Insert(0, "-Select-");
                ddlSub.Items.Insert(0, "-Select-");
                ddlSem.Items.Insert(0, "-Select-");
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
        string cs = @"Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
        try
        {

            SqlConnection con = new SqlConnection(cs);
            con.Open();



            //



            string sql = "select subNumber,semCode,forAcademicYear,[5.0] as '#Time 5',[4.75] as '#Time 4.75',[4.5] as '#Time 4.5',[4.25] as '#Time 4.25',[4.0] as '#Time 4.0',[3.75] as '#Time 3.75',[3.5] as '#Time 3.5',[3.25] as '#Time 3.25',[3.0] as '#Time 3.0',[2.75] as '#Time 2.75',[2.5] as '#Time 2.5',[2.25] as '#Time 2.25',[2.0] as '#Time 2.0',[1.75] as '#Time 1.75',[1.5] as '#Time 1.5',[1.25] as '#Time 1.25',[1.0] as '#Time 1.0' from   (select subNumber,semCode,forAcademicYear,marksGiven from feedCollection where forAcademicYear='" + ddlACYR.Text + "'and semCode='" + ddlSem.SelectedItem.Text + "' ) ps PIVOT ( count(marksGiven) for marksGiven in([5.0],[4.75],[4.5],[4.25],[4.0],[3.75],[3.5],[3.25],[3.0],[2.75],[2.5],[2.25],[2.0],[1.75],[1.5],[1.25],[1.0]) ) as pvt ";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable("feedCollection");

            da.Fill(dt);
            dt.Columns.Add("Out Of");
            dt.Columns.Add("Signature of Staff");
            dt.Columns.Add("Feedback From HOD");


            float a1=0.0f,a2=0.0f,a3=0.0f,a4=0.0f,a5=0.0f,a6=0.0f,a7=0.0f,a8=0.0f,a9=0.0f,a10=0.0f,a11=0.0f,a12=0.0f,a13=0.0f,a14=0.0f,a15=0.0f,a16=0.0f,a17=0.0f;
            foreach (DataRow dr in dt.Rows)
            {
                // Response.Write(dr[2].ToString());
                if (dr[3].ToString() == "0")
                    a1 = 0.0f;
                else
                    a1 = Convert.ToSingle(dr[3]);

                if (dr[4].ToString() == "0")
                    a2 = 0.0f;
                else
                    a2 = Convert.ToSingle(dr[4]);

                if (dr[5].ToString() == "0")
                    a3 = 0.0f;
                else
                    a3 = Convert.ToSingle(dr[5]);

                if (dr[6].ToString() == "0")
                    a4 = 0.0f;
                else
                    a4 = Convert.ToSingle(dr[6]);

                if (dr[7].ToString() == "0")
                    a5 = 0.0f;
                else
                    a5 = Convert.ToSingle(dr[7]);

                if (dr[8].ToString() == "0")
                    a6 = 0.0f;
                else
                    a6 = Convert.ToSingle(dr[8]);

                if (dr[9].ToString() == "0")
                    a7 = 0.0f;
                else
                    a7 = Convert.ToSingle(dr[9]);

                if (dr[10].ToString() == "0")
                    a8 = 0.0f;
                else
                    a8 = Convert.ToSingle(dr[10]);

                if (dr[11].ToString() == "0")
                    a9 = 0.0f;
                else
                    a9 = Convert.ToSingle(dr[11]);

                if (dr[12].ToString() == "0")
                    a10 = 0.0f;
                else
                    a10 = Convert.ToSingle(dr[12]);

                if (dr[13].ToString() == "0")
                    a11 = 0.0f;
                else
                    a11 = Convert.ToSingle(dr[13]);

                if (dr[14].ToString() == "0")
                    a12 = 0.0f;
                else
                    a12 = Convert.ToSingle(dr[14]);

                if (dr[15].ToString() == "0")
                    a13 = 0.0f;
                else
                    a13 = Convert.ToSingle(dr[15]);
                
                if (dr[16].ToString() == "0")
                    a14 = 0.0f;
                else
                    a14 = Convert.ToSingle(dr[16]);

                if (dr[17].ToString() == "0")
                    a15 = 0.0f;
                else
                    a15 = Convert.ToSingle(dr[17]);

                if (dr[18].ToString() == "0")
                    a16 = 0.0f;
                else
                    a16 = Convert.ToSingle(dr[18]);

                
                if (dr[19].ToString() == "0")
                    a17 = 0.0f;
                else
                    a17 = Convert.ToSingle(dr[19]);

                    
                float sc = Convert.ToSingle((a1 * 5.0) + (a2 * 4.75) + (a3 * 4.5) + (a4 * 4.25) + (a5 * 4.0) + (a6 * 3.75) + (a7 * 3.5) + (a8* 3.25) + (a9 * 3.0) + (a10 * 2.75) + (a11 * 2.5) + (a12 * 2.25) + (a13 * 2.0) + (a14 * 1.75) + (a15 * 1.5) + (a16 * 1.25) + (a17 * 1.0));
                dr[20] = sc.ToString();
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            //For Total Student

            sql = "select studentId from feedCollection where forAcademicYear='" + ddlACYR.Text + "' group by studentId ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr1 = cmd.ExecuteReader();

            int tot = 0;
            while (dr1.Read())
            {
                tot++;
            }
            Label1.Text = "Total Student=" + tot.ToString();

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }

    }
}
