using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuTotal
{
    public partial class LoginAdmin : Form
    {
        public LoginAdmin()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("workstation id=DBCinecatracho.mssql.somee.com;packet size=4096;user id=cesarsauceda_SQLLogin_1;pwd=nl65ssuu4h;data source=DBCinecatracho.mssql.somee.com;persist security info=False;initial catalog=DBCinecatracho");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("select Usuario, Contraseña from t_Administrador WHERE Usuario='" + txtusuario.Text + "' and Contraseña='" + txtcontra.Text+"'" , conexion);
            conexion.Open();
            SqlDataReader nuevo = comando.ExecuteReader();
            if (nuevo.Read() == true)
            {
                Administrador.FormMenu nuevo1 = new Administrador.FormMenu();
                nuevo1.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Datos Incorrectos");
                Form1 nuevo2 = new Form1();
                nuevo2.Show();
                this.Visible = false;
            }
            try
            {

                label1.Text = "Pelicula Encontrada";


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);


            }
            conexion.Close();
        }

        private void LoginAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
