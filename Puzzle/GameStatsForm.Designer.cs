namespace Puzzle
{
    partial class GameStatsForm
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
            this.piecesLabel = new System.Windows.Forms.Label();
            this.clicksLabel = new System.Windows.Forms.Label();
            this.secondsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // piecesLabel
            // 
            this.piecesLabel.AutoSize = true;
            this.piecesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.piecesLabel.Location = new System.Drawing.Point(35, 130);
            this.piecesLabel.Name = "piecesLabel";
            this.piecesLabel.Size = new System.Drawing.Size(49, 17);
            this.piecesLabel.TabIndex = 6;
            this.piecesLabel.Text = "pieces";
            // 
            // clicksLabel
            // 
            this.clicksLabel.AutoSize = true;
            this.clicksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.clicksLabel.Location = new System.Drawing.Point(35, 80);
            this.clicksLabel.Name = "clicksLabel";
            this.clicksLabel.Size = new System.Drawing.Size(42, 17);
            this.clicksLabel.TabIndex = 5;
            this.clicksLabel.Text = "clicks";
            // 
            // secondsLabel
            // 
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.secondsLabel.Location = new System.Drawing.Point(35, 30);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(61, 17);
            this.secondsLabel.TabIndex = 4;
            this.secondsLabel.Text = "seconds";
            // 
            // GameStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 171);
            this.Controls.Add(this.piecesLabel);
            this.Controls.Add(this.clicksLabel);
            this.Controls.Add(this.secondsLabel);
            this.Name = "GameStatsForm";
            this.Text = "Пазл";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label piecesLabel;
        private System.Windows.Forms.Label clicksLabel;
        private System.Windows.Forms.Label secondsLabel;
    }
}