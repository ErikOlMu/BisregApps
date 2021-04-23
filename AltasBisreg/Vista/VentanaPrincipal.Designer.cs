namespace AltasBisreg.Vista
{
    partial class VentanaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPrincipal));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.nuevoDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pueblosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diseñosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.otrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atributosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.familiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosDeComposicionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Connexion = new System.Windows.Forms.ToolStripStatusLabel();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoDocumentoToolStripMenuItem,
            this.datosToolStripMenuItem,
            this.tablasToolStripMenuItem,
            this.importacionToolStripMenuItem,
            this.nuevoToolStripMenuItem,
            this.configuracionToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1297, 56);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "Archivo";
            this.MenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip_ItemClicked);
            // 
            // nuevoDocumentoToolStripMenuItem
            // 
            this.nuevoDocumentoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoDocumentoToolStripMenuItem.Image")));
            this.nuevoDocumentoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.nuevoDocumentoToolStripMenuItem.Name = "nuevoDocumentoToolStripMenuItem";
            this.nuevoDocumentoToolStripMenuItem.Size = new System.Drawing.Size(202, 52);
            this.nuevoDocumentoToolStripMenuItem.Text = "Nuevo (Produccion)";
            this.nuevoDocumentoToolStripMenuItem.Click += new System.EventHandler(this.nuevoDocumentoToolStripMenuItem_Click);
            // 
            // datosToolStripMenuItem
            // 
            this.datosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.basesToolStripMenuItem,
            this.pueblosToolStripMenuItem,
            this.diseñosToolStripMenuItem,
            this.toolStripSeparator2,
            this.otrosToolStripMenuItem});
            this.datosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("datosToolStripMenuItem.Image")));
            this.datosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.datosToolStripMenuItem.Name = "datosToolStripMenuItem";
            this.datosToolStripMenuItem.Size = new System.Drawing.Size(110, 52);
            this.datosToolStripMenuItem.Text = "Datos";
            // 
            // basesToolStripMenuItem
            // 
            this.basesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("basesToolStripMenuItem.Image")));
            this.basesToolStripMenuItem.Name = "basesToolStripMenuItem";
            this.basesToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.basesToolStripMenuItem.Text = "Bases";
            this.basesToolStripMenuItem.Click += new System.EventHandler(this.basesToolStripMenuItem_Click);
            // 
            // pueblosToolStripMenuItem
            // 
            this.pueblosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pueblosToolStripMenuItem.Image")));
            this.pueblosToolStripMenuItem.Name = "pueblosToolStripMenuItem";
            this.pueblosToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.pueblosToolStripMenuItem.Text = "Pueblos";
            this.pueblosToolStripMenuItem.Click += new System.EventHandler(this.pueblosToolStripMenuItem_Click);
            // 
            // diseñosToolStripMenuItem
            // 
            this.diseñosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("diseñosToolStripMenuItem.Image")));
            this.diseñosToolStripMenuItem.Name = "diseñosToolStripMenuItem";
            this.diseñosToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.diseñosToolStripMenuItem.Text = "Diseños";
            this.diseñosToolStripMenuItem.Click += new System.EventHandler(this.diseñosToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // otrosToolStripMenuItem
            // 
            this.otrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atributosToolStripMenuItem,
            this.familiasToolStripMenuItem,
            this.localidadesToolStripMenuItem,
            this.seccionesToolStripMenuItem,
            this.productosDeComposicionToolStripMenuItem});
            this.otrosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("otrosToolStripMenuItem.Image")));
            this.otrosToolStripMenuItem.Name = "otrosToolStripMenuItem";
            this.otrosToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.otrosToolStripMenuItem.Text = "Otros";
            // 
            // atributosToolStripMenuItem
            // 
            this.atributosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("atributosToolStripMenuItem.Image")));
            this.atributosToolStripMenuItem.Name = "atributosToolStripMenuItem";
            this.atributosToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.atributosToolStripMenuItem.Text = "Atributos";
            this.atributosToolStripMenuItem.Click += new System.EventHandler(this.atributosToolStripMenuItem_Click);
            // 
            // familiasToolStripMenuItem
            // 
            this.familiasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("familiasToolStripMenuItem.Image")));
            this.familiasToolStripMenuItem.Name = "familiasToolStripMenuItem";
            this.familiasToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.familiasToolStripMenuItem.Text = "Familias";
            this.familiasToolStripMenuItem.Click += new System.EventHandler(this.familiasToolStripMenuItem_Click);
            // 
            // localidadesToolStripMenuItem
            // 
            this.localidadesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("localidadesToolStripMenuItem.Image")));
            this.localidadesToolStripMenuItem.Name = "localidadesToolStripMenuItem";
            this.localidadesToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.localidadesToolStripMenuItem.Text = "Localidades";
            this.localidadesToolStripMenuItem.Click += new System.EventHandler(this.localidadesToolStripMenuItem_Click);
            // 
            // seccionesToolStripMenuItem
            // 
            this.seccionesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("seccionesToolStripMenuItem.Image")));
            this.seccionesToolStripMenuItem.Name = "seccionesToolStripMenuItem";
            this.seccionesToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.seccionesToolStripMenuItem.Text = "Secciones";
            this.seccionesToolStripMenuItem.Click += new System.EventHandler(this.seccionesToolStripMenuItem_Click);
            // 
            // productosDeComposicionToolStripMenuItem
            // 
            this.productosDeComposicionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("productosDeComposicionToolStripMenuItem.Image")));
            this.productosDeComposicionToolStripMenuItem.Name = "productosDeComposicionToolStripMenuItem";
            this.productosDeComposicionToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.productosDeComposicionToolStripMenuItem.Text = "Productos de Composicion";
            this.productosDeComposicionToolStripMenuItem.Click += new System.EventHandler(this.productosDeComposicionToolStripMenuItem_Click);
            // 
            // tablasToolStripMenuItem
            // 
            this.tablasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tablasToolStripMenuItem.Image")));
            this.tablasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tablasToolStripMenuItem.Name = "tablasToolStripMenuItem";
            this.tablasToolStripMenuItem.Size = new System.Drawing.Size(112, 52);
            this.tablasToolStripMenuItem.Text = "Tablas";
            this.tablasToolStripMenuItem.Click += new System.EventHandler(this.tablasToolStripMenuItem_Click);
            // 
            // importacionToolStripMenuItem
            // 
            this.importacionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importacionToolStripMenuItem.Image")));
            this.importacionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.importacionToolStripMenuItem.Name = "importacionToolStripMenuItem";
            this.importacionToolStripMenuItem.Size = new System.Drawing.Size(152, 52);
            this.importacionToolStripMenuItem.Text = "Importacion";
            this.importacionToolStripMenuItem.Click += new System.EventHandler(this.importacionToolStripMenuItem_Click);
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configuracionToolStripMenuItem.Image")));
            this.configuracionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(148, 52);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            this.configuracionToolStripMenuItem.Click += new System.EventHandler(this.configuracionToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Connexion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 741);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1297, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Connexion
            // 
            this.Connexion.Image = ((System.Drawing.Image)(resources.GetObject("Connexion.Image")));
            this.Connexion.Name = "Connexion";
            this.Connexion.Size = new System.Drawing.Size(20, 20);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripMenuItem.Image")));
            this.nuevoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(194, 52);
            this.nuevoToolStripMenuItem.Text = "Nuevo (Productos)";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 767);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "VentanaPrincipal";
            this.Text = "Altas Bisreg";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VentanaPrincipal_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem nuevoDocumentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem basesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pueblosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diseñosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel Connexion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem otrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atributosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem familiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosDeComposicionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
    }
}

