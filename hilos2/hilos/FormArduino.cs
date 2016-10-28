using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hilos
{
    public partial class FormArduino : Form
    {
        public String tipo, porHum, TiemHr, TiemMin, HIhrs, HImin, HFhrs, HFmin, micro, macro, agua;

        public FormArduino()
        {
            InitializeComponent();
            TipoSuelo.Items.Add("Suelo 1");
            TipoSuelo.Items.Add("Suelo 2");
            TipoSuelo.Items.Add("Suelo 3");

            tipo = porHum = TiemHr = TiemMin = HIhrs = HImin = HFhrs = HFmin = micro = macro = agua = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tipo = TipoSuelo.Text;
            porHum = numericUpDown1.ToString();
            TiemHr = numericUpDown2.ToString();
            TiemMin = numericUpDown3.ToString();
            HIhrs = numericUpDown6.ToString();
            HImin = numericUpDown7.ToString();
            HFhrs = numericUpDown4.ToString();
            HFmin = numericUpDown5.ToString();

            micro = numericUpDown8.ToString();
            macro = numericUpDown9.ToString();
            agua = numericUpDown10.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
