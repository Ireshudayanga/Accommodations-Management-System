using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibraryManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try 
            {
                if (Session["role"]==null)
                {
                    LinkButton2.Visible = true; //Login
                    LinkButton1.Visible = true; //Signup
                    LinkButton3.Visible = false; //Logout

                    LinkButton4.Visible = false;
                    LinkButton6.Visible = true; //admin login
                    LinkButton11.Visible = false; 
                    LinkButton12.Visible = false;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                    LinkButton7.Visible = true;

                }
                else if(Session["role"].Equals("user"))
                {
                    LinkButton2.Visible = false; //Login
                    LinkButton1.Visible = false; //Signup
                    LinkButton3.Visible = true; //Logout

                    LinkButton4.Visible = false;
                    LinkButton6.Visible = false; //admin login
                    LinkButton11.Visible = false;
                    LinkButton12.Visible = false;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton2.Visible = false; //Login
                    LinkButton1.Visible = false; //Signup
                    LinkButton3.Visible = true; //Logout

                    LinkButton4.Visible = false;
                    LinkButton6.Visible = false; //admin login
                    LinkButton11.Visible = true;
                    LinkButton12.Visible = true;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                }
                else if (Session["role"].Equals("landloard"))
                {
                    LinkButton2.Visible = false; //Login
                    LinkButton1.Visible = false; //Signup
                    LinkButton3.Visible = true; //Logout

                    LinkButton4.Visible = true;
                    LinkButton6.Visible = false; //admin login
                    LinkButton11.Visible = false;
                    LinkButton12.Visible = false;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                }
                else if (Session["role"].Equals("warden"))
                {
                    LinkButton2.Visible = false; //Login
                    LinkButton1.Visible = false; //Signup
                    LinkButton3.Visible = true; //Logout
                    LinkButton4.Visible = false;
                    LinkButton6.Visible = false; //admin login
                    LinkButton11.Visible = false;
                    LinkButton12.Visible = false;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = true;
                    LinkButton7.Visible = false;
                }
            }
            catch (Exception ex)
            { 
           
            
            }

        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("wardenlogin.aspx");
        }
        
        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAccommodationManagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminPublisherManagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAccomodationInventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAccomodationIssue.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("wardenlocationmanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("landloadPublisher.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {
                Response.Redirect("Error.aspx");
            }
            else if (Session["role"].Equals("user") || Session["role"].Equals("landloard"))
            {
                Response.Redirect("AccommodationList.aspx");
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["full_name"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton2.Visible = true; //Login
            LinkButton1.Visible = true; //Signup
            LinkButton3.Visible = false; //Logout


            LinkButton4.Visible = false;
            LinkButton6.Visible = true; //admin login
            LinkButton11.Visible = false;
            LinkButton12.Visible = false;
            LinkButton8.Visible = false;
            LinkButton9.Visible = false;
            LinkButton10.Visible = false;

            Response.Redirect("home.aspx");
        }

        
    }
}