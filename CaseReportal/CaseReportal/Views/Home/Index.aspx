<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="CaseReportal.Model.Entities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"]%></h2>
    <% foreach (var item in (IEnumerable<User>)ViewData["Users"])
       {%>
    <p>User First Name: <%= item.Id %> </p>
    <p>User First Name: <%= item.FirstName%> </p>
    <p>User First Name: <%= item.LastName%> </p>
    <p>User First Name: <%= item.Email%> </p>
    <p>User First Name: <%= item.Password%> </p>
    <p>User First Name: <%= item.Nonce%> </p>
    <% } %>
</asp:Content>
