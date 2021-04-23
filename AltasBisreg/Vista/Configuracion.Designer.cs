namespace AltasBisreg.Vista
{
    partial class Configuracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracion));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_pv1 = new System.Windows.Forms.TextBox();
            this.txb_pv2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_pv3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_pcoste = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_CrearBDD = new System.Windows.Forms.Button();
            this.txb_RutaSql = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbx_Ambito = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.AbrirFixero = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(309, 39);
            this.label2.TabIndex = 8;
            this.label2.Text = "CONFIGURACION";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Precio Venta 1:";
            // 
            // txb_pv1
            // 
            this.txb_pv1.Location = new System.Drawing.Point(143, 39);
            this.txb_pv1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_pv1.Name = "txb_pv1";
            this.txb_pv1.Size = new System.Drawing.Size(132, 22);
            this.txb_pv1.TabIndex = 10;
            // 
            // txb_pv2
            // 
            this.txb_pv2.Location = new System.Drawing.Point(143, 71);
            this.txb_pv2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_pv2.Name = "txb_pv2";
            this.txb_pv2.Size = new System.Drawing.Size(132, 22);
            this.txb_pv2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Precio Venta 2:";
            // 
            // txb_pv3
            // 
            this.txb_pv3.Location = new System.Drawing.Point(143, 103);
            this.txb_pv3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_pv3.Name = "txb_pv3";
            this.txb_pv3.Size = new System.Drawing.Size(132, 22);
            this.txb_pv3.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Precio Venta 3:";
            // 
            // txb_pcoste
            // 
            this.txb_pcoste.Location = new System.Drawing.Point(143, 135);
            this.txb_pcoste.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_pcoste.Name = "txb_pcoste";
            this.txb_pcoste.Size = new System.Drawing.Size(132, 22);
            this.txb_pcoste.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 139);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Precio Coste";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txb_pv1);
            this.groupBox1.Controls.Add(this.txb_pcoste);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txb_pv3);
            this.groupBox1.Controls.Add(this.txb_pv2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(24, 81);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(323, 199);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Codigo Tarifa";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btn_CrearBDD);
            this.groupBox2.Controls.Add(this.txb_RutaSql);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(24, 288);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(796, 108);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Base de Datos";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(443, 44);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 26);
            this.button1.TabIndex = 20;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_CrearBDD
            // 
            this.btn_CrearBDD.Image = ((System.Drawing.Image)(resources.GetObject("btn_CrearBDD.Image")));
            this.btn_CrearBDD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CrearBDD.Location = new System.Drawing.Point(547, 28);
            this.btn_CrearBDD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_CrearBDD.Name = "btn_CrearBDD";
            this.btn_CrearBDD.Size = new System.Drawing.Size(195, 54);
            this.btn_CrearBDD.TabIndex = 19;
            this.btn_CrearBDD.Text = "Crear Base de Datos";
            this.btn_CrearBDD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CrearBDD.UseVisualStyleBackColor = true;
            this.btn_CrearBDD.Click += new System.EventHandler(this.btn_CrearBDD_Click);
            // 
            // txb_RutaSql
            // 
            this.txb_RutaSql.Location = new System.Drawing.Point(68, 44);
            this.txb_RutaSql.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_RutaSql.Name = "txb_RutaSql";
            this.txb_RutaSql.Size = new System.Drawing.Size(380, 22);
            this.txb_RutaSql.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 48);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Ruta:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbx_Ambito);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(355, 81);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(465, 199);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configuracion";
            // 
            // cbx_Ambito
            // 
            this.cbx_Ambito.FormattingEnabled = true;
            this.cbx_Ambito.Items.AddRange(new object[] {
            "00001",
            "00002",
            "00003"});
            this.cbx_Ambito.Location = new System.Drawing.Point(112, 36);
            this.cbx_Ambito.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_Ambito.Name = "cbx_Ambito";
            this.cbx_Ambito.Size = new System.Drawing.Size(108, 24);
            this.cbx_Ambito.TabIndex = 18;
            this.cbx_Ambito.SelectedIndexChanged += new System.EventHandler(this.cbx_Ambito_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 39);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Valor Ambito:";
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Location = new System.Drawing.Point(652, 11);
            this.btn_Guardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(168, 38);
            this.btn_Guardar.TabIndex = 20;
            this.btn_Guardar.Text = "Aplicar Cambios";
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // AbrirFixero
            // 
            this.AbrirFixero.Filter = "Archivos Base de Datos|*.db";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Archivos Base de Datos|*.db";
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 409);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(853, 456);
            this.MinimumSize = new System.Drawing.Size(853, 456);
            this.Name = "Configuracion";
            this.Text = "Configuracion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_pv1;
        private System.Windows.Forms.TextBox txb_pv2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_pv3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_pcoste;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_CrearBDD;
        private System.Windows.Forms.TextBox txb_RutaSql;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbx_Ambito;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog AbrirFixero;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}