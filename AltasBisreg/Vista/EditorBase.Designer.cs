using System.Reflection;
using System.Windows.Forms;

namespace AltasBisreg.Vista
{
    partial class EditorBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorBase));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_Tipo = new System.Windows.Forms.ComboBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.tbx_ID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbx_PedidoMinimo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_Nombre = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbx_RelAributo = new System.Windows.Forms.ComboBox();
            this.tbx_MRelatributos = new System.Windows.Forms.TextBox();
            this.tbx_MAtributo = new System.Windows.Forms.TextBox();
            this.tbx_MSeccion = new System.Windows.Forms.TextBox();
            this.tbx_Mfamilia = new System.Windows.Forms.TextBox();
            this.tbx_Atributo = new System.Windows.Forms.TextBox();
            this.tbx_Familia = new System.Windows.Forms.TextBox();
            this.tbx_Seccion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbx_pv3 = new System.Windows.Forms.TextBox();
            this.tbx_pv1 = new System.Windows.Forms.TextBox();
            this.tbx_pv2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbx_pCoste = new System.Windows.Forms.TextBox();
            this.GridTarifas = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.GridComposiciones = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txb_CompCantidad = new System.Windows.Forms.TextBox();
            this.txb_CompID = new System.Windows.Forms.TextBox();
            this.btnaltacomposicion = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.porupbox5 = new System.Windows.Forms.GroupBox();
            this.txb_TarifaPrecio = new System.Windows.Forms.TextBox();
            this.txb_TarifaID = new System.Windows.Forms.TextBox();
            this.btn_CrearTarifa = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridTarifas)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridComposiciones)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.porupbox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "TIPO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_Tipo);
            this.groupBox1.Controls.Add(this.btn_Buscar);
            this.groupBox1.Controls.Add(this.tbx_ID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(18, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base";
            // 
            // cbx_Tipo
            // 
            this.cbx_Tipo.FormattingEnabled = true;
            this.cbx_Tipo.Location = new System.Drawing.Point(146, 30);
            this.cbx_Tipo.Name = "cbx_Tipo";
            this.cbx_Tipo.Size = new System.Drawing.Size(63, 21);
            this.cbx_Tipo.TabIndex = 5;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(215, 28);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_Buscar.TabIndex = 4;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // tbx_ID
            // 
            this.tbx_ID.Location = new System.Drawing.Point(38, 30);
            this.tbx_ID.Name = "tbx_ID";
            this.tbx_ID.Size = new System.Drawing.Size(65, 20);
            this.tbx_ID.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbx_PedidoMinimo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbx_Nombre);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(329, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 74);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos";
            // 
            // tbx_PedidoMinimo
            // 
            this.tbx_PedidoMinimo.Location = new System.Drawing.Point(397, 30);
            this.tbx_PedidoMinimo.Name = "tbx_PedidoMinimo";
            this.tbx_PedidoMinimo.Size = new System.Drawing.Size(100, 20);
            this.tbx_PedidoMinimo.TabIndex = 5;
            this.tbx_PedidoMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Pedido Minimo";
            // 
            // tbx_Nombre
            // 
            this.tbx_Nombre.Location = new System.Drawing.Point(69, 30);
            this.tbx_Nombre.Name = "tbx_Nombre";
            this.tbx_Nombre.Size = new System.Drawing.Size(210, 20);
            this.tbx_Nombre.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbx_RelAributo);
            this.groupBox3.Controls.Add(this.tbx_MRelatributos);
            this.groupBox3.Controls.Add(this.tbx_MAtributo);
            this.groupBox3.Controls.Add(this.tbx_MSeccion);
            this.groupBox3.Controls.Add(this.tbx_Mfamilia);
            this.groupBox3.Controls.Add(this.tbx_Atributo);
            this.groupBox3.Controls.Add(this.tbx_Familia);
            this.groupBox3.Controls.Add(this.tbx_Seccion);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(19, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 162);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Referencias";
            // 
            // cbx_RelAributo
            // 
            this.cbx_RelAributo.FormattingEnabled = true;
            this.cbx_RelAributo.Location = new System.Drawing.Point(83, 117);
            this.cbx_RelAributo.Name = "cbx_RelAributo";
            this.cbx_RelAributo.Size = new System.Drawing.Size(100, 21);
            this.cbx_RelAributo.TabIndex = 19;
            this.cbx_RelAributo.SelectedIndexChanged += new System.EventHandler(this.tbx_RelAributo_TextChanged);
            // 
            // tbx_MRelatributos
            // 
            this.tbx_MRelatributos.Location = new System.Drawing.Point(189, 117);
            this.tbx_MRelatributos.Name = "tbx_MRelatributos";
            this.tbx_MRelatributos.ReadOnly = true;
            this.tbx_MRelatributos.Size = new System.Drawing.Size(100, 20);
            this.tbx_MRelatributos.TabIndex = 18;
            // 
            // tbx_MAtributo
            // 
            this.tbx_MAtributo.Location = new System.Drawing.Point(189, 88);
            this.tbx_MAtributo.Name = "tbx_MAtributo";
            this.tbx_MAtributo.ReadOnly = true;
            this.tbx_MAtributo.Size = new System.Drawing.Size(100, 20);
            this.tbx_MAtributo.TabIndex = 17;
            // 
            // tbx_MSeccion
            // 
            this.tbx_MSeccion.Location = new System.Drawing.Point(189, 59);
            this.tbx_MSeccion.Name = "tbx_MSeccion";
            this.tbx_MSeccion.ReadOnly = true;
            this.tbx_MSeccion.Size = new System.Drawing.Size(100, 20);
            this.tbx_MSeccion.TabIndex = 16;
            // 
            // tbx_Mfamilia
            // 
            this.tbx_Mfamilia.Location = new System.Drawing.Point(189, 30);
            this.tbx_Mfamilia.Name = "tbx_Mfamilia";
            this.tbx_Mfamilia.ReadOnly = true;
            this.tbx_Mfamilia.Size = new System.Drawing.Size(100, 20);
            this.tbx_Mfamilia.TabIndex = 15;
            // 
            // tbx_Atributo
            // 
            this.tbx_Atributo.Location = new System.Drawing.Point(83, 88);
            this.tbx_Atributo.Name = "tbx_Atributo";
            this.tbx_Atributo.Size = new System.Drawing.Size(100, 20);
            this.tbx_Atributo.TabIndex = 14;
            this.tbx_Atributo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbx_Atributo.TextChanged += new System.EventHandler(this.tbx_Atributo_TextChanged);
            // 
            // tbx_Familia
            // 
            this.tbx_Familia.Location = new System.Drawing.Point(83, 30);
            this.tbx_Familia.Name = "tbx_Familia";
            this.tbx_Familia.Size = new System.Drawing.Size(100, 20);
            this.tbx_Familia.TabIndex = 13;
            this.tbx_Familia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbx_Familia.TextChanged += new System.EventHandler(this.tbx_Familia_TextChanged);
            // 
            // tbx_Seccion
            // 
            this.tbx_Seccion.Location = new System.Drawing.Point(83, 59);
            this.tbx_Seccion.Name = "tbx_Seccion";
            this.tbx_Seccion.Size = new System.Drawing.Size(100, 20);
            this.tbx_Seccion.TabIndex = 12;
            this.tbx_Seccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbx_Seccion.TextChanged += new System.EventHandler(this.tbx_Seccion_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Valor Atributo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Atributo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Seccion:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Familia:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbx_pv3);
            this.groupBox4.Controls.Add(this.tbx_pv1);
            this.groupBox4.Controls.Add(this.tbx_pv2);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.tbx_pCoste);
            this.groupBox4.Location = new System.Drawing.Point(329, 134);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(219, 162);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Precios";
            // 
            // tbx_pv3
            // 
            this.tbx_pv3.Location = new System.Drawing.Point(103, 88);
            this.tbx_pv3.Name = "tbx_pv3";
            this.tbx_pv3.Size = new System.Drawing.Size(100, 20);
            this.tbx_pv3.TabIndex = 22;
            this.tbx_pv3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbx_pv1
            // 
            this.tbx_pv1.Location = new System.Drawing.Point(103, 30);
            this.tbx_pv1.Name = "tbx_pv1";
            this.tbx_pv1.Size = new System.Drawing.Size(100, 20);
            this.tbx_pv1.TabIndex = 21;
            this.tbx_pv1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbx_pv2
            // 
            this.tbx_pv2.Location = new System.Drawing.Point(103, 59);
            this.tbx_pv2.Name = "tbx_pv2";
            this.tbx_pv2.Size = new System.Drawing.Size(100, 20);
            this.tbx_pv2.TabIndex = 20;
            this.tbx_pv2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Precio Coste:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Precio Venta 3:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Precio Venta 2:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Precio Venta 1:";
            // 
            // tbx_pCoste
            // 
            this.tbx_pCoste.Enabled = false;
            this.tbx_pCoste.Location = new System.Drawing.Point(103, 117);
            this.tbx_pCoste.Name = "tbx_pCoste";
            this.tbx_pCoste.Size = new System.Drawing.Size(100, 20);
            this.tbx_pCoste.TabIndex = 16;
            this.tbx_pCoste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GridTarifas
            // 
            this.GridTarifas.AllowUserToAddRows = false;
            this.GridTarifas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridTarifas.Location = new System.Drawing.Point(6, 19);
            this.GridTarifas.Name = "GridTarifas";
            this.GridTarifas.Size = new System.Drawing.Size(277, 132);
            this.GridTarifas.TabIndex = 23;
            this.GridTarifas.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.GridTarifas_UserDeletingRow);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.GridTarifas);
            this.groupBox5.Location = new System.Drawing.Point(554, 135);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(289, 162);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tarifas";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.GridComposiciones);
            this.groupBox6.Location = new System.Drawing.Point(18, 303);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(827, 318);
            this.groupBox6.TabIndex = 25;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Composicion";
            // 
            // GridComposiciones
            // 
            this.GridComposiciones.AllowUserToAddRows = false;
            this.GridComposiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridComposiciones.Location = new System.Drawing.Point(6, 19);
            this.GridComposiciones.Name = "GridComposiciones";
            this.GridComposiciones.Size = new System.Drawing.Size(815, 293);
            this.GridComposiciones.TabIndex = 24;
            this.GridComposiciones.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.GridComposiciones_UserDeletingRow);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txb_CompCantidad);
            this.groupBox7.Controls.Add(this.txb_CompID);
            this.groupBox7.Controls.Add(this.btnaltacomposicion);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Location = new System.Drawing.Point(852, 443);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(217, 126);
            this.groupBox7.TabIndex = 26;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Añadir Composicion";
            // 
            // txb_CompCantidad
            // 
            this.txb_CompCantidad.Location = new System.Drawing.Point(94, 61);
            this.txb_CompCantidad.Name = "txb_CompCantidad";
            this.txb_CompCantidad.Size = new System.Drawing.Size(100, 20);
            this.txb_CompCantidad.TabIndex = 6;
            this.txb_CompCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txb_CompID
            // 
            this.txb_CompID.Location = new System.Drawing.Point(94, 35);
            this.txb_CompID.Name = "txb_CompID";
            this.txb_CompID.Size = new System.Drawing.Size(100, 20);
            this.txb_CompID.TabIndex = 5;
            // 
            // btnaltacomposicion
            // 
            this.btnaltacomposicion.Location = new System.Drawing.Point(136, 97);
            this.btnaltacomposicion.Name = "btnaltacomposicion";
            this.btnaltacomposicion.Size = new System.Drawing.Size(75, 23);
            this.btnaltacomposicion.TabIndex = 4;
            this.btnaltacomposicion.Text = "Crear";
            this.btnaltacomposicion.UseVisualStyleBackColor = true;
            this.btnaltacomposicion.Click += new System.EventHandler(this.btnaltacomposicion_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Cantidad:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "ID Producto:";
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Location = new System.Drawing.Point(994, 598);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_Guardar.TabIndex = 27;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(852, 598);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // porupbox5
            // 
            this.porupbox5.Controls.Add(this.txb_TarifaPrecio);
            this.porupbox5.Controls.Add(this.txb_TarifaID);
            this.porupbox5.Controls.Add(this.btn_CrearTarifa);
            this.porupbox5.Controls.Add(this.label14);
            this.porupbox5.Controls.Add(this.label16);
            this.porupbox5.Location = new System.Drawing.Point(852, 135);
            this.porupbox5.Name = "porupbox5";
            this.porupbox5.Size = new System.Drawing.Size(217, 126);
            this.porupbox5.TabIndex = 29;
            this.porupbox5.TabStop = false;
            this.porupbox5.Text = "Añadir Tarifa";
            // 
            // txb_TarifaPrecio
            // 
            this.txb_TarifaPrecio.Location = new System.Drawing.Point(94, 61);
            this.txb_TarifaPrecio.Name = "txb_TarifaPrecio";
            this.txb_TarifaPrecio.Size = new System.Drawing.Size(100, 20);
            this.txb_TarifaPrecio.TabIndex = 6;
            this.txb_TarifaPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txb_TarifaID
            // 
            this.txb_TarifaID.Location = new System.Drawing.Point(94, 35);
            this.txb_TarifaID.Name = "txb_TarifaID";
            this.txb_TarifaID.Size = new System.Drawing.Size(100, 20);
            this.txb_TarifaID.TabIndex = 5;
            // 
            // btn_CrearTarifa
            // 
            this.btn_CrearTarifa.Location = new System.Drawing.Point(136, 97);
            this.btn_CrearTarifa.Name = "btn_CrearTarifa";
            this.btn_CrearTarifa.Size = new System.Drawing.Size(75, 23);
            this.btn_CrearTarifa.TabIndex = 4;
            this.btn_CrearTarifa.Text = "Crear";
            this.btn_CrearTarifa.UseVisualStyleBackColor = true;
            this.btn_CrearTarifa.Click += new System.EventHandler(this.btn_CrearTarifa_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Precio:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 38);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "ID Tarifa:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 31);
            this.label17.TabIndex = 7;
            this.label17.Text = "BASES";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(997, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 30;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EditorBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 627);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.porupbox5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 666);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1100, 666);
            this.Name = "EditorBase";
            this.Text = "Bases";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridTarifas)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridComposiciones)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.porupbox5.ResumeLayout(false);
            this.porupbox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_ID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbx_Nombre;
        private System.Windows.Forms.TextBox tbx_PedidoMinimo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbx_Atributo;
        private System.Windows.Forms.TextBox tbx_Familia;
        private System.Windows.Forms.TextBox tbx_Seccion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbx_pv3;
        private System.Windows.Forms.TextBox tbx_pv1;
        private System.Windows.Forms.TextBox tbx_pv2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbx_pCoste;
        private System.Windows.Forms.DataGridView GridTarifas;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView GridComposiciones;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.ComboBox cbx_Tipo;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txb_CompCantidad;
        private System.Windows.Forms.TextBox txb_CompID;
        private System.Windows.Forms.Button btnaltacomposicion;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox porupbox5;
        private System.Windows.Forms.TextBox txb_TarifaPrecio;
        private System.Windows.Forms.TextBox txb_TarifaID;
        private System.Windows.Forms.Button btn_CrearTarifa;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbx_MRelatributos;
        private System.Windows.Forms.TextBox tbx_MAtributo;
        private System.Windows.Forms.TextBox tbx_MSeccion;
        private System.Windows.Forms.TextBox tbx_Mfamilia;
        private System.Windows.Forms.ComboBox cbx_RelAributo;
    }
}