<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnableAc.aspx.cs" Inherits="Portal_Apogee.UnableAc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        table {
            max-width: none;
            background-color: transparent;
            border-collapse: collapse;
            border-spacing: 0;
        }

        .table {
            width: 100%;
            height: auto;
            margin-bottom: 20px;
        }

            .table th, .table td {
                width: auto;
                height: auto;
                padding: 8px;
                line-height: 20px;
                text-align: left;
                vertical-align: top;
                border-top: 1px solid #dddddd;
            }

            .table th {
                width: auto;
                height: auto;
                font-weight: bold;
            }

            .table thead th {
                vertical-align: bottom;
            }
    </style>

    <h1>Re-use Access Codes</h1>
    <br />
    <br />
    <label>Search: </label>
    <input type="text" name="txt_ac" value="" />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped"></asp:GridView>


</asp:Content>
