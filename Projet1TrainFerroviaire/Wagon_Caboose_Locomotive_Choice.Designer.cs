namespace Projet1TrainFerroviaire
{
    partial class Wagon_Caboose_Locomotive_Choice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wagon_Caboose_Locomotive_Choice));
            this.label2 = new System.Windows.Forms.Label();
            this.AddCaboose = new System.Windows.Forms.Button();
            this.AddWagon = new System.Windows.Forms.Button();
            this.AddLocomotive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(276, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quel véhicule voulez-vous ajouter ?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddCaboose
            // 
            this.AddCaboose.BackColor = System.Drawing.Color.Tan;
            this.AddCaboose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddCaboose.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCaboose.ForeColor = System.Drawing.Color.Gray;
            this.AddCaboose.Location = new System.Drawing.Point(321, 275);
            this.AddCaboose.Name = "AddCaboose";
            this.AddCaboose.Size = new System.Drawing.Size(145, 30);
            this.AddCaboose.TabIndex = 18;
            this.AddCaboose.Text = "Caboose";
            this.AddCaboose.UseVisualStyleBackColor = false;
            this.AddCaboose.Click += new System.EventHandler(this.AddCaboose_Click);
            // 
            // AddWagon
            // 
            this.AddWagon.BackColor = System.Drawing.Color.Tan;
            this.AddWagon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddWagon.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddWagon.ForeColor = System.Drawing.Color.Gray;
            this.AddWagon.Location = new System.Drawing.Point(118, 275);
            this.AddWagon.Name = "AddWagon";
            this.AddWagon.Size = new System.Drawing.Size(145, 30);
            this.AddWagon.TabIndex = 19;
            this.AddWagon.Text = "Wagon";
            this.AddWagon.UseVisualStyleBackColor = false;
            this.AddWagon.Click += new System.EventHandler(this.AddWagon_Click);
            // 
            // AddLocomotive
            // 
            this.AddLocomotive.BackColor = System.Drawing.Color.Tan;
            this.AddLocomotive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddLocomotive.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddLocomotive.ForeColor = System.Drawing.Color.Gray;
            this.AddLocomotive.Location = new System.Drawing.Point(524, 275);
            this.AddLocomotive.Name = "AddLocomotive";
            this.AddLocomotive.Size = new System.Drawing.Size(145, 30);
            this.AddLocomotive.TabIndex = 20;
            this.AddLocomotive.Text = "Locomotive";
            this.AddLocomotive.UseVisualStyleBackColor = false;
            this.AddLocomotive.Click += new System.EventHandler(this.AddLocomotive_Click);
            // 
            // Wagon_Caboose_Locomotive_Choice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddLocomotive);
            this.Controls.Add(this.AddWagon);
            this.Controls.Add(this.AddCaboose);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Wagon_Caboose_Locomotive_Choice";
            this.Text = "Choix de Vehicule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddCaboose;
        private System.Windows.Forms.Button AddWagon;
        private System.Windows.Forms.Button AddLocomotive;
    }
}