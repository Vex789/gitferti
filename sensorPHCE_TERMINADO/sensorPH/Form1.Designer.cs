namespace sensorPH
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnCalibracion = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnAcido = new System.Windows.Forms.Button();
            this.btnalcalina = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCE = new System.Windows.Forms.Button();
            this.btnfinCE = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM3";
            // 
            // btnCalibracion
            // 
            this.btnCalibracion.Enabled = false;
            this.btnCalibracion.Location = new System.Drawing.Point(83, 111);
            this.btnCalibracion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCalibracion.Name = "btnCalibracion";
            this.btnCalibracion.Size = new System.Drawing.Size(112, 35);
            this.btnCalibracion.TabIndex = 0;
            this.btnCalibracion.Text = "Calibracion";
            this.btnCalibracion.UseVisualStyleBackColor = true;
            this.btnCalibracion.Click += new System.EventHandler(this.btnCalibracion_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(499, 37);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(424, 288);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // btnAcido
            // 
            this.btnAcido.Enabled = false;
            this.btnAcido.Location = new System.Drawing.Point(131, 177);
            this.btnAcido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAcido.Name = "btnAcido";
            this.btnAcido.Size = new System.Drawing.Size(112, 35);
            this.btnAcido.TabIndex = 2;
            this.btnAcido.Text = "Acido";
            this.btnAcido.UseVisualStyleBackColor = true;
            this.btnAcido.Click += new System.EventHandler(this.btnAcido_Click);
            // 
            // btnalcalina
            // 
            this.btnalcalina.Enabled = false;
            this.btnalcalina.Location = new System.Drawing.Point(131, 240);
            this.btnalcalina.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnalcalina.Name = "btnalcalina";
            this.btnalcalina.Size = new System.Drawing.Size(112, 35);
            this.btnalcalina.TabIndex = 3;
            this.btnalcalina.Text = "Alcalina";
            this.btnalcalina.UseVisualStyleBackColor = true;
            this.btnalcalina.Click += new System.EventHandler(this.btnalcalina_Click);
            // 
            // btnExit
            // 
            this.btnExit.Enabled = false;
            this.btnExit.Location = new System.Drawing.Point(131, 302);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 35);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Terminar";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "INICIO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Enabled = false;
            this.btnSalir.Location = new System.Drawing.Point(24, 356);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(112, 35);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCE
            // 
            this.btnCE.Location = new System.Drawing.Point(325, 67);
            this.btnCE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCE.Name = "btnCE";
            this.btnCE.Size = new System.Drawing.Size(112, 35);
            this.btnCE.TabIndex = 7;
            this.btnCE.Text = "INICIO";
            this.btnCE.UseVisualStyleBackColor = true;
            this.btnCE.Click += new System.EventHandler(this.btnCE_Click);
            // 
            // btnfinCE
            // 
            this.btnfinCE.Enabled = false;
            this.btnfinCE.Location = new System.Drawing.Point(325, 133);
            this.btnfinCE.Name = "btnfinCE";
            this.btnfinCE.Size = new System.Drawing.Size(112, 35);
            this.btnfinCE.TabIndex = 8;
            this.btnfinCE.Text = "Salir";
            this.btnfinCE.UseVisualStyleBackColor = true;
            this.btnfinCE.Click += new System.EventHandler(this.btnfinCE_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "SENSOR PH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "SENSOR CE";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 695);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnfinCE);
            this.Controls.Add(this.btnCE);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnalcalina);
            this.Controls.Add(this.btnAcido);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnCalibracion);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnCalibracion;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnAcido;
        private System.Windows.Forms.Button btnalcalina;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCE;
        private System.Windows.Forms.Button btnfinCE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

