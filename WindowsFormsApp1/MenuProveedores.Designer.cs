namespace WindowsFormsApp1
{
    partial class MenuProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuProveedores));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.productos = new System.Windows.Forms.Button();
            this.ventas = new System.Windows.Forms.Button();
            this.proveedores = new System.Windows.Forms.Button();
            this.pos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(75)))), ((int)(((byte)(135)))));
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(9, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(60, 60);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(75)))), ((int)(((byte)(135)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(755, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
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
            this.label1.TabIndex = 8;
            this.label1.Text = "Abarrotes el Toro";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(75)))), ((int)(((byte)(135)))));
            this.pictureBox1.Location = new System.Drawing.Point(-3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1267, 80);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // productos
            // 
            this.productos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(143)))), ((int)(((byte)(204)))));
            this.productos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("productos.BackgroundImage")));
            this.productos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.productos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.productos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productos.ForeColor = System.Drawing.Color.White;
            this.productos.Location = new System.Drawing.Point(250, 392);
            this.productos.Name = "productos";
            this.productos.Size = new System.Drawing.Size(360, 260);
            this.productos.TabIndex = 23;
            this.productos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.productos.UseMnemonic = false;
            this.productos.UseVisualStyleBackColor = false;
            // 
            // ventas
            // 
            this.ventas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(143)))), ((int)(((byte)(204)))));
            this.ventas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ventas.BackgroundImage")));
            this.ventas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ventas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ventas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventas.ForeColor = System.Drawing.Color.White;
            this.ventas.Location = new System.Drawing.Point(675, 392);
            this.ventas.Name = "ventas";
            this.ventas.Size = new System.Drawing.Size(360, 260);
            this.ventas.TabIndex = 22;
            this.ventas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ventas.UseMnemonic = false;
            this.ventas.UseVisualStyleBackColor = false;
            this.ventas.Click += new System.EventHandler(this.ventas_Click);
            // 
            // proveedores
            // 
            this.proveedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(143)))), ((int)(((byte)(204)))));
            this.proveedores.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("proveedores.BackgroundImage")));
            this.proveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.proveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.proveedores.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proveedores.ForeColor = System.Drawing.Color.White;
            this.proveedores.Location = new System.Drawing.Point(672, 104);
            this.proveedores.Name = "proveedores";
            this.proveedores.Size = new System.Drawing.Size(360, 260);
            this.proveedores.TabIndex = 21;
            this.proveedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.proveedores.UseMnemonic = false;
            this.proveedores.UseVisualStyleBackColor = false;
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
            this.pos.Location = new System.Drawing.Point(250, 104);
            this.pos.Name = "pos";
            this.pos.Size = new System.Drawing.Size(360, 260);
            this.pos.TabIndex = 20;
            this.pos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.pos.UseMnemonic = false;
            this.pos.UseVisualStyleBackColor = false;
            this.pos.Click += new System.EventHandler(this.pos_Click);
            // 
            // MenuProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.productos);
            this.Controls.Add(this.ventas);
            this.Controls.Add(this.proveedores);
            this.Controls.Add(this.pos);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MenuProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú de proveedores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuProveedores_FormClosing);
            this.Load += new System.EventHandler(this.MenuProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button productos;
        private System.Windows.Forms.Button ventas;
        private System.Windows.Forms.Button proveedores;
        private System.Windows.Forms.Button pos;
    }
}