﻿namespace CertificationInterface
{
    partial class MainWindow
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
            this.btn_ConfigureAwait = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ConfigureAwait
            // 
            this.btn_ConfigureAwait.Location = new System.Drawing.Point(137, 47);
            this.btn_ConfigureAwait.Name = "btn_ConfigureAwait";
            this.btn_ConfigureAwait.Size = new System.Drawing.Size(96, 23);
            this.btn_ConfigureAwait.TabIndex = 0;
            this.btn_ConfigureAwait.Text = "Configure Await";
            this.btn_ConfigureAwait.UseVisualStyleBackColor = true;
            this.btn_ConfigureAwait.Click += new System.EventHandler(this.btn_ConfigureAwait_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 261);
            this.Controls.Add(this.btn_ConfigureAwait);
            this.Name = "MainWindow";
            this.Text = "Certification Exam Ref 70-483";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ConfigureAwait;
    }
}

