<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CaseReportal.Models.SubmissionModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Submit A New Case Report</h2>
        <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.") %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Title) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Title) %>
                    <%: Html.ValidationMessageFor(m => m.Title) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Case) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Case) %>
                    <%: Html.ValidationMessageFor(m => m.Case) %>
                </div>
                
                <p>
                    <input type="submit" value="Submit" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
