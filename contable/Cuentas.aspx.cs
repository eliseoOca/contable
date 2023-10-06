using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace contable
{
    public partial class Cuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                actualizarLabel();
            }
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void actualizarLabel()
        {
            Label2.Text = "";
            DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            foreach(DataRowView dr in dv)
            {
                DataRow row = dr.Row;
                Label2.Text += row["descripcion"].ToString() + " - ";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                int result = SqlDataSource1.Insert();
                Label1.Text = "";
                if (result != 0)
                {
                    Label1.Text = "Se ha agregado " + result.ToString() + " Cuenta";
                    actualizarLabel();
                    TextBox1.Text = "";
                }
                else
                {
                    Label1.Text = "No se AGREGO LA CUENTA";
                }
            }
            else
            {
                Label1.Text = "Ingrese una descripción válida.";
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader;
            SqlDataReader reader = (SqlDataReader)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
            if(reader.Read())
            {
                TextBox2.Text = reader["descripcion"].ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataSource1.DeleteParameters["id"].DefaultValue = ListBox1.SelectedValue;
                int result = SqlDataSource1.Delete();
                Label3.Text = "";
                if (result != 0)
                {
                    Label3.Text = "Se ha Borrado correctamente " + result.ToString() + " Cuenta";
                    actualizarLabel();
                    TextBox2.Text = "";
                }
                else
                {
                    Label3.Text = "No se esta Borrando correctamente";
                }
            }
            catch (Exception ex)
            {
                Label3.Text = "Error al borrar la cuenta: " + ex.Message;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataSource1.UpdateParameters["id"].DefaultValue = ListBox1.SelectedValue.ToString();
                SqlDataSource1.UpdateParameters["descripcion"].DefaultValue = TextBox2.Text;
                int result = SqlDataSource1.Update();
                Label3.Text = "";
                if (result != 0)
                {
                    Label3.Text = "Se ha Modificado correctamente " + result.ToString() + " Cuenta";
                    actualizarLabel();
                    TextBox2.Text = "";
                }
                else
                {
                    Label3.Text = "No se Modifico correctamente";
                }
            }
            catch (Exception ex)
            {
                Label3.Text = "Error al modificar la cuenta: " + ex.Message;
            }
        }

        
    }
}