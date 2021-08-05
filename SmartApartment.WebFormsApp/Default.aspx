<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartApartment.WebFormsApp._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //alert('Hello');
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
             <h2>Error</h2>
            <p>
                <input class="form-control" type="text" id="errorInput" />
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Access Token</h2>
            <p>
                <input class="form-control" type="text" id="accessTokeInput" />
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>ID Token Hosting</h2>
            <p>
                <input class="form-control" type="text" id="idTokenInput" />
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

    <div class="row">
        <div class="col col-12">
            <div id="form1" runat="server">
                <div class="d1">
                    <h1>Id Token</h1>
                    <h3>Decoded Header</h3>
                    <p class="monobox">
                        <asp:TextBox ID="boxHeader" runat="server" TextMode="MultiLine" Width="50em" Height="8em" ReadOnly="true"></asp:TextBox>
                    </p>
                    <h3>Decoded Payload</h3>
                    <table>
                        <tr>
                            <td>
                                <p class="monobox">
                                    <asp:TextBox ID="boxPayload" runat="server" TextMode="MultiLine" Width="50em" Height="22em" ReadOnly="true"></asp:TextBox>
                                </p>
                            </td>
                            <td>
                                <asp:Image ID="imgPayload" runat="server"/></td>
                        </tr>
                    </table>
                    <h3>Raw Signature</h3>
                    <p class="monobox">
                        <asp:TextBox ID="boxSignature" runat="server" TextMode="MultiLine" Width="50em" Height="12em" ReadOnly="true"></asp:TextBox>
                    </p>
                    <p><a href="index.aspx">Back to Landing Page</a></p>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
