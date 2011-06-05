<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CaseReportal.Models.ReviewModels>" %>
<%@ Import Namespace="CaseReportal.Model.Entities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <%
        object successful;
        var s = ViewData.TryGetValue("ShowSuccess", out successful);
        if (s == true && (bool)successful) {%>
        <p>Your review was successfully received.  Thank You.</p>
    <% } %>

    <h2>Case Reports Pending Review</h2>
    <% foreach (var article in ViewData.Model.Articles) {%>
    <p>Case: <%= article.Title %> <%= Html.ActionLink("Review Article", "ReviewArticle", "Review", new { articleId = article.Id }, new {})%></p> 
    <%} %>
</asp:Content>
