<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="wardenlocationmanagement.aspx.cs" Inherits="eLibraryManagement.wardenlocationmanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <style>   
     
    /* Custom CSS */
.my-custom-margin {
    margin: 13px;
}


.my-custom-btncolor {
  background-color:#2f692f;
}
.my-custom-btncolorwerning {
  background-color:#f1df14;
  border:none;
  
}
.my-custom-btncolordeactive {
  background-color:red;
  border:none;
}

.my-custom-btncolor:hover {
  background-color:#102f10;
}
.my-custom-btncolorwerning:hover {
  background-color:#e1d872;
  border:none;
}
.my-custom-btncolordeactive:hover {
  background-color:#881a1a;
  border:none;
}



.my-custom-padding {
    margin-left:80px;
}

.my-custom-button{
    width:130px;
}

.my-custom-buttonpermentdelet{
    width:535px;
}

.my-custom-button-status{
    width:40px;
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
     <div class="col-md-12 ">
         <div class="card">
             <div class="card-body">

                  <div class="row">
                     <div class="col">
                         <center>
                             <h3>landloards Details</h3>
                         </center>
                     </div>
                 </div>

                 <div class="row">
                     <div class="col">
                         <center>
                             <img src="images/user%20Icon.png" width ="80px"/>
                         </center>
                     </div>
                 </div>
            
                

                 <div class="row my-custom-margin">
                     <div class="col">
                         <hr />
                      </div>
                 </div>

                 <div class="row my-custom-margin ">
                     <div class="col-md-5 mx-auto ">
                         <label>Member ID</label>
                         <div class="form-group">
                             <div class="input-group">
                             <asp:TextBox CssClass="form-control" ID="TextBox1"
                              runat="server" placeholder="Id"></asp:TextBox>
                             <asp:Button class="btn  btn-block btn-primary" ID="Button1" runat="server" Text="Search" OnClick="Button1_Click1" />
                             </div>
                         </div>
                     </div>
                    
                     <div class="col-md-5 mx-auto">
                         <label>Account Status</label>
                         <div class="form-group ">
                             <div class="input-group ">
                                 <asp:TextBox CssClass="form-control" ID="TextBox7"
                                 runat="server" placeholder="Status" ReadOnly="True" Width="70px"></asp:TextBox>

                                 <asp:LinkButton class="btn  btn-block btn-success my-custom-button-status my-custom-btncolor mr-1" 
                                     ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="fas fa-check-circle "></i></asp:LinkButton>

                                

                                 <asp:LinkButton class="btn  btn-block btn-success my-custom-button-status my-custom-btncolordeactive mr-1" 
                                     ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                              </div>
                         </div>
                     </div>
                 </div>


                  <div class="row mx-auto">
                     
                      <div class="col-md-4 mx-auto">
                          <label>Contact Number</label>
                         <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox4"
                              runat="server" placeholder="" ReadOnly="True" ></asp:TextBox>
                          </div>
                      </div>
                      <div class="col-md-5 mx-auto">
                          <label>Email</label>
                      <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox8"
                              runat="server" placeholder="" ReadOnly="True" ></asp:TextBox>
                          </div>
                      </div>                       
                  </div>    
                 
            
                 
               
                 
                   

                 <br />

                 <div class="row my-custom-margin">
                     <div class="col-md-8 mx-auto">
                         <center>
                         <asp:Button class="btn btn-lg btn-block btn-danger my-custom-buttonpermentdelet" ID="Button4" runat="server" Text="Permanently Delete advertisement " OnClick="Button4_Click" />
                         </center>
                     </div>
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
