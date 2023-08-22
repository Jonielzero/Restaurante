namespace Restaurante.Clientes
{
    partial class registro_clientes
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
            this.tlp1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbus = new System.Windows.Forms.TextBox();
            this.btnbus = new System.Windows.Forms.Button();
            this.cbbus = new System.Windows.Forms.ComboBox();
            this.btneditar = new System.Windows.Forms.Button();
            this.tlp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp1
            // 
            this.tlp1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tlp1.ColumnCount = 3;
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tlp1.Controls.Add(this.dgv1, 0, 2);
            this.tlp1.Controls.Add(this.label1, 0, 0);
            this.tlp1.Controls.Add(this.txtbus, 0, 1);
            this.tlp1.Controls.Add(this.btnbus, 2, 1);
            this.tlp1.Controls.Add(this.cbbus, 1, 1);
            this.tlp1.Controls.Add(this.btneditar, 2, 0);
            this.tlp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp1.Location = new System.Drawing.Point(0, 0);
            this.tlp1.Name = "tlp1";
            this.tlp1.RowCount = 4;
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlp1.Size = new System.Drawing.Size(800, 450);
            this.tlp1.TabIndex = 2;
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(3, 69);
            this.dgv1.Name = "dgv1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.Size = new System.Drawing.Size(674, 354);
            this.dgv1.TabIndex = 0;
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
            this.label1.Size = new System.Drawing.Size(392, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "REGISTRO DE CLIENTES INGRESADOS\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbus
            // 
            this.txtbus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbus.Location = new System.Drawing.Point(3, 36);
            this.txtbus.Name = "txtbus";
            this.txtbus.Size = new System.Drawing.Size(674, 26);
            this.txtbus.TabIndex = 2;
            this.txtbus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbus_KeyPress);
            // 
            // btnbus
            // 
            this.btnbus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnbus.Location = new System.Drawing.Point(743, 36);
            this.btnbus.Name = "btnbus";
            this.btnbus.Size = new System.Drawing.Size(54, 27);
            this.btnbus.TabIndex = 3;
            this.btnbus.Text = "Buscar";
            this.btnbus.UseVisualStyleBackColor = true;
            this.btnbus.Click += new System.EventHandler(this.btnbus_Click);
            // 
            // cbbus
            // 
            this.cbbus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbus.FormattingEnabled = true;
            this.cbbus.Location = new System.Drawing.Point(683, 36);
            this.cbbus.Name = "cbbus";
            this.cbbus.Size = new System.Drawing.Size(54, 21);
            this.cbbus.TabIndex = 4;
            // 
            // btneditar
            // 
            this.btneditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btneditar.Location = new System.Drawing.Point(743, 3);
            this.btneditar.Name = "btneditar";
            this.btneditar.Size = new System.Drawing.Size(54, 27);
            this.btneditar.TabIndex = 5;
            this.btneditar.Text = "Editar";
            this.btneditar.UseVisualStyleBackColor = true;
            this.btneditar.Click += new System.EventHandler(this.btneditar_Click);
            // 
            // registro_clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlp1);
            this.Name = "registro_clientes";
            this.Text = "registro_clientes";
            this.Load += new System.EventHandler(this.registro_clientes_Load);
            this.tlp1.ResumeLayout(false);
            this.tlp1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbus;
        private System.Windows.Forms.Button btnbus;
        private System.Windows.Forms.ComboBox cbbus;
        private System.Windows.Forms.Button btneditar;
    }
}