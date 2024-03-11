<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminAccommodationManagement.aspx.cs" Inherits="eLibraryManagement.AdminPubisherManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        $(document).ready(function () {

            $("#GridView1").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();

        });
    </script>

        <style>    
    /* Custom CSS */
.my-custom-margin {
    margin: 13px;
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
    <script>
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('.table').DataTable();
        });
    </script>
    
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
                                <h3>Accommodation Manage</h3>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <img src="images/Accommodation%20manage.jpg" width="100px" />
                            </center>
                        </div>
                    </div>
               
                   

                    <div class="row my-custom-margin">
                        <div class="col">
                            <hr />
                         </div>
                    </div>

                    <div class="row my-custom-margin">
                        <div class="col-md-4 ">
                            <label>Accommodation ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox1"
                                 runat="server" placeholder="Id"></asp:TextBox>
                                <asp:Button class="btn  btn-block btn-primary" ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <label>Resident Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox3"
                                runat="server" placeholder="" ></asp:TextBox>
                            </div>
                        </div>
                    </div>

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
                        <h4>Accommodation List</h4>
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dormDBConnectionString %>" ProviderName="<%$ ConnectionStrings:dormDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [accommodation_resident_tbl]"></asp:SqlDataSource>
                <asp:RadioButton ID="RadioButton1" runat="server" />
                <div class ="col">
                    <asp:GridView  class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="accommodation_id" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="accommodation_id" HeaderText="accommodation_id" ReadOnly="True" SortExpression="accommodation_id" />
                            <asp:BoundField DataField="resident_name" HeaderText="resident_name" SortExpression="resident_name" />
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
