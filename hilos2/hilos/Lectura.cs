using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Ports;

namespace hilos
{
    public partial class Lectura : Form
    {
        delegate void SetTextCallback(string text);

        public Thread principal, luzDatos, graficas, guarda5min;
        public String cadE;
        /*luminosidad*/
        public int cont;
        public float watts;
        public float maxMJ, minMJ, MJ;
        /*humedad planta*/
        public float Maxh1, Minh1, h1, Maxh2, Minh2, h2,Maxh3, Minh3, h3, promedioh;
        /*humedad Relativa*/
        public float MaxhR1, MinhR1, hR1, MaxhR2, MinhR2, hR2, MaxhR3, MinhR3, hR3,promediohR;
        /*temperatura*/
        public float Maxt1, Mint1, t1, Maxt2, Mint2, t2, Maxt3, Mint3, t3,promediot;
        /*tanques*/
        public int micro, macro, tanque;
        /*1.- humedad1, 2.- humedad2, 3.- humedad3, 4.-hr1, 5.-hr2, 6.- hr3, 7.- tmp1,8.-tmp2,9.-tmp3, 10.-luz, 11.-micro, 12.- macro, 13.- tanque 14.-PH, 15.-CE */
        public String cadenaE = "(*1*2*3*4*5*6*7*8*9*10*11*12*13*Error*Error)";
        /*graficas*/
        public int tiempoHum;
        /*usuario*/
        String Rol;
        /*promedios minimos, maximos, valores actuales*/
        float PMinH, pMaxH, pMinHR, pMaxHR, pMinT, pMaxT, pMinL, pMaxL;
        /*guardado de archivos*/
        Random r1 = new Random();
        public int cont2;

        /// <summary>
        /// constructor del formulario de los sensores, todos los valores se inicializan 
        /// </summary>
        /// <param name="usuario"></param>
        public Lectura(String usuario )
        {

            InitializeComponent();

            creaCarpeta();

            principal = new Thread(new ThreadStart(lectura_puerto));
            luzDatos = new Thread(new ThreadStart(calculaJ));
            graficas = new Thread(new ThreadStart(graficar));
            guarda5min = new Thread(new ThreadStart(CrearArchivos5min));

            cadE = "";
            //serialPort1.Open();
            cont2 = cont = 0;
            Maxh1 = Maxh2 = Maxh3 = -5;
            Minh1 = Minh2 = Minh3 = 1024;

            Maxt1 = Maxt2 = Maxt3 = -5;
            Mint1 = Mint2 = Mint3 = 1024;

            maxMJ = MaxhR1 = MaxhR2 = MaxhR3 = -5;
            minMJ = MinhR1 = MinhR2 = MinhR3 = 1024;

            tiempoHum = 1;
            Rol = usuario;

            button2_Click(null, null);
        }
   
