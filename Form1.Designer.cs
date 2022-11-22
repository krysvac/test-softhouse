namespace test_softhouse
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
            this.oldData = new System.Windows.Forms.TextBox();
            this.newData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.convertButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // oldData
            // 
            this.oldData.Location = new System.Drawing.Point(12, 27);
            this.oldData.Multiline = true;
            this.oldData.Name = "oldData";
            this.oldData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.oldData.Size = new System.Drawing.Size(300, 180);
            this.oldData.TabIndex = 0;
            // 
            // newData
            // 
            this.newData.Location = new System.Drawing.Point(318, 27);
            this.newData.Multiline = true;
            this.newData.Name = "newData";
            this.newData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.newData.Size = new System.Drawing.Size(300, 180);
            this.newData.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Old data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "New data";
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(12, 213);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(75, 23);
            this.convertButton.TabIndex = 4;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 255);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newData);
            this.Controls.Add(this.oldData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox oldData;
        private TextBox newData;
        private Label label1;
        private Label label2;
        private Button convertButton;
    }
}