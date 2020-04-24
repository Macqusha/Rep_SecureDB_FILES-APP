namespace FileManager
{
    partial class Form2
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
            this.MyDataGridView = new System.Windows.Forms.DataGridView();
            this.TransactionTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSizeBefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSizeNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileChangedNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MyDataGridView
            // 
            this.MyDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyDataGridView.BackgroundColor = System.Drawing.Color.MintCream;
            this.MyDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.MyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionTime,
            this.Action,
            this.FileName,
            this.FileSizeBefore,
            this.FileSizeNew,
            this.FileChanged,
            this.FileChangedNew,
            this.FileCreated});
            this.MyDataGridView.GridColor = System.Drawing.Color.DarkSlateGray;
            this.MyDataGridView.Location = new System.Drawing.Point(12, 12);
            this.MyDataGridView.Name = "MyDataGridView";
            this.MyDataGridView.ReadOnly = true;
            this.MyDataGridView.RowHeadersWidth = 5;
            this.MyDataGridView.RowTemplate.Height = 24;
            this.MyDataGridView.Size = new System.Drawing.Size(776, 430);
            this.MyDataGridView.TabIndex = 6;
            // 
            // TransactionTime
            // 
            this.TransactionTime.HeaderText = "Дата транзакции";
            this.TransactionTime.MinimumWidth = 107;
            this.TransactionTime.Name = "TransactionTime";
            this.TransactionTime.ReadOnly = true;
            this.TransactionTime.Width = 107;
            // 
            // Action
            // 
            this.Action.HeaderText = "Действие";
            this.Action.MinimumWidth = 65;
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Width = 65;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "Имя файла";
            this.FileName.MinimumWidth = 120;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 120;
            // 
            // FileSizeBefore
            // 
            this.FileSizeBefore.HeaderText = "Длина";
            this.FileSizeBefore.MinimumWidth = 45;
            this.FileSizeBefore.Name = "FileSizeBefore";
            this.FileSizeBefore.ReadOnly = true;
            this.FileSizeBefore.Width = 45;
            // 
            // FileSizeNew
            // 
            this.FileSizeNew.HeaderText = "Новая длина";
            this.FileSizeNew.MinimumWidth = 45;
            this.FileSizeNew.Name = "FileSizeNew";
            this.FileSizeNew.ReadOnly = true;
            this.FileSizeNew.Width = 45;
            // 
            // FileChanged
            // 
            this.FileChanged.HeaderText = "Дата изменения";
            this.FileChanged.MinimumWidth = 107;
            this.FileChanged.Name = "FileChanged";
            this.FileChanged.ReadOnly = true;
            this.FileChanged.Width = 107;
            // 
            // FileChangedNew
            // 
            this.FileChangedNew.HeaderText = "Новая дата изменения";
            this.FileChangedNew.MinimumWidth = 107;
            this.FileChangedNew.Name = "FileChangedNew";
            this.FileChangedNew.ReadOnly = true;
            this.FileChangedNew.Width = 107;
            // 
            // FileCreated
            // 
            this.FileCreated.HeaderText = "Дата создания";
            this.FileCreated.MinimumWidth = 107;
            this.FileCreated.Name = "FileCreated";
            this.FileCreated.ReadOnly = true;
            this.FileCreated.Width = 107;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FileManager.Properties.Resources.main_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MyDataGridView);
            this.Name = "Form2";
            this.Text = "Poems - FileManager Logs";
            ((System.ComponentModel.ISupportInitialize)(this.MyDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MyDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSizeBefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSizeNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileChanged;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileChangedNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileCreated;
    }
}