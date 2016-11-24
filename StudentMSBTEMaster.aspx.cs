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
using System.Drawing;

public partial class StudentMSBTEMaster : System.Web.UI.Page
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
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from studentMaster where flag='False'", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvDetails.DataSource = ds;
            gvDetails.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            gvDetails.DataSource = ds;
            gvDetails.DataBind();
            int columncount = gvDetails.Rows[0].Cells.Count;
            gvDetails.Rows[0].Cells.Clear();
            gvDetails.Rows[0].Cells.Add(new TableCell());
            gvDetails.Rows[0].Cells[0].ColumnSpan = columncount;
            gvDetails.Rows[0].Cells[0].Text = "No Records Found";
        }
    }

    protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDetails.EditIndex = e.NewEditIndex;
        BindEmployeeDetails();
    }

    protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int sid = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Value.ToString());
        string name = gvDetails.DataKeys[e.RowIndex].Values["stdName"].ToString();
        //TextBox txtuname = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("lblitemuname");
        TextBox txtenroll = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtenroll");
        con.Open();

        SqlCommand cmd = new SqlCommand("update studentMaster set MSBTEEnrollmentNo='" + txtenroll.Text + "' where StudentID=" + sid, con);
        cmd.ExecuteNonQuery();
        con.Close();
        lblresult.ForeColor = Color.Green;
        lblresult.Text = "Enrollment assigned successfully !!..";
        gvDetails.EditIndex = -1;
        BindEmployeeDetails();
    }

    protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvDetails.EditIndex = -1;
        BindEmployeeDetails();
    }

    protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int sid = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["StudentID"].ToString());
        string name = gvDetails.DataKeys[e.RowIndex].Values["stdName"].ToString();
        con.Open();

        SqlCommand cmd = new SqlCommand("update studentMaster set flag='True' where StudentID=" + sid, con);
        int result = cmd.ExecuteNonQuery();
        con.Close();

        if (result == 1)
        {
            BindEmployeeDetails();
            lblresult.ForeColor = Color.Red;
            lblresult.Text = name + " Student deleted successfully";
        }
    }

    protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      
    }

    protected void gvDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
