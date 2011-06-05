<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SubmissionView
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>SubmissionView</h2>
    <%
        object successful;
        var s = ViewData.TryGetValue("ShowSuccess", out successful);
        if (s == true && (bool)successful) {%>
        <p>Your submission was successful.  It will be posted after it is peer reviewed.  Thank You.</p>
    <% } %>

    <% Html.ActionLink("Create A New Case Entry", "Submit", "Submission"); %>
</asp:Content>
