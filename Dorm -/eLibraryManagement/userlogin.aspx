<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="eLibraryManagement.userlogin" %>
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
            <div class="col-md-6 ">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="images/user%20Icon.png" width="110px"/>
                                </center>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Member Login</h3>
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
                                    <asp:Button class="button" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                                    </center>
                                </div>
                                <div class="form-group">
                                    <center>
                                        <a href="signup.aspx">
                                    <input class="signup" id="Button2" type="button" value="Sign Up" />
                                        </a>
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

            <div class="col-md-6 ">
    <div class="card">
        <div class="card-body">
            <div class="row">
                <div class="col">
                    <center>
                        <img src="images/user%20Icon.png" width="110px"/>
                    </center>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col">
                    <center>
                        <h3>Landloards Login</h3>
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
                        <asp:TextBox CssClass="form-control" ID="TextBox3"
                         runat="server" placeholder=""></asp:TextBox>
                    </div>
                    <label>Password</label>
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="TextBox4"
                         runat="server" placeholder="" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <center>
                        <asp:Button class="button" ID="Button3" runat="server" Text="Login" OnClick="Button3_Click" />
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
