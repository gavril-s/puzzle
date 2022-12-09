namespace Puzzle
{
    partial class StartForm
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
            this.components = new System.ComponentModel.Container();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.selectImageButton = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.runGameButton = new System.Windows.Forms.Button();
            this.columnsTextBox = new System.Windows.Forms.TextBox();
            this.rowsTextBox = new System.Windows.Forms.TextBox();
            this.columnsHintLabel = new System.Windows.Forms.Label();
            this.rowsHintLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(5, 5);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(790, 360);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox.TabIndex = 0;
            this.imageBox.TabStop = false;
            // 
            // selectImageButton
            // 
            this.selectImageButton.Location = new System.Drawing.Point(50, 400);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(180, 30);
            this.selectImageButton.TabIndex = 1;
            this.selectImageButton.Text = "Выбрать изображение";
            this.selectImageButton.UseVisualStyleBackColor = true;
            // 
            // runGameButton
            // 
            this.runGameButton.Location = new System.Drawing.Point(586, 400);
            this.runGameButton.Name = "runGameButton";
            this.runGameButton.Size = new System.Drawing.Size(180, 30);
            this.runGameButton.TabIndex = 2;
            this.runGameButton.Text = "Начать";
            this.runGameButton.UseVisualStyleBackColor = true;
            // 
            // columnsTextBox
            // 
            this.columnsTextBox.Location = new System.Drawing.Point(408, 420);
            this.columnsTextBox.Name = "columnsTextBox";
            this.columnsTextBox.Size = new System.Drawing.Size(100, 20);
            this.columnsTextBox.TabIndex = 3;
            // 
            // rowsTextBox
            // 
            this.rowsTextBox.Location = new System.Drawing.Point(408, 390);
            this.rowsTextBox.Name = "rowsTextBox";
            this.rowsTextBox.Size = new System.Drawing.Size(100, 20);
            this.rowsTextBox.TabIndex = 4;
            // 
            // columnsHintLabel
            // 
            this.columnsHintLabel.AutoSize = true;
            this.columnsHintLabel.Location = new System.Drawing.Point(281, 423);
            this.columnsHintLabel.Name = "columnsHintLabel";
            this.columnsHintLabel.Size = new System.Drawing.Size(116, 13);
            this.columnsHintLabel.TabIndex = 5;
            this.columnsHintLabel.Text = "Количество столбцов";
            // 
            // rowsHintLabel
            // 
            this.rowsHintLabel.AutoSize = true;
            this.rowsHintLabel.Location = new System.Drawing.Point(300, 393);
            this.rowsHintLabel.Name = "rowsHintLabel";
            this.rowsHintLabel.Size = new System.Drawing.Size(98, 13);
            this.rowsHintLabel.TabIndex = 6;
            this.rowsHintLabel.Text = "Количество строк";
            // 
            // StartForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.rowsHintLabel);
            this.Controls.Add(this.columnsHintLabel);
            this.Controls.Add(this.rowsTextBox);
            this.Controls.Add(this.columnsTextBox);
            this.Controls.Add(this.runGameButton);
            this.Controls.Add(this.selectImageButton);
            this.Controls.Add(this.imageBox);
            this.Name = "StartForm";
            this.Text = "Пазл";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Button selectImageButton;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button runGameButton;
        private System.Windows.Forms.TextBox columnsTextBox;
        private System.Windows.Forms.TextBox rowsTextBox;
        private System.Windows.Forms.Label columnsHintLabel;
        private System.Windows.Forms.Label rowsHintLabel;
    }
}