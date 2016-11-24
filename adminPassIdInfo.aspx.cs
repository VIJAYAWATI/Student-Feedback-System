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


public partial class adminPassIdInfo : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        


    }

    protected void btnallocate_Click1(object sender, EventArgs e)
    {
        try
        {
           string s= Session["adminId"].ToString();
           

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                    con.Open();

                    //parameterized sql
                    string sql = "update adminLogin set adminName=@adminName,adminId=@adminId,password=@password,flag=@flag where adminId='"+Session["adminId"].ToString()+"'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    //add parametr
                    cmd.Parameters.Add(new SqlParameter("@adminName", SqlDbType.VarChar,50));
                    cmd.Parameters.Add(new SqlParameter("@adminId", SqlDbType.VarChar,50));
                    cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar,20));
                    cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit, 0));


                    //pass alues
                    cmd.Parameters["@adminName"].Value = txtAdminName.Text;
                    cmd.Parameters["@adminId"].Value =txtAdminId.Text;;
                    cmd.Parameters["@password"].Value = txtAdminPass.Text;
                    cmd.Parameters["@flag"].Value = Convert.ToBoolean(0);




                    int cnt = cmd.ExecuteNonQuery();

                    if (cnt > 0)
                    {
                        lblmsg.Text = "Password and ID Updated successfully!..";
                        lblmsg.ForeColor = System.Drawing.Color.Gold;
                        //Response.Write("<script language='javascript'>alert(' Student admission updation successfully!')</script>");
                    }
                    else
                    {
                        lblmsg.Text = "ID and Password updation Failed!..";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        // Response.Write("<script language='javascript'>alert('Student admission updation Failed!')</script>");
                    }
                }

        catch (Exception ex)
        {
            lblmsg.Text = "Error:" + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;
            // Response.Write("<script language='javascript'>alert('Error!!!')</script>");
        }

    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminTasks.aspx");
    }
}
