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

public partial class AttendanceUpdation : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (Session["staffId"] == null)
        {
            Response.Redirect("staffLogin.aspx");
        }

        if (!IsPostBack)
        {
            BindEmployeeDetails();
        }
    
    }
    protected void BindEmployeeDetails()
    {
        con.Open();
        SqlCommand cmd3 = new SqlCommand("Select distinct attDate from attDateStaffId where flag='False' and staffId='" + Session["staffId"].ToString() + "'", con);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        if (ds3.Tables[0].Rows.Count > 0)
        {
            ddlAttendanceDate.DataSource = ds3;
            ddlAttendanceDate.DataTextField = "attDate";
            ddlAttendanceDate.DataValueField = "attDate";
            ddlAttendanceDate.DataBind();
            ddlSemCode.Items.Insert(0, "-Select-");
            ddlBatch.Items.Insert(0, "-Select-");
            ddlAttendanceDate.Items.Insert(0, "-Select-");
            
        }

       
        if (Page.IsPostBack == false)
        {
            String StaffId = Session["staffId"].ToString();
            String pass = Session["password"].ToString();
            try
            {
               

                SqlDataAdapter da = new SqlDataAdapter("select distinct semCode from R_StaffTeachesSubject where staffId='" + Session["staffId"].ToString() + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "R_StaffTeachesSubject");
                ddlSemCode.Items.Clear();
                ddlSemCode.DataSource = ds;
                ddlSemCode.DataTextField = "semCode";
                ddlSemCode.DataValueField = "semCode";
                ddlSemCode.DataBind();


                SqlDataAdapter da2 = new SqlDataAdapter("SELECT distinct forAcademicYear FROM  R_StaffTeachesSubject where staffId='" + Session["staffId"].ToString() + "' ", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2, "R_StaffTeachesSubject");
                ddlAcademicYear.Items.Clear();
                ddlAcademicYear.DataSource = ds2;
                ddlAcademicYear.DataTextField = "forAcademicYear";
                ddlAcademicYear.DataValueField = "forAcademicYear";
                ddlAcademicYear.DataBind();
                SqlDataAdapter da4 = new SqlDataAdapter("SELECT distinct subNumber FROM  R_StaffTeachesSubject where staffId='" + Session["staffId"].ToString() + "' ", con);
                DataSet ds4= new DataSet();
                da4.Fill(ds4, "R_StaffTeachesSubject");
                ddlSubCode.Items.Clear();
                ddlSubCode.DataSource = ds4;
                ddlSubCode.DataTextField = "subNumber";
                ddlSubCode.DataValueField = "subNumber";
                ddlSubCode.DataBind();
                ddlSubCode.Items.Insert(0, "-Select-");
                SqlDataAdapter da5 = new SqlDataAdapter("SELECT distinct subNumber FROM  R_StaffTeachesSubject where staffId='" + Session["staffId"].ToString() + "' ", con);
                DataSet ds5 = new DataSet();
                da4.Fill(ds5, "R_StaffTeachesSubject");
                ddlSubCode1.Items.Clear();
                ddlSubCode1.DataSource = ds5;
                ddlSubCode1.DataTextField = "subNumber";
                ddlSubCode1.DataValueField = "subNumber";
                ddlSubCode1.DataBind();

                ddlSemCode.Items.Insert(0, "-Select-");
                ddlBatch.Items.Insert(0, "-Select-");
                ddlAcademicYear.Items.Insert(0, "-Select-");
                con.Close();



            }

            catch (Exception ex)
            {
                lblmsg.Text = "Error:" + ex.Message.ToString();
                lblmsg.ForeColor = System.Drawing.Color.Red;
                // Response.Write("<script language='javascript'>alert('Error!!!')</script>");
            }

        }
    }

    protected void ddlAttendanceDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if(ddlAcademicYear.Text == "-Select-" || ddlBatch.Text == "-Select-" || ddlSemCode.Text == "-Select-" || ddlSubCode.Text == "-Select-" || ddlSubType.Text == "-Select-")
            {
            Response.Write("<script language='javascript'>alert(' Please select Option!')</script>");
            }
            else
            {
       
                con.Open();
       
                        //parameterized sql
                string sql = "update attendanceMaster set attDate=@attDate,fromTime=@fromTime,toTime=@toTime,subNumber=@subNumber,subType=@subType,roomNo=@roomNo,batch=@batch,semCode=@semCode,forAcademicYear=@forAcademicYear,ABrollNumbers=@ABrollNumbers,PBrollNumbers=@PBrollNumbers,comments=@comments,flag=@flag where attDate=@attDate and  subNumber=" + Convert.ToInt32(ddlSubCode.Text) + "and subType='" + ddlSubType.Text + "'";
                        SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add(new SqlParameter("@attDate", SqlDbType.VarChar, 10));
                    cmd.Parameters.Add(new SqlParameter("@fromTime", SqlDbType.VarChar, 10));
                    cmd.Parameters.Add(new SqlParameter("@toTime", SqlDbType.VarChar, 10));
                    cmd.Parameters.Add(new SqlParameter("@semCode", SqlDbType.VarChar, 20));
                    cmd.Parameters.Add(new SqlParameter("@subNumber", SqlDbType.VarChar, 20));
                    cmd.Parameters.Add(new SqlParameter("@subType", SqlDbType.VarChar, 20));
                    cmd.Parameters.Add(new SqlParameter("@roomNo", SqlDbType.VarChar,10));
                    cmd.Parameters.Add(new SqlParameter("@batch", SqlDbType.VarChar, 20));
                    cmd.Parameters.Add(new SqlParameter("@forAcademicYear", SqlDbType.VarChar, 20));
                    cmd.Parameters.Add(new SqlParameter("@ABrollNumbers", SqlDbType.VarChar,255));
                    cmd.Parameters.Add(new SqlParameter("@PBrollNumbers", SqlDbType.VarChar,255));
                    cmd.Parameters.Add(new SqlParameter("@comments", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit, 0));

                    //pass alues
                    cmd.Parameters["@attDate"].Value = txtDate.Text;
                    cmd.Parameters["@fromTime"].Value = txtTimeFrom.Text;
                    cmd.Parameters["@toTime"].Value = txtTimeTo.Text;
                    cmd.Parameters["@semCode"].Value = ddlSemCode.SelectedItem.Text;
                    cmd.Parameters["@subNumber"].Value = ddlSubCode1.SelectedItem.Text;
                    cmd.Parameters["@subType"].Value = ddlSubType1.SelectedItem.Text;
                    cmd.Parameters["@roomNo"].Value = txtRoomNo.Text;

                    int len = CheckBoxList1.Items.Count;

                    string absroll = "", pbsroll = "";
                    for (int i = 0; i < len; i++)
                    {
                        if (CheckBoxList1.Items[i].Selected)
                        {
                            absroll += CheckBoxList1.Items[i].Value + ",";
                        }
                        else
                        {
                            pbsroll += CheckBoxList1.Items[i].Value + ",";
                        }

                    }
                  
                    cmd.Parameters["@batch"].Value = ddlBatch.SelectedItem.Text;
                    cmd.Parameters["@forAcademicYear"].Value = ddlAcademicYear.SelectedItem.Text;
                    cmd.Parameters["@ABrollNumbers"].Value = absroll;
                    cmd.Parameters["@PBrollNumbers"].Value = pbsroll;
                    cmd.Parameters["@comments"].Value = txtComments.Text;
                    cmd.Parameters["@flag"].Value =Convert.ToBoolean(0);

                    int cnt = cmd.ExecuteNonQuery();
                    if (cnt > 0)
                    {
                        lblmsg.Text = "Attendance Updated Successfully!!";
                        lblmsg.ForeColor = System.Drawing.Color.Gold;

                        //Response.Write("<script language='javascript'>alert('Attendance Updated Successfully!!')=len.ToString()</script>");

                    }
                    else
                    {
                        lblmsg.Text = "Attendance Updation failed!!";
                        lblmsg.ForeColor = System.Drawing.Color.Red;

                       // Response.Write("<script language='javascript'>alert('Attendance Updation failed!!!')</script>");
                    }

                    con.Close();

                }
            }

        catch (Exception ex)
        {
            lblmsg.Text = "Error:" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            // Response.Write("<script language='javascript'>alert('Error!!!')</script>");
        }
           
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            //parameterized sql
            string sql = "update attendanceMaster set flag=@flag where attDate=@attDate and subNumber=" + Convert.ToInt32(ddlSubCode.Text) + "and subType='" + ddlSubType.Text + "' and  batch='" + ddlBatch.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);

            //add parametr

            cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit, 0));
            cmd.Parameters.Add(new SqlParameter("@attDate", SqlDbType.VarChar,10));

            //pass alues
            cmd.Parameters["@flag"].Value =Convert.ToBoolean(1);
            cmd.Parameters["@attDate"].Value =ddlAttendanceDate.Text;

            int cnt = cmd.ExecuteNonQuery();
            con.Close();
            if (cnt > 0)
            {
                BindEmployeeDetails();
                lblmsg.Text = "Attendance Deleted Successfully!!!";
                lblmsg.ForeColor = System.Drawing.Color.Gold;
                //Response.Write("<script language='javascript'>alert('Attendance Deleted Successfully!!')</script>");


            }
            else
            {
                lblmsg.Text = "Attendance Not Deleted!!!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                //Response.Write("<script language='javascript'>alert('Attendance Not Deleted!')</script>");
            }


        }
          catch (Exception ex)
        {
            lblmsg.Text = "Error:" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            // Response.Write("<script language='javascript'>alert('Error!!!')</script>");
        }
    }
    protected void txtTimeTo_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlSemCode_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlSubCode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlSubType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlBatch.Items.Clear();
        ddlBatch.Items.Insert(0, "-Select-");
        if (ddlSubType.Text == "TH")
        {
            ddlBatch.Items.Add("ALL");
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

                ddlBatch.Items.Clear();

                ddlBatch.DataSource = ds;
                ddlBatch.DataTextField = "batchname";
                ddlBatch.DataValueField = "batchname";
                ddlBatch.DataBind();
                ddlBatch.Items.Insert(0, "-Select-");
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error:" + ex.Message.ToString();
                lblmsg.ForeColor = System.Drawing.Color.Red;
                // Response.Write("<script language='javascript'>alert('Error!!!')</script>");
            }
        }
    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from attendanceMaster where attDate='" + ddlAttendanceDate.Text + "'and subNumber=" + Convert.ToInt32(ddlSubCode.Text) + "and subType='" + ddlSubType.Text + "'and batch='"+ddlBatch.Text+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            txtTimeFrom.Text = dr["fromTime"].ToString();
            txtTimeTo.Text = dr["toTime"].ToString();
            ddlSemCode.Text = dr["semCode"].ToString();
            ddlSubCode1.Text = dr["subNumber"].ToString();
            ddlSubType1.Text = dr["subType"].ToString();
            txtRoomNo.Text = dr["roomNo"].ToString();
            ddlAcademicYear.Text = dr["forAcademicYear"].ToString();
            txtComments.Text = dr["comments"].ToString();
            txtDate.Text = dr["attDate"].ToString();
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error:" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            // Response.Write("<script language='javascript'>alert('Error!!!')</script>");
        }
        
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();


            SqlCommand cmd = new SqlCommand("select * from StudentBatches where batchName=@batchName", con);
            cmd.Parameters.Add(new SqlParameter("@batchName", SqlDbType.NVarChar, 50));
            cmd.Parameters["@batchName"].Value = ddlBatch.SelectedItem.Text;

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            int startRoll = Convert.ToInt32(dr["startingRoll"].ToString());
            int endRoll = Convert.ToInt32(dr["endingRoll"].ToString());


            CheckBoxList1.Items.Clear();
            for (int i = startRoll; i <= endRoll; i++)
            {
                CheckBoxList1.Items.Add(i.ToString());
            }

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
    protected void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtComments_TextChanged(object sender, EventArgs e)
    {

    }
}
