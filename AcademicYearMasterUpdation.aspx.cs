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


public partial class AcademicYearMasterUpdation : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True");
 
    protected void Page_Load(object sender, EventArgs e)
    {
   if (!IsPostBack)
        {
            BindEmployeeDetails();
        }
    }

    protected void BindEmployeeDetails()
    {
        //con.Open();
        //SqlCommand cmd = new SqlCommand("Select *  from AcademicYearMaster where  flag='False'", con);
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //con.Close();
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    ddlAcademicStartYear.DataSource = ds;
        //    ddlAcademicStartYear.DataTextField = "forAcademicYear";
        //    ddlAcademicStartYear.DataValueField = "forAcademicYear";
        //    ddlAcademicStartYear.DataBind();
        //    ddlAcademicStartYear.Items.Insert(0, "-Select-");

        //}
        con.Open();
        SqlCommand cmd = new SqlCommand("Select distinct forAcademicYear  from AcademicYearMaster ", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
   
            ddlAcademicStartYear.DataSource = ds;
            ddlAcademicStartYear.DataTextField = "forAcademicYear";
            ddlAcademicStartYear.DataValueField = "forAcademicYear";
            ddlAcademicStartYear.DataBind();
            ddlAcademicStartYear.Items.Insert(0, "-Select-");

        
    }


     

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();

            if (ddlAcademicStartYear.Text == "-Select-"||ddlSemType.Text=="-Select-")
            {
                Response.Write("<script language='javascript'>alert(' Please select Option!')</script>");
            }
            else
            {
                string strStartDt = txtTermStarts.Text;
                string strEndDt = txtTermEnds.Text;
                string strTermstart = strStartDt.Substring(8, 2);
                string strTermstart1 = strStartDt.Substring(6, 4);
                string strAcyr = ddlAcademicStartYear.Text;
                string strLastYr = strAcyr.Substring(5, 2);
                string strTermEnd = strEndDt.Substring(8, 2);
                string strStartYr = strAcyr.Substring(0, 4);
                if ((strStartYr == strTermstart || strStartYr == strTermstart1 || strLastYr == strTermstart) && (strLastYr == strTermEnd || strTermstart == strTermEnd))
                {
                  
                //parameterized sql
                string sql = "update AcademicYearMaster set forAcademicYear=@forAcademicYear,instudyyear=@instudyyear,semType=@semType,termStarts=@termStarts,termEnds=@termEnds,flag=@flag where forAcademicYear='"+ddlAcademicStartYear.SelectedItem.Text+"' and inStudyYear='"+ddlForYear.SelectedItem.Text+"'and semType='"+ddlSemType.SelectedItem.Text+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                //add parametr
                cmd.Parameters.Add(new SqlParameter("@forAcademicYear", SqlDbType.VarChar,20));
                cmd.Parameters.Add(new SqlParameter("@instudyyear", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@semType", SqlDbType.VarChar,20));
                cmd.Parameters.Add(new SqlParameter("@termStarts", SqlDbType.DateTime, 15));
                cmd.Parameters.Add(new SqlParameter("@termEnds", SqlDbType.DateTime, 15));
                cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit,0));


                //pass alues
                cmd.Parameters["@forAcademicYear"].Value = ddlAcademicStartYear.Text;
                cmd.Parameters["@instudyyear"].Value = ddlForYear1.Text;
                cmd.Parameters["@semType"].Value =ddlSemType1.SelectedItem.Text;
                cmd.Parameters["@termStarts"].Value = txtTermStarts.Text;
                cmd.Parameters["@termEnds"].Value = txtTermEnds.Text;
                cmd.Parameters["@flag"].Value = Convert.ToBoolean(0);

                int cnt = cmd.ExecuteNonQuery();

                if (cnt > 0)
                {
                    lblmsg.Text = "Academic year Updated Successfully!!!.";
                    lblmsg.ForeColor = System.Drawing.Color.Gold;
                    //Response.Write("<script language='javascript'>alert('Academic year Updated Successfully!!!')</script>");


                }
                else
                {
                    lblmsg.Text = "Academic year not Updated !.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                   // Response.Write("<script language='javascript'>alert('Year not Updated!')</script>");
                }
                }
            else
            {
                
                    lblmsg.Text = " Year not Updated due to mismatch in Academic year and dates!..";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
            }
                con.Close();
            }
            }
   
      

        catch (Exception ex)
        {
            lblmsg.Text = "Error:"+ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            //Response.Write("<script language='javascript'>alert('Error')</script>");
        }
    }
        
    


    
