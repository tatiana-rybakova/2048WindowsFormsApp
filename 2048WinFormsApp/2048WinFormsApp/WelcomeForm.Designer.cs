namespace _2048WinFormsApp
{
    partial class WelcomeForm
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
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.mapSizeLabel = new System.Windows.Forms.Label();
            this.sizeListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Location = new System.Drawing.Point(130, 63);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(147, 20);
            this.WelcomeLabel.TabIndex = 0;
            this.WelcomeLabel.Text = "Добро пожаловать!";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.NameLabel.Location = new System.Drawing.Point(150, 111);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(97, 20);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Введите имя";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(121, 397);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(198, 84);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Начать";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(24, 147);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(354, 27);
            this.NameTextBox.TabIndex = 4;
            // 
            // mapSizeLabel
            // 
            this.mapSizeLabel.AutoSize = true;
            this.mapSizeLabel.Location = new System.Drawing.Point(121, 208);
            this.mapSizeLabel.Name = "mapSizeLabel";
            this.mapSizeLabel.Size = new System.Drawing.Size(172, 20);
            this.mapSizeLabel.TabIndex = 5;
            this.mapSizeLabel.Text = "Выберите размер поля";
            // 
            // sizeListBox
            // 
            this.sizeListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sizeListBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sizeListBox.FormattingEnabled = true;
            this.sizeListBox.ItemHeight = 31;
            this.sizeListBox.Items.AddRange(new object[] {
            "4x4",
            "7x7",
            "9x9"});
            this.sizeListBox.Location = new System.Drawing.Point(187, 253);
            this.sizeListBox.Name = "sizeListBox";
            this.sizeListBox.Size = new System.Drawing.Size(48, 97);
            this.sizeListBox.TabIndex = 6;
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 520);
            this.Controls.Add(this.sizeListBox);
            this.Controls.Add(this.mapSizeLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.WelcomeLabel);
            this.Name = "WelcomeForm";
            this.Text = "WelcomeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label WelcomeLabel;
        private Label NameLabel;
        private Button StartButton;
        public TextBox NameTextBox;
        private Label mapSizeLabel;
        public ListBox sizeListBox;
    }
}