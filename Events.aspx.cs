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

public partial class Events : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
                con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                con.Open();
                          //parameterized sql
                            string sql = "insert into Events values(@EventTitle,@EventDate,@EventVenue,@EventConductedBy,@Description)";
                            SqlCommand cmd = new SqlCommand(sql, con);

                            //add parametr
                            cmd.Parameters.Add(new SqlParameter("@EventTitle", SqlDbType.VarChar,50));
                            cmd.Parameters.Add(new SqlParameter("@EventDate", SqlDbType.DateTime));
                            cmd.Parameters.Add(new SqlParameter("@EventVenue", SqlDbType.VarChar,50));
                            cmd.Parameters.Add(new SqlParameter("@EventConductedBy", SqlDbType.VarChar,50));
                            cmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar,255));


                            //pass alues
                            cmd.Parameters["@EventTitle"].Value = txtETitle.Text;
                            cmd.Parameters["@EventDate"].Value = txtDate.Text;
                            cmd.Parameters["@EventVenue"].Value = txtEVenue.Text;
                            cmd.Parameters["@EventConductedBy"].Value = txtConducted.Text;
                            cmd.Parameters["@Description"].Value = txtDiscription.Text;
                            int cnt = cmd.ExecuteNonQuery();

                            if (cnt > 0)
                            {
                                lblmsg.Text = "Events added successfully!..";
                                lblmsg.ForeColor = System.Drawing.Color.Green;
                                
                            }

                            else
                            {
                                lblmsg.Text = "Events not Added! ";
                                lblmsg.ForeColor = System.Drawing.Color.Red;
                                // Response.Write("<script language='javascript'>alert('Student admission Failed!')</script>");
                            }


                        
    


                    
                    con.Close();

                }

            


        catch (Exception ex)
        {
            lblmsg.Text = "Error " + ex.Message.ToString();
            lblmsg.ForeColor = System.Drawing.Color.Red;

            // Response.Write("<script language='javascript'>alert('Invalid Values!!!')</script>");
        }

    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {

    }
}