protected void  Button2_Click(object sender, EventArgs e)
{
    try
        {
            con.Open();
            //parameterized sql
            string sql = "update AcademicYearMaster set flag=@flag where forAcademicYear='"+ddlAcademicStartYear.Text+"'and inStudyYear='"+ddlForYear.Text+"'and semType='"+ddlSemType.Text+"'";
            SqlCommand cmd = new SqlCommand(sql, con);

            //add parametr

            cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit,0));
            //cmd.Parameters.Add(new SqlParameter("@forAcademicYear", SqlDbType.VarChar,20));
            //cmd.Parameters.Add(new SqlParameter("@inStudyYear", SqlDbType.Int));
            //cmd.Parameters.Add(new SqlParameter("@semType", SqlDbType.VarChar, 20));


            //pass alues
            cmd.Parameters["@flag"].Value =Convert.ToBoolean(1);
           // cmd.Parameters["@forAcademicYear"].Value = ddlAcademicStartYear.Text;
            //cmd.Parameters["@inStudyYear"].Value = ddlForYear.Text;
            //cmd.Parameters["@semType"].Value = ddlSemType.Text;

            int cnt = cmd.ExecuteNonQuery();
            con.Close();
            if (cnt > 0)
            {
                BindEmployeeDetails();
                lblmsg.Text = "Year Deleted Successfully!!!..";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                //Response.Write("<script language='javascript'>alert('Year Deleted Successfully!!')</script>");


            }
            else
            {
                lblmsg.Text = "Year Not Deleted!..";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                //Response.Write("<script language='javascript'>alert('Year Not Deleted')</script>");
            }

         
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error:" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            //Response.Write("<script language='javascript'>alert('Error')</script>");
        }

}
protected void ddlAcademicStartYear_SelectedIndexChanged1(object sender, EventArgs e)
{
 //con.Open();
 //SqlCommand cmd = new SqlCommand("Select * from AcademicYearMaster where forAcademicYear='" + ddlAcademicStartYear.Text +"'", con);
 //       SqlDataReader dr = cmd.ExecuteReader();

 //       dr.Read();
 //       ddlAcademicStartYear.Text = dr["forAcademicYear"].ToString();
 //       ddlForYear1.Text = dr["instudyyear"].ToString();
 //       ddlSemType1.Text = dr["semType"].ToString();
 //       txtTermStarts.Text = dr["termStarts"].ToString();
 //       txtTermEnds.Text = dr["termEnds"].ToString();
 //       dr.Close();
 //       con.Close();
}

protected void ddlSemNo_SelectedIndexChanged(object sender, EventArgs e)
{

}
protected void ddlForYear_SelectedIndexChanged(object sender, EventArgs e)
{
    //con.Open();
    //SqlCommand cmd = new SqlCommand("Select * from AcademicYearMaster where  inStudyYear='" + ddlForYear.Text + "'", con);
    //SqlDataReader dr = cmd.ExecuteReader();

    //dr.Read();
    //ddlForYear1.Text = dr["instudyyear"].ToString();
    //ddlSemType1.Text = dr["semType"].ToString();
    //txtTermStarts.Text = dr["termStarts"].ToString();
    //txtTermEnds.Text = dr["termEnds"].ToString();
    //dr.Close();
    //con.Close();

}
protected void ddlSemType_SelectedIndexChanged(object sender, EventArgs e)
{
    try
    {
        lblmsg.Text = "";
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from AcademicYearMaster where  semType='" + ddlSemType.SelectedItem.Text + "'and forAcademicYear='" + ddlAcademicStartYear.SelectedItem.Text + "'and inStudyYear='" + ddlForYear.SelectedItem.Text + "'and flag='False'", con);
        SqlDataReader dr = cmd.ExecuteReader();

        dr.Read();
        ddlAcademicStartYear.Text = dr["forAcademicYear"].ToString();
        ddlForYear1.Text = dr["instudyyear"].ToString();
        ddlSemType1.Text = dr["semType"].ToString();
        txtTermStarts.Text = dr["termStarts"].ToString();
        txtTermEnds.Text = dr["termEnds"].ToString();
        dr.Close();

        con.Close();
    }
    catch (Exception ex)
    {
        txtTermStarts.Text = "";
        txtTermEnds.Text = "";
        lblmsg.Text = "Error:" + ex.Message.ToString();
        lblmsg.ForeColor = System.Drawing.Color.Red;
    }
}
}
