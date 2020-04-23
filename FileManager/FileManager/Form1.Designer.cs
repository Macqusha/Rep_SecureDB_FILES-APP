namespace FileManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.but_Load_from_DB = new System.Windows.Forms.Button();
            this.but_Load_from_Catalog = new System.Windows.Forms.Button();
            this.but_Synchronize = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // but_Load_from_DB
            // 
            this.but_Load_from_DB.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.but_Load_from_DB, "but_Load_from_DB");
            this.but_Load_from_DB.Name = "but_Load_from_DB";
            this.but_Load_from_DB.UseVisualStyleBackColor = true;
            this.but_Load_from_DB.Click += new System.EventHandler(this.but_Load_from_DB_Click);
            // 
            // but_Load_from_Catalog
            // 
            resources.ApplyResources(this.but_Load_from_Catalog, "but_Load_from_Catalog");
            this.but_Load_from_Catalog.Name = "but_Load_from_Catalog";
            this.but_Load_from_Catalog.UseVisualStyleBackColor = true;
            this.but_Load_from_Catalog.Click += new System.EventHandler(this.but_Load_from_Catalog_Click);
            // 
            // but_Synchronize
            // 
            resources.ApplyResources(this.but_Synchronize, "but_Synchronize");
            this.but_Synchronize.Name = "but_Synchronize";
            this.but_Synchronize.UseVisualStyleBackColor = true;
            this.but_Synchronize.Click += new System.EventHandler(this.but_Synchronize_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.MintCream;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.FileSize,
            this.FileChanged,
            this.FileCreated});
            resources.ApplyResources(this.dataGridView, "dataGridView");
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            // 
            // FileName
            // 
            resources.ApplyResources(this.FileName, "FileName");
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // FileSize
            // 
            resources.ApplyResources(this.FileSize, "FileSize");
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            // 
            // FileChanged
            // 
            resources.ApplyResources(this.FileChanged, "FileChanged");
            this.FileChanged.Name = "FileChanged";
            this.FileChanged.ReadOnly = true;
            // 
            // FileCreated
            // 
            resources.ApplyResources(this.FileCreated, "FileCreated");
            this.FileCreated.Name = "FileCreated";
            this.FileCreated.ReadOnly = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FileManager.Properties.Resources.main_background;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.but_Synchronize);
            this.Controls.Add(this.but_Load_from_Catalog);
            this.Controls.Add(this.but_Load_from_DB);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button but_Load_from_DB;
        private System.Windows.Forms.Button but_Load_from_Catalog;
        private System.Windows.Forms.Button but_Synchronize;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileChanged;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileCreated;
    }
}

