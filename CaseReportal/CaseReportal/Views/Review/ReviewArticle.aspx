<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CaseReportal.Models.ReviewArticleModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ReviewArticle
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Review Article - <%=Html.DisplayText(Model.Title)%></h2>
    <p><%= Html.DisplayText(Model.Case) %></p>
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Could not save review. Please correct the errors and try again.") %>
        <div>
            <fieldset>
                <legend>Case Report Review</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.ReviewComment) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.ReviewComment)%>
                    <%: Html.ValidationMessageFor(m => m.ReviewComment)%>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Accepted) %>
                </div>
                <div class="editor-field">
                    True: <%: Html.RadioButtonFor(m => m.Accepted, true) %>
                    False: <%: Html.RadioButtonFor(m => m.Accepted, false) %>
                    <%: Html.ValidationMessageFor(m => m.Accepted) %>
                </div>
                
                <p>
                    <input type="submit" value="Submit" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
