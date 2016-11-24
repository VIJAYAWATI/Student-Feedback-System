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

public partial class ChangePassword : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtOldPassword.Text==Session["password"].ToString())
            {
               
                    if (txtNewPassword.Text == txtConfirmNewPassword.Text)
                    {
                        con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                        con.Open();
                        //parameterized sql
                        string sql = "update staffLogin set password=@Password";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        //add parametr
                        cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 50));

                        //pass alues
                        cmd.Parameters["@Password"].Value = txtConfirmNewPassword.Text;


                        int cnt = cmd.ExecuteNonQuery();

                        if (cnt > 0)
                        {
                            lblmsg.Text = "Password changed successfully!..";
                            lblmsg.ForeColor = System.Drawing.Color.Green;
                            // Response.Write("<script language='javascript'>alert('Staff Information Updated Successfully!!')</script>");


                        }
                        else
                        {
                            lblmsg.Text = "Password Cannot Changed!..";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            //Response.Write("<script language='javascript'>alert('Staff Information Not Updated!')</script>");
                        }

                        con.Close();
                    }
                    else
                    {
                        lblmsg.Text = "Password did not Match..";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
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
}
