using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace contable
{
    public partial class RegistroContables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                actualizarLabel();
            }

        }
        protected void actualizarLabel()
        {
            Label2.Text = "";
            DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            foreach (DataRowView dr in dv)
            {
                DataRow row = dr.Row;
                Label2.Text += row["monto"].ToString() + " - ";
            }
        }
        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text) && !string.IsNullOrEmpty(TextBox3.Text))
            {
                try
                {
                    int result = SqlDataSource1.Insert();
                    Label1.Text = "";
                    if (result != 0)
                    {
                        Label1.Text = "Se ha agregado " + result.ToString() + " un monto";
                        actualizarLabel();
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                    }
                    else
                    {
                        Label1.Text = "No se AGREGO LA CUENTA";
                    }
                }
                catch (Exception ex)
                {

                    Label1.Text = "Error al insertar en la base de datos: " + ex.Message;
                }
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader;
            SqlDataReader reader = (SqlDataReader)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
            if (reader.Read())
            {
                TextBox1.Text = reader["idCuenta"].ToString();
                TextBox2.Text = reader["monto"].ToString();
                TextBox3.Text = reader["tipo"].ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text) && !string.IsNullOrEmpty(TextBox3.Text))
            {
                try
                {
                    SqlDataSource1.UpdateParameters["idCuenta"].DefaultValue = TextBox1.Text;
                    SqlDataSource1.UpdateParameters["monto"].DefaultValue = TextBox2.Text;
                    SqlDataSource1.UpdateParameters["tipo"].DefaultValue = TextBox3.Text;

                    int result = SqlDataSource1.Update();
                    Label1.Text = "";

                    if (result != 0)
                    {
                        Label1.Text = "Se ha actualizado " + result.ToString() + " registro(s)";
                        actualizarLabel();
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                    }
                    else
                    {
                        Label1.Text = "No se actualizó ningún registro";
                    }
                }
                catch (Exception ex)
                {
                    
                    Label1.Text = "Error al actualizar en la base de datos: " + ex.Message;
                }
            }
            else
            {
                Label1.Text = "Ingrese un monto válido.";
            }

        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text) && !string.IsNullOrEmpty(TextBox3.Text))
            {
                try
                {
                    SqlDataSource1.DeleteParameters["idCuenta"].DefaultValue = ListBox1.SelectedValue;

                    int result = SqlDataSource1.Delete();
                    Label1.Text = "";

                    if (result != 0)
                    {
                        Label1.Text = "Se ha eliminado " + result.ToString() + " registro(s)";
                        actualizarLabel();
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                    }
                    else
                    {
                        Label1.Text = "No se eliminó ningún registro";
                    }
                }
                catch (Exception ex)
                {
                    // Maneja la excepción aquí, puedes mostrar un mensaje de error o registrarla para depuración.
                    Label1.Text = "Error al eliminar en la base de datos: " + ex.Message;
                }
            }
            else
            {
                Label1.Text = "Ingrese un monto válido.";
            }

        }
    }
}


    

