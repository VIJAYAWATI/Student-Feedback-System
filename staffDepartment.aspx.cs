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


public partial class staffDepartment : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (Page.IsPostBack == false)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("select courseCode from courseMaster", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "courseMaster");
                ddljoindept.Items.Clear();
                ddljoindept.DataSource = ds;
                ddljoindept.DataTextField = "courseCode";
                ddljoindept.DataValueField = "courseCode";
                ddljoindept.DataBind();

                SqlDataAdapter da1 = new SqlDataAdapter("select staffId,staff_Id from lstStaff_ID", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "lstStaff_ID");
                ddlStaffId.Items.Clear();
                ddlStaffId.DataSource = ds1;
                ddlStaffId.DataTextField = "staff_Id";
                ddlStaffId.DataValueField = "staffId";
                ddlStaffId.DataBind();

                SqlDataAdapter da2 = new SqlDataAdapter("select courseCode from courseMaster", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2, "courseMaster");
                ddlCurrentdept.Items.Clear();
                ddlCurrentdept.DataSource = ds2;
                ddlCurrentdept.DataTextField = "courseCode";
                ddlCurrentdept.DataValueField = "courseCode";
                ddlCurrentdept.DataBind();

                ddljoindept.Items.Insert(0, "-Select-");
                ddlStaffId.Items.Insert(0, "-Select-");
                ddlCurrentdept.Items.Insert(0, "-Select-");
                con.Close();
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error!: " + ex.Message.ToString();
                lblmsg.ForeColor = System.Drawing.Color.Red;
               // Response.Write("<script language='javascript'>alert('Error')</script>");
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try{

        
           if (ddlStaffId.Text == "-Select-" || ddlCurrentdept.Text == "-Select-" || ddljoindept.Text == "-Select-"||ddlStaffStatus.Text=="--Select--"||ddlStaffType.Text=="---SELECT---"||ddlDesignation.Text=="-SELECT-" )
            {
                Response.Write("<script language='javascript'>alert(' Please select Option!')</script>");
            }
            else
            {
                con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                con.Open();

                SqlCommand cmd1 = new SqlCommand("select * from staffDept where staffId='" +Convert.ToInt32(ddlStaffId.Text)+"'", con);
                SqlDataReader dr = cmd1.ExecuteReader();

                if (dr.Read())
                {
                    //lblmsg.Text = " Staff already Exists in this Department!..";
                    //lblmsg.ForeColor = System.Drawing.Color.Red;
                    Response.Write("<script language='javascript'>alert(' Staff already Exists in this Department!.')</script>");
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    
                    //parameterized sql
                    string sql = "insert into staffDept values(@staffId,@joiningDept,@currentDept,@staffType,@designation,@staffStatus,@flag)";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    //add parametr
                    cmd.Parameters.Add(new SqlParameter("@staffId", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@joiningDept", SqlDbType.VarChar,10));
                    cmd.Parameters.Add(new SqlParameter("@currentDept", SqlDbType.VarChar,10));
                    cmd.Parameters.Add(new SqlParameter("@staffType", SqlDbType.VarChar,15));
                    //cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar,50));
                    //cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar,50));
                    cmd.Parameters.Add(new SqlParameter("@designation", SqlDbType.VarChar,15));
                    cmd.Parameters.Add(new SqlParameter("@staffStatus", SqlDbType.VarChar,15));

                    cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit,0));

                    //pass alues
                    cmd.Parameters["@staffId"].Value =Convert.ToInt32(ddlStaffId.Text);
                    cmd.Parameters["@joiningDept"].Value = ddljoindept.SelectedItem.Text;
                    cmd.Parameters["@currentDept"].Value = ddlCurrentdept.SelectedItem.Text;
                    cmd.Parameters["@staffType"].Value = ddlStaffType.SelectedItem.Text;
                    //cmd.Parameters["@UserName"].Value = txtStaffloginid.Text;
                    //cmd.Parameters["@Password"].Value = txtStaffPassword.Text;
                    cmd.Parameters["@designation"].Value = ddlDesignation.SelectedItem.Text;
                    cmd.Parameters["@staffStatus"].Value = ddlStaffStatus.SelectedItem.Text;

                    cmd.Parameters["@flag"].Value =Convert.ToBoolean(0);


                    int cnt = cmd.ExecuteNonQuery();

                    if (cnt > 0)
                    {
                        lblmsg.Text = "Staff joined in Department Successfully!!..";
                        lblmsg.ForeColor = System.Drawing.Color.Gold;
                        //Response.Write("<script language='javascript'>alert('Staff Added Successfully!!')</script>");


                    }
                    else
                    {
                       lblmsg.Text = "Staff not Joined!..";
                       lblmsg.ForeColor = System.Drawing.Color.Red;
                        //Response.Write("<script language='javascript'>alert('Staff Not Added!')</script>");
                    }

                    con.Close();
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error!: " + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            //Response.Write("<script language='javascript'>alert('Error')</script>");
        }
    }
    protected void ddlCurrentdept_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void ddlStaffId_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtStaffloginid_TextChanged(object sender, EventArgs e)
    {

    }
}
