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

public partial class College : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from instituteMaster where instituteCode='" +txtInstituteCode.Text + "' and subNumber='" + txtSubNo.Text + "'", con);
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
                    cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit, 0));

                    //pass alues
                    cmd.Parameters["@subNumber"].Value = Convert.ToInt32(txtSubNo.Text);
                    cmd.Parameters["@subCode"].Value = txtSubCode.Text;
                    cmd.Parameters["@subName"].Value = txtFName.Text;
                    cmd.Parameters["@semCode"].Value = ddlSemCode.SelectedItem.Text;
                    cmd.Parameters["@flag"].Value = "0";


                    int cnt = cmd.ExecuteNonQuery();

                    if (cnt > 0)
                    {
                        Response.Write("<script language='javascript'>alert('Subject Added Successfully!!')</script>");


                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('Subject Not Added')</script>");
                    }

                    con.Close();
                }
            }
    }

        catch (Exception ex)
        {
            Response.Write("<script language='javascript'>alert('Error')</script>");
        }

    }
}
