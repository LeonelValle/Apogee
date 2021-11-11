<%@ Page Title="Upload Access Codes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="Portal_Apogee.Upload" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            width: 100%;
            margin: 5px;
        }

        .table-condensed tr th {
            border: 0px solid #6e7bd9;
            color: white;
            background-color: #6e7bd9;
        }

        .table-condensed, .table-condensed tr td {
            border: 0px solid #000;
        }

        tr:nth-child(even) {
            background: #f8f7ff
        }

        tr:nth-child(odd) {
            background: #fff;
        }

        #dropSection {
            height: 300px;
            width: 600px;
            background-color: skyblue;
        }

        #btnUpload {
            display: none;
        }

        .active {
            background-color: yellow !important;
        }

    </style>

    <link rel="stylesheet" type="text/css" href="styles.css" />
    <script type="text/javascript" src="Scripts/scripts.js"></script>
   
    <br />
    <br />
    <br />

    <%--<asp:GridView ID="GridView1" runat="server"></asp:GridView>--%>

    <div>
        <div>
            <div>
                <!-- ADD A FILE UPLOAD CONTROL AND A BUTTON TO EXECUTE. -->
                Select a file:
                <asp:Button ID="btn_Upload" runat="server" Text="Upload" OnClick="btn_Upload_Click"   />
                <br />
                <asp:FileUpload ID="FileUpload" runat="server" onchange="this.form.submit();" />
                <br />

                <br />

            </div>



            <br />
            <br />
            <br />
            <!-- ADD A GRIDVIEW CONTROL. -->
            <div style="text-align: -webkit-center;">
                <asp:GridView ID="dv_Accesscode" CssClass="table-condensed" runat="server" EmptyDataText="NO DATA!">
                </asp:GridView>

            </div>
        </div>
    </div>


</asp:Content>
