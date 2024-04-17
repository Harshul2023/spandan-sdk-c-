namespace SPANDAN_SDK_POC
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            label2 = new Label();
            checkBox1 = new CheckBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(221, 442);
            button1.Name = "button1";
            button1.Size = new Size(233, 46);
            button1.TabIndex = 0;
            button1.Text = "Create-Lead II-Test";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(540, 442);
            button2.Name = "button2";
            button2.Size = new Size(215, 46);
            button2.TabIndex = 1;
            button2.Text = "Start Lead II Trace";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(221, 158);
            label1.Name = "label1";
            label1.Size = new Size(293, 32);
            label1.TabIndex = 2;
            label1.Tag = "Welcome to Spandan SDK";
            label1.Text = "Welcome to Spandan SDK";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(221, 530);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(554, 46);
            progressBar1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(221, 289);
            label2.Name = "label2";
            label2.Size = new Size(261, 32);
            label2.TabIndex = 4;
            label2.Text = "User Authentication : - ";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(513, 289);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(196, 36);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Authenticated";
            checkBox1.UseVisualStyleBackColor = true;
  
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(221, 708);
            label3.Name = "label3";
            label3.Size = new Size(0, 32);
            label3.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1325, 939);
            Controls.Add(label3);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private ProgressBar progressBar1;
        private Label label2;
        private CheckBox checkBox1;
        private Label label3;
    }
}
