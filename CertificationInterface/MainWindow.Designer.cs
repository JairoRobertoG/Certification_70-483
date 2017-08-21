namespace CertificationInterface
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
            this.btn_thread_class = new System.Windows.Forms.Button();
            this.txtConsoleView = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_thread_class
            // 
            this.btn_thread_class.Location = new System.Drawing.Point(28, 37);
            this.btn_thread_class.Name = "btn_thread_class";
            this.btn_thread_class.Size = new System.Drawing.Size(274, 23);
            this.btn_thread_class.TabIndex = 0;
            this.btn_thread_class.Text = "LISTING 1-1 Creating a thread with the Thread class";
            this.btn_thread_class.UseVisualStyleBackColor = true;
            this.btn_thread_class.Click += new System.EventHandler(this.btn_thread_class_Click);
            // 
            // txtConsoleView
            // 
            this.txtConsoleView.Location = new System.Drawing.Point(28, 123);
            this.txtConsoleView.Multiline = true;
            this.txtConsoleView.Name = "txtConsoleView";
            this.txtConsoleView.Size = new System.Drawing.Size(384, 101);
            this.txtConsoleView.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 261);
            this.Controls.Add(this.txtConsoleView);
            this.Controls.Add(this.btn_thread_class);
            this.Name = "MainWindow";
            this.Text = "Certification Exam Ref 70-483";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_thread_class;
        private System.Windows.Forms.TextBox txtConsoleView;
    }
}

