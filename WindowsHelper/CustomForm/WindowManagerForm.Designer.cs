namespace WindowsHelper.CustomForm
{
    partial class WindowManagerForm
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
            this.button1920x1080 = new System.Windows.Forms.Button();
            this.buttonSaveWindowPosition = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1920x1080
            // 
            this.button1920x1080.Location = new System.Drawing.Point(12, 12);
            this.button1920x1080.Name = "button1920x1080";
            this.button1920x1080.Size = new System.Drawing.Size(75, 23);
            this.button1920x1080.TabIndex = 0;
            this.button1920x1080.Text = "1920x1080";
            this.button1920x1080.UseVisualStyleBackColor = true;
            this.button1920x1080.Click += new System.EventHandler(this.button1920x1080_Click);
            // 
            // buttonSaveWindowPosition
            // 
            this.buttonSaveWindowPosition.Location = new System.Drawing.Point(12, 52);
            this.buttonSaveWindowPosition.Name = "buttonSaveWindowPosition";
            this.buttonSaveWindowPosition.Size = new System.Drawing.Size(193, 23);
            this.buttonSaveWindowPosition.TabIndex = 1;
            this.buttonSaveWindowPosition.Text = "Запомнить положение окна";
            this.buttonSaveWindowPosition.UseVisualStyleBackColor = true;
            this.buttonSaveWindowPosition.Click += new System.EventHandler(this.buttonSaveWindowPosition_Click);
            // 
            // WindowManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 436);
            this.Controls.Add(this.buttonSaveWindowPosition);
            this.Controls.Add(this.button1920x1080);
            this.Name = "WindowManagerForm";
            this.Text = "WindowManagerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1920x1080;
        private Button buttonSaveWindowPosition;
    }
}