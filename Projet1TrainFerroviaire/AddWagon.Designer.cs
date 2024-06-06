namespace Projet1TrainFerroviaire
{
    partial class AddWagon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddWagon));
            this.addWagon_btn = new System.Windows.Forms.Button();
            this.wagon_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.animaux_rbtn = new System.Windows.Forms.RadioButton();
            this.grain_rbtn = new System.Windows.Forms.RadioButton();
            this.citerne_rbtn = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.black_rbtn = new System.Windows.Forms.RadioButton();
            this.gray_rbtn = new System.Windows.Forms.RadioButton();
            this.wood_rbtn = new System.Windows.Forms.RadioButton();
            this.yellow_rbtn = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // addWagon_btn
            // 
            this.addWagon_btn.BackColor = System.Drawing.Color.Tan;
            this.addWagon_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addWagon_btn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addWagon_btn.ForeColor = System.Drawing.Color.Gray;
            this.addWagon_btn.Location = new System.Drawing.Point(310, 371);
            this.addWagon_btn.Name = "addWagon_btn";
            this.addWagon_btn.Size = new System.Drawing.Size(157, 30);
            this.addWagon_btn.TabIndex = 37;
            this.addWagon_btn.Text = "Ajouter le Wagon";
            this.addWagon_btn.UseVisualStyleBackColor = false;
            this.addWagon_btn.Click += new System.EventHandler(this.addWagon_btn_Click);
            // 
            // wagon_txt
            // 
            this.wagon_txt.Location = new System.Drawing.Point(385, 90);
            this.wagon_txt.Name = "wagon_txt";
            this.wagon_txt.Size = new System.Drawing.Size(174, 20);
            this.wagon_txt.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(365, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 33;
            this.label5.Text = "Color";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(154, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 32;
            this.label4.Text = "Type de Wagon";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(250, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "Nom du Wagon : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(360, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 30;
            this.label2.Text = "Wagon";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.animaux_rbtn);
            this.groupBox1.Controls.Add(this.grain_rbtn);
            this.groupBox1.Controls.Add(this.citerne_rbtn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(182, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 68);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // animaux_rbtn
            // 
            this.animaux_rbtn.AutoSize = true;
            this.animaux_rbtn.Location = new System.Drawing.Point(181, 32);
            this.animaux_rbtn.Name = "animaux_rbtn";
            this.animaux_rbtn.Size = new System.Drawing.Size(65, 17);
            this.animaux_rbtn.TabIndex = 8;
            this.animaux_rbtn.TabStop = true;
            this.animaux_rbtn.Text = "Animaux";
            this.animaux_rbtn.UseVisualStyleBackColor = true;
            this.animaux_rbtn.CheckedChanged += new System.EventHandler(this.animaux_rbtn_CheckedChanged);
            // 
            // grain_rbtn
            // 
            this.grain_rbtn.AutoSize = true;
            this.grain_rbtn.Location = new System.Drawing.Point(73, 32);
            this.grain_rbtn.Name = "grain_rbtn";
            this.grain_rbtn.Size = new System.Drawing.Size(50, 17);
            this.grain_rbtn.TabIndex = 5;
            this.grain_rbtn.TabStop = true;
            this.grain_rbtn.Text = "Grain";
            this.grain_rbtn.UseVisualStyleBackColor = true;
            this.grain_rbtn.CheckedChanged += new System.EventHandler(this.grain_rbtn_CheckedChanged);
            // 
            // citerne_rbtn
            // 
            this.citerne_rbtn.AutoSize = true;
            this.citerne_rbtn.Location = new System.Drawing.Point(310, 32);
            this.citerne_rbtn.Name = "citerne_rbtn";
            this.citerne_rbtn.Size = new System.Drawing.Size(58, 17);
            this.citerne_rbtn.TabIndex = 7;
            this.citerne_rbtn.TabStop = true;
            this.citerne_rbtn.Text = "Citerne";
            this.citerne_rbtn.UseVisualStyleBackColor = true;
            this.citerne_rbtn.CheckedChanged += new System.EventHandler(this.citerne_rbtn_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.black_rbtn);
            this.groupBox2.Controls.Add(this.gray_rbtn);
            this.groupBox2.Controls.Add(this.wood_rbtn);
            this.groupBox2.Controls.Add(this.yellow_rbtn);
            this.groupBox2.Location = new System.Drawing.Point(182, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 69);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            // 
            // black_rbtn
            // 
            this.black_rbtn.AutoSize = true;
            this.black_rbtn.Enabled = false;
            this.black_rbtn.Location = new System.Drawing.Point(310, 31);
            this.black_rbtn.Name = "black_rbtn";
            this.black_rbtn.Size = new System.Drawing.Size(52, 17);
            this.black_rbtn.TabIndex = 13;
            this.black_rbtn.TabStop = true;
            this.black_rbtn.Text = "Black";
            this.black_rbtn.UseVisualStyleBackColor = true;
            // 
            // gray_rbtn
            // 
            this.gray_rbtn.AutoSize = true;
            this.gray_rbtn.Enabled = false;
            this.gray_rbtn.Location = new System.Drawing.Point(155, 31);
            this.gray_rbtn.Name = "gray_rbtn";
            this.gray_rbtn.Size = new System.Drawing.Size(47, 17);
            this.gray_rbtn.TabIndex = 12;
            this.gray_rbtn.TabStop = true;
            this.gray_rbtn.Text = "Gray";
            this.gray_rbtn.UseVisualStyleBackColor = true;
            // 
            // wood_rbtn
            // 
            this.wood_rbtn.AutoSize = true;
            this.wood_rbtn.Enabled = false;
            this.wood_rbtn.Location = new System.Drawing.Point(228, 31);
            this.wood_rbtn.Name = "wood_rbtn";
            this.wood_rbtn.Size = new System.Drawing.Size(54, 17);
            this.wood_rbtn.TabIndex = 11;
            this.wood_rbtn.TabStop = true;
            this.wood_rbtn.Text = "Wood";
            this.wood_rbtn.UseVisualStyleBackColor = true;
            // 
            // yellow_rbtn
            // 
            this.yellow_rbtn.AutoSize = true;
            this.yellow_rbtn.Enabled = false;
            this.yellow_rbtn.Location = new System.Drawing.Point(73, 31);
            this.yellow_rbtn.Name = "yellow_rbtn";
            this.yellow_rbtn.Size = new System.Drawing.Size(56, 17);
            this.yellow_rbtn.TabIndex = 9;
            this.yellow_rbtn.TabStop = true;
            this.yellow_rbtn.Text = "Yellow";
            this.yellow_rbtn.UseVisualStyleBackColor = true;
            // 
            // AddWagon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addWagon_btn);
            this.Controls.Add(this.wagon_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddWagon";
            this.Text = "Ajout du Wagon";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addWagon_btn;
        private System.Windows.Forms.TextBox wagon_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton grain_rbtn;
        private System.Windows.Forms.RadioButton citerne_rbtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton wood_rbtn;
        private System.Windows.Forms.RadioButton yellow_rbtn;
        private System.Windows.Forms.RadioButton animaux_rbtn;
        private System.Windows.Forms.RadioButton black_rbtn;
        private System.Windows.Forms.RadioButton gray_rbtn;
    }
}