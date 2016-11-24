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

public partial class SubjectSubTypeAllocation : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (!IsPostBack)
        {
            BindEmployeeDetails();
        }
    
    }
    protected void BindEmployeeDetails()
    {
        try
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("Select distinct subNumber from R_sub_subType where flag='False'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSubNumber.DataSource = ds;
                ddlSubNumber.DataTextField = "subNumber";
                ddlSubNumber.DataValueField = "subNumber";
                ddlSubNumber.DataBind();
                ddlSubNumber.Items.Insert(0, "--SELECT--");

            }
            con.Close();

        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error:-" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }
    }
  
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
       

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            //parameterized sql
            string sql = "update  R_sub_subType set subNumber=@subNumber,subType=@subType,maxMarks=@maxMarks,minMarks=@minMarks,weeklyLoad=@weeklyLoad,examCode=@examCode,flag=@flag where subNumber='"+ddlSubNumber.Text+"'and subType='"+ddlSubType.Text+"'";
            SqlCommand cmd = new SqlCommand(sql, con);

            //add parametr

            cmd.Parameters.Add(new SqlParameter("@subNumber", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@subType", SqlDbType.VarChar, 20));
            cmd.Parameters.Add(new SqlParameter("@maxMarks", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@minMarks", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@weeklyLoad", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@examCode", SqlDbType.VarChar, 20));
            cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit,0));


            //pass alues
            cmd.Parameters["@subNumber"].Value = ddlSubNumber.SelectedItem.Text;
            cmd.Parameters["@subType"].Value = ddlSubType1.SelectedItem.Text;
            cmd.Parameters["@maxMarks"].Value = Convert.ToInt32(txtMaxMark.Text);
            cmd.Parameters["@minMarks"].Value = Convert.ToInt32(txtMinMark.Text);
            cmd.Parameters["@weeklyLoad"].Value = Convert.ToInt32(txtWLoad.Text);
            cmd.Parameters["@examCode"].Value = txtExamcode.Text;
            cmd.Parameters["@flag"].Value =Convert.ToBoolean(0);

            int cnt = cmd.ExecuteNonQuery();
            if (cnt > 0)
            {
                BindEmployeeDetails();
                lblmsg.Text = "Subject  SubType Updated Successfully.!!";
                lblmsg.ForeColor = System.Drawing.Color.Gold;
                //Response.Write("<script language='javascript'>alert('Subject  SubType Updated Successfully!!')</script>");


            }
            else
            {
                lblmsg.Text = "Subject  SubType Not Updated. !!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
               // Response.Write("<script language='javascript'>alert('Subject Not Updated')</script>");
            }
            con.Close();


      }  
        catch (Exception ex)
        {
            lblmsg.Text = "Error:-" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
           // Response.Write("<script language='javascript'>alert('Error')</script>");
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        try
        {
            con.Open();
            //parameterized sql
            string sql = "update R_sub_subType set flag=@flag where subNumber=@subNumber and subType='"+ddlSubType.Text+"'";
            SqlCommand cmd = new SqlCommand(sql, con);

            //add parametr

            cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit,0));
            cmd.Parameters.Add(new SqlParameter("@subNumber", SqlDbType.Int));

            //pass alues
            cmd.Parameters["@flag"].Value =Convert.ToBoolean(1);
            cmd.Parameters["@subNumber"].Value = Convert.ToInt32(ddlSubNumber.Text);
            int cnt = cmd.ExecuteNonQuery();
            if (cnt > 0)
            {
                BindEmployeeDetails();
                lblmsg.Text = "Subject SubType Deleted Successfully.!!";
                lblmsg.ForeColor = System.Drawing.Color.Gold;
                //Response.Write("<script language='javascript'>alert('Subject SubType Deleted Successfully!!')</script>");


            }
            else
            {
                lblmsg.Text = "Subject SubType Not Deleted !!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                //Response.Write("<script language='javascript'>alert('Subject SubType Not Deleted')</script>");
            }

            con.Close();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error:-" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            //Response.Write("<script language='javascript'>alert('Error')</script>");
        }

    }
    protected void ddlSubCode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlSubType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Select * from R_sub_subType where subNumber=" + Convert.ToInt32(ddlSubNumber.Text)+" and subType='"+ddlSubType.Text+"' and flag='False'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            ddlSubType1.Text = dr["subType"].ToString();
            txtMaxMark.Text = dr["maxMarks"].ToString();
            txtMinMark.Text = dr["minMarks"].ToString();
            txtWLoad.Text = dr["weeklyLoad"].ToString();
            txtExamcode.Text = dr["examCode"].ToString();
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error:-" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }

    }
    protected void txtMaxMark_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtMinMark_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtWLoad_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtExamcode_TextChanged(object sender, EventArgs e)
    {

    }
}
