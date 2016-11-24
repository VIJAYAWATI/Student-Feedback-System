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

public partial class SubjectUpdation : System.Web.UI.Page
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
        try
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SubjectMaster where flag='False'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "subNumber";
                DropDownList1.DataValueField = "subNumber";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "--SELECT--");

            }
            SqlDataAdapter da1 = new SqlDataAdapter("select semCode from semMaster", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "semMaster");
            ddlSemCode.Items.Clear();
            ddlSemCode.DataSource = ds1;
            ddlSemCode.DataTextField = "semCode";
            ddlSemCode.DataValueField = "semCode";
            ddlSemCode.DataBind();
            ddlSemCode.Items.Insert(0, "-Select-");
            con.Close();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error:" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }



    }
  


    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.Text == "--SELECT--"||ddlSemCode.Text=="-Select-")
            {
                Response.Write("<script language='javascript'>alert('Please select Option!!')</script>");
            }
            else
            {

                con.Open();
                string sql = "update SubjectMaster set subNumber=@subNumber,subCode=@subCode,subName=@subName,semCode=@semCode,flag=@flag where subNumber=@subNumber1";
                SqlCommand cmd = new SqlCommand(sql, con);

                //add parametr
                cmd.Parameters.Add(new SqlParameter("@subNumber1", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@subNumber", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@subCode", SqlDbType.VarChar, 20));
                cmd.Parameters.Add(new SqlParameter("@subName", SqlDbType.VarChar, 20));
                cmd.Parameters.Add(new SqlParameter("@semCode", SqlDbType.VarChar, 20));
                cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit, 0));



                //pass alues
                cmd.Parameters["@subNumber1"].Value = Convert.ToInt32(DropDownList1.Text);
                cmd.Parameters["@subNumber"].Value = Convert.ToInt32(txtSubNo.Text);
                cmd.Parameters["@subCode"].Value = txtSubCode.Text;
                cmd.Parameters["@subName"].Value = txtFName.Text;
                cmd.Parameters["@semCode"].Value = ddlSemCode.SelectedItem.Text;
                cmd.Parameters["@flag"].Value = Convert.ToBoolean(0);
                int cnt = cmd.ExecuteNonQuery();
                con.Close();
                if (cnt > 0)
                {
                    BindEmployeeDetails();
                    lblmsg.Text = "Subject Updated Successfully.!!!";
                    lblmsg.ForeColor = System.Drawing.Color.Gold;
                    //Response.Write("<script language='javascript'>alert('Subject Updated Successfully!!')</script>");


                }
                else
                {
                    lblmsg.Text = "Subject  not Updated. !!!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    //Response.Write("<script language='javascript'>alert('Subject Not Updated')</script>");
                }

            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error:"+ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
           // Response.Write("<script language='javascript'>alert('Error')</script>");
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.Text == "--SELECT--"|| ddlSemCode.Text == "-Select-")
            {
                Response.Write("<script language='javascript'>alert('Please select Option!!')</script>");
            }
            else
            {
                con.Open();
                //parameterized sql
                string sql = "update SubjectMaster set flag=@flag where subNumber=@subNumber";
                SqlCommand cmd = new SqlCommand(sql, con);

                //add parametr

                cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit, 0));
                cmd.Parameters.Add(new SqlParameter("@subNumber", SqlDbType.Int));

                //pass alues
                cmd.Parameters["@flag"].Value = Convert.ToBoolean(1);
                cmd.Parameters["@subNumber"].Value = Convert.ToInt32(DropDownList1.Text);

                int cnt = cmd.ExecuteNonQuery();
                con.Close();
                if (cnt > 0)
                {
                    BindEmployeeDetails();
                    lblmsg.Text = "Subject Deleted Successfully.!!!";
                    lblmsg.ForeColor = System.Drawing.Color.Gold;
                    // Response.Write("<script language='javascript'>alert('Subject Deleted Successfully!!')</script>");


                }
                else
                {
                    lblmsg.Text = "Subject  not Deleted. !!!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    //Response.Write("<script language='javascript'>alert('Subject Not Deleted')</script>");
                }

            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error:"+ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red; 
            //Response.Write("<script language='javascript'>alert('Error')</script>");
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SubjectMaster where subNumber=" + Convert.ToInt32(DropDownList1.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            txtSubNo.Text = dr["subNumber"].ToString();
            txtSubCode.Text = dr["subCode"].ToString();
            txtFName.Text = dr["subName"].ToString();
            ddlSemCode.Text = dr["semCode"].ToString();

            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error:" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            //Response.Write("<script language='javascript'>alert('Error')</script>");
        }
    }
    protected void txtFName_TextChanged(object sender, EventArgs e)
    {

    }
}
