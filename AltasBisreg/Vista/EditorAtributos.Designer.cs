namespace AltasBisreg.Vista
{
    partial class EditorAtributos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorAtributos));
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GridRelaciones = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_CrearRel = new System.Windows.Forms.Button();
            this.tbx_RId = new System.Windows.Forms.TextBox();
            this.tbx_RDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_Descripcion = new System.Windows.Forms.TextBox();
            this.tbx_ID = new System.Windows.Forms.TextBox();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridRelaciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(171, 31);
            this.label17.TabIndex = 8;
            this.label17.Text = "ATRIBUTOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Descripcion:";
            // 
            // GridRelaciones
            // 
            this.GridRelaciones.AllowUserToAddRows = false;
            this.GridRelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridRelaciones.Location = new System.Drawing.Point(6, 19);
            this.GridRelaciones.Name = "GridRelaciones";
            this.GridRelaciones.Size = new System.Drawing.Size(284, 135);
            this.GridRelaciones.TabIndex = 11;
            this.GridRelaciones.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.GridRelaciones_UserDeletingRow);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_CrearRel);
            this.groupBox1.Controls.Add(this.tbx_RId);
            this.groupBox1.Controls.Add(this.tbx_RDescripcion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.GridRelaciones);
            this.groupBox1.Location = new System.Drawing.Point(12, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 160);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Relacion Atributos";
            // 
            // btn_CrearRel
            // 
            this.btn_CrearRel.Location = new System.Drawing.Point(485, 68);
            this.btn_CrearRel.Name = "btn_CrearRel";
            this.btn_CrearRel.Size = new System.Drawing.Size(75, 23);
            this.btn_CrearRel.TabIndex = 20;
            this.btn_CrearRel.Text = "Crear";
            this.btn_CrearRel.UseVisualStyleBackColor = true;
            this.btn_CrearRel.Click += new System.EventHandler(this.btn_CrearRel_Click);
            // 
            // tbx_RId
            // 
            this.tbx_RId.Location = new System.Drawing.Point(378, 16);
            this.tbx_RId.Name = "tbx_RId";
            this.tbx_RId.Size = new System.Drawing.Size(96, 20);
            this.tbx_RId.TabIndex = 19;
            // 
            // tbx_RDescripcion
            // 
            this.tbx_RDescripcion.Location = new System.Drawing.Point(378, 42);
            this.tbx_RDescripcion.Name = "tbx_RDescripcion";
            this.tbx_RDescripcion.Size = new System.Drawing.Size(182, 20);
            this.tbx_RDescripcion.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Descripcion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "ID:";
            // 
            // tbx_Descripcion
            // 
            this.tbx_Descripcion.Location = new System.Drawing.Point(87, 85);
            this.tbx_Descripcion.Name = "tbx_Descripcion";
            this.tbx_Descripcion.Size = new System.Drawing.Size(182, 20);
            this.tbx_Descripcion.TabIndex = 13;
            // 
            // tbx_ID
            // 
            this.tbx_ID.Location = new System.Drawing.Point(87, 59);
            this.tbx_ID.Name = "tbx_ID";
            this.tbx_ID.Size = new System.Drawing.Size(96, 20);
            this.tbx_ID.TabIndex = 14;
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(528, 12);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(75, 23);
            this.btn_Eliminar.TabIndex = 15;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Location = new System.Drawing.Point(528, 103);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_Guardar.TabIndex = 16;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(189, 57);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_Buscar.TabIndex = 17;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // EditorAtributos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 304);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.tbx_ID);
            this.Controls.Add(this.tbx_Descripcion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label17);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(631, 343);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(631, 343);
            this.Name = "EditorAtributos";
            this.Text = "Atributos";
            ((System.ComponentModel.ISupportInitialize)(this.GridRelaciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView GridRelaciones;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_Descripcion;
        private System.Windows.Forms.TextBox tbx_ID;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox tbx_RId;
        private System.Windows.Forms.TextBox tbx_RDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_CrearRel;
    }
}