<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="eLibraryManagement.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

/* Custom CSS */
.my-custom-margin {
    margin: 13px;
}

.margin{
    margin:5px;
}

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
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
    <div class="row">
        <div class="col-md-8 mx-auto">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <img src="images/user%20Icon.png" width="80px"/>
                            </center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Member Sign Up</h3>
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <hr />
                         </div>
                    </div>

                    <div class="row my-custom-margin">
                        <div class="col-md-6">
                            <label>Full Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox1"
                                 runat="server" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Date of Birth</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox3"
                                runat="server" placeholder="" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                    </div>



                    <div class="row my-custom-margin">
                        <div class="col-md-6">
                            <label>Contact No:</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox2"
                                runat="server" placeholder="" TextMode="Phone"></asp:TextBox>
                         </div>
                        </div>
                        <div class="col-md-6">
                            <label>Email</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox4"
                                runat="server" placeholder="" TextMode="Email"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    
                    <div class="row my-custom-margin">
                        <div class="col-md-4">
                            <label>State</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox5"
                                runat="server" placeholder="" ></asp:TextBox>
                         </div>
                        </div>
                        <div class="col-md-4">
                            <label>City</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox6"
                                runat="server" placeholder="" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Postal Code</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox7"
                             runat="server" placeholder="" ></asp:TextBox>
                         </div>
                       </div>
                    </div>


                    <div class="row my-custom-margin">
                        <div class="col-md-12">
                            <label>Full Address:</label>
                            <div class="form-group">
                             <asp:TextBox CssClass="form-control" ID="TextBox8"
                                runat="server" placeholder="" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                   </div>

                    <br />

                    <div class="row my-custom-margin">
                        <div class="col-md-12">
                            <center>
                            <span class="badge rounded-pill text-bg-primary">Login Credential</span>
                            </center>
                         </div>
                    </div>

                  
                    
                    <div class="row my-custom-margin ">
                        <div class="col-md-6">
                            <label class="margin">Username: </label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox9"
                                 runat="server" placeholder="usrename"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label class="margin">Password</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox10"
                                runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group  my-custom-margin">
                        <center>
                        <asp:Button class="button" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" />
                        </center>
                    </div>
                    <br />
                </div>
            </div>
            <div class="homelink my-custom-margin">
            <a href="home.aspx" class="nounderline"><< Back to Home</a>
            </div>
        </div>
    </div>
</div>

</asp:Content>
