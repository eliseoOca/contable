using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace contable
{
    public partial class RegistroContables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    completarTabla();
                }
            }

        }

        protected void completarTabla()
        {
            try
            {
                DataView dv = (DataView)DropDpwlisTable.Select(DataSourceSelectArguments.Empty);
                Table1.CellSpacing = 10; 
                Table1.CellPadding = 10;
                Table1.GridLines = GridLines.Both;

                if (dv != null && dv.Count > 0)
                {
                    // Rellenar cabecera
                    TableRow headerRow = new TableRow();

                    TableCell headerCell1 = new TableCell();
                    headerCell1.Text = "Cuenta";
                    headerRow.Cells.Add(headerCell1);

                    TableCell headerCell2 = new TableCell();
                    headerCell2.Text = "Monto";
                    headerRow.Cells.Add(headerCell2);

                    TableCell headerCell3 = new TableCell();
                    headerCell3.Text = "Tipo";
                    headerRow.Cells.Add(headerCell3);

                    Table1.Rows.Add(headerRow);

                    // Rellenar las filas
                    foreach (DataRowView rowView in dv)
                    {
                        DataRow row = rowView.Row;
                        TableRow tableRow = new TableRow();

                        TableCell cell1 = new TableCell();
                        cell1.Text = row["descripcion"].ToString();
                        tableRow.Cells.Add(cell1);

                        TableCell cell2 = new TableCell();
                        cell2.Text = row["monto"].ToString();
                        tableRow.Cells.Add(cell2);


                        TableCell cell3 = new TableCell();
                        string tipo = row.Field<bool>("tipo") ? "Debe" : "Haber";
                        cell3.Text = tipo;
                        tableRow.Cells.Add(cell3);

                        Table1.Rows.Add(tableRow);
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", $"alert('Error');", true);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataSource2.InsertParameters["idCuenta"].DefaultValue = DropDownList1.SelectedValue;
            SqlDataSource2.InsertParameters["monto"].DefaultValue = TextBox1.Text;
            bool tipo;

            if (RadioButtonList1.SelectedValue == "Debe")
            {
                tipo = true;
            }
            else
            {
                tipo = false;
            }
            SqlDataSource2.InsertParameters["tipo"].DefaultValue = tipo.ToString();
            int result = SqlDataSource2.Insert();
            if (result > 0)
            {
                Label1.Text = "Agregado " + result.ToString() + "cuenta.";
                completarTabla();
                TextBox1.Text=String.Empty;
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int result = SqlDataSource2.Delete();
            if (result > 0)
            {

                Label1.Text = "Borrado " + result.ToString() + " registro.";
                completarTabla();
                TextBox1.Text = string.Empty;
            }
            else
            {
                Label1.Text = "No se borraron registros.";
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = (DataView)SqlDataBorrar.Select(DataSourceSelectArguments.Empty);
            if (dv != null && dv.Count > 0)
            {
                DataRowView row = dv[0];
                DropDownList1.SelectedValue = row["descripcion"].ToString();
                TextBox1.Text = row["monto"].ToString();
                RadioButtonList1.SelectedValue = row["tipo"].ToString();
            }
            completarTabla();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlDataSourceUpdate.UpdateParameters["id"].DefaultValue = DropDownList2.SelectedValue;
            int result = SqlDataSourceUpdate.Update();

            if (result > 0)
            {

                Label1.Text = "Actualizado " + result.ToString() + " registro.";
                completarTabla();
                TextBox2.Text = string.Empty;
            }
            else
            {
                Label1.Text = "No se actualizaron registros.";
            }
        }
    }
}