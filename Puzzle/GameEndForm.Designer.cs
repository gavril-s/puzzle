namespace Puzzle
{
    partial class GameEndForm
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
            onDestroy();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.message = new System.Windows.Forms.Label();
            this.statsButton = new System.Windows.Forms.Button();
            this.newGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.message.Location = new System.Drawing.Point(136, 40);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(227, 39);
            this.message.TabIndex = 0;
            this.message.Text = "Пазл собран!";
            // 
            // statsButton
            // 
            this.statsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.statsButton.Location = new System.Drawing.Point(70, 140);
            this.statsButton.Name = "statsButton";
            this.statsButton.Size = new System.Drawing.Size(100, 30);
            this.statsButton.TabIndex = 1;
            this.statsButton.Text = "Справка";
            this.statsButton.UseVisualStyleBackColor = true;
            // 
            // newGameButton
            // 
            this.newGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.newGameButton.Location = new System.Drawing.Point(320, 140);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(100, 30);
            this.newGameButton.TabIndex = 2;
            this.newGameButton.Text = "Новая игра";
            this.newGameButton.UseVisualStyleBackColor = true;
            // 
            // GameEndForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.statsButton);
            this.Controls.Add(this.message);
            this.Name = "GameEndForm";
            this.Text = "Пазл";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Button statsButton;
        private System.Windows.Forms.Button newGameButton;
    }
}