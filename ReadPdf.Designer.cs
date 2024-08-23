namespace ReadPdfInDotNet
{
    partial class ReadPdf
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
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(223, 9);
            label1.Name = "label1";
            label1.Size = new Size(384, 39);
            label1.TabIndex = 0;
            label1.Text = "Add your Pdf file to read";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Font = new Font("Georgia", 20F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(223, 121);
            button1.Name = "button1";
            button1.Size = new Size(300, 89);
            button1.TabIndex = 1;
            button1.Text = "Open File";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 260);
            label2.Name = "label2";
            label2.Size = new Size(228, 30);
            label2.TabIndex = 2;
            label2.Text = "Extracted Results : ";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(223, 268);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 3;
            label3.Text = "";
            label3.Click += label3_Click;
            // 
            // ReadPdf
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1080, 550);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "ReadPdf";
            Text = "ReadPdf";
            Load += ReadPdf_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label2;
        private Label label3;
    }
}
