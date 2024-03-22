<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="eLibraryManagement.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .error-message {
            text-align: center;
            margin-top: 20%;
            font-size: 24px;
            color: red;
            margin-bottom: 13%;
            font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            font-weight: bold;
        }
         .signup{
            background-color:#538a48;
            color: white;
            padding: 5px ;
            margin: 4px 0;      
            border: none;
            cursor: pointer;
            width: 10%;
            border-radius: 10px;
         }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="error-message">
        <h1>You should register as a User to see page context.</h1>
         <br />
             <div class="form-group">
                <center>
                    <a href="signup.aspx">
                        <input class="signup" id="Button2" type="button" value="Sign Up" />
                    </a>
                </center>
</div>

    </div>
     
</asp:Content>
