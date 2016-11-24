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

public partial class AttendanceMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (Session["staffId"] == null)
        {
            Response.Redirect("staffLogin.aspx");
        }
           
        if (Page.IsPostBack == false)
        {
            String StaffId = Session["staffId"].ToString();
            String pass = Session["password"].ToString();
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("select distinct semCode from R_StaffTeachesSubject where staffId='"+Session["staffId"].ToString()+"'", con);
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
   
  

    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlAcademicYear.Text == "-Select-" || ddlBatch.Text == "--Select Batch Name--" || ddlSemCode.Text == "-Select-" || ddlSubNumber.Text == "-Select-" || ddlSubType.Text == "-Select-")
            {
                Response.Write("<script language='javascript'>alert(' Please select Option!')</script>");
            }
            else
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from attendanceMaster where attDate= '" + txtDate.Text + "'and fromTime=" + ddlTimeFrom.Text + "and toTime=" + ddlTimeTo.Text + " and semCode='" + ddlSemCode.Text + "' and roomNo='" + txtRoomNo.Text + "' and forAcademicYear='" + ddlAcademicYear.Text + "'", con);
                SqlDataReader dr = cmd1.ExecuteReader();

                if (dr.Read())
                {
                    Response.Write("<script language='javascript'>alert(' Attendance already Taken in this period!')</script>");
                    dr.Close();
                }
                else
                {
                    dr.Close();

                    //parameterized sql
                    string sql = "insert into attendanceMaster(attDate,fromTime,toTime,semCode,subNumber,subType,roomNo,batch,forAcademicYear,ABrollNumbers,PBrollNumbers,comments,flag) values(@attDate,@fromTime,@toTime,@semCode,@subNumber,@subType,@roomNo,@batch,@forAcademicYear,@ABrollNumbers,@PBrollNumbers,@comments,@flag)";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    //add parametr
                    cmd.Parameters.Add(new SqlParameter("@attDate", SqlDbType.VarChar,10));
                    cmd.Parameters.Add(new SqlParameter("@fromTime", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlParameter("@toTime", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlParameter("@semCode", SqlDbType.VarChar, 20));
                    cmd.Parameters.Add(new SqlParameter("@subNumber", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@subType", SqlDbType.VarChar, 20));
                    cmd.Parameters.Add(new SqlParameter("@roomNo", SqlDbType.VarChar,10));
                    cmd.Parameters.Add(new SqlParameter("@batch", SqlDbType.VarChar, 20));
                    cmd.Parameters.Add(new SqlParameter("@forAcademicYear", SqlDbType.VarChar, 20));
                    cmd.Parameters.Add(new SqlParameter("@ABrollNumbers", SqlDbType.VarChar, 255));
                    cmd.Parameters.Add(new SqlParameter("@PBrollNumbers", SqlDbType.VarChar, 255));
                    cmd.Parameters.Add(new SqlParameter("@comments", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit, 0));

                    //pass alues
                    cmd.Parameters["@attDate"].Value = txtDate.Text;
                    cmd.Parameters["@fromTime"].Value = ddlTimeFrom.Text;
                    cmd.Parameters["@toTime"].Value = ddlTimeTo.Text;
                    cmd.Parameters["@semCode"].Value = ddlSemCode.SelectedItem.Text;
                    cmd.Parameters["@subNumber"].Value = ddlSubNumber.SelectedItem.Value;
                    cmd.Parameters["@subType"].Value = ddlSubType.SelectedItem.Text;
                    cmd.Parameters["@roomNo"].Value =txtRoomNo.Text;

                    int len = CheckBoxList1.Items.Count;

                    string absroll = "", pbsroll="";
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
                    cmd.Parameters["@flag"].Value =0;

                    int cnt = cmd.ExecuteNonQuery();
                    if (cnt > 0)
                    {

                        lblmsg.Text = "Attendance Completed Successfully!!..";
                        lblmsg.ForeColor = System.Drawing.Color.Gold;
                       // Response.Write("<script language='javascript'>alert('Attendance Completed Successfully!!')</script>");

                    }
                    else
                    {
                        //lblmsg2.Text = "Staff not added";
                        Response.Write("<script language='javascript'>alert('Attendance failed!!!')</script>");
                    }

                    con.Close();

                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error:- " + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            //Response.Write("<script language='javascript'>alert('Error!!!')</script>");
        }

    }
    
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlSemCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select distinct subNumber,str(subNumber)+'-'+subName as Sub_Number from lstStaffTeachesSubject where semCode=@semCode and staffId='"+Session["staffId"].ToString()+"'", con);
            da.SelectCommand.Parameters.Add(new SqlParameter("@semCode", SqlDbType.VarChar, 50));
            da.SelectCommand.Parameters["@semCode"].Value = ddlSemCode.SelectedItem.Text;

            DataSet ds = new DataSet();
            da.Fill(ds, "lstStaffTeachesSubject");

            ddlSubNumber.Items.Clear();

            ddlSubNumber.DataSource = ds;
            ddlSubNumber.DataTextField = "Sub_Number";
            ddlSubNumber.DataValueField = "subNumber";
            ddlSubNumber.DataBind();
            ddlSubNumber.Items.Insert(0, "-Select-");

            SqlDataAdapter da1 = new SqlDataAdapter("select distinct batchName from StudentBatches where semCode=@semCode", con);
            da1.SelectCommand.Parameters.Add(new SqlParameter("@semCode", SqlDbType.VarChar, 50));
            da1.SelectCommand.Parameters["@semCode"].Value = ddlSemCode.SelectedItem.Text;

            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "StudentBatches");

            ddlBatch.Items.Clear();

            ddlBatch.DataSource = ds1;
            ddlBatch.DataTextField = "batchName";
            ddlBatch.DataValueField = "batchName";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, "--Select Batch Name--");
            con.Close();
        }

        catch (Exception ex)
        {
            lblmsg.Text = "Error:" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            // Response.Write("<script language='javascript'>alert('Error!!!')</script>");
        }
          
    }
    protected void ddlSubNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select distinct subType from lstStaffTeachesSubject where subNumber=@subNumber", con);
            da.SelectCommand.Parameters.Add(new SqlParameter("@subNumber", SqlDbType.Int));
            da.SelectCommand.Parameters["@subNumber"].Value = ddlSubNumber.SelectedItem.Value;

            DataSet ds = new DataSet();
            da.Fill(ds, " lstStaffTeachesSubject");

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
            lblmsg.Text = "Error:" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            // Response.Write("<script language='javascript'>alert('Error!!!')</script>");
        }
    }
    
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();

          
            SqlCommand cmd= new SqlCommand("select * from StudentBatches where batchName=@batchName", con);
            cmd.Parameters.Add(new SqlParameter("@batchName", SqlDbType.NVarChar, 50));
            cmd.Parameters["@batchName"].Value = ddlBatch.SelectedItem.Text;

            SqlDataReader dr=cmd.ExecuteReader();
            dr.Read();

            int startRoll = Convert.ToInt32(dr["startingRoll"].ToString());
            int endRoll = Convert.ToInt32(dr["endingRoll"].ToString());


            CheckBoxList1.Items.Clear();
            for (int i = startRoll ; i <= endRoll ; i++)
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
    protected void ddlSemCode_SelectedIndexChanged1(object sender, EventArgs e)
    {
        

           

    }
    

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {

    }
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
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
protected void  txtTimeTo_TextChanged(object sender, EventArgs e)
{

}
protected void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
{

}
protected void ddlTimeFrom_SelectedIndexChanged(object sender, EventArgs e)
{

}
protected void Button2_Click(object sender, EventArgs e)
{
    Session.Abandon();
    Session.Clear();
    Response.Redirect("staffLogin.aspx");
    
}
protected void Button2_Click1(object sender, EventArgs e)
{
    Session.Abandon();
    Session.Clear();
    Response.Redirect("staffLogin.aspx");
}
}