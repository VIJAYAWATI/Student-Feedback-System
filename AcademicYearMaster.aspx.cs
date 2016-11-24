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

public partial class AcademicYearMaster : System.Web.UI.Page
{
                
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
            int i = 0;

            ddlAcademicStartYear.Items.Insert(i, "---Select---");
            for (int acyr1 = 1983; acyr1 < System.DateTime.Now.Year + 1; acyr1++)
            {
                ListItem yr3 = new ListItem();
                yr3.Text = Convert.ToString(acyr1);
                yr3.Value = acyr1.ToString();
                ddlAcademicStartYear.Items.Insert(++i, yr3);
            }
          
        
              
    }

    protected void Button1_Click(object sender, EventArgs e)
    {


        try
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=VIJAY-PC;Initial Catalog=StudentDB;Integrated Security=True";
            con.Open();
            if (ddlSemType.Text == "-Select-")
            {
                Response.Write("<script language='javascript'>alert(' Please select Option!')</script>");
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand("select * from AcademicYearMaster where forAcademicYear='" + txtACYR.Text + "'and semType='" + ddlSemType.Text + "'and instudyyear='" + ddlForYear.Text + "'", con);
                SqlDataReader dr2 = cmd2.ExecuteReader();

                if (dr2.Read())
                {
                    Response.Write("<script language='javascript'>alert(' Academic year Already Exists !')</script>");
                    dr2.Close();
                }
                else
                {
                    dr2.Close();


                    string strStartDt = txtTermStarts.Text;
                    string strEndDt = txtTermEnds.Text;
                    //  DateTime  dtS =Convert.ToDateTime(strStartDt) ;
                    //  DateTime dtE = Convert.ToDateTime(strEndDt);
                    //  string str1 = Convert.ToString((dtS- dtE));

                    //DateTime d = Convert.ToDateTime(str1);
                    // lbldtdiff.Text = d.ToString();
                    string strTermstart = strStartDt.Substring(8, 2);
                    string strTermstart1 = strStartDt.Substring(6, 4);
                    string strAcyr = txtACYR.Text;
                    string strLastYr = strAcyr.Substring(5, 2);
                    string strTermEnd = strEndDt.Substring(8, 2);
                    string strStartYr = strAcyr.Substring(0, 4);



                    if (IsPostBack == true)
                    {


                        if ((strStartYr == strTermstart || strStartYr == strTermstart1 || strLastYr == strTermstart) && (strLastYr == strTermEnd || strTermstart == strTermEnd))
                        {
                            //if (diffMonth >=4 && diffMonth < 7)
                            //{
                            //    //parameterized sql
                            string sql = "insert into AcademicYearMaster values(@forAcademicYear,@instudyyear,@semType,@termStarts,@termEnds,@flag)";
                            SqlCommand cmd = new SqlCommand(sql, con);

                            //add parametr
                            cmd.Parameters.Add(new SqlParameter("@forAcademicYear", SqlDbType.VarChar, 50));
                            cmd.Parameters.Add(new SqlParameter("@instudyyear", SqlDbType.Int));
                            cmd.Parameters.Add(new SqlParameter("@semType", SqlDbType.VarChar, 16));
                            cmd.Parameters.Add(new SqlParameter("@termStarts", SqlDbType.DateTime));
                            cmd.Parameters.Add(new SqlParameter("@termEnds", SqlDbType.DateTime));
                            cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Bit, 0));


                            //pass alues
                            cmd.Parameters["@forAcademicYear"].Value = txtACYR.Text;
                            cmd.Parameters["@instudyyear"].Value = ddlForYear.Text;
                            cmd.Parameters["@semType"].Value = ddlSemType.Text;
                            cmd.Parameters["@termStarts"].Value = txtTermStarts.Text;
                            cmd.Parameters["@termEnds"].Value = txtTermEnds.Text;
                            cmd.Parameters["@flag"].Value = Convert.ToBoolean(0);

                            int cnt = cmd.ExecuteNonQuery();

                            if (cnt > 0)
                            {
                                lblmsg.Text = "Academic year allocated Successfully!!!";
                                lblmsg.ForeColor = System.Drawing.Color.Green;
                                //Response.Write("<script language='javascript'>alert('Academic year allocated Successfully!!!')</script>");
                                ddlAcademicStartYear.Items.Clear();

                            }

                            con.Close();
                        }
                        //else
                        //{
                        //    lblmsg.Text = "Invalid Terms..";
                        //    lblmsg.ForeColor = System.Drawing.Color.Red;

                            //}

                        else
                        {
                            lblmsg.Text = "Invalid Year!!..";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            ddlAcademicStartYear.Items.Clear();


                        }
                    }
                }
            }
        }


        catch (Exception ex)
        {
            lblmsg.Text = "Error:-" + ex.Message;
            lblmsg.ForeColor = System.Drawing.Color.Red;
            // Response.Write("<script language='javascript'>alert('Error')</script>");
        }
    }
    

    
       
    protected void txtAcademicYear_TextChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        txtACYR.Text = "";
        txtTermEnds.Text = "";
        txtTermStarts.Text = "";
        ddlSemType.SelectedIndex = 0; lblmsg.Text = "";
    }
    protected void txtAcademicYear_TextChanged1(object sender, EventArgs e)
    {
        
    }
    protected void ddlAcademicStartYear_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {

            string yr3 = ddlAcademicStartYear.SelectedValue;
            int nxtyr1 = Convert.ToInt32(yr3) + 1;
            string nxtyr2 = nxtyr1.ToString();
            string nxtyr3 = nxtyr2.Substring(2, 2);
            txtACYR.Text = yr3 + '-' + nxtyr3;
           
            
        }
        catch (Exception ex)
        {

            lblmsg.Text = ex.Message;
            lblmsg.ForeColor = System.Drawing.Color.Red;

        }
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
}
         
        


