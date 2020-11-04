<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Social_Media_Web_Site.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE-edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title> Home </title>
    <link href="css/home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="header-container">
                <div class="left">
                     <h1 runat="server" > iMedia </h1>
                </div>
                 <div class="right">
                     <asp:LinkButton ID="logOutBtn" CssClass="logout" runat="server" OnClick="logOutBtn_Click">Log Out</asp:LinkButton>
                 </div>
            </div>
        </div>
         <div class="content">
            <div class="right-side">
                <div class="profile">
                    <asp:Image src="images/user.png" cssClass="dp" ID="Image1" runat="server" />
                    <asp:Label ID="userName" cssClass="userName" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
              <div class="left-side">
                  <div class="create-post">
                      <asp:TextBox ID="addPost" TextMode="MultiLine" Placeholder="Write something..." cssClass="addPost" runat="server"></asp:TextBox>
                      <asp:FileUpload ID="FileUpload1" cssClass="addPostImage" runat="server" />
                      <asp:Button ID="addPostBtn" cssClass="addPostBtn" runat="server" Text="Post" />
                      
                  </div>

                  <div class="posts">
                      
                  </div>
              </div>
        </div>

    </form>
</body>
</html>
