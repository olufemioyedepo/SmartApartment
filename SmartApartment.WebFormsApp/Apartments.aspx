<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Apartments.aspx.cs" Inherits="SmartApartment.WebFormsApp.Apartments" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Apartments</h3>
    <hr />
    <div class="row">
        <div  class="col col-12">
            <div class="table-responsive">
                <div class="table-responsive">
                            <table class="table table-striped table-bordered dataTable" role="grid">
                                <thead>
                                    <tr class="no-wrap">
                                        <th>Name</th>
                                        <th>Apartment Type</th>
                                        <th>Address</th>
                                        <th>Description</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptItems" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("Name")%></td>
                                                <td><%#Eval("ApartmentType")%></td>
                                                <td><%#Eval("Address")%></td>
                                                <td><%#Eval("Description")%></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
            </div>
        </div>
    </div>

</asp:Content>

