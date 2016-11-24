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

public partial class FeedbackMaster : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["StudentID"] == null || Session["StudentID"].ToString() == "")
        {
            Response.Redirect("StudentLogin.aspx");
        }
        String StudentID = Session["StudentID"].ToString();
        lblWelCome.Text = "Welcome , " + Session["stdName"].ToString();
        //int str = DateTime.Now.Year;
        //int st = str + 1;
        //string str1 = st.ToString();
        //string str2 = str1.Substring(2, 2);
        //txtAcademicYear.Text = str + "-" + Convert.ToInt32(str2) ;
        Button1.Visible = false;
        if (Session["StudentId"] == null)
        {
            Response.Redirect("StudentLogin.aspx");
        }
        //lbltest.Text = Session["RollNo"].ToString();

        if (Page.IsPostBack == false)
        {
            String StudentId = Session["StudentId"].ToString();

          
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("select semCode from AdmissionMaster where  StudentId='" + Session["StudentId"].ToString() + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "AdmissionMaster");
                ddlSemCode.DataSource = ds;
                ddlSemCode.DataTextField = "semCode";
                ddlSemCode.DataValueField = "semCode";
                ddlSemCode.DataBind();
                ddlSemCode.Items.Insert(0, "--SELECT--");


                SqlDataAdapter da1 = new SqlDataAdapter("select distinct forAcademicYear from admissionMaster where studentId='" + Session["StudentId"].ToString() + "'", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "admissionMaster");
                ddlAcademicYear.DataSource = ds1;
                ddlAcademicYear.DataTextField = "forAcademicYear";
                ddlAcademicYear.DataValueField = "forAcademicYear";
                ddlAcademicYear.DataBind();
                ddlAcademicYear.Items.Insert(0, "--SELECT--");

            }
        }
    

    protected void BindEmployeeDetails()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from feedBackQuest order by questionNo", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
       
        gvDetails.DataSource = ds;
        gvDetails.DataBind();         
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int sum = 0;
        TextBox1.Text = "0";



        //attedance percentage for session studentid

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
        con.Open();


        string sql1 = "select * from AdmissionMaster where forAcademicYear='" + ddlAcademicYear.Text + "' and studentId='" + Session["StudentId"].ToString() + "'and semCode='"+ddlSemCode.Text+"'";
        SqlCommand cmd1 = new SqlCommand(sql1, con);

        SqlDataReader dr1 = cmd1.ExecuteReader();

        if (dr1.Read())
        {
            Session["RollNo"] = dr1["RollNO"];
        }

        dr1.Close();
        // lbltest.Text = Session["RollNo"].ToString();

        string sql2;
        string stId = Session["StudentId"].ToString();

        sql2 = "select * from attendancePer where forAcademicYear=@forAcademicYear and studentId='" + Session["StudentId"].ToString() + "'and subNumber='" + ddlSubCode.Text + "'and subType='TH'";

        SqlCommand da2 = new SqlCommand(sql2, con);

        da2.Parameters.AddWithValue("@studentId", Session["StudentId"].ToString());
        da2.Parameters.AddWithValue("@forAcademicYear", ddlAcademicYear.Text);
        // da1.Parameters.AddWithValue("@RollNo", Session["RollNo"].ToString());
        SqlDataReader dr2 = da2.ExecuteReader();
        string[] Num = new string[255];
        string[] Num1 = new string[255];

        int j = 0, m = 0, tot = 0;
        while (dr2.Read())
        {
            tot++;
            Num = dr2["PBrollNumbers"].ToString().Split(',');
            for (int k = 0; k < Num.Length; k++)
            {
                Num1[m] = Num[k];
                m++;
            }
        }


        int p = 0;

        for (int v = 0; v < m; v++)
        {
            if (Session["RollNo"].ToString() == Num1[v])
            {
                p++;
                // Label12.Text += Num1[i].ToString();
            }
        }
        int per = p * 100 / tot;

        lbltest.Text = "Your Attendance for this subject=" + per.ToString() + "%";
        Session["presenty"] = lbltest.Text;
        //if per<55 and str=5  then str=4
        //lbltest.Text = Session["RollNo"].ToString();
        dr2.Close();


        for (int i = 0; i < gvDetails.Rows.Count; i++)
        {

            DropDownList ddlrateting = (DropDownList)gvDetails.Rows[i].FindControl("DropDownList1");
            Label lblqueno = (Label)gvDetails.Rows[i].FindControl("lblqueno");
            string str = ddlrateting.Text;
            TextBox1.Text = (Convert.ToInt32(TextBox1.Text) + Convert.ToInt32(str)).ToString();

            string StudentId = Session["StudentId"].ToString();

            try
            {
               
                
                //parameterized sql
                string sql = "insert into feedCollection(StudentId,semCode,subNumber,forAcademicYear,feedBackDate,questionNo,marksGiven) values(@StudentId,@semCode,@subNumber,@forAcademicYear,@feedBackDate,@questionNo,@marksGiven)";
                SqlCommand cmd = new SqlCommand(sql, con);

                //add parametr

                cmd.Parameters.Add(new SqlParameter("@StudentId", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@semCode", SqlDbType.NVarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@subNumber", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@forAcademicYear", SqlDbType.VarChar, 10));
                cmd.Parameters.Add(new SqlParameter("@feedBackDate", SqlDbType.DateTime));
                cmd.Parameters.Add(new SqlParameter("@questionNo", SqlDbType.Int));


                cmd.Parameters.Add(new SqlParameter("@marksGiven", SqlDbType.Float));


                //pass alues
                cmd.Parameters["@StudentId"].Value = Session["StudentId"].ToString();
                cmd.Parameters["@semCode"].Value = ddlSemCode.SelectedItem.Text;
                cmd.Parameters["@subNumber"].Value = Convert.ToInt32(ddlSubCode.SelectedItem.Value);
                cmd.Parameters["@forAcademicYear"].Value = ddlAcademicYear.Text;
                cmd.Parameters["@feedBackDate"].Value = System.DateTime.Now;
                cmd.Parameters["@questionNo"].Value = Convert.ToInt32(lblqueno.Text);


                float mark=Convert.ToSingle(str);
                if (per<40)
                {

                    if(mark==1)
                        cmd.Parameters["@marksGiven"].Value ="2.5";
                    else if(mark==2)
                        cmd.Parameters["@marksGiven"].Value = "2.75";
                    else if (mark == 3)
                        cmd.Parameters["@marksGiven"].Value = "3.0";
                    else if (mark == 4)
                        cmd.Parameters["@marksGiven"].Value = "3.25";
                    else if (mark == 5)
                        cmd.Parameters["@marksGiven"].Value = "3.5";
                }

                else if (per > 40 && per<=60)
                {

                    if (mark == 1)
                        cmd.Parameters["@marksGiven"].Value = "2.75";
                    else if (mark == 2)
                        cmd.Parameters["@marksGiven"].Value = "3.0";
                    else if (mark == 3)
                        cmd.Parameters["@marksGiven"].Value = "3.0";
                    else if (mark == 4)
                        cmd.Parameters["@marksGiven"].Value = "4.0";
                    else if (mark == 5)
                        cmd.Parameters["@marksGiven"].Value = "4.5";
                }

                else if (per > 60 && per <= 85)
                {

                    if (mark == 1)
                        cmd.Parameters["@marksGiven"].Value = "1.5";
                    else if (mark == 2)
                        cmd.Parameters["@marksGiven"].Value = "2.0";
                    else if (mark == 3)
                        cmd.Parameters["@marksGiven"].Value = "3.0";
                    else if (mark == 4)
                        cmd.Parameters["@marksGiven"].Value = "4.0";
                    else if (mark == 5)
                        cmd.Parameters["@marksGiven"].Value = "5.0";
                }
                else
                {
                    cmd.Parameters["@marksGiven"].Value =mark;

                }
                
                Session["score"] = TextBox1.Text;
                int cnt = cmd.ExecuteNonQuery();
               

                
               

            }
            catch (Exception ex)
            {
            
            }
        }
       Response.Redirect("FeedStatus.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        
        try
        {
            if (ddlSubCode.Text == "--SELECT--" || ddlSemCode.Text == "--SELECT--" )
            {
                Response.Write("<script language='javascript'>alert(' Please select Option!')</script>");
            }
            else
            {
                Button1.Visible = true;

                //verify student already given fee

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from feedCollection where StudentId= '" + Session["StudentId"].ToString() + "'and subNumber='" + ddlSubCode.SelectedItem.Value +"'", con);
                SqlDataReader dr = cmd1.ExecuteReader();

                if (dr.Read())
                {
                    Response.Write("<script language='javascript'>alert(' Student already Feedback Given!')</script>");
                    dr.Close();
                }
                else
                {
                    dr.Close();


                    BindEmployeeDetails();
                }
            }
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

            SqlDataAdapter da = new SqlDataAdapter("select subNumber,str(subNumber)+'-'+subName as Sub_Code from SubjectMaster where semcode='" + ddlSemCode.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "SubjectMaster");
            ddlSubCode.DataSource = ds;
            ddlSubCode.DataTextField = "Sub_Code";
            ddlSubCode.DataValueField = "subNumber";

            ddlSubCode.DataBind();
            ddlSubCode.Items.Insert(0, "--SELECT--");
            con.Close();

        }
        catch (Exception ex)
        {
        }
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtAcademicYear_TextChanged(object sender, EventArgs e)
    {

    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        Session.Abandon();
        Session.Clear();
        Response.Redirect("studentLogin.aspx");
    }
   
}
