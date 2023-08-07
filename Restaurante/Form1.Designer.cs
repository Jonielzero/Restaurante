namespace Restaurante
{
    partial class Form1
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
            this.productos = new System.Windows.Forms.Button();
            this.Ventas = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // productos
            // 
            this.productos.Location = new System.Drawing.Point(12, 86);
            this.productos.Name = "productos";
            this.productos.Size = new System.Drawing.Size(194, 234);
            this.productos.TabIndex = 0;
            this.productos.Text = "Producto";
            this.productos.UseVisualStyleBackColor = true;
            this.productos.Click += new System.EventHandler(this.button1_Click);
            // 
            // Ventas
            // 
            this.Ventas.Image = global::Restaurante.Properties.Resources.Indian_Food_PNG_Photos;
            this.Ventas.Location = new System.Drawing.Point(203, 86);
            this.Ventas.Name = "Ventas";
            this.Ventas.Size = new System.Drawing.Size(193, 234);
            this.Ventas.TabIndex = 1;
            this.Ventas.Text = "Ventas";
            this.Ventas.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(394, 86);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(199, 234);
            this.button3.TabIndex = 2;
            this.button3.Text = "Clientes";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(591, 86);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(189, 234);
            this.button4.TabIndex = 3;
            this.button4.Text = "Proveedores";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Ventas);
            this.Controls.Add(this.productos);
            this.Name = "Form1";
            this.Text = "Rest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button productos;
        private System.Windows.Forms.Button Ventas;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

