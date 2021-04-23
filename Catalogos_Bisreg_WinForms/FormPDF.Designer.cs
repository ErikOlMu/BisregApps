namespace Catalogos_Bisreg_WinForms
{
    partial class FormPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPDF));
            this.Celda_PDF = new System.Windows.Forms.PictureBox();
            this.tbx_Tamaño = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Ltb_Campos = new System.Windows.Forms.ListBox();
            this.tbx_Orientacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_Fuente = new System.Windows.Forms.TextBox();
            this.btn_Guardar_PDF = new System.Windows.Forms.Button();
            this.txb_DirIMG = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_Columnas = new System.Windows.Forms.TextBox();
            this.cb_sizeSalida = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_Ruta_Salida = new System.Windows.Forms.TextBox();
            this.btn_Cargar_Salida = new System.Windows.Forms.Button();
            this.chbx_Nombrescampos = new System.Windows.Forms.CheckBox();
            this.chbx_Barcode = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Camposdefecto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Celda_PDF)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Celda_PDF
            // 
            this.Celda_PDF.BackColor = System.Drawing.Color.White;
            this.Celda_PDF.Location = new System.Drawing.Point(380, 5);
            this.Celda_PDF.Name = "Celda_PDF";
            this.Celda_PDF.Size = new System.Drawing.Size(900, 900);
            this.Celda_PDF.TabIndex = 0;
            this.Celda_PDF.TabStop = false;
            this.Celda_PDF.Paint += new System.Windows.Forms.PaintEventHandler(this.Celda_PDF_Paint);
            this.Celda_PDF.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Celda_PDF_MouseClick);
            this.Celda_PDF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Celda_PDF_MouseClick);
            // 
            // tbx_Tamaño
            // 
            this.tbx_Tamaño.Location = new System.Drawing.Point(35, 44);
            this.tbx_Tamaño.Name = "tbx_Tamaño";
            this.tbx_Tamaño.Size = new System.Drawing.Size(100, 20);
            this.tbx_Tamaño.TabIndex = 2;
            this.tbx_Tamaño.TextChanged += new System.EventHandler(this.tbx_Tamaño_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tamaño";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Ltb_Campos
            // 
            this.Ltb_Campos.FormattingEnabled = true;
            this.Ltb_Campos.Location = new System.Drawing.Point(170, 47);
            this.Ltb_Campos.Name = "Ltb_Campos";
            this.Ltb_Campos.Size = new System.Drawing.Size(155, 251);
            this.Ltb_Campos.TabIndex = 5;
            this.Ltb_Campos.SelectedIndexChanged += new System.EventHandler(this.Ltb_Campos_SelectedIndexChanged);
            // 
            // tbx_Orientacion
            // 
            this.tbx_Orientacion.Location = new System.Drawing.Point(35, 91);
            this.tbx_Orientacion.Name = "tbx_Orientacion";
            this.tbx_Orientacion.Size = new System.Drawing.Size(100, 20);
            this.tbx_Orientacion.TabIndex = 6;
            this.tbx_Orientacion.TextChanged += new System.EventHandler(this.tbx_Orientacion_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Orientacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fuente";
            // 
            // tbx_Fuente
            // 
            this.tbx_Fuente.Location = new System.Drawing.Point(35, 135);
            this.tbx_Fuente.Name = "tbx_Fuente";
            this.tbx_Fuente.Size = new System.Drawing.Size(100, 20);
            this.tbx_Fuente.TabIndex = 9;
            this.tbx_Fuente.TextChanged += new System.EventHandler(this.tbx_Fuente_TextChanged);
            // 
            // btn_Guardar_PDF
            // 
            this.btn_Guardar_PDF.Location = new System.Drawing.Point(222, 167);
            this.btn_Guardar_PDF.Name = "btn_Guardar_PDF";
            this.btn_Guardar_PDF.Size = new System.Drawing.Size(116, 39);
            this.btn_Guardar_PDF.TabIndex = 10;
            this.btn_Guardar_PDF.Text = "Generar PDF";
            this.btn_Guardar_PDF.UseVisualStyleBackColor = true;
            this.btn_Guardar_PDF.Click += new System.EventHandler(this.btn_Guardar_PDF_Click);
            // 
            // txb_DirIMG
            // 
            this.txb_DirIMG.Location = new System.Drawing.Point(9, 32);
            this.txb_DirIMG.Name = "txb_DirIMG";
            this.txb_DirIMG.Size = new System.Drawing.Size(177, 20);
            this.txb_DirIMG.TabIndex = 11;
            this.txb_DirIMG.TextChanged += new System.EventHandler(this.txb_DirIMG_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Directorio Imagenes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Columnas";
            // 
            // txb_Columnas
            // 
            this.txb_Columnas.Location = new System.Drawing.Point(11, 72);
            this.txb_Columnas.Name = "txb_Columnas";
            this.txb_Columnas.Size = new System.Drawing.Size(50, 20);
            this.txb_Columnas.TabIndex = 14;
            this.txb_Columnas.TextChanged += new System.EventHandler(this.txb_Columnas_TextChanged);
            // 
            // cb_sizeSalida
            // 
            this.cb_sizeSalida.FormattingEnabled = true;
            this.cb_sizeSalida.Location = new System.Drawing.Point(67, 72);
            this.cb_sizeSalida.Name = "cb_sizeSalida";
            this.cb_sizeSalida.Size = new System.Drawing.Size(121, 21);
            this.cb_sizeSalida.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tamaño Salida";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Ruta Salida";
            // 
            // txb_Ruta_Salida
            // 
            this.txb_Ruta_Salida.Location = new System.Drawing.Point(11, 127);
            this.txb_Ruta_Salida.Name = "txb_Ruta_Salida";
            this.txb_Ruta_Salida.Size = new System.Drawing.Size(175, 20);
            this.txb_Ruta_Salida.TabIndex = 18;
            this.txb_Ruta_Salida.TextChanged += new System.EventHandler(this.txb_Ruta_Salida_TextChanged);
            // 
            // btn_Cargar_Salida
            // 
            this.btn_Cargar_Salida.Location = new System.Drawing.Point(185, 127);
            this.btn_Cargar_Salida.Name = "btn_Cargar_Salida";
            this.btn_Cargar_Salida.Size = new System.Drawing.Size(30, 20);
            this.btn_Cargar_Salida.TabIndex = 19;
            this.btn_Cargar_Salida.Text = "...";
            this.btn_Cargar_Salida.UseVisualStyleBackColor = true;
            this.btn_Cargar_Salida.Click += new System.EventHandler(this.btn_Cargar_Salida_Click);
            // 
            // chbx_Nombrescampos
            // 
            this.chbx_Nombrescampos.AutoSize = true;
            this.chbx_Nombrescampos.Checked = true;
            this.chbx_Nombrescampos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbx_Nombrescampos.Location = new System.Drawing.Point(170, 304);
            this.chbx_Nombrescampos.Name = "chbx_Nombrescampos";
            this.chbx_Nombrescampos.Size = new System.Drawing.Size(116, 17);
            this.chbx_Nombrescampos.TabIndex = 20;
            this.chbx_Nombrescampos.Text = "Nombre del Campo";
            this.chbx_Nombrescampos.UseVisualStyleBackColor = true;
            // 
            // chbx_Barcode
            // 
            this.chbx_Barcode.AutoSize = true;
            this.chbx_Barcode.Checked = true;
            this.chbx_Barcode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbx_Barcode.Location = new System.Drawing.Point(170, 328);
            this.chbx_Barcode.Name = "chbx_Barcode";
            this.chbx_Barcode.Size = new System.Drawing.Size(66, 17);
            this.chbx_Barcode.TabIndex = 21;
            this.chbx_Barcode.Text = "Barcode";
            this.chbx_Barcode.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(185, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 20);
            this.button3.TabIndex = 22;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(170, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Campos";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 33);
            this.button1.TabIndex = 24;
            this.button1.Text = "Añadir Tamaño";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btn_Guardar_PDF);
            this.groupBox1.Controls.Add(this.txb_DirIMG);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txb_Columnas);
            this.groupBox1.Controls.Add(this.cb_sizeSalida);
            this.groupBox1.Controls.Add(this.btn_Cargar_Salida);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txb_Ruta_Salida);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(-3, 651);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 224);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PDF";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Camposdefecto);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbx_Tamaño);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chbx_Barcode);
            this.groupBox2.Controls.Add(this.Ltb_Campos);
            this.groupBox2.Controls.Add(this.chbx_Nombrescampos);
            this.groupBox2.Controls.Add(this.tbx_Orientacion);
            this.groupBox2.Controls.Add(this.tbx_Fuente);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(-3, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 366);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controles de Celda";
            // 
            // btn_Camposdefecto
            // 
            this.btn_Camposdefecto.Location = new System.Drawing.Point(11, 304);
            this.btn_Camposdefecto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Camposdefecto.Name = "btn_Camposdefecto";
            this.btn_Camposdefecto.Size = new System.Drawing.Size(123, 41);
            this.btn_Camposdefecto.TabIndex = 24;
            this.btn_Camposdefecto.Text = "Campos por defecto";
            this.btn_Camposdefecto.UseVisualStyleBackColor = true;
            this.btn_Camposdefecto.Click += new System.EventHandler(this.btn_Camposdefecto_Click);
            // 
            // FormPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1292, 857);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Celda_PDF);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPDF";
            this.Text = "FormPDF";
            ((System.ComponentModel.ISupportInitialize)(this.Celda_PDF)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox Celda_PDF;
        private System.Windows.Forms.TextBox tbx_Tamaño;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Ltb_Campos;
        private System.Windows.Forms.TextBox tbx_Orientacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_Fuente;
        private System.Windows.Forms.Button btn_Guardar_PDF;
        private System.Windows.Forms.TextBox txb_DirIMG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_Columnas;
        private System.Windows.Forms.ComboBox cb_sizeSalida;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_Ruta_Salida;
        private System.Windows.Forms.Button btn_Cargar_Salida;
        public System.Windows.Forms.CheckBox chbx_Nombrescampos;
        private System.Windows.Forms.CheckBox chbx_Barcode;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Camposdefecto;
    }
}