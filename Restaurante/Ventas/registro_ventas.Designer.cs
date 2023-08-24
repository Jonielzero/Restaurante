namespace Restaurante.Ventas
{
    partial class registro_ventas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registro_ventas));
            this.tlp1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbus = new System.Windows.Forms.TextBox();
            this.btnbus = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbmes = new System.Windows.Forms.ComboBox();
            this.cbbus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnbusmes = new System.Windows.Forms.Button();
            this.txtano = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lb1 = new System.Windows.Forms.Label();
            this.Lbtotal = new System.Windows.Forms.Label();
            this.tlp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp1
            // 
            this.tlp1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tlp1.ColumnCount = 3;
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tlp1.Controls.Add(this.label1, 0, 0);
            this.tlp1.Controls.Add(this.txtbus, 0, 1);
            this.tlp1.Controls.Add(this.btnbus, 2, 1);
            this.tlp1.Controls.Add(this.dgv1, 0, 4);
            this.tlp1.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tlp1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tlp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp1.Location = new System.Drawing.Point(0, 0);
            this.tlp1.Name = "tlp1";
            this.tlp1.RowCount = 6;
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tlp1.Size = new System.Drawing.Size(800, 450);
            this.tlp1.TabIndex = 3;
            this.tlp1.Paint += new System.Windows.Forms.PaintEventHandler(this.tlp1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "REGISTRO DE VENTAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbus
            // 
            this.txtbus.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtbus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbus.Location = new System.Drawing.Point(3, 39);
            this.txtbus.Name = "txtbus";
            this.txtbus.Size = new System.Drawing.Size(674, 26);
            this.txtbus.TabIndex = 2;
            // 
            // btnbus
            // 
            this.btnbus.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnbus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnbus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnbus.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnbus.Location = new System.Drawing.Point(743, 39);
            this.btnbus.Name = "btnbus";
            this.btnbus.Size = new System.Drawing.Size(54, 39);
            this.btnbus.TabIndex = 3;
            this.btnbus.Text = "Buscar";
            this.btnbus.UseVisualStyleBackColor = false;
            this.btnbus.Click += new System.EventHandler(this.btnbus_Click);
            // 
            // dgv1
            // 
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.WindowFrame;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(3, 165);
            this.dgv1.Name = "dgv1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.Size = new System.Drawing.Size(674, 264);
            this.dgv1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.cbmes, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbbus, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnbusmes, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtano, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 84);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(674, 39);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // cbmes
            // 
            this.cbmes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbmes.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cbmes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbmes.ForeColor = System.Drawing.SystemColors.Window;
            this.cbmes.FormattingEnabled = true;
            this.cbmes.Location = new System.Drawing.Point(339, 15);
            this.cbmes.Name = "cbmes";
            this.cbmes.Size = new System.Drawing.Size(162, 21);
            this.cbmes.TabIndex = 6;
            this.cbmes.Click += new System.EventHandler(this.cbmes_Click);
            // 
            // cbbus
            // 
            this.cbbus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbbus.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cbbus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbus.ForeColor = System.Drawing.SystemColors.Window;
            this.cbbus.FormattingEnabled = true;
            this.cbbus.Location = new System.Drawing.Point(171, 15);
            this.cbbus.Name = "cbbus";
            this.cbbus.Size = new System.Drawing.Size(162, 21);
            this.cbbus.TabIndex = 4;
            this.cbbus.Click += new System.EventHandler(this.cbbus_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(33, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filtrar Registro de Ventas por";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnbusmes
            // 
            this.btnbusmes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbusmes.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnbusmes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnbusmes.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnbusmes.Location = new System.Drawing.Point(617, 3);
            this.btnbusmes.Name = "btnbusmes";
            this.btnbusmes.Size = new System.Drawing.Size(54, 33);
            this.btnbusmes.TabIndex = 5;
            this.btnbusmes.Text = "Filtrar";
            this.btnbusmes.UseVisualStyleBackColor = false;
            this.btnbusmes.Click += new System.EventHandler(this.btnbusmes_Click);
            // 
            // txtano
            // 
            this.txtano.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtano.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtano.Location = new System.Drawing.Point(507, 16);
            this.txtano.Name = "txtano";
            this.txtano.Size = new System.Drawing.Size(95, 20);
            this.txtano.TabIndex = 8;
            this.txtano.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtano_KeyPress);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lb1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Lbtotal, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 129);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(674, 30);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // lb1
            // 
            this.lb1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lb1.Location = new System.Drawing.Point(411, 14);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(125, 16);
            this.lb1.TabIndex = 0;
            this.lb1.Text = "Total de Ventas :";
            // 
            // Lbtotal
            // 
            this.Lbtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lbtotal.AutoSize = true;
            this.Lbtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbtotal.ForeColor = System.Drawing.Color.Snow;
            this.Lbtotal.Location = new System.Drawing.Point(542, 14);
            this.Lbtotal.Name = "Lbtotal";
            this.Lbtotal.Size = new System.Drawing.Size(51, 16);
            this.Lbtotal.TabIndex = 1;
            this.Lbtotal.Text = "L. 0.00";
            // 
            // registro_ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlp1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "registro_ventas";
            this.Text = "registro_ventas";
            this.Load += new System.EventHandler(this.registro_ventas_Load);
            this.tlp1.ResumeLayout(false);
            this.tlp1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbus;
        private System.Windows.Forms.Button btnbus;
        private System.Windows.Forms.ComboBox cbbus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnbusmes;
        private System.Windows.Forms.ComboBox cbmes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtano;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label Lbtotal;
    }
}