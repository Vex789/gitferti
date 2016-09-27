using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Ferti_Irrigacion1._0
{
    public partial class Form4 : Form
    {
       
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'usuarios.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.usuarios.Usuarios);

        }

        private void btnagregaCli_Click(object sender, EventArgs e)
        {
          
            
        }

        private void btnEliminaCli_Click(object sender, EventArgs e)
        {
            
        }
        void limpia()
        {
            textRol.Text = "";
            textpassword.Text = "";
            textusuario.Text = "";
        }
    }
}
