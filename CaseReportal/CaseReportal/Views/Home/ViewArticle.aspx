<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CaseReportal.Model.Entities.Article>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData.Model.Title %>: </h2>
    <h3>By: <%: ViewData.Model.User.LastName %>,  <%: ViewData.Model.User.FirstName %></h3>

    <p><%: ViewData.Model.Case %></p>
</asp:Content>
