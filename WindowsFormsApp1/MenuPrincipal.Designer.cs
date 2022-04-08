namespace WindowsFormsApp1
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pos = new System.Windows.Forms.Button();
            this.proveedores = new System.Windows.Forms.Button();
            this.compras = new System.Windows.Forms.Button();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.salir = new System.Windows.Forms.Button();
            this.ventas = new System.Windows.Forms.Button();
            this.productos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(75)))), ((int)(((byte)(135)))));
            this.pictureBox1.Location = new System.Drawing.Point(-3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1267, 80);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(75)))), ((int)(((byte)(135)))));
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(460, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Abarrotes el Toro";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(75)))), ((int)(((byte)(135)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(755, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pos
            // 
            this.pos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(143)))), ((int)(((byte)(204)))));
            this.pos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pos.BackgroundImage")));
            this.pos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pos.ForeColor = System.Drawing.Color.White;
            this.pos.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.pos.Location = new System.Drawing.Point(30, 102);
            this.pos.Name = "pos";
            this.pos.Size = new System.Drawing.Size(360, 260);
            this.pos.TabIndex = 9;
            this.pos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.pos.UseMnemonic = false;
            this.pos.UseVisualStyleBackColor = false;
            this.pos.Click += new System.EventHandler(this.pos_Click);
            // 
            // proveedores
            // 
            this.proveedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(143)))), ((int)(((byte)(204)))));
            this.proveedores.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("proveedores.BackgroundImage")));
            this.proveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.proveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.proveedores.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proveedores.ForeColor = System.Drawing.Color.White;
            this.proveedores.Location = new System.Drawing.Point(452, 102);
            this.proveedores.Name = "proveedores";
            this.proveedores.Size = new System.Drawing.Size(360, 260);
            this.proveedores.TabIndex = 11;
            this.proveedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.proveedores.UseMnemonic = false;
            this.proveedores.UseVisualStyleBackColor = false;
            this.proveedores.Click += new System.EventHandler(this.proveedores_Click);
            // 
            // compras
            // 
            this.compras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(143)))), ((int)(((byte)(204)))));
            this.compras.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("compras.BackgroundImage")));
            this.compras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.compras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.compras.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compras.ForeColor = System.Drawing.Color.White;
            this.compras.Location = new System.Drawing.Point(874, 102);
            this.compras.Name = "compras";
            this.compras.Size = new System.Drawing.Size(360, 260);
            this.compras.TabIndex = 13;
            this.compras.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.compras.UseMnemonic = false;
            this.compras.UseVisualStyleBackColor = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(143)))), ((int)(((byte)(204)))));
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(981, 434);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(150, 150);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 16;
            this.pictureBox8.TabStop = false;
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(143)))), ((int)(((byte)(204)))));
            this.salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.salir.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salir.ForeColor = System.Drawing.Color.White;
            this.salir.Location = new System.Drawing.Point(874, 390);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(360, 260);
            this.salir.TabIndex = 15;
            this.salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.salir.UseMnemonic = false;
            this.salir.UseVisualStyleBackColor = false;
            // 
            // ventas
            // 
            this.ventas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(143)))), ((int)(((byte)(204)))));
            this.ventas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ventas.BackgroundImage")));
            this.ventas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ventas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ventas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventas.ForeColor = System.Drawing.Color.White;
            this.ventas.Location = new System.Drawing.Point(455, 390);
            this.ventas.Name = "ventas";
            this.ventas.Size = new System.Drawing.Size(360, 260);
            this.ventas.TabIndex = 17;
            this.ventas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ventas.UseMnemonic = false;
            this.ventas.UseVisualStyleBackColor = false;
            // 
            // productos
            // 
            this.productos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(143)))), ((int)(((byte)(204)))));
            this.productos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("productos.BackgroundImage")));
            this.productos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.productos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.productos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productos.ForeColor = System.Drawing.Color.White;
            this.productos.Location = new System.Drawing.Point(30, 390);
            this.productos.Name = "productos";
            this.productos.Size = new System.Drawing.Size(360, 260);
            this.productos.TabIndex = 19;
            this.productos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.productos.UseMnemonic = false;
            this.productos.UseVisualStyleBackColor = false;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.productos);
            this.Controls.Add(this.ventas);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.compras);
            this.Controls.Add(this.proveedores);
            this.Controls.Add(this.pos);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú principal";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button pos;
        private System.Windows.Forms.Button proveedores;
        private System.Windows.Forms.Button compras;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Button ventas;
        private System.Windows.Forms.Button productos;
    }
}

