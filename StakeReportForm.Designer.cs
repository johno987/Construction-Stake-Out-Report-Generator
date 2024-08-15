
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
            TitleLabel = new Label();
            BrowseDesignDataLabel = new Label();
            label1 = new Label();
            DesignDataFilePath = new TextBox();
            AsBuiltDataFilePath = new TextBox();
            BrowseDesignDataDialog = new OpenFileDialog();
            BrowseDesignDataButton = new Button();
            BrowseAsBuiltData = new Button();
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
            // DesignDataFilePath
            // 
            DesignDataFilePath.Location = new System.Drawing.Point(176, 88);
            DesignDataFilePath.Name = "DesignDataFilePath";
            DesignDataFilePath.Size = new Size(548, 23);
            DesignDataFilePath.TabIndex = 3;
            // 
            // AsBuiltDataFilePath
            // 
            AsBuiltDataFilePath.Location = new System.Drawing.Point(176, 176);
            AsBuiltDataFilePath.Name = "AsBuiltDataFilePath";
            AsBuiltDataFilePath.Size = new Size(548, 23);
            AsBuiltDataFilePath.TabIndex = 4;
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
            BrowseAsBuiltData.Click += this.BrowseAsBuiltData_Click;
            // 
            // StakeOutReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(825, 458);
            Controls.Add(BrowseAsBuiltData);
            Controls.Add(BrowseDesignDataButton);
            Controls.Add(AsBuiltDataFilePath);
            Controls.Add(DesignDataFilePath);
            Controls.Add(label1);
            Controls.Add(BrowseDesignDataLabel);
            Controls.Add(TitleLabel);
            Name = "StakeOutReport";
            Text = "Stake Out Report";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private Label BrowseDesignDataLabel;
        private Label label1;
        private TextBox DesignDataFilePath;
        private TextBox AsBuiltDataFilePath;
        private OpenFileDialog BrowseDesignDataDialog;
        private Button BrowseDesignDataButton;
        private Button BrowseAsBuiltData;
    }
}
