namespace AltasBisreg.Vista
{
    partial class EditorDocumentoProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorDocumentoProductos));
            this.GridProductos = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exportarExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.GridProductos)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridProductos
            // 
            this.GridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridProductos.Location = new System.Drawing.Point(0, 48);
            this.GridProductos.Margin = new System.Windows.Forms.Padding(2);
            this.GridProductos.Name = "GridProductos";
            this.GridProductos.RowHeadersWidth = 51;
            this.GridProductos.RowTemplate.Height = 24;
            this.GridProductos.Size = new System.Drawing.Size(944, 338);
            this.GridProductos.TabIndex = 0;
            this.GridProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridProductos_KeyDown);
            this.GridProductos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GridProductos_KeyPress);
            this.GridProductos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GridProductos_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarExcelToolStripMenuItem,
            this.importarExcelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(944, 48);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exportarExcelToolStripMenuItem
            // 
            this.exportarExcelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportarExcelToolStripMenuItem.Image")));
            this.exportarExcelToolStripMenuItem.Name = "exportarExcelToolStripMenuItem";
            this.exportarExcelToolStripMenuItem.Size = new System.Drawing.Size(133, 44);
            this.exportarExcelToolStripMenuItem.Text = "Exportar Excel";
            this.exportarExcelToolStripMenuItem.Click += new System.EventHandler(this.exportarExcelToolStripMenuItem_Click);
            // 
            // importarExcelToolStripMenuItem
            // 
            this.importarExcelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importarExcelToolStripMenuItem.Image")));
            this.importarExcelToolStripMenuItem.Name = "importarExcelToolStripMenuItem";
            this.importarExcelToolStripMenuItem.Size = new System.Drawing.Size(135, 44);
            this.importarExcelToolStripMenuItem.Text = "Importar Excel";
            this.importarExcelToolStripMenuItem.Click += new System.EventHandler(this.importarExcelToolStripMenuItem_Click);
            // 
            // EditorDocumentoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 386);
            this.Controls.Add(this.GridProductos);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditorDocumentoProductos";
            this.Text = "Documento (Productos)";
            ((System.ComponentModel.ISupportInitialize)(this.GridProductos)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView GridProductos;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportarExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarExcelToolStripMenuItem;
    }
}