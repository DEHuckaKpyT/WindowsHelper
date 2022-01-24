namespace WindowsHelper.CustomForm
{
    partial class TransparentWindowForm
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
            this.CloseWindowButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CloseWindowButton
            // 
            this.CloseWindowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseWindowButton.BackColor = System.Drawing.Color.Red;
            this.CloseWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseWindowButton.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CloseWindowButton.Location = new System.Drawing.Point(1243, 1);
            this.CloseWindowButton.Name = "CloseWindowButton";
            this.CloseWindowButton.Size = new System.Drawing.Size(20, 10);
            this.CloseWindowButton.TabIndex = 0;
            this.CloseWindowButton.UseVisualStyleBackColor = false;
            this.CloseWindowButton.Click += new System.EventHandler(this.CloseWindowButton_Click);
            // 
            // TransparentWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1264, 704);
            this.ControlBox = false;
            this.Controls.Add(this.CloseWindowButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "TransparentWindowForm";
            this.Opacity = 0.5D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TransparentWindowForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button CloseWindowButton;
    }
}