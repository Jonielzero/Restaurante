namespace Restaurante.Productos
{
    partial class agregarproducto
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
            this.panel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbnombre = new System.Windows.Forms.ComboBox();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnagregar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnnuevo = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.ColumnCount = 4;
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panel1.Controls.Add(this.panel2, 1, 1);
            this.panel1.Controls.Add(this.dataGridView1, 2, 1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RowCount = 3;
            this.panel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.panel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.panel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.ColumnCount = 2;
            this.panel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.panel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panel2.Controls.Add(this.label1, 0, 0);
            this.panel2.Controls.Add(this.label2, 0, 2);
            this.panel2.Controls.Add(this.cbnombre, 0, 1);
            this.panel2.Controls.Add(this.txtcantidad, 0, 3);
            this.panel2.Controls.Add(this.panel3, 1, 3);
            this.panel2.Controls.Add(this.panel4, 1, 1);
            this.panel2.Controls.Add(this.panel5, 1, 2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(83, 70);
            this.panel2.Name = "panel2";
            this.panel2.RowCount = 4;
            this.panel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00001F));
            this.panel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panel2.Size = new System.Drawing.Size(394, 309);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Del Producto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Agregar Cantidad";
            // 
            // cbnombre
            // 
            this.cbnombre.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cbnombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbnombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbnombre.ForeColor = System.Drawing.SystemColors.Window;
            this.cbnombre.FormattingEnabled = true;
            this.cbnombre.Location = new System.Drawing.Point(3, 80);
            this.cbnombre.Name = "cbnombre";
            this.cbnombre.Size = new System.Drawing.Size(256, 28);
            this.cbnombre.TabIndex = 3;
            this.cbnombre.Click += new System.EventHandler(this.cbnombre_Click);
            // 
            // txtcantidad
            // 
            this.txtcantidad.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtcantidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtcantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcantidad.ForeColor = System.Drawing.SystemColors.Window;
            this.txtcantidad.Location = new System.Drawing.Point(3, 234);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(256, 26);
            this.txtcantidad.TabIndex = 4;
            this.txtcantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcantidad_KeyPress);
            // 
            // panel3
            // 
            this.panel3.ColumnCount = 2;
            this.panel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel3.Controls.Add(this.btnagregar, 0, 0);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(265, 234);
            this.panel3.Name = "panel3";
            this.panel3.RowCount = 2;
            this.panel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel3.Size = new System.Drawing.Size(126, 72);
            this.panel3.TabIndex = 5;
            // 
            // btnagregar
            // 
            this.btnagregar.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnagregar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnagregar.FlatAppearance.BorderSize = 0;
            this.btnagregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnagregar.Location = new System.Drawing.Point(3, 3);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(57, 30);
            this.btnagregar.TabIndex = 0;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = false;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // panel4
            // 
            this.panel4.ColumnCount = 2;
            this.panel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel4.Controls.Add(this.btnnuevo, 0, 0);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(265, 80);
            this.panel4.Name = "panel4";
            this.panel4.RowCount = 2;
            this.panel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel4.Size = new System.Drawing.Size(126, 71);
            this.panel4.TabIndex = 6;
            // 
            // btnnuevo
            // 
            this.btnnuevo.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnnuevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnnuevo.FlatAppearance.BorderSize = 0;
            this.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnuevo.Location = new System.Drawing.Point(3, 3);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(57, 29);
            this.btnnuevo.TabIndex = 1;
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.UseVisualStyleBackColor = false;
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // panel5
            // 
            this.panel5.ColumnCount = 2;
            this.panel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel5.Controls.Add(this.button2, 1, 1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(265, 157);
            this.panel5.Name = "panel5";
            this.panel5.RowCount = 3;
            this.panel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panel5.Size = new System.Drawing.Size(126, 71);
            this.panel5.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Location = new System.Drawing.Point(66, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 28);
            this.button2.TabIndex = 20;
            this.button2.Text = "Registro";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(60)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(483, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(234, 309);
            this.dataGridView1.TabIndex = 1;
            // 
            // agregarproducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name = "agregarproducto";
            this.Text = "Agregar Existencias";
            this.Load += new System.EventHandler(this.agregarproducto_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panel1;
        private System.Windows.Forms.TableLayoutPanel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbnombre;
        private System.Windows.Forms.TextBox txtcantidad;
        private System.Windows.Forms.TableLayoutPanel panel3;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.TableLayoutPanel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel panel4;
        private System.Windows.Forms.Button btnnuevo;
        private System.Windows.Forms.Button button2;
    }
}