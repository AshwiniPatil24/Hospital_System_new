
namespace Ruby_Hospital
{
    partial class Master_Radiology
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Master_Radiology));
            this.panel_head = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtdate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCharges = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRadiologyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel_head.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_head
            // 
            this.panel_head.BackColor = System.Drawing.Color.Teal;
            this.panel_head.BackgroundImage = global::Ruby_Hospital.Properties.Resources.bg;
            this.panel_head.Controls.Add(this.label10);
            this.panel_head.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_head.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_head.Location = new System.Drawing.Point(0, 0);
            this.panel_head.Name = "panel_head";
            this.panel_head.Size = new System.Drawing.Size(1189, 40);
            this.panel_head.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(50, 5, 50, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(322, 36);
            this.label10.TabIndex = 2;
            this.label10.Text = "Master Radiology Test";
            // 
            // txtSearchName
            // 
            this.txtSearchName.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtSearchName.Location = new System.Drawing.Point(563, 172);
            this.txtSearchName.Multiline = true;
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(294, 29);
            this.txtSearchName.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(393, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 23);
            this.label2.TabIndex = 84;
            this.label2.Text = "Search By Test";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.panel1.BackgroundImage = global::Ruby_Hospital.Properties.Resources.bg;
            this.panel1.Controls.Add(this.txtdate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtCharges);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtRadiologyName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(97, 223);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 224);
            this.panel1.TabIndex = 88;
            // 
            // txtdate
            // 
            this.txtdate.Enabled = false;
            this.txtdate.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtdate.Location = new System.Drawing.Point(412, 173);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(129, 27);
            this.txtdate.TabIndex = 85;
            this.txtdate.Value = new System.DateTime(2023, 6, 30, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label5.Location = new System.Drawing.Point(299, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 21);
            this.label5.TabIndex = 84;
            this.label5.Text = "Added On";
            // 
            // txtCharges
            // 
            this.txtCharges.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtCharges.ForeColor = System.Drawing.Color.Gray;
            this.txtCharges.Location = new System.Drawing.Point(412, 112);
            this.txtCharges.MaxLength = 10;
            this.txtCharges.Multiline = true;
            this.txtCharges.Name = "txtCharges";
            this.txtCharges.Size = new System.Drawing.Size(366, 29);
            this.txtCharges.TabIndex = 84;
            this.txtCharges.Text = "Enter Charges";
            this.txtCharges.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCharges_MouseClick);
            this.txtCharges.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCharges_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label3.Location = new System.Drawing.Point(316, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 21);
            this.label3.TabIndex = 83;
            this.label3.Text = "Charges";
            // 
            // txtRadiologyName
            // 
            this.txtRadiologyName.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtRadiologyName.ForeColor = System.Drawing.Color.Gray;
            this.txtRadiologyName.Location = new System.Drawing.Point(412, 50);
            this.txtRadiologyName.MaxLength = 30;
            this.txtRadiologyName.Multiline = true;
            this.txtRadiologyName.Name = "txtRadiologyName";
            this.txtRadiologyName.Size = new System.Drawing.Size(366, 29);
            this.txtRadiologyName.TabIndex = 82;
            this.txtRadiologyName.Text = "Enter the Radiology Name";
            this.txtRadiologyName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRadiologyName_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(271, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Radiology Test";
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.BackColor = System.Drawing.Color.DarkGreen;
            this.btnsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnsave.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnsave.Location = new System.Drawing.Point(537, 534);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(131, 39);
            this.btnsave.TabIndex = 89;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(49, 468);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(1101, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 84;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(53, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1101, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Ruby_Hospital.Properties.Resources._264294910_108862081637008_8238947895213189007_n_removebg_preview;
            this.pictureBox2.Location = new System.Drawing.Point(1045, 39);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(144, 66);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 90;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::Ruby_Hospital.Properties.Resources.icons8_search_50__1_1;
            this.pictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox3.Location = new System.Drawing.Point(872, 167);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 34);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 88;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // Master_Radiology
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 591);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel_head);
            this.Name = "Master_Radiology";
            this.Text = "Master_Radiology";
            this.Load += new System.EventHandler(this.Master_Radiology_Load);
            this.panel_head.ResumeLayout(false);
            this.panel_head.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_head;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRadiologyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCharges;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtdate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}