
namespace SuperDuperGame
{
    partial class MainMenu
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
            this.Играть = new System.Windows.Forms.Button();
            this.Выход = new System.Windows.Forms.Button();
            this.Управление = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Играть
            // 
            this.Играть.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Играть.AutoSize = true;
            this.Играть.BackgroundImage = global::SuperDuperGame.Properties.Resources.Играть;
            this.Играть.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Играть.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Играть.FlatAppearance.BorderSize = 0;
            this.Играть.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Играть.Location = new System.Drawing.Point(525, 352);
            this.Играть.Margin = new System.Windows.Forms.Padding(2);
            this.Играть.Name = "Играть";
            this.Играть.Size = new System.Drawing.Size(230, 35);
            this.Играть.TabIndex = 0;
            this.Играть.UseVisualStyleBackColor = true;
            this.Играть.Click += new System.EventHandler(this.button1_Click);
            // 
            // Выход
            // 
            this.Выход.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Выход.AutoSize = true;
            this.Выход.BackColor = System.Drawing.Color.LightGreen;
            this.Выход.BackgroundImage = global::SuperDuperGame.Properties.Resources.выход1;
            this.Выход.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Выход.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Выход.FlatAppearance.BorderSize = 0;
            this.Выход.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Выход.Location = new System.Drawing.Point(545, 480);
            this.Выход.Margin = new System.Windows.Forms.Padding(2);
            this.Выход.Name = "Выход";
            this.Выход.Size = new System.Drawing.Size(195, 35);
            this.Выход.TabIndex = 1;
            this.Выход.UseVisualStyleBackColor = false;
            this.Выход.Click += new System.EventHandler(this.button2_Click);
            // 
            // Управление
            // 
            this.Управление.BackgroundImage = global::SuperDuperGame.Properties.Resources.Управление;
            this.Управление.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Управление.FlatAppearance.BorderSize = 0;
            this.Управление.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Управление.Location = new System.Drawing.Point(444, 416);
            this.Управление.Name = "Управление";
            this.Управление.Size = new System.Drawing.Size(395, 35);
            this.Управление.TabIndex = 2;
            this.Управление.UseVisualStyleBackColor = true;
            this.Управление.Click += new System.EventHandler(this.Управление_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackgroundImage = global::SuperDuperGame.Properties.Resources._20D04FE0_3AEA_1069_A2D8_08002B30309D_;
            this.ClientSize = new System.Drawing.Size(1280, 640);
            this.Controls.Add(this.Управление);
            this.Controls.Add(this.Выход);
            this.Controls.Add(this.Играть);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Играть;
        private System.Windows.Forms.Button Выход;
        private System.Windows.Forms.Button Управление;
    }
}