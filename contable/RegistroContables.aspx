<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroContables.aspx.cs" Inherits="contable.RegistroContables" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Inicio.aspx">Inicio</asp:HyperLink>
            <br />
            <br />
            Ingresar Monto:<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Seleccion Cuenta:<br />
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="descripcion" DataValueField="id">
            </asp:DropDownList>
            <br />
            <br />
            Ingrese Tipo:<br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Text="Debe" Value="Debe"></asp:ListItem>
                <asp:ListItem Text="Haber" Value="Haber"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Agregar" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Modificar" OnClick="Button2_Click" />
            &nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" DataSourceID="SqlDataSource1" DataTextField="descripcion" DataValueField="id">
            </asp:DropDownList>
&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Borrar" />
            <br />
            <br />
            <asp:Table ID="Table1" runat="server">
            </asp:Table>
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:contable %>" SelectCommand="SELECT * FROM [Cuentas]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:contable %>" DeleteCommand="DELETE FROM [RegistrosContables] WHERE [id] = @id" InsertCommand="INSERT INTO [RegistrosContables] ([idCuenta], [monto], [tipo]) VALUES (@idCuenta, @monto, @tipo)" SelectCommand="SELECT * FROM [RegistrosContables]" UpdateCommand="UPDATE RegistrosContables SET idCuenta = @idCuenta, monto = @monto, tipo = @tipo WHERE (id = @id)">
                <DeleteParameters>
                    <asp:ControlParameter ControlID="DropDownList2" Name="id" PropertyName="SelectedValue" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="idCuenta" Type="Int32" />
                    <asp:Parameter Name="monto" Type="Int32" />
                    <asp:Parameter Name="tipo" Type="Boolean" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="idCuenta" PropertyName="SelectedValue" Type="Int32" />
                    <asp:ControlParameter ControlID="TextBox1" Name="monto" PropertyName="Text" Type="Int32" />
                    <asp:ControlParameter ControlID="RadioButtonList1" Name="tipo" PropertyName="SelectedValue" Type="Boolean" />
                    <asp:Parameter Name="id" />
                </UpdateParameters>
            </asp:SqlDataSource>
            &nbsp;<asp:SqlDataSource ID="DropDpwlisTable" runat="server" ConnectionString="<%$ ConnectionStrings:contable %>" DeleteCommand="DELETE FROM [Cuentas] WHERE [id] = @id" InsertCommand="INSERT INTO [Cuentas] ([descripcion]) VALUES (@descripcion)" SelectCommand="SELECT Cuentas.id, Cuentas.descripcion, RegistrosContables.monto, RegistrosContables.tipo FROM Cuentas INNER JOIN RegistrosContables ON Cuentas.id = RegistrosContables.idCuenta" UpdateCommand="UPDATE [Cuentas] SET [descripcion] = @descripcion WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="descripcion" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataBorrar" runat="server"  ConnectionString="<%$ ConnectionStrings:contable %>" SelectCommand="SELECT * FROM [RegistrosContables] WHERE ([id] = @id)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList2" Name="id" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceUpdate" runat="server" ConnectionString="<%$ ConnectionStrings:contable %>" DeleteCommand="DELETE FROM [Cuentas] WHERE [id] = @id" InsertCommand="INSERT INTO [Cuentas] ([descripcion]) VALUES (@descripcion)" SelectCommand="SELECT * FROM [Cuentas]" UpdateCommand="UPDATE [Cuentas] SET [descripcion] = @descripcion WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="descripcion" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:ControlParameter ControlID="TextBox2" Name="descripcion" PropertyName="Text" Type="String" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
        </div>
    </form>
</body>
</html>
