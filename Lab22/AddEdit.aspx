<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEdit.aspx.cs" Inherits="Lab22.AddEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add/Edit Masina</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f2f2f2;
        }
        #container {
            width: 50%;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        #form1 div {
            margin-bottom: 15px;
        }
        #form1 label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        #form1 input[type="text"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
            box-sizing: border-box;
        }
        #form1 .btn {
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }
        #form1 .btn:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <div id="container">
        <form id="form1" runat="server">
            <div>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblNume" runat="server" Text="Nume:"></asp:Label>
                <asp:TextBox ID="txtNume" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblCuloare" runat="server" Text="Culoare:"></asp:Label>
                <asp:TextBox ID="txtCuloare" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblAnFabricare" runat="server" Text="An Fabricare:"></asp:Label>
                <asp:TextBox ID="txtAnFabricare" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn" />
            </div>
        </form>
    </div>
</body>
</html>
