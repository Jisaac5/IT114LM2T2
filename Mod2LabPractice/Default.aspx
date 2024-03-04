<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mod2LabPractice.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Twitter clone practice</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--<asp:Repeater runat="server" ID="PostRepeater">
                <ItemTemplate>
                    <div>
                        <p><%# Eval("Content")  %></p>
                        <p><%# Eval("PostedBy")  %></p>
                        <p><%# Eval("PostedOn")  %></p>
                        <br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>--%>

            <% foreach (var post in posts)%>
            <%{ %>
            <% if (post.PostedBy !="joblipat")%>
            <%{ %>
                <div>
                    <p><%= post.Content %></p>
                    <p><%= post.PostedBy %></p>
                    <p><%= post.PostedOn %></p>
                    <br />
                </div>
            <%} %>
            <%else%>
            <%{  %>
            <div>
                <p>You are not allowed to see this</p>
                <br />
            </div>
            <%} %>
            <%} %>
        </div>
    </form>
</body>
</html>
