using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sensorPH
{
    public partial class Form1 : Form
    {
        string str="";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
            timer1.Start();
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (serialPort1.BytesToRead > 0)
            {
                string g = serialPort1.ReadLine();
                str = g;

            }
            else
                str = "Empty";
            richTextBox1.Text = str;
        }

        private void btnalcalina_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("alkali:10.00");
        }

        private void btnCalibracion_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("calibration");
            btnAcido.Enabled = true;
            btnalcalina.Enabled = true;
            btnExit.Enabled = true;
        }

        private void btnAcido_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("acid:4.00");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            serialPort1.WriteLine("exit");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("sensorPH\r");
            btnCalibracion.Enabled = true;
            btnCE.Enabled = false;
            btnSalir.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("fin");
            btnAcido.Enabled = false;
            btnCalibracion.Enabled = false;
            btnalcalina.Enabled = false;
            btnExit.Enabled = false;
            btnSalir.Enabled = false;
            btnCE.Enabled = true;

        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("sensorCE\r");
            btnfinCE.Enabled = true;
            button1.Enabled = false;
        }

        private void btnfinCE_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("fin\r");
            button1.Enabled = true;
            
        }
        

        
        
    }
}
