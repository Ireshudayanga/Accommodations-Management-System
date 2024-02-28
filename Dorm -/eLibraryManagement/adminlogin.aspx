<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="eLibraryManagement.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

    .container{
       margin:48px 80px;
     }

    .button {
    background-color: #04AA6D;
    color: white;
    padding: 7px ;
    margin-top: 15px;
    border: none;
    cursor: pointer;
    width: 50%;
    border-radius: 10px;
    
     }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container">
     <div class="row">
         <div class="col-md-6 mx-auto">
             <div class="card">
                 <div class="card-body">
                     <div class="row">
                         <div class="col">
                             <center>
                                 <img src="images/admin%20icon.png" width="100px" />
                             </center>
                         </div>
                     </div>
                     <br />
                     <div class="row">
                         <div class="col">
                             <center>
                                 <h3>Admin Login</h3>
                             </center>
                         </div>
                     </div>
                     <div class="row">
                         <div class="col">
                             <hr />
                          </div>
                     </div>
                     <div class="row">
                         <div class="col">
                             <label> Username</label>
                             <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox1"
                                  runat="server" placeholder=""></asp:TextBox>
                             </div>
                             <label>Password</label>
                             <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox2"
                                  runat="server" placeholder="" TextMode="Password"></asp:TextBox>
                             </div>
                             <div class="form-group">
                                 <center>
                                 <asp:Button class="button" ID="Button1" runat="server" Text="Login" />
                                 </center>
                             </div>
                         </div>
                     </div>
                 </div>
             </div>
             <div class="homelink">
             <a href="home.aspx" class="nounderline"><< Back to Home</a>
             </div>
         </div>
     </div>
 </div>
    
</asp:Content>
