using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data;

namespace NorthwindApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            gvShipper.RowEditing += GvShipper_RowEditing;
            gvShipper.RowCancelingEdit += GvShipper_RowCancelingEdit;
            gvShipper.RowUpdating += GvShipper_RowUpdating;
            if (!IsPostBack)
            {
                GetAll();
            }
            

        }

        private void GvShipper_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvShipper.Rows[e.RowIndex];
            TextBox txtCompanyName = (TextBox)row.FindControl("txtCompanyname");
            TextBox txtPhone = (TextBox)row.FindControl("txtPhone");
            Label lblId = (Label)row.FindControl("lblId");

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Password=ITIdev123;Persist Security Info=True;User ID=sa;Initial Catalog=Northwind;Data Source=DESKTOP-GUPHSG0";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Shipper_Update";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = lblId.Text;
            cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = txtCompanyName.Text;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = txtPhone.Text;

            cmd.ExecuteNonQuery();
            cn.Close();

            gvShipper.EditIndex = -1;
            GetAll();
        }


        private void GvShipper_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvShipper.EditIndex = -1;
            GetAll();
        }

        private void GetAll()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Password=ITIdev123;Persist Security Info=True;User ID=sa;Initial Catalog=Northwind;Data Source=DESKTOP-GUPHSG0";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Shipper_GetAll";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);

            cn.Close();

            this.gvShipper.DataSource = ds.Tables[0];
            this.gvShipper.DataBind();
        }

        //private void SetRow()
        //{
        //    DataTable dt = new DataTable();
        //    DataRow dr = null;
        //    dt.Columns(new DataColumn("RowNumber"));
        //    dr = dt.NewRow();
        //    dr["RowNumber"] = 1;
        //    dt.Rows.Add(dr);
        //}

        private void GvShipper_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvShipper.EditIndex = e.NewEditIndex;
            GetAll();
        }
    }
}