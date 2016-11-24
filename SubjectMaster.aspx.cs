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

public partial class SubjectMaster : System.Web.UI.Page
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
               
             
                SqlDataAdapter da = new SqlDataAdapter("select semCode from semMaster", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "semMaster");
                ddlSemCode.Items.Clear();
                ddlSemCode.DataSource = ds;
                ddlSemCode.DataTextField = "semCode";
                ddlSemCode.DataValueField = "semCode";
                ddlSemCode.DataBind();
                ddlSemCode.Items.Insert(0, "-Select-"); 
                con.Close();

              }

            
            catch (Exception ex)
            {
                lblmsg.Text = "Error " + ex.Message.ToString();
                lblmsg.ForeColor = System.Drawing.Color.Gold; 
                //Response.Write("<script language='javascript'>alert('Error!!!')</script>");
            }
        }
    }

    
    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            if (ddlSemCode.Text == "-Select-")
            {
                Response.Write("<script language='javascript'>alert(' Please select Option!')</script>");
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from SubjectMaster where semCode='" + ddlSemCode.Text + "' and subNumber='" + txtSubNo.Text + "'", con);
                SqlDataReader dr = cmd1.ExecuteReader();

                if (dr.Read())
                {
                    Response.Write("<script language='javascript'>alert(' Subject  already Exist!')</script>");
                    dr.Close();
                }
                else
                {
                    dr.Close();

                    //parameterized sql
                    string sql = "insert into SubjectMaster values(@subNumber,@subCode,@subName,@semCode,@flag)";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    //add parametr
                    cmd.Parameters.Add(new SqlParameter("@subNumber", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@subCode", SqlDbType.VarChar, 20));
                    cmd.Parameters.Add(new SqlParameter("@subName", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@semCode", SqlDbType.VarChar, 20));
                    cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit,0));

                    //pass alues
                    cmd.Parameters["@subNumber"].Value = Convert.ToInt32(txtSubNo.Text);
                    cmd.Parameters["@subCode"].Value = txtSubCode.Text;
                    cmd.Parameters["@subName"].Value = txtFName.Text;
                    cmd.Parameters["@semCode"].Value = ddlSemCode.SelectedItem.Text;
                    cmd.Parameters["@flag"].Value = Convert.ToBoolean(0);


                    int cnt = cmd.ExecuteNonQuery();

                    if (cnt > 0)
                    {
                        lblmsg.Text = "Subject Added Successfully!!!";
                        lblmsg.ForeColor = System.Drawing.Color.Gold;
                        //Response.Write("<script language='javascript'>alert('Subject Added Successfully!!')</script>");


                    }
                    else
                    {
                        lblmsg.Text = "Subject  not Added !!!";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        //Response.Write("<script language='javascript'>alert('Subject Not Added')</script>");
                    }

                    con.Close();
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
    protected void ddlSemCode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtSubNo_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        txtFName.Text = "";
        txtSubCode.Text = "";
        txtSubNo.Text = "";
       
    }
}
