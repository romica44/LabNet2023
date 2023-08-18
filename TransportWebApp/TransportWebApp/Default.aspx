<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TransportWebApp.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transport Web App</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            margin: 0;
            padding: 0;
            background-color: #FFC0CB; /* Cambiar el fondo a rosa claro */
        }

        .container {
            width: 80%;
            margin: auto;
            padding: 20px;
            background-color: #f5f5f5;
            border-radius: 10px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        }

        .transport-lists {
            display: flex; 
            justify-content: center;
            margin-top: 20px;
        }

        .list-box {
            width: 40%; 
            min-height: 150px;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color: white;
            box-shadow: 0px 0px 5px rgba(0, 0, 0, 0.1);
        }

        h1 {
            color: #333;
        }

        label {
            display: block;
            margin-bottom: 5px;
        }

        input[type="text"],
        select {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        button {
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        button:hover {
            background-color: #0056b3;
        }

        .error {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Transport Web App</h1>
            <p>Ingrese los datos del transporte</p>
            <label for="ddlTipoTransporte">Elija tipo de transporte:</label>
            <asp:DropDownList ID="ddlTipoTransporte" runat="server"></asp:DropDownList>
            <br />
            <label for="txtNumeroTransporte">Número de transporte:</label>
            <asp:TextBox ID="txtNumeroTransporte" runat="server"></asp:TextBox>
            <br />
            <label for="txtCantidadPasajeros">Cantidad de pasajeros:</label>
            <asp:TextBox ID="txtCantidadPasajeros" runat="server"></asp:TextBox>
            <br />
            <asp:Button id="btnAgregar" runat="server" onclick="BtnAgregarTransporte" Text="Agregar"></asp:Button>
            <br />
            <br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="error"></asp:Label>
        </div>
        <div class="transport-lists">
            <div class="list-box">
                <asp:ListBox ID="lstTaxis" runat="server" style="height: 140px;"></asp:ListBox>
            </div>
            <div class="list-box">
                <asp:ListBox ID="lstOmnibus" runat="server" style="height: 140px;"></asp:ListBox>
            </div>
        </div>
    </form>
</body>
</html>
