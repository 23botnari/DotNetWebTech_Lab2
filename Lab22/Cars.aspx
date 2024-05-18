<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="Lab22.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Car List</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f2f2f2;
        }
        #container {
            width: 80%;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            text-align: center;
            margin-bottom: 20px;
            color: #007bff;
        }
        h2 {
            text-align: center;
            margin-bottom: 20px;
        }
        #btnAddNew {
            display: block;
            margin: 20px auto;
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        #btnAddNew:hover {
            background-color: #0056b3;
        }
        /* GridView styles */
        #GridView1 {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            margin-top: 20px;
        }
        #GridView1 th, #GridView1 td {
            padding: 8px;
            border-bottom: 1px solid #ddd;
            text-align: left;
        }
        #GridView1 th {
            background-color: #007bff;
            color: #fff;
        }
        #GridView1 tr:nth-child(even) {
            background-color: #f2f2f2;
        }
        /* GridView command field styles */
        .gridview-command:last-child{
            background-color:red;
        }
        .gridview-command:first-child{
            background-color:orange;
        }
        .gridview-command {
            width: 80px;
            text-align: center;
               display: inline-block;
            padding: 6px 12px;
         margin: 0 5px;
         text-decoration: none;
         color: #fff;
           background-color: #007bff;
          border: 1px solid transparent;
          border-radius: 4px;
       cursor: pointer;
        }
       
        .gridview-command:hover {
            background-color: #0056b3;
            border-color: #0056b3;
        }
    </style>
</head>
<body>
    <h1>Laboratorul Restantierului</h1>
    <form id="form1" runat="server">
        <div id="container">
            <h2>Car List</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" InsertVisible="False" />
                    <asp:BoundField DataField="nume" HeaderText="Nume" />
                    <asp:BoundField DataField="culoare" HeaderText="Culoare" />
                    <asp:BoundField DataField="an_fabricare" HeaderText="An Fabricare" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ControlStyle-CssClass="gridview-command" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
        </div>
    </form>
</body>
</html>
