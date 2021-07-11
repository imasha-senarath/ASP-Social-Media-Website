<%@ Page Language="C#" AutoEventWireup="true" CodeFile ="welcome.aspx.cs" Inherits="Social_Media_Web_Site.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE-edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title> SIgn Up</title>
    <link href="css/welcome.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">     
        <div class="header">
            <div class="header-container">
                <h1>iMedia</h1>
            </div>
        </div>
        <div class="content">
            <div class="login">
                <h1>Welcome Back</h1>
                <asp:TextBox ID="loginUserEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" validationgroup="LoginInfoGroup" CssClass="error" runat="server" ErrorMessage="Email is Required." ControlToValidate="loginUserEmail"></asp:RequiredFieldValidator>
                <asp:TextBox ID="loginUserPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" validationgroup="LoginInfoGroup" CssClass="error" runat="server" ErrorMessage="Password is Required." ControlToValidate="loginUserPassword"></asp:RequiredFieldValidator>
                <asp:Button ID="loginBtn" runat="server" validationgroup="LoginInfoGroup" Text="Log In" OnClick="loginBtn_Click"/>
                 <asp:Label ID="loginErrorMsg" runat="server" Text="" CssClass="error"></asp:Label>
            </div>

            <div class="signup">
                <h1>Get Started with iMedia</h1>
                <asp:TextBox ID="signUpUserName" runat="server" placeholder="Username"></asp:TextBox>
                <asp:TextBox ID="signUpUserEmail" runat="server" placeholder="Email" OnTextChanged="userEmail_TextChanged" TextMode="Email"></asp:TextBox>
                <asp:TextBox ID="signUpUserPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                <asp:Label ID="signUpErrorMsg" runat="server" Text="" CssClass="error"></asp:Label>
                <asp:Button ID="signUpBtn" runat="server" Text="Sign Up" OnClick="signUpBtn_Click" />
                <p>By clicking signup button, you agree to our Terms of Services and Privacy Policy.</p>
            </div>
        </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</body>
</html>
