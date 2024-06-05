namespace Projet1TrainFerroviaire
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AddTrain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddTrain
            // 
            this.AddTrain.BackColor = System.Drawing.Color.Tan;
            this.AddTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddTrain.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTrain.ForeColor = System.Drawing.Color.Gray;
            this.AddTrain.Location = new System.Drawing.Point(303, 12);
            this.AddTrain.Name = "AddTrain";
            this.AddTrain.Size = new System.Drawing.Size(150, 75);
            this.AddTrain.TabIndex = 0;
            this.AddTrain.Text = "Add Train";
            this.AddTrain.UseVisualStyleBackColor = false;
            this.AddTrain.Click += new System.EventHandler(this.AddTrain_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddTrain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "TrainManager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddTrain;
    }
}

