using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace Ferti_Irrigacion1._0
{
    public partial class Form1 : Form
    {
           private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mostrarRespaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

   

        private void button1_Click(object sender, EventArgs e)
        {
           if (textBoxUsuario.Text == "" && textBoxPassword.Text == "" || textBoxUsuario.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Debes introducir usuario y contraseña para accesar al sistema");
                this.Close();
            }
            else
           {
                  bool existe = false;
                  OleDbConnection Conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\usuarios.accdb");
                   Conexion.Open();
                   String consulta = "Select *from Usuarios where Usuario='" + textBoxUsuario.Text + "' and Password='" + textBoxPassword.Text + "'and Rol='Administrador'";
                   OleDbCommand comando = new OleDbCommand(consulta, Conexion);
                   OleDbDataReader lector;
                   lector = comando.ExecuteReader();
                   //MessageBox.Show("" + comando.ExecuteReader());
                   existe = lector.HasRows;
                   if (existe)
                   {
                       Form2 frm = new Form2("Administrador");
                       frm.Show();
                       this.Hide();
                   }
                   else
                   {
                       String consulta2 = "Select *from Usuarios where Usuario='" + textBoxUsuario.Text + "' and Password='" + textBoxPassword.Text + "'and Rol='Agronomo'";
                       comando = new OleDbCommand(consulta2, Conexion);
                       lector = comando.ExecuteReader();
                       //MessageBox.Show("" + comando.ExecuteReader());
                       existe = lector.HasRows;
                       if (existe)
                       {
                           Form2 frm = new Form2("Agronomo");
                           frm.Show();
                           this.Hide();
                       }
                       else
                       {
                           String consulta3 = "Select *from Usuarios where Usuario='" + textBoxUsuario.Text + "' and Password='" + textBoxPassword.Text + "'and Rol='Alumno'";
                           comando = new OleDbCommand(consulta3, Conexion);
                           lector = comando.ExecuteReader();
                           //MessageBox.Show("" + comando.ExecuteReader());
                           existe = lector.HasRows;
                           if (existe)
                           {
                               Form2 frm = new Form2("Alumno");
                               frm.Show();
                               this.Hide();
                           }
                           else
                           {

                               label3.Text = "Datos Incorrectos";
                               textBoxPassword.Text = "";
                               textBoxUsuario.Text = "";
                               textBoxUsuario.Focus();
                           }

                           
                       }





                   }

                   


               
                  

            }
        }


    }
}
