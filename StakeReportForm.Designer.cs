
namespace StakeOutReport_WinForms
{
    partial class StakeOutReport //dont need to touch this file really
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StakeOutReport));
            TitleLabel = new Label();
            BrowseDesignDataLabel = new Label();
            label1 = new Label();
            DesignDataFilePathTextBox = new TextBox();
            AsBuiltDataFilePathTextBox = new TextBox();
            BrowseDesignDataDialog = new OpenFileDialog();
            BrowseDesignDataButton = new Button();
            BrowseAsBuiltData = new Button();
            ConfirmChoiceAndReadButton = new Button();
            ReadStatusLabel = new Label();
            DesignDataTable = new DataGridView();
            AsBuiltDataTable = new DataGridView();
            DesignDataPreviewLabel = new Label();
            AsBuiltDataPreviewLabel = new Label();
            CurrentDate = new Label();
            CalculateErrorButton = new Button();
            ErrorPreviewLabel = new Label();
            ErrorPreviewDataTable = new DataGridView();
            PrefixSelector = new ComboBox();
            AsBuiltPrefixLabel = new Label();
            CustomPrefixTextBox = new TextBox();
            PDFCheckBox = new CheckBox();
            ReportOptionsLabel = new Label();
            CSVCheckBox = new CheckBox();
            GenerateReportButton = new Button();
            ProjectNameTextBox = new TextBox();
            ProjectNameLabel = new Label();
            ElementOfWorksTextBox = new TextBox();
            ElementOfWorksLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)DesignDataTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AsBuiltDataTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ErrorPreviewDataTable).BeginInit();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Arial", 15F, FontStyle.Underline, GraphicsUnit.Point, 0);
            TitleLabel.Location = new System.Drawing.Point(12, 9);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(337, 23);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "STAKE OUT REPORT GENERATOR";
            // 
            // BrowseDesignDataLabel
            // 
            BrowseDesignDataLabel.AutoSize = true;
            BrowseDesignDataLabel.Font = new Font("Arial", 10F, FontStyle.Underline, GraphicsUnit.Point, 0);
            BrowseDesignDataLabel.Location = new System.Drawing.Point(12, 57);
            BrowseDesignDataLabel.Name = "BrowseDesignDataLabel";
            BrowseDesignDataLabel.Size = new Size(165, 16);
            BrowseDesignDataLabel.TabIndex = 1;
            BrowseDesignDataLabel.Text = "Browse For Design Data:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(12, 141);
            label1.Name = "label1";
            label1.Size = new Size(168, 16);
            label1.TabIndex = 2;
            label1.Text = "Browse For As-Built Data:";
            // 
            // DesignDataFilePathTextBox
            // 
            DesignDataFilePathTextBox.Location = new System.Drawing.Point(176, 88);
            DesignDataFilePathTextBox.Name = "DesignDataFilePathTextBox";
            DesignDataFilePathTextBox.Size = new Size(489, 23);
            DesignDataFilePathTextBox.TabIndex = 3;
            // 
            // AsBuiltDataFilePathTextBox
            // 
            AsBuiltDataFilePathTextBox.Location = new System.Drawing.Point(176, 176);
            AsBuiltDataFilePathTextBox.Name = "AsBuiltDataFilePathTextBox";
            AsBuiltDataFilePathTextBox.Size = new Size(489, 23);
            AsBuiltDataFilePathTextBox.TabIndex = 4;
            // 
            // BrowseDesignDataDialog
            // 
            BrowseDesignDataDialog.FileName = "openFileDialog1";
            // 
            // BrowseDesignDataButton
            // 
            BrowseDesignDataButton.Location = new System.Drawing.Point(25, 88);
            BrowseDesignDataButton.Name = "BrowseDesignDataButton";
            BrowseDesignDataButton.Size = new Size(127, 23);
            BrowseDesignDataButton.TabIndex = 5;
            BrowseDesignDataButton.Text = "Browse Design Data";
            BrowseDesignDataButton.UseVisualStyleBackColor = true;
            BrowseDesignDataButton.Click += BrowseDesignDataButton_Click;
            // 
            // BrowseAsBuiltData
            // 
            BrowseAsBuiltData.Location = new System.Drawing.Point(25, 176);
            BrowseAsBuiltData.Name = "BrowseAsBuiltData";
            BrowseAsBuiltData.Size = new Size(127, 23);
            BrowseAsBuiltData.TabIndex = 6;
            BrowseAsBuiltData.Text = "Browse As-Built Data";
            BrowseAsBuiltData.UseVisualStyleBackColor = true;
            BrowseAsBuiltData.Click += BrowseAsBuiltData_Click;
            // 
            // ConfirmChoiceAndReadButton
            // 
            ConfirmChoiceAndReadButton.BackColor = Color.White;
            ConfirmChoiceAndReadButton.Location = new System.Drawing.Point(12, 348);
            ConfirmChoiceAndReadButton.Name = "ConfirmChoiceAndReadButton";
            ConfirmChoiceAndReadButton.Size = new Size(174, 35);
            ConfirmChoiceAndReadButton.TabIndex = 7;
            ConfirmChoiceAndReadButton.Text = "Confirm Choice And Read";
            ConfirmChoiceAndReadButton.UseVisualStyleBackColor = false;
            ConfirmChoiceAndReadButton.Click += ConfirmChoiceAndReadButton_Click;
            // 
            // ReadStatusLabel
            // 
            ReadStatusLabel.AutoSize = true;
            ReadStatusLabel.Font = new Font("Segoe UI", 12F);
            ReadStatusLabel.Location = new System.Drawing.Point(21, 407);
            ReadStatusLabel.Name = "ReadStatusLabel";
            ReadStatusLabel.Size = new Size(106, 21);
            ReadStatusLabel.TabIndex = 8;
            ReadStatusLabel.Text = "No Data Read";
            // 
            // DesignDataTable
            // 
            DesignDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DesignDataTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            DesignDataTable.BackgroundColor = Color.White;
            DesignDataTable.BorderStyle = BorderStyle.Fixed3D;
            DesignDataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DesignDataTable.GridColor = Color.Black;
            DesignDataTable.Location = new System.Drawing.Point(831, 88);
            DesignDataTable.Name = "DesignDataTable";
            DesignDataTable.ReadOnly = true;
            DesignDataTable.RowHeadersWidth = 62;
            DesignDataTable.Size = new Size(333, 199);
            DesignDataTable.TabIndex = 9;
            // 
            // AsBuiltDataTable
            // 
            AsBuiltDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AsBuiltDataTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            AsBuiltDataTable.BackgroundColor = Color.White;
            AsBuiltDataTable.BorderStyle = BorderStyle.Fixed3D;
            AsBuiltDataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AsBuiltDataTable.GridColor = Color.Black;
            AsBuiltDataTable.Location = new System.Drawing.Point(1181, 88);
            AsBuiltDataTable.Name = "AsBuiltDataTable";
            AsBuiltDataTable.ReadOnly = true;
            AsBuiltDataTable.RowHeadersWidth = 62;
            AsBuiltDataTable.Size = new Size(333, 199);
            AsBuiltDataTable.TabIndex = 10;
            // 
            // DesignDataPreviewLabel
            // 
            DesignDataPreviewLabel.AutoSize = true;
            DesignDataPreviewLabel.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            DesignDataPreviewLabel.Location = new System.Drawing.Point(831, 70);
            DesignDataPreviewLabel.Name = "DesignDataPreviewLabel";
            DesignDataPreviewLabel.Size = new Size(114, 15);
            DesignDataPreviewLabel.TabIndex = 11;
            DesignDataPreviewLabel.Text = "Design Data Preview";
            DesignDataPreviewLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // AsBuiltDataPreviewLabel
            // 
            AsBuiltDataPreviewLabel.AutoSize = true;
            AsBuiltDataPreviewLabel.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            AsBuiltDataPreviewLabel.Location = new System.Drawing.Point(1181, 70);
            AsBuiltDataPreviewLabel.Name = "AsBuiltDataPreviewLabel";
            AsBuiltDataPreviewLabel.Size = new Size(120, 15);
            AsBuiltDataPreviewLabel.TabIndex = 12;
            AsBuiltDataPreviewLabel.Text = "As-Built Data Preview";
            AsBuiltDataPreviewLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // CurrentDate
            // 
            CurrentDate.AutoSize = true;
            CurrentDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            CurrentDate.Location = new System.Drawing.Point(1448, 12);
            CurrentDate.Name = "CurrentDate";
            CurrentDate.Size = new Size(125, 20);
            CurrentDate.TabIndex = 13;
            CurrentDate.Text = "DatePlaceHolder";
            CurrentDate.TextAlign = ContentAlignment.TopCenter;
            // 
            // CalculateErrorButton
            // 
            CalculateErrorButton.BackColor = Color.White;
            CalculateErrorButton.Location = new System.Drawing.Point(825, 305);
            CalculateErrorButton.Name = "CalculateErrorButton";
            CalculateErrorButton.Size = new Size(174, 35);
            CalculateErrorButton.TabIndex = 14;
            CalculateErrorButton.Text = "Calculate Error";
            CalculateErrorButton.UseVisualStyleBackColor = false;
            CalculateErrorButton.Visible = false;
            CalculateErrorButton.Click += CalculateErrorButton_Click;
            // 
            // ErrorPreviewLabel
            // 
            ErrorPreviewLabel.AutoSize = true;
            ErrorPreviewLabel.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            ErrorPreviewLabel.Location = new System.Drawing.Point(831, 368);
            ErrorPreviewLabel.Name = "ErrorPreviewLabel";
            ErrorPreviewLabel.Size = new Size(76, 15);
            ErrorPreviewLabel.TabIndex = 16;
            ErrorPreviewLabel.Text = "Error Preview";
            ErrorPreviewLabel.TextAlign = ContentAlignment.TopCenter;
            ErrorPreviewLabel.Visible = false;
            // 
            // ErrorPreviewDataTable
            // 
            ErrorPreviewDataTable.AllowUserToOrderColumns = true;
            ErrorPreviewDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ErrorPreviewDataTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ErrorPreviewDataTable.BackgroundColor = Color.White;
            ErrorPreviewDataTable.BorderStyle = BorderStyle.Fixed3D;
            ErrorPreviewDataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ErrorPreviewDataTable.GridColor = Color.Black;
            ErrorPreviewDataTable.Location = new System.Drawing.Point(831, 396);
            ErrorPreviewDataTable.Name = "ErrorPreviewDataTable";
            ErrorPreviewDataTable.ReadOnly = true;
            ErrorPreviewDataTable.RowHeadersWidth = 62;
            ErrorPreviewDataTable.Size = new Size(333, 276);
            ErrorPreviewDataTable.TabIndex = 15;
            ErrorPreviewDataTable.Visible = false;
            // 
            // PrefixSelector
            // 
            PrefixSelector.FormattingEnabled = true;
            PrefixSelector.Location = new System.Drawing.Point(228, 231);
            PrefixSelector.Name = "PrefixSelector";
            PrefixSelector.Size = new Size(85, 23);
            PrefixSelector.TabIndex = 17;
            PrefixSelector.SelectedIndexChanged += PrefixSelector_SelectedIndexChanged;
            // 
            // AsBuiltPrefixLabel
            // 
            AsBuiltPrefixLabel.AutoSize = true;
            AsBuiltPrefixLabel.Font = new Font("Arial", 10F, FontStyle.Underline, GraphicsUnit.Point, 0);
            AsBuiltPrefixLabel.Location = new System.Drawing.Point(2, 233);
            AsBuiltPrefixLabel.Name = "AsBuiltPrefixLabel";
            AsBuiltPrefixLabel.Size = new Size(201, 16);
            AsBuiltPrefixLabel.TabIndex = 18;
            AsBuiltPrefixLabel.Text = "Define The As-Built Data Prefix";
            // 
            // CustomPrefixTextBox
            // 
            CustomPrefixTextBox.Location = new System.Drawing.Point(12, 281);
            CustomPrefixTextBox.MaxLength = 10;
            CustomPrefixTextBox.Name = "CustomPrefixTextBox";
            CustomPrefixTextBox.PlaceholderText = "Custom";
            CustomPrefixTextBox.Size = new Size(301, 23);
            CustomPrefixTextBox.TabIndex = 19;
            CustomPrefixTextBox.Visible = false;
            CustomPrefixTextBox.TextChanged += CustomPrefixTextBox_TextChanged;
            // 
            // PDFCheckBox
            // 
            PDFCheckBox.AutoSize = true;
            PDFCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            PDFCheckBox.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PDFCheckBox.Location = new System.Drawing.Point(21, 506);
            PDFCheckBox.Name = "PDFCheckBox";
            PDFCheckBox.Size = new Size(48, 20);
            PDFCheckBox.TabIndex = 20;
            PDFCheckBox.Text = "PDF";
            PDFCheckBox.UseVisualStyleBackColor = true;
            PDFCheckBox.Visible = false;
            // 
            // ReportOptionsLabel
            // 
            ReportOptionsLabel.AutoSize = true;
            ReportOptionsLabel.Font = new Font("Arial", 10F, FontStyle.Underline, GraphicsUnit.Point, 0);
            ReportOptionsLabel.Location = new System.Drawing.Point(12, 471);
            ReportOptionsLabel.Name = "ReportOptionsLabel";
            ReportOptionsLabel.Size = new Size(122, 16);
            ReportOptionsLabel.TabIndex = 21;
            ReportOptionsLabel.Text = "Generate Report?";
            ReportOptionsLabel.Visible = false;
            // 
            // CSVCheckBox
            // 
            CSVCheckBox.AutoSize = true;
            CSVCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            CSVCheckBox.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CSVCheckBox.Location = new System.Drawing.Point(21, 548);
            CSVCheckBox.Name = "CSVCheckBox";
            CSVCheckBox.Size = new Size(48, 20);
            CSVCheckBox.TabIndex = 22;
            CSVCheckBox.Text = "CSV";
            CSVCheckBox.UseVisualStyleBackColor = true;
            CSVCheckBox.Visible = false;
            // 
            // GenerateReportButton
            // 
            GenerateReportButton.BackColor = Color.White;
            GenerateReportButton.Location = new System.Drawing.Point(6, 724);
            GenerateReportButton.Name = "GenerateReportButton";
            GenerateReportButton.Size = new Size(174, 35);
            GenerateReportButton.TabIndex = 23;
            GenerateReportButton.Text = "Generate Selected Reports";
            GenerateReportButton.UseVisualStyleBackColor = false;
            GenerateReportButton.Visible = false;
            GenerateReportButton.Click += GenerateReportButton_Click;
            // 
            // ProjectNameTextBox
            // 
            ProjectNameTextBox.Location = new System.Drawing.Point(12, 616);
            ProjectNameTextBox.MaxLength = 30;
            ProjectNameTextBox.Name = "ProjectNameTextBox";
            ProjectNameTextBox.PlaceholderText = "Project Title";
            ProjectNameTextBox.Size = new Size(489, 23);
            ProjectNameTextBox.TabIndex = 25;
            ProjectNameTextBox.Visible = false;
            ProjectNameTextBox.TextChanged += ProjectNameTextBox_TextChanged;
            // 
            // ProjectNameLabel
            // 
            ProjectNameLabel.AutoSize = true;
            ProjectNameLabel.Font = new Font("Arial", 10F, FontStyle.Underline, GraphicsUnit.Point, 0);
            ProjectNameLabel.Location = new System.Drawing.Point(12, 586);
            ProjectNameLabel.Name = "ProjectNameLabel";
            ProjectNameLabel.Size = new Size(91, 16);
            ProjectNameLabel.TabIndex = 24;
            ProjectNameLabel.Text = "Project Name";
            ProjectNameLabel.Visible = false;
            // 
            // ElementOfWorksTextBox
            // 
            ElementOfWorksTextBox.Location = new System.Drawing.Point(12, 686);
            ElementOfWorksTextBox.MaxLength = 100;
            ElementOfWorksTextBox.Name = "ElementOfWorksTextBox";
            ElementOfWorksTextBox.PlaceholderText = "Works Set Out";
            ElementOfWorksTextBox.Size = new Size(489, 23);
            ElementOfWorksTextBox.TabIndex = 27;
            ElementOfWorksTextBox.Visible = false;
            ElementOfWorksTextBox.TextChanged += ElementOfWorksTextBox_TextChanged;
            // 
            // ElementOfWorksLabel
            // 
            ElementOfWorksLabel.AutoSize = true;
            ElementOfWorksLabel.Font = new Font("Arial", 10F, FontStyle.Underline, GraphicsUnit.Point, 0);
            ElementOfWorksLabel.Location = new System.Drawing.Point(12, 656);
            ElementOfWorksLabel.Name = "ElementOfWorksLabel";
            ElementOfWorksLabel.Size = new Size(121, 16);
            ElementOfWorksLabel.TabIndex = 26;
            ElementOfWorksLabel.Text = "Element Of Works";
            ElementOfWorksLabel.Visible = false;
            // 
            // StakeOutReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(1572, 761);
            Controls.Add(ElementOfWorksTextBox);
            Controls.Add(ElementOfWorksLabel);
            Controls.Add(ProjectNameTextBox);
            Controls.Add(ProjectNameLabel);
            Controls.Add(GenerateReportButton);
            Controls.Add(CSVCheckBox);
            Controls.Add(ReportOptionsLabel);
            Controls.Add(PDFCheckBox);
            Controls.Add(CustomPrefixTextBox);
            Controls.Add(AsBuiltPrefixLabel);
            Controls.Add(PrefixSelector);
            Controls.Add(ErrorPreviewLabel);
            Controls.Add(ErrorPreviewDataTable);
            Controls.Add(CalculateErrorButton);
            Controls.Add(CurrentDate);
            Controls.Add(AsBuiltDataPreviewLabel);
            Controls.Add(DesignDataPreviewLabel);
            Controls.Add(AsBuiltDataTable);
            Controls.Add(DesignDataTable);
            Controls.Add(ReadStatusLabel);
            Controls.Add(ConfirmChoiceAndReadButton);
            Controls.Add(BrowseAsBuiltData);
            Controls.Add(BrowseDesignDataButton);
            Controls.Add(AsBuiltDataFilePathTextBox);
            Controls.Add(DesignDataFilePathTextBox);
            Controls.Add(label1);
            Controls.Add(BrowseDesignDataLabel);
            Controls.Add(TitleLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StakeOutReport";
            Text = "Stake Out Report Generator";
            ((System.ComponentModel.ISupportInitialize)DesignDataTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)AsBuiltDataTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)ErrorPreviewDataTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private Label BrowseDesignDataLabel;
        private Label label1;
        private TextBox DesignDataFilePathTextBox;
        private TextBox AsBuiltDataFilePathTextBox;
        private OpenFileDialog BrowseDesignDataDialog;
        private Button BrowseDesignDataButton;
        private Button BrowseAsBuiltData;
        private Button ConfirmChoiceAndReadButton;
        private Label ReadStatusLabel;
        private DataGridView DesignDataTable;
        private DataGridView AsBuiltDataTable;
        private Label DesignDataPreviewLabel;
        private Label AsBuiltDataPreviewLabel;
        private Label CurrentDate;
        private Button CalculateErrorButton;
        private Label ErrorPreviewLabel;
        private DataGridView ErrorPreviewDataTable;
        private ComboBox PrefixSelector;
        private Label AsBuiltPrefixLabel;
        private TextBox CustomPrefixTextBox;
        private CheckBox PDFCheckBox;
        private Label ReportOptionsLabel;
        private CheckBox CSVCheckBox;
        private Button GenerateReportButton;
        private TextBox ProjectNameTextBox;
        private Label ProjectNameLabel;
        private TextBox ElementOfWorksTextBox;
        private Label ElementOfWorksLabel;
    }
}
