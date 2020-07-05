using Empleado;
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

namespace Administrador
{
    public partial class LoginEmpleado : Form
    {
        public LoginEmpleado()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("workstation id=DBCinecatracho.mssql.somee.com;packet size=4096;user id=cesarsauceda_SQLLogin_1;pwd=nl65ssuu4h;data source=DBCinecatracho.mssql.somee.com;persist security info=False;initial catalog=DBCinecatracho");

        private void button1_Click(object sender, EventArgs e)        {
            SqlCommand comando = new SqlCommand("select Usuario, Contraseña from t_Empleados WHERE Usuario='" + txtusuario.Text + "' and Contraseña='" + txtcontra.Text + "'", conexion);
            conexion.Open();
            SqlDataReader nuevo = comando.ExecuteReader();
            if (nuevo.Read() == true)
            {
                Empleado.Form1 nuevo1 = new Empleado.Form1();
                nuevo1.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Datos Incorrectos");
                this.Visible = false;
                Application.Restart();
            }
           
            conexion.Close();
        }
    }
}
