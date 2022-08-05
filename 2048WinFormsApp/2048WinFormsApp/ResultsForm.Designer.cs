namespace _2048WinFormsApp
{
    partial class ResultsForm
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
            this.ResultsDataGridView = new System.Windows.Forms.DataGridView();
            this.HighScoreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserResultColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ResultsDataGridView
            // 
            this.ResultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HighScoreColumn,
            this.NameColumn,
            this.UserResultColumn});
            this.ResultsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ResultsDataGridView.Name = "ResultsDataGridView";
            this.ResultsDataGridView.RowHeadersWidth = 51;
            this.ResultsDataGridView.RowTemplate.Height = 29;
            this.ResultsDataGridView.Size = new System.Drawing.Size(506, 450);
            this.ResultsDataGridView.TabIndex = 0;
            // 
            // HighScoreColumn
            // 
            this.HighScoreColumn.HeaderText = "";
            this.HighScoreColumn.MinimumWidth = 6;
            this.HighScoreColumn.Name = "HighScoreColumn";
            this.HighScoreColumn.Width = 125;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Имя";
            this.NameColumn.MinimumWidth = 6;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.Width = 125;
            // 
            // UserResultColumn
            // 
            this.UserResultColumn.HeaderText = "Результат";
            this.UserResultColumn.MinimumWidth = 6;
            this.UserResultColumn.Name = "UserResultColumn";
            this.UserResultColumn.Width = 125;
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 450);
            this.Controls.Add(this.ResultsDataGridView);
            this.Name = "ResultsForm";
            this.Text = "ResultsForm";
            this.Load += new System.EventHandler(this.ResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResultsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DataGridView ResultsDataGridView;
        private DataGridViewTextBoxColumn HighScoreColumn;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn UserResultColumn;
    }
}