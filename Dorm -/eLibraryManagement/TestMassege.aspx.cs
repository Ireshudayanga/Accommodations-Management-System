using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace eLibraryManagement
{
    public partial class TestMassege : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFriends();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lBtn = sender as LinkButton;
            Label1.Text = lBtn.Text;
            LoadChatbox();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();

            string time = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
            string name = username;
            string query = "insert into Chat (Sender, Receiver, Message, Date) values ('" + name + "','" + Label1.Text + "','" + TextBox1.Text + "','" + time + "')";

            int i = ExecuteQuery(query);
            if (i == 1)
            {
                TextBox1.Text = "";
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            LoadChatbox();
        }

        protected void LoadFriends()
        {
            string agent = "iresh";


            SqlConnection conn = new SqlConnection(connectionString);
            
                conn.Open();
                string str = "select DISTINCT Name from [tblfrends] where Name!='" + agent + "'";
                SqlCommand cmd1 = new SqlCommand(str, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataList1.DataSource = ds;
                DataList1.DataBind();
            
        }

        protected void LoadChatbox()
        {
            string username = Session["username"].ToString();

            string name = username;
            SqlConnection conn = new SqlConnection(connectionString);
            
                conn.Open();
                string str = "select * from chat where Receiver = '" + name + "' OR Sender = '" + name + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataList2.DataSource = ds;
                DataList2.DataBind();
            
        }

        protected int ExecuteQuery(string query)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                return cmd.ExecuteNonQuery();
            
        }
    }
}
