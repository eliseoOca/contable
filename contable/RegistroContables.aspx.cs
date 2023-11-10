using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace contable
{
    public partial class RegistroContables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataSource2.InsertParameters["idCuenta"].DefaultValue = DropDownList1.SelectedValue;
            SqlDataSource2.InsertParameters["monto"].DefaultValue = TextBox1.Text;
            SqlDataSource2.InsertParameters["tipo"].DefaultValue = RadioButtonList1.SelectedValue;
            int result = SqlDataSource2.Insert();
            if (result > 0)
            {
                Label1.Text = "Agregado " + result.ToString() + "cuenta.";
                TextBox1.Text=String.Empty;
        }

            }
        }
            }