        /// <summary>
        /// lectura del puerto, se hace cada segundo
        /// genera maximos y minimos dentro del sistema
        /// </summary>
        public void lectura_puerto()
        {
            String[] aux;

            while(true)
            {
                // if(serialPort1.ReadBufferSize != 0)
                if (cadenaE.Length != 0)
                {
                    cadE = "";
                    while (cadE.Length < 30)
                    {
                        // cadE = serialPort1.ReadLine();
                        cadenaE = "(" + "*" + r1.Next(20) + "*" + r1.Next(20) + "*" + r1.Next(20) + "*" + r1.Next(20) + "*" + r1.Next(20) + "*" + r1.Next(20) + "*" + r1.Next(20) + "*" + r1.Next(20) + "*" + r1.Next(20) + "*" + r1.Next(20) + "*" + r1.Next(20) + "*" + r1.Next(20) + "*" + r1.Next(20) + "*" + r1.Next(20) + "*" + r1.Next(20) + "*" + ")";
                        cadE = cadenaE;
                    }
                    aux = cadE.Split('*');
                    /*sensor luminosidad*/
                    cont++;
                    watts += float.Parse(aux[10]);
                    /*sensor humedad en la planta*/
                    if (Minh1 > float.Parse(aux[1]))
                        Minh1 = float.Parse(aux[1]);
                    if (Maxh1 < float.Parse(aux[1]))
                        Maxh1 = float.Parse(aux[1]);

                    if (Minh2 > float.Parse(aux[2]))
                        Minh2 = float.Parse(aux[2]);
                    if (Maxh2 < float.Parse(aux[2]))
                        Maxh2 = float.Parse(aux[2]);

                    if (Minh3 > float.Parse(aux[3]))
                        Minh3 = float.Parse(aux[3]);
                    if (Maxh3 < float.Parse(aux[3]))
                        Maxh3 = float.Parse(aux[3]);

                    h1 = float.Parse(aux[1]);
                    h2 = float.Parse(aux[2]);
                    h3 = float.Parse(aux[3]);

                    /*humedad relativa*/
                    if (MinhR1 > float.Parse(aux[4]))
                        MinhR1 = float.Parse(aux[4]);
                    if (MaxhR1 < float.Parse(aux[4]))
                        MaxhR1 = float.Parse(aux[4]);

                    if (MinhR2 > float.Parse(aux[5]))
                        MinhR2 = float.Parse(aux[5]);
                    if (MaxhR2 < float.Parse(aux[5]))
                        MaxhR2 = float.Parse(aux[5]);

                    if (MinhR3 > float.Parse(aux[6]))
                        MinhR3 = float.Parse(aux[6]);
                    if (MaxhR3 < float.Parse(aux[6]))
                        MaxhR3 = float.Parse(aux[6]);

                    hR1 = float.Parse(aux[4]);
                    hR2 = float.Parse(aux[5]);
                    hR3 = float.Parse(aux[6]);

                    /*Temperatura*/
                    if (Mint1 > float.Parse(aux[7]))
                        Mint1 = float.Parse(aux[7]);
                    if (Maxt1 < float.Parse(aux[7]))
                        Maxt1 = float.Parse(aux[7]);

                    if (Mint2 > float.Parse(aux[8]))
                        Mint2 = float.Parse(aux[8]);
                    if (Maxt2 < float.Parse(aux[8]))
                        Maxt2 = float.Parse(aux[8]);

                    if (Mint3 > float.Parse(aux[9]))
                        Mint3 = float.Parse(aux[9]);
                    if (Maxt3 < float.Parse(aux[9]))
                        Maxt3 = float.Parse(aux[9]);

                    t1 = float.Parse(aux[7]);
                    t2 = float.Parse(aux[8]);
                    t3 = float.Parse(aux[9]);

                    /*tanques*/
                    micro = int.Parse(aux[11]);
                    macro = int.Parse(aux[12]);
                    tanque = int.Parse(aux[13]);

                    impresion("hola");

                }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// se calcula el total de megaJoul 
        /// </summary>
        public void calculaJ()
        {
            while (1 > 0)
            {
                Thread.Sleep(5000);
                float res = 0;
                res = watts / cont;
                res = res * 60 * 60;
                MJ = res / 1000;
                if (MJ < minMJ)
                    minMJ = MJ;
                if (MJ > maxMJ)
                    maxMJ = MJ;
                watts = 0;
                cont = 0;
                impresion2(" ");
            }

        }

        public void impresion2(String cadena)
        {
           /* if (this.VactualHumR.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(impresion2);
                this.Invoke(d, new object[] { cadena });
            }
            else
            {
                VactualHumR.Text += MJ+ " - "+ maxMJ+ " - " + minMJ+ '\n';
            }*/

        }

        public void impresion(String cadena)    //1 segundo 
        {
            if (this.MinH.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(impresion);
                this.Invoke(d, new object[] { cadena });
            }
            else
            {
                //VactualHumR.Text += h1 + " - " + h2 + " - " + h3 + '\n';*/
                
                /*promedio de min y max*/
                PMinH = (Minh1 + Minh2 + Minh3) / 3;
                pMaxH = (Maxh1 + Maxh2 + Maxh3) / 3;

                pMinHR = (MinhR1 + MinhR2 + MinhR3) / 3;
                pMaxHR = (MaxhR1 + MaxhR2 + MaxhR3) / 3;

                pMinT = (Mint1 + Mint2 + Mint3) / 3;
                pMaxT = (Maxt1 + Maxt2 + Maxt3) / 3;

                pMinL = minMJ;
                pMaxL = maxMJ;

                /*calcula maximos y minimos*/


                /*textbox*/
                MinH.Text = PMinH.ToString() + " %";
                MaxH.Text = pMaxH.ToString() + " %";
                VaH.Text = promedioh.ToString() + " %";

                MinHR.Text = pMinHR.ToString() + " %";
                MaxHR.Text = pMaxHR.ToString() + " %";
                VaHR.Text = promediohR.ToString() + " %";
   
                MinTemp.Text = pMinT.ToString() + " °C";
                MaxTemp.Text = pMaxT.ToString() + " °C";
                VaTemp.Text = promediot.ToString() + " °C";

                MinLuz.Text = pMinL.ToString() + " MJ";
                MaxLuz.Text = pMaxL.ToString() + " MJ";
                VaLuz.Text = MJ.ToString() + " MJ";

                Micronutriente.Text = micro.ToString() + " %";
                Macronutriente.Text = macro.ToString() + " %";
                Mezcla.Text = tanque.ToString() + " %";
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            principal.Start();
            luzDatos.Start();
            graficas.Start();
            guarda5min.Start();

        }

        private void Lectura_FormClosing(object sender, FormClosingEventArgs e)
        {
            principal.Abort();
            luzDatos.Abort();
            graficas.Abort();
            guarda5min.Abort();
        }

        public void graficar()
        {
            while (true)
            {
                GraficaHumedad(" ");
                archivo1hora();
                Thread.Sleep(5000);
            }

        }

        public void GraficaHumedad(String cadena)   //1 hora    
        {
            if (this.grafica_humedad.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(GraficaHumedad);
                this.Invoke(d, new object[] { cadena });
            }
            else
            {
                promedioh = (h1 + h2 + h3) / 3;
                promediohR =(hR1 + hR2 + hR3) / 3;
                promediot = ( t1 + t2 + t3) / 3;
               
                grafica_humedad.Series[0].Points.AddXY(tiempoHum, promedioh);
                GraficaHumRelativa.Series[0].Points.AddXY(tiempoHum, promediohR);
                grafica_temperatura.Series[0].Points.AddXY(tiempoHum,promediot);
                grafica_luz.Series[0].Points.AddXY(tiempoHum,MJ);
                tiempoHum++;

                sensores(PMinH, pMaxH, promedioh, pMinHR, pMaxHR, promediohR, pMinT, pMaxT, promediot, minMJ, maxMJ, MJ, 0, 0, 0, 1, 1, 1, micro, macro, tanque);
            }

        }

        public void muestraExcel()
        {
            String ruta = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            try
            {
                openFileDialog1.InitialDirectory = Application.StartupPath + "\\" + "invernadero";
                openFileDialog1.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.FileName.Equals("") == false)
                    {
                        ruta = openFileDialog1.FileName;
                    }
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks._Open(ruta);
                    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel._Worksheet)excelBook.Worksheets.get_Item(1);
                    excelApp.Visible = true;
                    object valueat = excelWorksheet.get_Range("A1", "A1").Value2;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Lectura_Load(object sender, EventArgs e)
        {
            if (Rol == "Administrador")
            {
                abrirRespaldoToolStripMenuItem.Enabled = true;
                usuarioToolStripMenuItem.Enabled = true;

            }
            if (Rol == "Agronomo")
            {
                abrirRespaldoToolStripMenuItem.Enabled = true;
                usuarioToolStripMenuItem.Enabled = false;
            }
            if (Rol == "Alumno")
            {

                abrirRespaldoToolStripMenuItem.Enabled = false;
                usuarioToolStripMenuItem.Enabled = false;
            }
            dataGridView1.AutoResizeColumnHeadersHeight();
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

        }

        private void abrirRespaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            muestraExcel();
        }

        private void ExportarDataGridViewExcel(DataGridView grd)
        {
            DateTime fecha = DateTime.Today;
            String ruta = Application.StartupPath + "\\" + "invernadero" + "\\" + fecha.ToString("D");
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
                        hoja_trabajo.Cells[i, j + 1] = grd.Columns[j].HeaderText;
                    hoja_trabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                }
            }
            //tabla 2
            try
            {
                libros_trabajo.SaveAs(ruta, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
            catch { }
        }

        public void sensores(float mH, float MH, float AH, float mHR, float MHR, float AHR, float mT, float MT, float AT, float mL, float ML, float AL, float mPH, float MPH, float APH, float mCE, float MCE, float ACE, float micro, float macro, float tanque)
        {
            if (cont2 < 24)
            {
                dataGridView1.Rows.Add(mH, MH, AH, mHR, MHR, AHR, mT, MT, AT, mL, ML, AL, mPH, MPH, APH, mCE, MCE, ACE, micro, macro, tanque);
                cont2++;
            }
            else
            {
                ExportarDataGridViewExcel(dataGridView1);
                cont2 = 0;
                dataGridView1.Rows.Clear();
            }
        }

        public void CrearArchivos5min() //  5 minutos archivo 
        {
            String fecha;

            while (true)
            {
                String pathsource = Application.StartupPath + "\\" + "invernadero";
                String str;
                fecha = DateTime.Today.ToString("d");
                fecha = fecha.Replace('/', '-');
                StreamWriter strw = File.AppendText(Application.StartupPath + "\\" + "invernadero" + "\\" + "5min" + fecha + "respaldo.txt" );

                str = DateTime.Now.ToShortTimeString() +" --- " + "humedad: " + promedioh + " , "
                                                                + "humedad Relativa: " + promediohR + " , "
                                                                + "Temperatura: " + promediot + " , "
                                                                + "luminosidad: " + MJ ;
                strw.WriteLine(str);
                strw.Close();

                strw = File.AppendText(Application.StartupPath + "\\" + "invernadero" + "\\" +  fecha + "-datosmin");

                str = DateTime.Now.ToShortTimeString() + "#" + promedioh + "#" + promediohR + "#" + promediot + "#" + MJ + "#";
                strw.WriteLine(str);
                strw.Close();
            
                arch5min(fecha);
    
                Thread.Sleep(2000);
            }
        }

        public void arch5min(String fecha)
        {
            String v1, v2, v3;

            if (this.RichHumSuelo.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(arch5min);
                this.Invoke(d, new object[] { fecha });
            }
            else
            {
                //Humedad En la planta
                v1 = h1.ToString();
                v2 = h2.ToString();
                v3 = h3.ToString();

                while (v1.Length < 10)
                { v1 += " "; }

                while (v2.Length < 10)
                { v2 += " "; }

                while (v3.Length < 10)
                { v3 += " "; }

                RichHumSuelo.Text += "\n" + DateTime.Now.ToShortTimeString() + " --- valor Actual: " + promedioh + " %\n\t" + "Primer Valor : " + v1 + "%\t\tSegundo Valor : " + v2 + " %\t\tTercer Valor : " + v3 + " %\n";
            
                //Humedad en el ambiente
                v1 = hR1.ToString();
                v2 = hR2.ToString();
                v3 = hR3.ToString();

                while (v1.Length < 10)
                { v1 += " "; }

                while (v2.Length < 10)
                { v2 += " "; }

                while (v3.Length < 10)
                { v3 += " "; }

                richHumedadAmb.Text += "\n" + DateTime.Now.ToShortTimeString() + " --- valor Actual: " + promediohR + " %\n\t" + "Primer Valor : " + v1 + " %\t\tSegundo Valor : " + v2 + " %\t\tTercer Valor : " + v3 + " %\n";
            
                //temperatura
                v1 = t1.ToString();
                v2 = t2.ToString();
                v3 = t3.ToString();

                while (v1.Length < 10)
                { v1 += " "; }

                while (v2.Length < 10)
                { v2 += " "; }

                while (v3.Length < 10)
                { v3 += " "; }

                RichTemp.Text += "\n" + DateTime.Now.ToShortTimeString() + " --- valor Actual: " + promediot + " °C\n\t" + "Primer Valor : " + v1 + " °C\t\tSegundo Valor : " + v2 + " °C\t\tTercer Valor : " + v3 + " °C\n";
            
                //Luz
                RichLuz.Text += "\n" + DateTime.Now.ToShortTimeString() + " --- valor Actual: " + MJ + " MJ";
            
            }
        }

        public void archivo1hora()  // 1 hora archivo 
        {
            String fecha;

            String pathsource = Application.StartupPath + "\\" + "invernadero";
            String str;
            fecha = DateTime.Today.ToString("d");
            fecha = fecha.Replace('/', '-');
            StreamWriter strw = File.AppendText(Application.StartupPath + "\\" + "invernadero" + "\\" + fecha + "Respaldo.txt");

            str =       "humedad: " + "Maximo:" + pMaxH + " Minimo:" + PMinH + " Actual: " + promedioh + " , "
                    +   "humedad Relativa: " + "Maximo:" + pMaxHR + " Minimo:" + pMinHR + " Actual: " + promediohR + " , "
                    +   "Temperatura: " + "Maximo:" + pMaxT + " Minimo:" + pMinT + " Actual: " + promediot + " , "
                    +   "luminosidad: " + "Maximo:" + maxMJ + " Minimo:" + minMJ + " Actual: " + MJ + " , "
                    +   "Micro: " + micro + ","
                    +   "Macro: " + macro + ","
                    +   "Mezcla: " + tanque;

            strw.WriteLine(str);
            strw.Close();


            strw = File.AppendText(Application.StartupPath + "\\" + "invernadero" + "\\" + fecha  + "-datoshr");
            str =   //"humedad: "
                    "#" + pMaxH + "#" + PMinH + "#" + promedioh +
                    //+ "humedad Relativa: " 
                    "#" + pMaxHR + "#" + pMinHR + "#" + promediohR +
                    //+ "Temperatura: "
                    "#" + pMaxT + "#" + pMinT + "#" + promediot +
                    //+ "luminosidad: "
                    "#" + maxMJ + "#" + minMJ + "#" + MJ +
                    //+ "Micro: "
                    "#" + micro +
                    //+ "Macro: "
                    "#" + macro +
                    //+ "Mezcla: " + tanque;
                    "#" + tanque
                    ;
            strw.WriteLine(str);
            strw.Close();
        }

        private void grafica_humedad_Click(object sender, EventArgs e)
        {
            groupBox9.Size = new Size(1070, 543);
            grafica_humedad.Size = new Size(1017, 184);
            RichHumSuelo.Size = new Size(697, 232);
            RichHumSuelo.Location = new Point(179, 298);

            //maximos minimos
            label9.Location = new Point(200, 251);
            MinH.Location = new Point(249, 251);
            label7.Location = new Point(446, 251);
            VaH.Location = new Point(519, 251);
            label8.Location = new Point(716, 251);
            MaxH.Location = new Point(768, 251);

            //otros grupos
            groupBox8.Visible = false;
            groupBox6.Visible = false;
            groupBox2.Visible = false;
        }

        private void GraficaHumRelativa_Click(object sender, EventArgs e)
        {
            groupBox2.Size = new Size(1070, 543);
            groupBox2.Location = new Point(12, 35);
            GraficaHumRelativa.Size = new Size(1017, 184);
            richHumedadAmb.Size = new Size(697, 232);
            richHumedadAmb.Location = new Point(179, 298);

            //maximos minimos
            label1.Location = new Point(200, 251);
            MinHR.Location = new Point(249, 251);
            label6.Location = new Point(446, 251);
            VaHR.Location = new Point(519, 251);
            label5.Location = new Point(716, 251);
            MaxHR.Location = new Point(768, 251);

            //otros grupos
            groupBox9.Visible = false;
            groupBox6.Visible = false;
            groupBox8.Visible = false;
        }

        private void grafica_temperatura_Click(object sender, EventArgs e)
        {
            groupBox6.Size = new Size(1070, 543);
            groupBox6.Location = new Point(12, 35);
            grafica_temperatura.Size = new Size(1017, 184);
            RichTemp.Size = new Size(697, 232);
            RichTemp.Location = new Point(179, 298);

            //maximos minimos
            label18.Location = new Point(200, 251);
            MinTemp.Location = new Point(249, 251);
            label6.Location = new Point(446, 251);
            VaTemp.Location = new Point(519, 251);
            label7.Location = new Point(716, 251);
            MaxTemp.Location = new Point(768, 251);

            //otros grupos
            groupBox9.Visible = false;
            groupBox2.Visible = false;
            groupBox8.Visible = false;
        }

        private void grafica_luz_Click(object sender, EventArgs e)
        {
            groupBox8.Size = new Size(1070, 543);
            groupBox8.Location = new Point(12, 35);
            grafica_luz.Size = new Size(1017, 184);
            RichLuz.Size = new Size(697, 232);
            RichLuz.Location = new Point(179, 298);

            //maximos minimos
            label24.Location = new Point(200, 251);
            MinLuz.Location = new Point(249, 251);
            label22.Location = new Point(446, 251);
            VaLuz.Location = new Point(519, 251);
            label23.Location = new Point(716, 251);
            MaxLuz.Location = new Point(768, 251);

            //otros grupos
            groupBox9.Visible = false;
            groupBox2.Visible = false;
            groupBox6.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox9.Visible = true;
            groupBox8.Visible = true;
            groupBox6.Visible = true;
            groupBox2.Visible = true;

            //humedad en el suelo
            groupBox9.Size = new Size(525, 264);
            grafica_humedad.Size = new Size(470, 184);
            label9.Location = new Point(21, 221);
            MinH.Location = new Point(67, 221);
            label7.Location = new Point(176, 233);
            VaH.Location = new Point(249, 233);
            label8.Location = new Point(366, 221);
            MaxH.Location = new Point(410, 221);

            //humedad relativa
            groupBox2.Size = new Size(525, 264);
            groupBox2.Location = new Point(557, 35);
            GraficaHumRelativa.Size = new Size(470, 184);
            
            label1.Location = new Point(21, 221);
            MinHR.Location = new Point(67, 221);
            label6.Location = new Point(176, 233);
            VaHR.Location = new Point(249, 233);
            label5.Location = new Point(366, 221);
            MaxHR.Location = new Point(410, 221);

            //Temperatura
            groupBox6.Size = new Size(525, 264);
            groupBox6.Location = new Point(12, 314);
            grafica_temperatura.Size = new Size(470, 184);

            label18.Location = new Point(21, 221);
            MinTemp.Location = new Point(67, 221);
            label6.Location = new Point(176, 233);
            VaTemp.Location = new Point(249, 233);
            label7.Location = new Point(366, 221);
            MaxTemp.Location = new Point(410, 221);

            //Luminosidad
            groupBox8.Size = new Size(525, 264);
            groupBox8.Location = new Point(557, 314);
            grafica_luz.Size = new Size(470, 184);

            label24.Location = new Point(21, 221);
            MinLuz.Location = new Point(67, 221);
            label22.Location = new Point(176, 233);
            VaLuz.Location = new Point(249, 233);
            label23.Location = new Point(366, 221);
            MaxLuz.Location = new Point(410, 221);
        }

        public void creaCarpeta()
        {
            String path = Application.StartupPath + "\\" + "invernadero";

            try 
            {
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
            } 
            catch (Exception e) 
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            } 
        }

        private void preferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormArduino arduino;
            byte[] mBuffer;

            arduino = new FormArduino();
            arduino.ShowDialog();

            if (arduino.DialogResult == DialogResult.OK)
            {
                //tipo
                mBuffer = Encoding.ASCII.GetBytes("tipo");
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                mBuffer = Encoding.ASCII.GetBytes(arduino.tipo);
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                //Porcentaje de humedad
                mBuffer = Encoding.ASCII.GetBytes("humedad");
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                mBuffer = Encoding.ASCII.GetBytes(arduino.porHum);
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                //Tiempo de riego
                mBuffer = Encoding.ASCII.GetBytes("tiempo");
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                mBuffer = Encoding.ASCII.GetBytes(arduino.TiemHr);
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                mBuffer = Encoding.ASCII.GetBytes(arduino.TiemMin);
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                //inicio
                mBuffer = Encoding.ASCII.GetBytes("inicio");
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                mBuffer = Encoding.ASCII.GetBytes(arduino.HIhrs);
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                mBuffer = Encoding.ASCII.GetBytes(arduino.HImin);
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                //fin
                mBuffer = Encoding.ASCII.GetBytes("fin");
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                mBuffer = Encoding.ASCII.GetBytes(arduino.HFhrs);
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                mBuffer = Encoding.ASCII.GetBytes(arduino.HFmin);
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                //micro macro agua
                mBuffer = Encoding.ASCII.GetBytes("tanques");
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                mBuffer = Encoding.ASCII.GetBytes(arduino.micro);
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                mBuffer = Encoding.ASCII.GetBytes(arduino.macro);
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                mBuffer = Encoding.ASCII.GetBytes(arduino.agua);
                serialPort1.Write(mBuffer, 0, mBuffer.Length);

                MessageBox.Show("algo");
            }  
        }
    }
}
