namespace AltasBisreg.Vista
{
    partial class EditorPueblos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorPueblos));
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_ID = new System.Windows.Forms.TextBox();
            this.tbx_Nombre = new System.Windows.Forms.TextBox();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.ListaLocalidades = new System.Windows.Forms.ListBox();
            this.tbx_Localidad = new System.Windows.Forms.TextBox();
            this.txb_NombreLocalidad = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.packsBasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 30);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(179, 39);
            this.label17.TabIndex = 9;
            this.label17.Text = "PUEBLOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Localidad";
            // 
            // tbx_ID
            // 
            this.tbx_ID.Location = new System.Drawing.Point(95, 100);
            this.tbx_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_ID.Name = "tbx_ID";
            this.tbx_ID.Size = new System.Drawing.Size(132, 22);
            this.tbx_ID.TabIndex = 14;
            // 
            // tbx_Nombre
            // 
            this.tbx_Nombre.Location = new System.Drawing.Point(95, 140);
            this.tbx_Nombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_Nombre.Name = "tbx_Nombre";
            this.tbx_Nombre.Size = new System.Drawing.Size(304, 22);
            this.tbx_Nombre.TabIndex = 15;
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(640, 42);
            this.btn_Eliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(100, 28);
            this.btn_Eliminar.TabIndex = 17;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(236, 97);
            this.btn_Buscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(100, 28);
            this.btn_Buscar.TabIndex = 18;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Location = new System.Drawing.Point(640, 272);
            this.btn_Guardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(100, 28);
            this.btn_Guardar.TabIndex = 19;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // ListaLocalidades
            // 
            this.ListaLocalidades.FormattingEnabled = true;
            this.ListaLocalidades.ItemHeight = 16;
            this.ListaLocalidades.Location = new System.Drawing.Point(408, 47);
            this.ListaLocalidades.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListaLocalidades.Name = "ListaLocalidades";
            this.ListaLocalidades.Size = new System.Drawing.Size(223, 260);
            this.ListaLocalidades.TabIndex = 20;
            this.ListaLocalidades.SelectedIndexChanged += new System.EventHandler(this.ListaLocalidades_SelectedIndexChanged);
            // 
            // tbx_Localidad
            // 
            this.tbx_Localidad.Location = new System.Drawing.Point(95, 181);
            this.tbx_Localidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_Localidad.Name = "tbx_Localidad";
            this.tbx_Localidad.Size = new System.Drawing.Size(132, 22);
            this.tbx_Localidad.TabIndex = 21;
            this.tbx_Localidad.TextChanged += new System.EventHandler(this.tbx_Localidad_TextChanged);
            // 
            // txb_NombreLocalidad
            // 
            this.txb_NombreLocalidad.Location = new System.Drawing.Point(236, 181);
            this.txb_NombreLocalidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_NombreLocalidad.Name = "txb_NombreLocalidad";
            this.txb_NombreLocalidad.ReadOnly = true;
            this.txb_NombreLocalidad.Size = new System.Drawing.Size(163, 22);
            this.txb_NombreLocalidad.TabIndex = 22;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.packsBasesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 28);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // packsBasesToolStripMenuItem
            // 
            this.packsBasesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.listaToolStripMenuItem});
            this.packsBasesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("packsBasesToolStripMenuItem.Image")));
            this.packsBasesToolStripMenuItem.Name = "packsBasesToolStripMenuItem";
            this.packsBasesToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.packsBasesToolStripMenuItem.Text = "Pack Bases";
            this.packsBasesToolStripMenuItem.Click += new System.EventHandler(this.packsBasesToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // listaToolStripMenuItem
            // 
            this.listaToolStripMenuItem.Name = "listaToolStripMenuItem";
            this.listaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.listaToolStripMenuItem.Text = "Lista";
            this.listaToolStripMenuItem.Click += new System.EventHandler(this.listaToolStripMenuItem_Click);
            // 
            // EditorPueblos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 305);
            this.Controls.Add(this.txb_NombreLocalidad);
            this.Controls.Add(this.tbx_Localidad);
            this.Controls.Add(this.ListaLocalidades);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.tbx_Nombre);
            this.Controls.Add(this.tbx_ID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(771, 352);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(771, 352);
            this.Name = "EditorPueblos";
            this.Text = "Pueblos";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_ID;
        private System.Windows.Forms.TextBox tbx_Nombre;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.ListBox ListaLocalidades;
        private System.Windows.Forms.TextBox tbx_Localidad;
        private System.Windows.Forms.TextBox txb_NombreLocalidad;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem packsBasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaToolStripMenuItem;
    }
}