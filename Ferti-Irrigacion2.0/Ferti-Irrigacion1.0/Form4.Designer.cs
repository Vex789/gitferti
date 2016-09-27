namespace Ferti_Irrigacion1._0
{
    partial class Form4
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textpassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textusuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.datausuarios = new System.Windows.Forms.DataGridView();
            this.usuarios = new Ferti_Irrigacion1._0.usuarios();
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usuariosTableAdapter = new Ferti_Irrigacion1._0.usuariosTableAdapters.UsuariosTableAdapter();
            this.idUsuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuarCli = new System.Windows.Forms.Button();
            this.btnEliminaCli = new System.Windows.Forms.Button();
            this.btnagregaCli = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datausuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textRol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textpassword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textusuario);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 126);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuario";
            // 
            // textpassword
            // 
            this.textpassword.Location = new System.Drawing.Point(88, 55);
            this.textpassword.MaxLength = 30;
            this.textpassword.Name = "textpassword";
            this.textpassword.Size = new System.Drawing.Size(121, 20);
            this.textpassword.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Contraseña";
            // 
            // textusuario
            // 
            this.textusuario.Location = new System.Drawing.Point(88, 29);
            this.textusuario.MaxLength = 30;
            this.textusuario.Name = "textusuario";
            this.textusuario.Size = new System.Drawing.Size(121, 20);
            this.textusuario.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Usuario";
            // 
            // textRol
            // 
            this.textRol.Location = new System.Drawing.Point(88, 81);
            this.textRol.MaxLength = 30;
            this.textRol.Name = "textRol";
            this.textRol.Size = new System.Drawing.Size(121, 20);
            this.textRol.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Rol";
            // 
            // datausuarios
            // 
            this.datausuarios.AllowUserToAddRows = false;
            this.datausuarios.AllowUserToDeleteRows = false;
            this.datausuarios.AutoGenerateColumns = false;
            this.datausuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datausuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idUsuarioDataGridViewTextBoxColumn,
            this.usuarioDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.rolDataGridViewTextBoxColumn});
            this.datausuarios.DataSource = this.usuariosBindingSource;
            this.datausuarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datausuarios.Location = new System.Drawing.Point(248, 142);
            this.datausuarios.Name = "datausuarios";
            this.datausuarios.ReadOnly = true;
            this.datausuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datausuarios.Size = new System.Drawing.Size(342, 150);
            this.datausuarios.TabIndex = 58;
            // 
            // usuarios
            // 
            this.usuarios.DataSetName = "usuarios";
            this.usuarios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usuariosBindingSource
            // 
            this.usuariosBindingSource.DataMember = "Usuarios";
            this.usuariosBindingSource.DataSource = this.usuarios;
            // 
            // usuariosTableAdapter
            // 
            this.usuariosTableAdapter.ClearBeforeFill = true;
            // 
            // idUsuarioDataGridViewTextBoxColumn
            // 
            this.idUsuarioDataGridViewTextBoxColumn.DataPropertyName = "IdUsuario";
            this.idUsuarioDataGridViewTextBoxColumn.HeaderText = "IdUsuario";
            this.idUsuarioDataGridViewTextBoxColumn.Name = "idUsuarioDataGridViewTextBoxColumn";
            this.idUsuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioDataGridViewTextBoxColumn
            // 
            this.usuarioDataGridViewTextBoxColumn.DataPropertyName = "Usuario";
            this.usuarioDataGridViewTextBoxColumn.HeaderText = "Usuario";
            this.usuarioDataGridViewTextBoxColumn.Name = "usuarioDataGridViewTextBoxColumn";
            this.usuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rolDataGridViewTextBoxColumn
            // 
            this.rolDataGridViewTextBoxColumn.DataPropertyName = "Rol";
            this.rolDataGridViewTextBoxColumn.HeaderText = "Rol";
            this.rolDataGridViewTextBoxColumn.Name = "rolDataGridViewTextBoxColumn";
            this.rolDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnGuarCli
            // 
            this.btnGuarCli.Location = new System.Drawing.Point(403, 27);
            this.btnGuarCli.Name = "btnGuarCli";
            this.btnGuarCli.Size = new System.Drawing.Size(87, 29);
            this.btnGuarCli.TabIndex = 60;
            this.btnGuarCli.Text = "MODIFICAR";
            this.btnGuarCli.UseVisualStyleBackColor = true;
            // 
            // btnEliminaCli
            // 
            this.btnEliminaCli.Location = new System.Drawing.Point(530, 27);
            this.btnEliminaCli.Name = "btnEliminaCli";
            this.btnEliminaCli.Size = new System.Drawing.Size(87, 29);
            this.btnEliminaCli.TabIndex = 61;
            this.btnEliminaCli.Text = "ELIMINAR";
            this.btnEliminaCli.UseVisualStyleBackColor = true;
            this.btnEliminaCli.Click += new System.EventHandler(this.btnEliminaCli_Click);
            // 
            // btnagregaCli
            // 
            this.btnagregaCli.Location = new System.Drawing.Point(276, 27);
            this.btnagregaCli.Name = "btnagregaCli";
            this.btnagregaCli.Size = new System.Drawing.Size(87, 29);
            this.btnagregaCli.TabIndex = 59;
            this.btnagregaCli.Text = "NUEVO";
            this.btnagregaCli.UseVisualStyleBackColor = true;
            this.btnagregaCli.Click += new System.EventHandler(this.btnagregaCli_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 324);
            this.Controls.Add(this.btnGuarCli);
            this.Controls.Add(this.btnEliminaCli);
            this.Controls.Add(this.btnagregaCli);
            this.Controls.Add(this.datausuarios);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form4";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datausuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textpassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textusuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView datausuarios;
        private usuarios usuarios;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private usuariosTableAdapters.UsuariosTableAdapter usuariosTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnGuarCli;
        private System.Windows.Forms.Button btnEliminaCli;
        private System.Windows.Forms.Button btnagregaCli;
    }
}