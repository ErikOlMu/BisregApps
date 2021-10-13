namespace Catalogos_Bisreg_WinForms
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.TablaProductos = new System.Windows.Forms.DataGridView();
            this.ListaDeCampos = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Importar_Excel = new System.Windows.Forms.Button();
            this.Button_Export_PDF = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_DirIMG = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TablaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // TablaProductos
            // 
            this.TablaProductos.AllowUserToAddRows = false;
            this.TablaProductos.AllowUserToDeleteRows = false;
            this.TablaProductos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.TablaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaProductos.Location = new System.Drawing.Point(12, 154);
            this.TablaProductos.MultiSelect = false;
            this.TablaProductos.Name = "TablaProductos";
            this.TablaProductos.ReadOnly = true;
            this.TablaProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablaProductos.Size = new System.Drawing.Size(776, 284);
            this.TablaProductos.TabIndex = 0;
            this.TablaProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TablaProductos_KeyDown);
            // 
            // ListaDeCampos
            // 
            this.ListaDeCampos.FormattingEnabled = true;
            this.ListaDeCampos.Location = new System.Drawing.Point(548, 79);
            this.ListaDeCampos.Name = "ListaDeCampos";
            this.ListaDeCampos.Size = new System.Drawing.Size(240, 69);
            this.ListaDeCampos.TabIndex = 2;
            this.ListaDeCampos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListaDeCampos_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(548, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(240, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(545, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Campos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Añadir Campo";
            // 
            // btn_Importar_Excel
            // 
            this.btn_Importar_Excel.Location = new System.Drawing.Point(12, 120);
            this.btn_Importar_Excel.Name = "btn_Importar_Excel";
            this.btn_Importar_Excel.Size = new System.Drawing.Size(99, 28);
            this.btn_Importar_Excel.TabIndex = 6;
            this.btn_Importar_Excel.Text = "Importar Excel";
            this.btn_Importar_Excel.UseVisualStyleBackColor = true;
            this.btn_Importar_Excel.Click += new System.EventHandler(this.btn_Importar_Excel_Click);
            // 
            // Button_Export_PDF
            // 
            this.Button_Export_PDF.Location = new System.Drawing.Point(689, 444);
            this.Button_Export_PDF.Name = "Button_Export_PDF";
            this.Button_Export_PDF.Size = new System.Drawing.Size(99, 23);
            this.Button_Export_PDF.TabIndex = 7;
            this.Button_Export_PDF.Text = "Exportar a PDF";
            this.Button_Export_PDF.UseVisualStyleBackColor = true;
            this.Button_Export_PDF.Click += new System.EventHandler(this.Button_Export_PDF_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(513, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 20);
            this.button3.TabIndex = 25;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Directorio Imagenes";
            // 
            // txb_DirIMG
            // 
            this.txb_DirIMG.Location = new System.Drawing.Point(337, 23);
            this.txb_DirIMG.Name = "txb_DirIMG";
            this.txb_DirIMG.Size = new System.Drawing.Size(177, 20);
            this.txb_DirIMG.TabIndex = 23;
            this.txb_DirIMG.TextChanged += new System.EventHandler(this.txb_DirIMG_TextChanged);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 472);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_DirIMG);
            this.Controls.Add(this.Button_Export_PDF);
            this.Controls.Add(this.btn_Importar_Excel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ListaDeCampos);
            this.Controls.Add(this.TablaProductos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrincipal";
            this.Text = "Catalogos Bisreg";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TablaProductos;
        private System.Windows.Forms.ListBox ListaDeCampos;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Importar_Excel;
        private System.Windows.Forms.Button Button_Export_PDF;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_DirIMG;
    }
}

