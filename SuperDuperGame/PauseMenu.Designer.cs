
namespace SuperDuperGame
{
    partial class PauseMenu
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
            this.Продолжить = new System.Windows.Forms.Button();
            this.кВыборуУровня = new System.Windows.Forms.Button();
            this.Выход = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Продолжить
            // 
            this.Продолжить.Location = new System.Drawing.Point(141, 61);
            this.Продолжить.Name = "Продолжить";
            this.Продолжить.Size = new System.Drawing.Size(178, 64);
            this.Продолжить.TabIndex = 0;
            this.Продолжить.Text = "button1";
            this.Продолжить.UseVisualStyleBackColor = true;
            this.Продолжить.Click += new System.EventHandler(this.Продолжить_Click);
            // 
            // кВыборуУровня
            // 
            this.кВыборуУровня.Location = new System.Drawing.Point(144, 166);
            this.кВыборуУровня.Name = "кВыборуУровня";
            this.кВыборуУровня.Size = new System.Drawing.Size(175, 62);
            this.кВыборуУровня.TabIndex = 1;
            this.кВыборуУровня.Text = "button1";
            this.кВыборуУровня.UseVisualStyleBackColor = true;
            this.кВыборуУровня.Click += new System.EventHandler(this.кВыборуУровня_Click);
            // 
            // Выход
            // 
            this.Выход.Location = new System.Drawing.Point(144, 273);
            this.Выход.Name = "Выход";
            this.Выход.Size = new System.Drawing.Size(175, 63);
            this.Выход.TabIndex = 2;
            this.Выход.Text = "button1";
            this.Выход.UseVisualStyleBackColor = true;
            this.Выход.Click += new System.EventHandler(this.Выход_Click);
            // 
            // PauseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 421);
            this.Controls.Add(this.Выход);
            this.Controls.Add(this.кВыборуУровня);
            this.Controls.Add(this.Продолжить);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PauseMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PauseMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Продолжить;
        private System.Windows.Forms.Button кВыборуУровня;
        private System.Windows.Forms.Button Выход;
    }
}