<%@ Page Title="Apartment Types" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApartmentTypes.aspx.cs" Inherits="SmartApartment.WebFormsApp.ApartmentTypes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Apartment Types</h3>
    <hr />

    <div class="row">
        <div  class="col col-12">
            <div class="table-responsive">
                <div class="table-responsive">
                            <table class="table table-striped table-bordered dataTable" role="grid">
                                <thead>
                                    <tr class="no-wrap">
                                        <th>Name</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptItems" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("Name")%></td>
                                                
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
