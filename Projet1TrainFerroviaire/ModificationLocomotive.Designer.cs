namespace Projet1TrainFerroviaire
{
    partial class ModificationLocomotive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificationLocomotive));
            this.nomLocomotive_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.moyenVoyage_rbtn = new System.Windows.Forms.RadioButton();
            this.longVoyage_rbtn = new System.Windows.Forms.RadioButton();
            this.courtVoyage_rbtn = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.green_rbtn = new System.Windows.Forms.RadioButton();
            this.blue_rbtn = new System.Windows.Forms.RadioButton();
            this.brown_rbtn = new System.Windows.Forms.RadioButton();
            this.modifierLocomotive_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nomLocomotive_txt
            // 
            this.nomLocomotive_txt.Location = new System.Drawing.Point(368, 78);
            this.nomLocomotive_txt.Name = "nomLocomotive_txt";
            this.nomLocomotive_txt.Size = new System.Drawing.Size(174, 20);
            this.nomLocomotive_txt.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(360, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "Color";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(309, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "Type de Locomotive";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(190, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "Nom de la Locomotive :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(279, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "Modification de la Locomotive";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.moyenVoyage_rbtn);
            this.groupBox1.Controls.Add(this.longVoyage_rbtn);
            this.groupBox1.Controls.Add(this.courtVoyage_rbtn);
            this.groupBox1.Location = new System.Drawing.Point(178, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 68);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // moyenVoyage_rbtn
            // 
            this.moyenVoyage_rbtn.AutoSize = true;
            this.moyenVoyage_rbtn.Location = new System.Drawing.Point(164, 32);
            this.moyenVoyage_rbtn.Name = "moyenVoyage_rbtn";
            this.moyenVoyage_rbtn.Size = new System.Drawing.Size(93, 17);
            this.moyenVoyage_rbtn.TabIndex = 6;
            this.moyenVoyage_rbtn.TabStop = true;
            this.moyenVoyage_rbtn.Text = "MoyenVoyage";
            this.moyenVoyage_rbtn.UseVisualStyleBackColor = true;
            // 
            // longVoyage_rbtn
            // 
            this.longVoyage_rbtn.AutoSize = true;
            this.longVoyage_rbtn.Location = new System.Drawing.Point(46, 32);
            this.longVoyage_rbtn.Name = "longVoyage_rbtn";
            this.longVoyage_rbtn.Size = new System.Drawing.Size(85, 17);
            this.longVoyage_rbtn.TabIndex = 5;
            this.longVoyage_rbtn.TabStop = true;
            this.longVoyage_rbtn.Text = "LongVoyage";
            this.longVoyage_rbtn.UseVisualStyleBackColor = true;
            // 
            // courtVoyage_rbtn
            // 
            this.courtVoyage_rbtn.AutoSize = true;
            this.courtVoyage_rbtn.Location = new System.Drawing.Point(282, 32);
            this.courtVoyage_rbtn.Name = "courtVoyage_rbtn";
            this.courtVoyage_rbtn.Size = new System.Drawing.Size(86, 17);
            this.courtVoyage_rbtn.TabIndex = 7;
            this.courtVoyage_rbtn.TabStop = true;
            this.courtVoyage_rbtn.Text = "CourtVoyage";
            this.courtVoyage_rbtn.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.green_rbtn);
            this.groupBox2.Controls.Add(this.blue_rbtn);
            this.groupBox2.Controls.Add(this.brown_rbtn);
            this.groupBox2.Location = new System.Drawing.Point(178, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 69);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // green_rbtn
            // 
            this.green_rbtn.AutoSize = true;
            this.green_rbtn.Location = new System.Drawing.Point(282, 33);
            this.green_rbtn.Name = "green_rbtn";
            this.green_rbtn.Size = new System.Drawing.Size(54, 17);
            this.green_rbtn.TabIndex = 11;
            this.green_rbtn.TabStop = true;
            this.green_rbtn.Text = "Green";
            this.green_rbtn.UseVisualStyleBackColor = true;
            // 
            // blue_rbtn
            // 
            this.blue_rbtn.AutoSize = true;
            this.blue_rbtn.Location = new System.Drawing.Point(46, 33);
            this.blue_rbtn.Name = "blue_rbtn";
            this.blue_rbtn.Size = new System.Drawing.Size(46, 17);
            this.blue_rbtn.TabIndex = 9;
            this.blue_rbtn.TabStop = true;
            this.blue_rbtn.Text = "Blue";
            this.blue_rbtn.UseVisualStyleBackColor = true;
            // 
            // brown_rbtn
            // 
            this.brown_rbtn.AutoSize = true;
            this.brown_rbtn.Location = new System.Drawing.Point(164, 33);
            this.brown_rbtn.Name = "brown_rbtn";
            this.brown_rbtn.Size = new System.Drawing.Size(55, 17);
            this.brown_rbtn.TabIndex = 10;
            this.brown_rbtn.TabStop = true;
            this.brown_rbtn.Text = "Brown";
            this.brown_rbtn.UseVisualStyleBackColor = true;
            // 
            // modifierLocomotive_btn
            // 
            this.modifierLocomotive_btn.BackColor = System.Drawing.Color.Tan;
            this.modifierLocomotive_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modifierLocomotive_btn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifierLocomotive_btn.ForeColor = System.Drawing.Color.Gray;
            this.modifierLocomotive_btn.Location = new System.Drawing.Point(312, 362);
            this.modifierLocomotive_btn.Name = "modifierLocomotive_btn";
            this.modifierLocomotive_btn.Size = new System.Drawing.Size(145, 30);
            this.modifierLocomotive_btn.TabIndex = 27;
            this.modifierLocomotive_btn.Text = "Modifier la locomotive";
            this.modifierLocomotive_btn.UseVisualStyleBackColor = false;
            this.modifierLocomotive_btn.Click += new System.EventHandler(this.modifierLocomotive_btn_Click);
            // 
            // ModificationLocomotive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.modifierLocomotive_btn);
            this.Controls.Add(this.nomLocomotive_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModificationLocomotive";
            this.Text = "Modification Locomotive";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nomLocomotive_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton moyenVoyage_rbtn;
        private System.Windows.Forms.RadioButton longVoyage_rbtn;
        private System.Windows.Forms.RadioButton courtVoyage_rbtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton green_rbtn;
        private System.Windows.Forms.RadioButton blue_rbtn;
        private System.Windows.Forms.RadioButton brown_rbtn;
        private System.Windows.Forms.Button modifierLocomotive_btn;
    }
}