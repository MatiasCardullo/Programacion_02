namespace WindowsFormsApplication
{
    partial class Form1
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
            this.btnPunto1 = new System.Windows.Forms.Button();
            this.btnPunto2 = new System.Windows.Forms.Button();
            this.btnPunto3 = new System.Windows.Forms.Button();
            this.btnPunto4 = new System.Windows.Forms.Button();
            this.btnPunto5 = new System.Windows.Forms.Button();
            this.rtbTextoSalida = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnPunto1
            // 
            this.btnPunto1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPunto1.Location = new System.Drawing.Point(9, 12);
            this.btnPunto1.Name = "btnPunto1";
            this.btnPunto1.Size = new System.Drawing.Size(134, 67);
            this.btnPunto1.TabIndex = 0;
            this.btnPunto1.Text = "Punto 1";
            this.btnPunto1.UseVisualStyleBackColor = true;
            this.btnPunto1.Click += new System.EventHandler(this.btnPunto1_Click);
            // 
            // btnPunto2
            // 
            this.btnPunto2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPunto2.Location = new System.Drawing.Point(162, 12);
            this.btnPunto2.Name = "btnPunto2";
            this.btnPunto2.Size = new System.Drawing.Size(134, 67);
            this.btnPunto2.TabIndex = 1;
            this.btnPunto2.Text = "Punto 2";
            this.btnPunto2.UseVisualStyleBackColor = true;
            this.btnPunto2.Click += new System.EventHandler(this.btnPunto2_Click);
            // 
            // btnPunto3
            // 
            this.btnPunto3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPunto3.Location = new System.Drawing.Point(9, 95);
            this.btnPunto3.Name = "btnPunto3";
            this.btnPunto3.Size = new System.Drawing.Size(134, 67);
            this.btnPunto3.TabIndex = 2;
            this.btnPunto3.Text = "Punto 3";
            this.btnPunto3.UseVisualStyleBackColor = true;
            this.btnPunto3.Click += new System.EventHandler(this.btnPunto3_Click);
            // 
            // btnPunto4
            // 
            this.btnPunto4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPunto4.Location = new System.Drawing.Point(162, 95);
            this.btnPunto4.Name = "btnPunto4";
            this.btnPunto4.Size = new System.Drawing.Size(134, 67);
            this.btnPunto4.TabIndex = 3;
            this.btnPunto4.Text = "Punto 4";
            this.btnPunto4.UseVisualStyleBackColor = true;
            this.btnPunto4.Click += new System.EventHandler(this.btnPunto4_Click);
            // 
            // btnPunto5
            // 
            this.btnPunto5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPunto5.Location = new System.Drawing.Point(89, 183);
            this.btnPunto5.Name = "btnPunto5";
            this.btnPunto5.Size = new System.Drawing.Size(134, 67);
            this.btnPunto5.TabIndex = 4;
            this.btnPunto5.Text = "Punto 5";
            this.btnPunto5.UseVisualStyleBackColor = true;
            this.btnPunto5.Click += new System.EventHandler(this.btnPunto5_Click);
            // 
            // rtbTextoSalida
            // 
            this.rtbTextoSalida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rtbTextoSalida.Location = new System.Drawing.Point(302, 12);
            this.rtbTextoSalida.Name = "rtbTextoSalida";
            this.rtbTextoSalida.Size = new System.Drawing.Size(361, 238);
            this.rtbTextoSalida.TabIndex = 5;
            this.rtbTextoSalida.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 262);
            this.Controls.Add(this.rtbTextoSalida);
            this.Controls.Add(this.btnPunto5);
            this.Controls.Add(this.btnPunto4);
            this.Controls.Add(this.btnPunto3);
            this.Controls.Add(this.btnPunto2);
            this.Controls.Add(this.btnPunto1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPunto1;
        private System.Windows.Forms.Button btnPunto2;
        private System.Windows.Forms.Button btnPunto3;
        private System.Windows.Forms.Button btnPunto4;
        private System.Windows.Forms.Button btnPunto5;
        private System.Windows.Forms.RichTextBox rtbTextoSalida;
    }
}

