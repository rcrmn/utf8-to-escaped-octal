namespace UTF8_escape_C
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.hexRadioButton = new System.Windows.Forms.RadioButton();
            this.octalRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hexRadioButton);
            this.panel1.Controls.Add(this.octalRadioButton);
            this.panel1.Location = new System.Drawing.Point(12, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(157, 71);
            this.panel1.TabIndex = 1;
            // 
            // hexRadioButton
            // 
            this.hexRadioButton.AutoSize = true;
            this.hexRadioButton.Location = new System.Drawing.Point(26, 37);
            this.hexRadioButton.Name = "hexRadioButton";
            this.hexRadioButton.Size = new System.Drawing.Size(121, 17);
            this.hexRadioButton.TabIndex = 1;
            this.hexRadioButton.Text = "UTF-8 hex (\\u00XX)";
            this.hexRadioButton.UseVisualStyleBackColor = true;
            // 
            // octalRadioButton
            // 
            this.octalRadioButton.AutoSize = true;
            this.octalRadioButton.Checked = true;
            this.octalRadioButton.Location = new System.Drawing.Point(26, 13);
            this.octalRadioButton.Name = "octalRadioButton";
            this.octalRadioButton.Size = new System.Drawing.Size(82, 17);
            this.octalRadioButton.TabIndex = 0;
            this.octalRadioButton.TabStop = true;
            this.octalRadioButton.Text = "Octal (\\0oo)";
            this.octalRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Output Format";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 399);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton hexRadioButton;
        private System.Windows.Forms.RadioButton octalRadioButton;
        private System.Windows.Forms.Label label1;
    }
}

