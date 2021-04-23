using System.Reflection;
using System.Windows.Forms;

namespace AltasBisreg.Vista
{
    partial class Importacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Importacion));
            this.GridExcel = new System.Windows.Forms.DataGridView();
            this.GridColumnas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_Tablas = new System.Windows.Forms.ComboBox();
            this.btn_ImportarExcel = new System.Windows.Forms.Button();
            this.btn_ImportarDatos = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridColumnas)).BeginInit();
            this.SuspendLayout();
            // 
            // GridExcel
            // 
            this.GridExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridExcel.Location = new System.Drawing.Point(16, 137);
            this.GridExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GridExcel.Name = "GridExcel";
            this.GridExcel.RowHeadersWidth = 51;
            this.GridExcel.Size = new System.Drawing.Size(885, 466);
            this.GridExcel.TabIndex = 0;
            // 
            // GridColumnas
            // 
            this.GridColumnas.AllowUserToAddRows = false;
            this.GridColumnas.AllowUserToDeleteRows = false;
            this.GridColumnas.AllowUserToResizeColumns = false;
            this.GridColumnas.AllowUserToResizeRows = false;
            this.GridColumnas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridColumnas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.GridColumnas.Location = new System.Drawing.Point(909, 137);
            this.GridColumnas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GridColumnas.Name = "GridColumnas";
            this.GridColumnas.RowHeadersWidth = 51;
            this.GridColumnas.Size = new System.Drawing.Size(324, 466);
            this.GridColumnas.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Columna BDD";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Columna Excel";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(921, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccionar Tabla:";
            // 
            // cbx_Tablas
            // 
            this.cbx_Tablas.FormattingEnabled = true;
            this.cbx_Tablas.Location = new System.Drawing.Point(1057, 91);
            this.cbx_Tablas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_Tablas.Name = "cbx_Tablas";
            this.cbx_Tablas.Size = new System.Drawing.Size(160, 24);
            this.cbx_Tablas.TabIndex = 3;
            this.cbx_Tablas.SelectedIndexChanged += new System.EventHandler(this.cbx_Tablas_SelectedIndexChanged);
            // 
            // btn_ImportarExcel
            // 
            this.btn_ImportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btn_ImportarExcel.Image")));
            this.btn_ImportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ImportarExcel.Location = new System.Drawing.Point(16, 76);
            this.btn_ImportarExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ImportarExcel.Name = "btn_ImportarExcel";
            this.btn_ImportarExcel.Size = new System.Drawing.Size(157, 53);
            this.btn_ImportarExcel.TabIndex = 4;
            this.btn_ImportarExcel.Text = "Importar Excel";
            this.btn_ImportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ImportarExcel.UseVisualStyleBackColor = true;
            this.btn_ImportarExcel.Click += new System.EventHandler(this.btn_ImportarExcel_Click);
            // 
            // btn_ImportarDatos
            // 
            this.btn_ImportarDatos.Image = ((System.Drawing.Image)(resources.GetObject("btn_ImportarDatos.Image")));
            this.btn_ImportarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ImportarDatos.Location = new System.Drawing.Point(1061, 15);
            this.btn_ImportarDatos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ImportarDatos.Name = "btn_ImportarDatos";
            this.btn_ImportarDatos.Size = new System.Drawing.Size(157, 53);
            this.btn_ImportarDatos.TabIndex = 5;
            this.btn_ImportarDatos.Text = "Importar Datos";
            this.btn_ImportarDatos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ImportarDatos.UseVisualStyleBackColor = true;
            this.btn_ImportarDatos.Click += new System.EventHandler(this.btn_ImportarDatos_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFile";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 39);
            this.label2.TabIndex = 6;
            this.label2.Text = "IMPORTACION";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(736, 76);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 53);
            this.button1.TabIndex = 7;
            this.button1.Text = "Añadir Columna";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(581, 76);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 53);
            this.button2.TabIndex = 8;
            this.button2.Text = "Borrar Tabla";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Importacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 494);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_ImportarDatos);
            this.Controls.Add(this.btn_ImportarExcel);
            this.Controls.Add(this.cbx_Tablas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GridColumnas);
            this.Controls.Add(this.GridExcel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1275, 665);
            this.MinimumSize = new System.Drawing.Size(1275, 665);
            this.Name = "Importacion";
            this.Text = "Importacion";
            ((System.ComponentModel.ISupportInitialize)(this.GridExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridColumnas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridExcel;
        private System.Windows.Forms.DataGridView GridColumnas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_Tablas;
        private System.Windows.Forms.Button btn_ImportarExcel;
        private System.Windows.Forms.Button btn_ImportarDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}