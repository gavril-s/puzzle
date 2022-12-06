namespace Puzzle
{
    partial class GameForm
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
            this.puzzleGridPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // puzzleGridPanel
            // 
            this.puzzleGridPanel.Location = new System.Drawing.Point(242, 55);
            this.puzzleGridPanel.Name = "puzzleGridPanel";
            this.puzzleGridPanel.Size = new System.Drawing.Size(662, 526);
            this.puzzleGridPanel.TabIndex = 1;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 677);
            this.Controls.Add(this.puzzleGridPanel);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel puzzleGridPanel;
    }
}