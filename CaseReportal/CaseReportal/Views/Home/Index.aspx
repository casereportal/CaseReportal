<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CaseReportal.Models.HomeViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Articles: </h2>
    <% if (ViewData.Model != null && ViewData.Model.Articles != null) {%>  
        <% foreach (var article in ViewData.Model.Articles) {%>
        <p>Article Title: <%= article.Title %> </p>
        <p>Publish Date: <%= article.Published %> </p>
        <p>Author: <%= article.User.LastName %>, <%= article.User.FirstName %> </p>
        <% } %>
    <% } %>
</asp:Content>
