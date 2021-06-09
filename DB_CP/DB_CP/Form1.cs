using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_CP
{
    public partial class Form1 : Form
    {

        private string connection_str = String.Format("Server=localhost;Port=5432;" +
                        "Database=course_work_db;User Id=postgres;Password=123;");

        private NpgsqlConnection conn;
        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        public Form1()
        {
            InitializeComponent();
            select();
        }

        private void load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connection_str);
            select();
        }

        private void select()
        {
            try
            {
                conn = new NpgsqlConnection(connection_str);
                conn.Open();

                sql = @"select * from actors_select()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());                        
                conn.Close();
                dgvData.DataSource = null;
                dgvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error: ", ex.Message);
            }
        }
    }
}
