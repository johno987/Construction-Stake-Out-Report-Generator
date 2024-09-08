
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
            Error2DCheckBox = new CheckBox();
            WaterMarkLabel = new Label();
            DefineErrorCheckBox = new CheckBox();
            ToleranceTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DesignDataTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AsBuiltDataTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ErrorPreviewDataTable).BeginInit();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            resources.ApplyResources(TitleLabel, "TitleLabel");
            TitleLabel.Name = "TitleLabel";
            // 
            // BrowseDesignDataLabel
            // 
            resources.ApplyResources(BrowseDesignDataLabel, "BrowseDesignDataLabel");
            BrowseDesignDataLabel.Name = "BrowseDesignDataLabel";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // DesignDataFilePathTextBox
            // 
            resources.ApplyResources(DesignDataFilePathTextBox, "DesignDataFilePathTextBox");
            DesignDataFilePathTextBox.Name = "DesignDataFilePathTextBox";
            DesignDataFilePathTextBox.ReadOnly = true;
            // 
            // AsBuiltDataFilePathTextBox
            // 
            resources.ApplyResources(AsBuiltDataFilePathTextBox, "AsBuiltDataFilePathTextBox");
            AsBuiltDataFilePathTextBox.Name = "AsBuiltDataFilePathTextBox";
            AsBuiltDataFilePathTextBox.ReadOnly = true;
            // 
            // BrowseDesignDataDialog
            // 
            BrowseDesignDataDialog.FileName = "openFileDialog1";
            // 
            // BrowseDesignDataButton
            // 
            resources.ApplyResources(BrowseDesignDataButton, "BrowseDesignDataButton");
            BrowseDesignDataButton.Name = "BrowseDesignDataButton";
            BrowseDesignDataButton.UseVisualStyleBackColor = true;
            BrowseDesignDataButton.Click += BrowseDesignDataButton_Click;
            // 
            // BrowseAsBuiltData
            // 
            resources.ApplyResources(BrowseAsBuiltData, "BrowseAsBuiltData");
            BrowseAsBuiltData.Name = "BrowseAsBuiltData";
            BrowseAsBuiltData.UseVisualStyleBackColor = true;
            BrowseAsBuiltData.Click += BrowseAsBuiltData_Click;
            // 
            // ConfirmChoiceAndReadButton
            // 
            ConfirmChoiceAndReadButton.BackColor = Color.White;
            resources.ApplyResources(ConfirmChoiceAndReadButton, "ConfirmChoiceAndReadButton");
            ConfirmChoiceAndReadButton.Name = "ConfirmChoiceAndReadButton";
            ConfirmChoiceAndReadButton.UseVisualStyleBackColor = false;
            ConfirmChoiceAndReadButton.Click += ConfirmChoiceAndReadButton_Click;
            // 
            // ReadStatusLabel
            // 
            resources.ApplyResources(ReadStatusLabel, "ReadStatusLabel");
            ReadStatusLabel.Name = "ReadStatusLabel";
            // 
            // DesignDataTable
            // 
            DesignDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DesignDataTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            DesignDataTable.BackgroundColor = Color.White;
            DesignDataTable.BorderStyle = BorderStyle.Fixed3D;
            DesignDataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DesignDataTable.GridColor = Color.Black;
            resources.ApplyResources(DesignDataTable, "DesignDataTable");
            DesignDataTable.Name = "DesignDataTable";
            DesignDataTable.ReadOnly = true;
            // 
            // AsBuiltDataTable
            // 
            AsBuiltDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AsBuiltDataTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            AsBuiltDataTable.BackgroundColor = Color.White;
            AsBuiltDataTable.BorderStyle = BorderStyle.Fixed3D;
            AsBuiltDataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AsBuiltDataTable.GridColor = Color.Black;
            resources.ApplyResources(AsBuiltDataTable, "AsBuiltDataTable");
            AsBuiltDataTable.Name = "AsBuiltDataTable";
            AsBuiltDataTable.ReadOnly = true;
            // 
            // DesignDataPreviewLabel
            // 
            resources.ApplyResources(DesignDataPreviewLabel, "DesignDataPreviewLabel");
            DesignDataPreviewLabel.Name = "DesignDataPreviewLabel";
            // 
            // AsBuiltDataPreviewLabel
            // 
            resources.ApplyResources(AsBuiltDataPreviewLabel, "AsBuiltDataPreviewLabel");
            AsBuiltDataPreviewLabel.Name = "AsBuiltDataPreviewLabel";
            // 
            // CurrentDate
            // 
            resources.ApplyResources(CurrentDate, "CurrentDate");
            CurrentDate.Name = "CurrentDate";
            // 
            // CalculateErrorButton
            // 
            CalculateErrorButton.BackColor = Color.White;
            resources.ApplyResources(CalculateErrorButton, "CalculateErrorButton");
            CalculateErrorButton.Name = "CalculateErrorButton";
            CalculateErrorButton.UseVisualStyleBackColor = false;
            CalculateErrorButton.Click += CalculateErrorButton_Click;
            // 
            // ErrorPreviewLabel
            // 
            resources.ApplyResources(ErrorPreviewLabel, "ErrorPreviewLabel");
            ErrorPreviewLabel.Name = "ErrorPreviewLabel";
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
            resources.ApplyResources(ErrorPreviewDataTable, "ErrorPreviewDataTable");
            ErrorPreviewDataTable.Name = "ErrorPreviewDataTable";
            ErrorPreviewDataTable.ReadOnly = true;
            // 
            // PrefixSelector
            // 
            PrefixSelector.FormattingEnabled = true;
            resources.ApplyResources(PrefixSelector, "PrefixSelector");
            PrefixSelector.Name = "PrefixSelector";
            PrefixSelector.SelectedIndexChanged += PrefixSelector_SelectedIndexChanged;
            // 
            // AsBuiltPrefixLabel
            // 
            resources.ApplyResources(AsBuiltPrefixLabel, "AsBuiltPrefixLabel");
            AsBuiltPrefixLabel.Name = "AsBuiltPrefixLabel";
            // 
            // CustomPrefixTextBox
            // 
            resources.ApplyResources(CustomPrefixTextBox, "CustomPrefixTextBox");
            CustomPrefixTextBox.Name = "CustomPrefixTextBox";
            CustomPrefixTextBox.TextChanged += CustomPrefixTextBox_TextChanged;
            // 
            // PDFCheckBox
            // 
            resources.ApplyResources(PDFCheckBox, "PDFCheckBox");
            PDFCheckBox.Name = "PDFCheckBox";
            PDFCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReportOptionsLabel
            // 
            resources.ApplyResources(ReportOptionsLabel, "ReportOptionsLabel");
            ReportOptionsLabel.Name = "ReportOptionsLabel";
            // 
            // CSVCheckBox
            // 
            resources.ApplyResources(CSVCheckBox, "CSVCheckBox");
            CSVCheckBox.Name = "CSVCheckBox";
            CSVCheckBox.UseVisualStyleBackColor = true;
            // 
            // GenerateReportButton
            // 
            GenerateReportButton.BackColor = Color.White;
            resources.ApplyResources(GenerateReportButton, "GenerateReportButton");
            GenerateReportButton.Name = "GenerateReportButton";
            GenerateReportButton.UseVisualStyleBackColor = false;
            GenerateReportButton.Click += GenerateReportButton_Click;
            // 
            // ProjectNameTextBox
            // 
            resources.ApplyResources(ProjectNameTextBox, "ProjectNameTextBox");
            ProjectNameTextBox.Name = "ProjectNameTextBox";
            ProjectNameTextBox.TextChanged += ProjectNameTextBox_TextChanged;
            // 
            // ProjectNameLabel
            // 
            resources.ApplyResources(ProjectNameLabel, "ProjectNameLabel");
            ProjectNameLabel.Name = "ProjectNameLabel";
            // 
            // ElementOfWorksTextBox
            // 
            resources.ApplyResources(ElementOfWorksTextBox, "ElementOfWorksTextBox");
            ElementOfWorksTextBox.Name = "ElementOfWorksTextBox";
            ElementOfWorksTextBox.TextChanged += ElementOfWorksTextBox_TextChanged;
            // 
            // ElementOfWorksLabel
            // 
            resources.ApplyResources(ElementOfWorksLabel, "ElementOfWorksLabel");
            ElementOfWorksLabel.Name = "ElementOfWorksLabel";
            // 
            // Error2DCheckBox
            // 
            resources.ApplyResources(Error2DCheckBox, "Error2DCheckBox");
            Error2DCheckBox.Name = "Error2DCheckBox";
            Error2DCheckBox.UseVisualStyleBackColor = true;
            // 
            // WaterMarkLabel
            // 
            resources.ApplyResources(WaterMarkLabel, "WaterMarkLabel");
            WaterMarkLabel.ForeColor = SystemColors.ControlDarkDark;
            WaterMarkLabel.Name = "WaterMarkLabel";
            // 
            // DefineErrorCheckBox
            // 
            resources.ApplyResources(DefineErrorCheckBox, "DefineErrorCheckBox");
            DefineErrorCheckBox.Name = "DefineErrorCheckBox";
            DefineErrorCheckBox.UseVisualStyleBackColor = true;
            DefineErrorCheckBox.CheckedChanged += DefineErrorCheckBox_CheckedChanged;
            // 
            // ToleranceTextBox
            // 
            resources.ApplyResources(ToleranceTextBox, "ToleranceTextBox");
            ToleranceTextBox.Name = "ToleranceTextBox";
            ToleranceTextBox.TextChanged += ToleranceTextBox_TextChanged;
            ToleranceTextBox.KeyPress += ToleranceTextBox_KeyPress;
            // 
            // StakeOutReport
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(ToleranceTextBox);
            Controls.Add(DefineErrorCheckBox);
            Controls.Add(WaterMarkLabel);
            Controls.Add(Error2DCheckBox);
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
            Name = "StakeOutReport";
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
        private CheckBox Error2DCheckBox;
        private Label WaterMarkLabel;
        private CheckBox DefineErrorCheckBox;
        private TextBox ToleranceTextBox;
    }
}
