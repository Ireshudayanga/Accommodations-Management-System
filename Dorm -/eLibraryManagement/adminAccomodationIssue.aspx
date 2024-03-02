<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminAccomodationIssue.aspx.cs" Inherits="eLibraryManagement.adminAccomodationIssue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
<style>   
     
    /* Custom CSS */
.my-custom-margin {
    margin: 13px;
}

.my-custom-padding {
    margin-left:80px;
}

.my-custom-button{
    width:130px;
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

  <div class="container-fluid">
    <div class="row">
        <div class="col-md-6 ">
            <div class="card">
                <div class="card-body">

                     <div class="row">
                        <div class="col">
                            <center>
                                <h3>Accommodation Issues</h3>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <img src="images/accommodation%20Issue.jpg" width="100px" />
                            </center>
                        </div>
                    </div>
               
                   

                    <div class="row my-custom-margin">
                        <div class="col">
                            <hr />
                         </div>
                    </div>

                    <div class="row my-custom-margin">
                        <div class="col-md-6 ">
                            <label>Accommodation ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox1"
                                 runat="server" placeholder="Id"></asp:TextBox>
                                <asp:Button class="btn  btn-block btn-primary" ID="Button1" runat="server" Text="Search" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Publisher ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox3"
                                runat="server" placeholder="Id" ></asp:TextBox>
                                <asp:Button class="btn  btn-block btn-primary" ID="Button5" runat="server" Text="Search" />
                        
                                </div>
                            </div>
                        </div>
                    </div>

                     <div class="row my-custom-margin">
                         <div class="col-md-6 ">
                            <label>Owner Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox2"
                                runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                          </div>
                         </div>
                         <div class="col-md-6">
                             <label>Resident Name</label>
                            <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox4"
                                 runat="server" placeholder="" ReadOnly="True" ></asp:TextBox>
                             </div>
                         </div>
                     </div>     
                    
                      <div class="row my-custom-margin">
                        <div class="col-md-6 ">
                            <label>Issue Date</label>
                             <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox5"
                              runat="server" placeholder="" TextMode="Date"></asp:TextBox>
                         </div>
                          </div>
                          <div class="col-md-6">
                              <label>End Date</label>
                          <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox6"
                                runat="server" placeholder="" TextMode="Date"  ></asp:TextBox>
                          </div>
                       </div>
                    </div>  

                    <br />

                    <div class="row my-custom-margin">

                        <div class="col-md-6 ">
                            <asp:Button class="btn btn-lg btn-block btn-success my-custom-button my-custom-padding " ID="Button2" runat="server" Text="Issue" />
                        </div>
                        <div class="col-md-6">
                            <asp:Button class="btn btn-lg btn-block btn-danger my-custom-button" ID="Button4" runat="server" Text="Return" />
                        </div>
                    </div>

                    
                       
                    <br />
                </div>
            </div>
            <div class="homelink my-custom-margin">
            <a href="home.aspx" class="nounderline"><< Back to Home</a>
            </div>
        </div>


        <%--Second Column --%>     <%--Second Column --%>    <%--Second Column --%>


     <div class="col-md-6 ">
    <div class="card">
        <div class="card-body">
            <div class="row">
                <div class="col">
                    <center>
                        <h4>Details</h4>
                    </center>
                </div>
            </div>
            <br />
           

            <div class="row">
                <div class="col">
                    <hr />
                 </div>
            </div>

            <div class="row">
                <div class ="col">
                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server">

                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div class="homelink my-custom-margin">
    <a href="home.aspx" class="nounderline"><< Back to Home</a>
    </div>
</div>


    </div>
</div>

</asp:Content>
