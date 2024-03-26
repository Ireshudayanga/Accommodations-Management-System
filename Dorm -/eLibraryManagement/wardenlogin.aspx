<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="wardenlogin.aspx.cs" Inherits="eLibraryManagement.wardenlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <%-- custom css not working for logging button ... --%>
 <style>
     .button {
         background-color: #04AA6D;
         color: white;
         padding: 7px ;
         margin-top: 15px;
         border: none;
         cursor: pointer;
         width: 75%;
         border-radius: 10px;
         
     }

     .button:hover{
          background-color:#2f692f;
      }

     .signup{
         background-color:#0094ff;
         color: white;
         padding: 7px ;
         margin: 4px 0;
         border: none;
         cursor: pointer;
         width: 75%;
         border-radius: 10px;
     }
     .container{
         margin:48px;
     }
     .signup:hover{
         background-color:#316285;
     }
 </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
    <div class="row">
     <div class="col-md-8 mx-auto ">
     <div class="card">
         <div class="card-body">
             <div class="row">
                 <div class="col">
                     <center>
                         <img src="images/user%20Icon.png" width="90px"/>
                     </center>
                 </div>
             </div>
             <br />
             <div class="row">
                 <div class="col">
                     <center>
                         <h3>Warden Login</h3>
                     </center>
                 </div>
             </div>
             <div class="row">
                 <div class="col">
                     <hr />
                  </div>
             </div>
             <div class="row">
                 <div class="col mx-auto">

                   <label> Warden Id</label>
                    <center>
                     <div class="form-group">
                         <asp:TextBox CssClass="form-control" ID="TextBox1"
                          runat="server" width="500px" placeholder=""></asp:TextBox>
                     </div>
                        </center>
                     <label>Password</label>
                     <center>
                     <div class="form-group">
                         <asp:TextBox CssClass="form-control" ID="TextBox2"
                          runat="server" placeholder=""  width="500px" TextMode="Password"></asp:TextBox>
                     </div>
                    </center>
                     <div class="form-group">
                         <center>
                         <asp:Button class="button" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                        
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
