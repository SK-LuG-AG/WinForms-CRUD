using System.Data;
using System.Data.SqlClient;

namespace CRUD
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand concmd;
        //SqlDataReader dR;
        SqlDataAdapter dA;

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tseha\source\repos\CRUD\CRUD\Database1.mdf;Integrated Security=True");
            con.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
            {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tseha\source\repos\CRUD\CRUD\Database1.mdf;Integrated Security=True");
            con.Open();

        }

        private void GetData()
        {
            concmd = new SqlCommand("Select * from GameInfo", con);
            dA = new SqlDataAdapter(concmd);
            DataTable dT = new DataTable();
                dA.Fill(dT);
            dataGridView1.DataSource = dT;
                
                }

      
        private void BtnSpeichern_Click(object sender, EventArgs e)
        {
            SaveInfo();

            GetData();
        }

        protected void SaveInfo()
        {
            string QUERY = "Insert into GameInfo" +
                "(Id,Release,Genre,Bewertung)" +
                "VALUES(@id,@Release,@Genre,@Bewertung)";
            SqlCommand CMD = new SqlCommand(QUERY, con);
            CMD.Parameters.AddWithValue("@id", txtID.Text);
            CMD.Parameters.AddWithValue("@Release", txtDate.Text);
            CMD.Parameters.AddWithValue("@Genre", txtGenre.Text);
            CMD.Parameters.AddWithValue("@Bewertung", txtIGN.Text);
            CMD.ExecuteNonQuery();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateInfo();
            GetData();
        }

        protected void UpdateInfo()
        {
            string QUERY = "Update GameInfo Set Release= @Release, Genre=@Genre, Bewertung=@Bewertung where Id=@Id";
            SqlCommand CMD = new SqlCommand(QUERY, con);
            CMD.Parameters.AddWithValue("@id", txtID.Text);
            CMD.Parameters.AddWithValue("@Release", txtDate.Text);
            CMD.Parameters.AddWithValue("@Genre", txtGenre.Text);
            CMD.Parameters.AddWithValue("@Bewertung", txtIGN.Text);
            CMD.ExecuteNonQuery();
        }

        private void btnLöschen_Click(object sender, EventArgs e)
        {
            DeleteInfo();
            GetData();

        }

        protected void DeleteInfo()
        {
            string QUERY = "Delete from GameInfo " +
             "where Id = @Id";
            SqlCommand CMD = new SqlCommand(QUERY, con);
            CMD.Parameters.AddWithValue("@Id", txtID.Text);
            CMD.ExecuteNonQuery();


        }

        private void btnSuche_Click(object sender, EventArgs e) => Find();

        protected void Find()
        {
            concmd = new SqlCommand("Select * from GameInfo where Id='" + txtID.Text + "'", con);
            dA = new SqlDataAdapter(concmd);
            DataTable dT = new DataTable();
            dA.Fill(dT);
            dataGridView1.DataSource = dT;


        }
    }
}