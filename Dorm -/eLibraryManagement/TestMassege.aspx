<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TestMassege.aspx.cs" Inherits="eLibraryManagement.TestMassege" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>

        .customcard{

            padding-bottom: 10%;
             padding-top: 10%;
        }
        .custom-textbox {
        width: 400px;
        height: 51px;
        padding: 10px;
        border: 1px solid #ced4da;
        border-radius: 5px;
        box-sizing: border-box; /* This ensures that padding and border are included in the width and height */
        font-size: 16px;
        }
         .button {
             background-color: #04AA6D;
            color: white;
            padding: 7px ;
            margin-top: 15px;
            border: none;
            cursor: pointer;
            width: 15%;
            border-radius: 10px;
     
         }

        .message-box {
            border: none;
            border-radius: 5px;
            margin-bottom: 10px;
            padding: 10px;
        }

        .sender {
            font-weight: bold;
        }

        .message-input {
            margin-bottom: 10px;
        }

        /* Styling for LinkButton */
        .link-button {
            display: inline-block;
            padding: 6px 12px;
            margin-bottom: 0;
            font-size: 14px;
            font-weight: normal;
            line-height: 1.42857143;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            cursor: pointer;
            background-image: none;
            border: 1px solid transparent;
            border-radius: 4px;
            transition: all 0.3s ease;
            color: #fff;
            background-color: #007bff;
            border-color: #007bff;
        }

        .link-button:hover {
            color: #fff;
            background-color: #0056b3;
            border-color: #0056b3;
        }

        .customrow{

            padding:40px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container customcard">
    <div class="card">
      <div class="card-body">

        <div class="row customrow">
            <div class="col-md-12">


        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="1000"></asp:Timer>
                
                <div class="message-box">
                <asp:DataList ID="DataList2" runat="server">
                    <ItemTemplate>

                 <div class="message">
                        <div>
                            <span class="sender"><%# Eval("Sender") %>:</span>
                            <span class="message-text"><%# Eval("Message") %></span>
                        </div>
                   </div>     
                    
                    </ItemTemplate>
                </asp:DataList>
               </div>
            
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:DataList ID="DataList1" runat="server" RepeatDirection="Vertical" Height="1px" Width="189px">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" ForeColor="Black" runat="server" Text='<%# Bind("Name") %>' OnClick="LinkButton1_Click"></asp:LinkButton>
            </ItemTemplate>
        </asp:DataList>

        <center>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:TextBox CssClass="custom-textbox" ID="TextBox1" runat="server" Width="400px" Height="51px"></asp:TextBox>
        <asp:Button class="button" ID="Button1" runat="server" Text="Replay" OnClick="Button1_Click" />
        </center>
        
         </div> 
      </div>  
     </div> 
    </div>  
    </div>
</asp:Content>
