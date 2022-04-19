using System.Reflection;
using System.Windows.Forms;

namespace AltasBisreg.Vista
{
    partial class EditorDocument
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorDocument));
            this.GridDocumento = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exportarAExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importacionExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alertasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diseñosTemporalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_Tipo = new System.Windows.Forms.ComboBox();
            this.tbx_Pueblo = new System.Windows.Forms.TextBox();
            this.tbx_Diseño = new System.Windows.Forms.TextBox();
            this.tbx_Base = new System.Windows.Forms.TextBox();
            this.btn_Añadir = new System.Windows.Forms.Button();
            this.lbx_Pueblos = new System.Windows.Forms.ListBox();
            this.lbx_Diseños = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.chlbx_PackDiseños = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridDocumento)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridDocumento
            // 
            this.GridDocumento.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDocumento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridDocumento.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridDocumento.Location = new System.Drawing.Point(12, 244);
            this.GridDocumento.Name = "GridDocumento";
            this.GridDocumento.RowHeadersWidth = 51;
            this.GridDocumento.Size = new System.Drawing.Size(1085, 527);
            this.GridDocumento.TabIndex = 1;
            this.GridDocumento.VirtualMode = true;
            this.GridDocumento.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDocumento_CellValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarAExcelToolStripMenuItem,
            this.importacionExcelToolStripMenuItem,
            this.alertasToolStripMenuItem,
            this.diseñosTemporalesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1109, 48);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // exportarAExcelToolStripMenuItem
            // 
            this.exportarAExcelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportarAExcelToolStripMenuItem.Image")));
            this.exportarAExcelToolStripMenuItem.Name = "exportarAExcelToolStripMenuItem";
            this.exportarAExcelToolStripMenuItem.Size = new System.Drawing.Size(142, 44);
            this.exportarAExcelToolStripMenuItem.Text = "Exportar a Excel";
            this.exportarAExcelToolStripMenuItem.Click += new System.EventHandler(this.exportarAExcelToolStripMenuItem_Click);
            // 
            // importacionExcelToolStripMenuItem
            // 
            this.importacionExcelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importacionExcelToolStripMenuItem.Image")));
            this.importacionExcelToolStripMenuItem.Name = "importacionExcelToolStripMenuItem";
            this.importacionExcelToolStripMenuItem.Size = new System.Drawing.Size(154, 44);
            this.importacionExcelToolStripMenuItem.Text = "Importacion Excel";
            this.importacionExcelToolStripMenuItem.Click += new System.EventHandler(this.importacionExcelToolStripMenuItem_Click);
            // 
            // alertasToolStripMenuItem
            // 
            this.alertasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alertasToolStripMenuItem.Image")));
            this.alertasToolStripMenuItem.Name = "alertasToolStripMenuItem";
            this.alertasToolStripMenuItem.Size = new System.Drawing.Size(95, 44);
            this.alertasToolStripMenuItem.Text = "Alertas";
            this.alertasToolStripMenuItem.Click += new System.EventHandler(this.alertasToolStripMenuItem_Click);
            // 
            // diseñosTemporalesToolStripMenuItem
            // 
            this.diseñosTemporalesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("diseñosTemporalesToolStripMenuItem.Image")));
            this.diseñosTemporalesToolStripMenuItem.Name = "diseñosTemporalesToolStripMenuItem";
            this.diseñosTemporalesToolStripMenuItem.Size = new System.Drawing.Size(133, 44);
            this.diseñosTemporalesToolStripMenuItem.Text = "Packs Diseños";
            this.diseñosTemporalesToolStripMenuItem.Click += new System.EventHandler(this.diseñosTemporalesToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "DOCUMENTO";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "TIPO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(119, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "PUEBLO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(206, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "BASE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(274, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "DISEÑO";
            // 
            // cbx_Tipo
            // 
            this.cbx_Tipo.FormattingEnabled = true;
            this.cbx_Tipo.Location = new System.Drawing.Point(36, 151);
            this.cbx_Tipo.Name = "cbx_Tipo";
            this.cbx_Tipo.Size = new System.Drawing.Size(62, 21);
            this.cbx_Tipo.TabIndex = 14;
            // 
            // tbx_Pueblo
            // 
            this.tbx_Pueblo.Location = new System.Drawing.Point(122, 152);
            this.tbx_Pueblo.Name = "tbx_Pueblo";
            this.tbx_Pueblo.Size = new System.Drawing.Size(61, 20);
            this.tbx_Pueblo.TabIndex = 17;
            this.tbx_Pueblo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbx_Pueblo_KeyDown);
            // 
            // tbx_Diseño
            // 
            this.tbx_Diseño.Location = new System.Drawing.Point(273, 152);
            this.tbx_Diseño.Name = "tbx_Diseño";
            this.tbx_Diseño.Size = new System.Drawing.Size(61, 20);
            this.tbx_Diseño.TabIndex = 18;
            this.tbx_Diseño.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbx_Diseño_KeyDown);
            // 
            // tbx_Base
            // 
            this.tbx_Base.Location = new System.Drawing.Point(198, 152);
            this.tbx_Base.Name = "tbx_Base";
            this.tbx_Base.Size = new System.Drawing.Size(61, 20);
            this.tbx_Base.TabIndex = 19;
            // 
            // btn_Añadir
            // 
            this.btn_Añadir.Image = ((System.Drawing.Image)(resources.GetObject("btn_Añadir.Image")));
            this.btn_Añadir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Añadir.Location = new System.Drawing.Point(354, 140);
            this.btn_Añadir.Name = "btn_Añadir";
            this.btn_Añadir.Size = new System.Drawing.Size(78, 41);
            this.btn_Añadir.TabIndex = 20;
            this.btn_Añadir.Text = "Añadir";
            this.btn_Añadir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Añadir.UseVisualStyleBackColor = true;
            this.btn_Añadir.Click += new System.EventHandler(this.btn_Añadir_Click);
            // 
            // lbx_Pueblos
            // 
            this.lbx_Pueblos.FormattingEnabled = true;
            this.lbx_Pueblos.Location = new System.Drawing.Point(478, 92);
            this.lbx_Pueblos.Name = "lbx_Pueblos";
            this.lbx_Pueblos.Size = new System.Drawing.Size(118, 121);
            this.lbx_Pueblos.TabIndex = 21;
            this.lbx_Pueblos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbx_Pueblos_KeyDown);
            // 
            // lbx_Diseños
            // 
            this.lbx_Diseños.FormattingEnabled = true;
            this.lbx_Diseños.Location = new System.Drawing.Point(645, 92);
            this.lbx_Diseños.Name = "lbx_Diseños";
            this.lbx_Diseños.Size = new System.Drawing.Size(118, 121);
            this.lbx_Diseños.TabIndex = 22;
            this.lbx_Diseños.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbx_Diseños_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(491, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "PUEBLOS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(662, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "DISEÑOS";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1057, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 26;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(824, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 17);
            this.label8.TabIndex = 27;
            this.label8.Text = "PACK DISEÑOS";
            // 
            // chlbx_PackDiseños
            // 
            this.chlbx_PackDiseños.FormattingEnabled = true;
            this.chlbx_PackDiseños.Location = new System.Drawing.Point(951, 92);
            this.chlbx_PackDiseños.Name = "chlbx_PackDiseños";
            this.chlbx_PackDiseños.Size = new System.Drawing.Size(73, 21);
            this.chlbx_PackDiseños.TabIndex = 28;
            this.chlbx_PackDiseños.Text = "GENERAL";
            this.chlbx_PackDiseños.SelectedValueChanged += new System.EventHandler(this.chlbx_PackDiseños_SelectedValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(1030, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 29;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EditorDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 783);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chlbx_PackDiseños);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbx_Diseños);
            this.Controls.Add(this.lbx_Pueblos);
            this.Controls.Add(this.btn_Añadir);
            this.Controls.Add(this.tbx_Base);
            this.Controls.Add(this.tbx_Diseño);
            this.Controls.Add(this.tbx_Pueblo);
            this.Controls.Add(this.cbx_Tipo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GridDocumento);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditorDocument";
            this.Text = "Documento";
            this.Resize += new System.EventHandler(this.Editor_de_Document_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.GridDocumento)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridDocumento;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportarAExcelToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_Tipo;
        private System.Windows.Forms.TextBox tbx_Pueblo;
        private System.Windows.Forms.TextBox tbx_Diseño;
        private System.Windows.Forms.TextBox tbx_Base;
        private System.Windows.Forms.Button btn_Añadir;
        private System.Windows.Forms.ListBox lbx_Pueblos;
        private System.Windows.Forms.ListBox lbx_Diseños;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ToolStripMenuItem alertasToolStripMenuItem;
        private ToolStripMenuItem diseñosTemporalesToolStripMenuItem;
        private Button button1;
        private Label label8;
        private ComboBox chlbx_PackDiseños;
        private ToolStripMenuItem importacionExcelToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private Button button2;
    }
}