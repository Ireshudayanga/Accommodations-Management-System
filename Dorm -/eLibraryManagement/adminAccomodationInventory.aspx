<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminAccomodationInventory.aspx.cs" Inherits="eLibraryManagement.adminAccomodationInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!--
<script type ="text/javascript">

    function readURL(input) {

        if (input.files && input.files[0])
        {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#imgview').attr('src', e.target.result);
            };

            reader.readAsDataURL(input.files[0]);
        }

    }

</script>

    -->


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
    width:160px;
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
        <div class="col-md-6 ">
            <div class="card">
                <div class="card-body">

                     <div class="row">
                        <div class="col">
                            <center>
                                <h3>Accommodation Details</h3>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <img src="images/inventory.jpg" width ="300px"/>
                            </center>
                        </div>
                    </div>
               

                    <div class="row my-custom-margin">
                        <div class="col">
                            <hr />
                         </div>
                    </div>

                    <div class="row my-custom-margin">
                        <div class="col">
                            <asp:FileUpload onchange="readURL(this);" CssClass="form-control" ID="FileUpload1" runat="server" />
                        </div>
                    </div>

                    <div class="row my-custom-margin ">
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
                            <label>Owner Name</label> 
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox3"
                                runat="server" placeholder="Name" ></asp:TextBox>
                            </div>
                        </div>
                    </div>


                     <div class="row my-custom-margin">
                         <div class="col-md-4 ">
                            <label>Area</label>
                             <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                 <asp:ListItem Text="Pitpana" Value="Pitpana" />
                                 <asp:ListItem Text="Maithridasa Road" Value="Maithridasa Road" />
                                 <asp:ListItem Text="Temple Junction" Value="Temple Junction" />
                                 <asp:ListItem Text="School Junction" Value="School Junction" />
                                 <asp:ListItem Text="~600m to NSBM" Value="~600m to NSBM" />
                             </asp:DropDownList>
                          </div>

                         <div class="col-md-4 ">
                            <label>Time Period</label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
                                    <asp:ListItem Text="1 month - 3 month" Value="0" />
                                    <asp:ListItem Text="1 month - 6 month" Value="1" />
                                    <asp:ListItem Text="1 month - 9 month" Value="2" />
                                    <asp:ListItem Text="For year" Value="3" />
                                    <asp:ListItem Text="More than year" Value="4" />
                                </asp:DropDownList>
                            </div>

                         <div class="col-md-4">
                             <label>Contact Number</label>
                            <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox4"
                                 runat="server" placeholder="" ></asp:TextBox>
                             </div>
                         </div>              
                     </div>    
                    
                    <div class="row my-custom-margin">
                        <div class="col-md-4 ">
                        <label>State</label>
                        <div class="form-group">
                             <asp:TextBox CssClass="form-control" ID="TextBox9"
                             runat="server" placeholder="" ></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                            <label>City</label>
                        <div class="form-group">
                             <asp:TextBox CssClass="form-control" ID="TextBox10"
                             runat="server" placeholder=""  ></asp:TextBox>
                            </div>
                     </div>
                        <div class="col-md-4">
                            <label>Postal Code</label>
                     <div class="form-group">
                             <asp:TextBox CssClass="form-control" ID="TextBox11"
                             runat="server" placeholder=""  ></asp:TextBox>
                         </div>
                     </div>                       
                    </div>  
                    
                    <div class="row my-custom-margin">
                        <div class="col-md-12">
                            <label>Full Address:</label>
                            <div class="form-group">
                             <asp:TextBox CssClass="form-control" ID="TextBox12"
                                runat="server" placeholder="" TextMode="MultiLine" ></asp:TextBox>
                            </div>
                        </div>
                   </div>
                    
                      

                    <br />

                   <div class="row my-custom-margin">
                        <div class="col-md-4 ">
                            <asp:Button class="btn btn-lg btn-block btn-success my-custom-button" ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" />
                        </div>
                        <div class="col-md-4">
                            <asp:Button class="btn btn-lg btn-block btn-primary my-custom-button" ID="Button3" runat="server" Text="Update" OnClick="Button3_Click" />
                        </div>
                       <div class="col-md-4">
                         <asp:Button class="btn btn-lg btn-block btn-danger my-custom-button" ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" />
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
                        <h4>Accomodation Inventory</h4>
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dormDBConnectionString4 %>" ProviderName="<%$ ConnectionStrings:dormDBConnectionString4.ProviderName %>" SelectCommand="SELECT * FROM [img_upload]"></asp:SqlDataSource>
                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                     <Columns>
                        <asp:BoundField DataField="img_name" HeaderText="img_name" SortExpression="img_name" />
                        <asp:BoundField DataField="img_id" HeaderText="img_id" SortExpression="img_id" />
                        <asp:BoundField DataField="img_link" HeaderText="img_link" SortExpression="img_link" />
                    </Columns>
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
