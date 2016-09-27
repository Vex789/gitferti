using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferti_Irrigacion1._0
{
    public partial class Form2 : Form
    {
        int cont = 0, contador = 0;
        int Ntanques = 0;
        Form4 frm4 = new Form4();

        public int i, j;
        //puntos graficas
        public Point HP, HA;
        public Point TMP;
        public Point LUZ;
        //maxima y minima
        public int maxHP, minHP;
        public int maxHA, minHA;
        public int maxTMP, minTMP;
        public int maxLUZ, minLUZ;
        String Rol;

        public Form2(string rol)
        {
            InitializeComponent();
            Rol = rol;
          
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //serialPort1.Open();
            timerSensores.Start();
            HP = new Point();
            HA = new Point();
            TMP = new Point();
            maxHA = minHA = maxHP = minHP = maxTMP = minTMP = maxLUZ = minLUZ = 0;
            i = 0;
            j = 5;
            if (Rol == "Administrador")
            {
               /* usuariosToolStripMenuItem.Enabled = true;
                altaToolStripMenuItem.Enabled = true;
                bajaToolStripMenuItem.Enabled = true;
                modificacionToolStripMenuItem.Enabled = true;
                rESPALDOToolStripMenuItem.Enabled = true;
                mostrarRespaldoToolStripMenuItem.Enabled = true;*/
            }
            if(Rol=="Agronomo")
            {

               /* rESPALDOToolStripMenuItem.Enabled = true;
                mostrarRespaldoToolStripMenuItem.Enabled = true;*/
            }
            if(Rol=="Alumno")
            {

                /*usuariosToolStripMenuItem.Enabled = false;
                altaToolStripMenuItem.Enabled = false;
                bajaToolStripMenuItem.Enabled = false;
                modificacionToolStripMenuItem.Enabled = false;
                rESPALDOToolStripMenuItem.Enabled = false;
                mostrarRespaldoToolStripMenuItem.Enabled = false;*/
            }
            dataGridView1.AutoResizeColumnHeadersHeight();
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            label21.Text = DateTime.Now.ToShortTimeString();
            label2.Text = DateTime.Now.ToShortDateString();
            Timer t1 = new Timer();
            t1.Interval = 1000;
            t1.Tick += timer1_Tick;
            t1.Start();
            

        }

        public void LeerDatos()
        {
            String Aux;
            int i = 2;
            Random rnd = new Random();
            String val = "";
            String[] cad = new String[] { "(","#","1","#","2","#","3","#","4","#","5","#","6","#","7","#",")","#","9","10"};
            String[] cadEnt = null;
            String cad2 = "";



            while (val.Length < 50)
            {
               // val = serialPort1.ReadExisting();
                cad2 = val;
                System.Threading.Thread.Sleep(5000);
            }

            cadEnt = cad2.Split('(');

            foreach (String st in cadEnt)
            {
                if (cuenta(st))
                {
                    cad2 = st;
                }
            }

            cadEnt = cad2.Split('#');

            //Humedad relativa y en la planta
            HP.Y = (int)int.Parse(cadEnt[1]);
            GraficaHumedad.Series[0].Points.AddXY(HP.X, HP.Y);
            HP.X++;

            if (minHP == 0)
                minHP = HP.Y;

            if (maxHP < HP.Y)
                maxHP = HP.Y;
            if (minHP > HP.Y)
                minHP = HP.Y;

            textHPmax.Text = maxHP.ToString();
            textHPmin.Text = minHP.ToString();
            textHPact.Text = HP.Y.ToString();

            HA.Y = (int)float.Parse(cadEnt[2]);
            GraficaHumedad.Series[1].Points.AddXY(HA.X, HA.Y);
            HA.X++;

            if (minHA == 0)
                minHA = HA.Y;

            if (maxHA < HA.Y)
                maxHA = HA.Y;
            if (minHA > HA.Y)
                minHA = HA.Y;

            textHAmax.Text = maxHA.ToString();
            textHAmin.Text = minHA.ToString();
            textHAact.Text = HA.Y.ToString();

            //temperatura
            TMP.Y = (int)float.Parse(cadEnt[3]);
            GraficaTemp.Series[0].Points.AddXY(TMP.X, TMP.Y);
            TMP.X++;

            if (minTMP == 0)
                minTMP = TMP.Y;

            if (maxTMP < TMP.Y)
                maxTMP = TMP.Y;
            if (minTMP > TMP.Y)
                minTMP = TMP.Y;

            TextTempMax.Text = maxTMP.ToString();
            TextTempMin.Text = minTMP.ToString();
            textTEMact.Text = TMP.Y.ToString();
            //luminosidad
            LUZ.Y = (int)float.Parse(cadEnt[4]);
            GraficaLuz.Series[0].Points.AddXY(LUZ.X, LUZ.Y);
            LUZ.X++;

            if (minLUZ == 0)
                minLUZ = LUZ.Y;

            if (maxLUZ < LUZ.Y)
                maxLUZ = LUZ.Y;
            if (minLUZ > LUZ.Y)
                minLUZ = LUZ.Y;

            textLuzMax.Text = maxLUZ.ToString();
            textLuzMin.Text = minLUZ.ToString();
            textLuzAct.Text = LUZ.Y.ToString();

            //Tanques
            textMicroN.Text = "         " + int.Parse(cadEnt[5]).ToString() + " cm";
            textMacroN.Text = "         " + int.Parse(cadEnt[6]).ToString() + " cm";
            textMezcla.Text = "         " + int.Parse(cadEnt[7]).ToString() + " cm";

        }

        public Boolean cuenta(String cad)
        {
            Boolean band = false;
            int cont = 0;

            foreach (Char c in cad)
            {
                if (c == '#')
                    cont++;
            }

            if (cont == 8)
                band = true;

            return band;
        }
        void muestraExcel()
        {
            String ruta="";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            try
            {
                openFileDialog1.InitialDirectory = "Directory.GetCurrentDirectory();";
                openFileDialog1.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.FileName.Equals("") == false)
                    {
                        ruta = openFileDialog1.FileName;
                    }
                    //OpenMicrosoftExcel(ruta);
                    // Instancia de Excel,
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    // Abrir Workook deseado
                    Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks._Open(ruta);
                    // Obtener primera hoja del workbook actual
                    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel._Worksheet)excelBook.Worksheets.get_Item(1);
                    // Visible o no excel de preferencia falso
                    excelApp.Visible = true;
                    // Leer el valor dela Celda Especificada en el rango
                    object valueat = excelWorksheet.get_Range("A1", "A1").Value2;


                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }


        private void uSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm4.Show();
        }

        private void abrirRespaldoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            muestraExcel();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             
        }
        private void ExportarDataGridViewExcel(DataGridView grd)
        {

            DateTime fecha = DateTime.Today;
            String ruta = "C:\\Users\\ale\\Desktop\\Ferti-Irrigacion2.0\\Ferti-Irrigacion1.0\\bin\\Debug\\" + fecha.ToString("D");
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            libros_trabajo = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
            //tabla 1
            for (int i = 0; i < grd.Rows.Count; i++)
            {
                for (int j = 0; j < grd.Columns.Count; j++)
                {
                    if (i == 1)
                    {
                        hoja_trabajo.Cells[i, j + 1] = grd.Columns[j].HeaderText;

                    }
                    hoja_trabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();


                }

            }
            //tabla 2

            libros_trabajo.SaveAs(ruta, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
            libros_trabajo.Close(true);
            aplicacion.Quit();

        }

        void sensores(int mH, int MH, int mHR, int MHR, int mT, int MT, int mL, int ML, int mPH, int MPH, int mCE, int MCE)
        {
            if (cont < 24)
            {
                dataGridView1.Rows.Add(mH, MH, mHR, MHR, mT, MT, mL, ML, mPH, MPH, mCE, MCE);
                cont++;
            }
            else
            {
                timer1.Stop();
                ExportarDataGridViewExcel(dataGridView1);
            }


        }

        private void timerSensores_Tick(object sender, EventArgs e)
        {

            i++;
            j++;
            LeerDatos();

            labelHora.Text = DateTime.Now.ToShortTimeString();
            labelFecha.Text = DateTime.Now.ToShortDateString();
            ((Timer)sender).Stop();
            // System.Threading.Thread.Sleep(3600000); hora 
            System.Threading.Thread.Sleep(1000); //minuto
            timer1.Start();  // iniciar nuevamente el timer.
            sensores(1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6);
       
        }
       
        

    }
}
