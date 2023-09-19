namespace DLX_homework_winforms
{
    partial class Form1
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
            txtResultsDisplay = new RichTextBox();
            grpQueryExecution = new GroupBox();
            txtQueryInput = new TextBox();
            btnExecuteQuery = new Button();
            grpSettings = new GroupBox();
            chkAllowDuplicates = new CheckBox();
            chkPrintOnScreen = new CheckBox();
            chkSaveToDb = new CheckBox();
            grpFileSelection = new GroupBox();
            btnAddFile = new Button();
            lstSelectedFiles = new ListBox();
            btnClearOutput = new Button();
            grpQueryExecution.SuspendLayout();
            grpSettings.SuspendLayout();
            grpFileSelection.SuspendLayout();
            SuspendLayout();
            // 
            // txtResultsDisplay
            // 
            txtResultsDisplay.Location = new Point(12, 12);
            txtResultsDisplay.Name = "txtResultsDisplay";
            txtResultsDisplay.ReadOnly = true;
            txtResultsDisplay.Size = new Size(1007, 799);
            txtResultsDisplay.TabIndex = 0;
            txtResultsDisplay.Text = "";
            // 
            // grpQueryExecution
            // 
            grpQueryExecution.Controls.Add(txtQueryInput);
            grpQueryExecution.Location = new Point(1025, 12);
            grpQueryExecution.Name = "grpQueryExecution";
            grpQueryExecution.Size = new Size(473, 69);
            grpQueryExecution.TabIndex = 1;
            grpQueryExecution.TabStop = false;
            grpQueryExecution.Text = "Enter search query";
            // 
            // txtQueryInput
            // 
            txtQueryInput.Location = new Point(6, 22);
            txtQueryInput.Name = "txtQueryInput";
            txtQueryInput.Size = new Size(461, 23);
            txtQueryInput.TabIndex = 0;
            // 
            // btnExecuteQuery
            // 
            btnExecuteQuery.Location = new Point(1031, 334);
            btnExecuteQuery.Name = "btnExecuteQuery";
            btnExecuteQuery.Size = new Size(75, 40);
            btnExecuteQuery.TabIndex = 1;
            btnExecuteQuery.Text = "Run";
            btnExecuteQuery.UseVisualStyleBackColor = true;
            btnExecuteQuery.Click += btnExecuteQuery_Click;
            // 
            // grpSettings
            // 
            grpSettings.Controls.Add(chkAllowDuplicates);
            grpSettings.Controls.Add(chkPrintOnScreen);
            grpSettings.Controls.Add(chkSaveToDb);
            grpSettings.Location = new Point(1031, 219);
            grpSettings.Name = "grpSettings";
            grpSettings.Size = new Size(467, 109);
            grpSettings.TabIndex = 2;
            grpSettings.TabStop = false;
            grpSettings.Text = "Settings";
            // 
            // chkAllowDuplicates
            // 
            chkAllowDuplicates.AutoSize = true;
            chkAllowDuplicates.Location = new Point(6, 72);
            chkAllowDuplicates.Name = "chkAllowDuplicates";
            chkAllowDuplicates.Size = new Size(113, 19);
            chkAllowDuplicates.TabIndex = 2;
            chkAllowDuplicates.Text = "Allow duplicates";
            chkAllowDuplicates.UseVisualStyleBackColor = true;
            // 
            // chkPrintOnScreen
            // 
            chkPrintOnScreen.AutoSize = true;
            chkPrintOnScreen.Checked = true;
            chkPrintOnScreen.CheckState = CheckState.Checked;
            chkPrintOnScreen.Location = new Point(6, 47);
            chkPrintOnScreen.Name = "chkPrintOnScreen";
            chkPrintOnScreen.Size = new Size(105, 19);
            chkPrintOnScreen.TabIndex = 1;
            chkPrintOnScreen.Text = "Print on screen";
            chkPrintOnScreen.UseVisualStyleBackColor = true;
            // 
            // chkSaveToDb
            // 
            chkSaveToDb.AutoSize = true;
            chkSaveToDb.Location = new Point(6, 22);
            chkSaveToDb.Name = "chkSaveToDb";
            chkSaveToDb.Size = new Size(114, 19);
            chkSaveToDb.TabIndex = 0;
            chkSaveToDb.Text = "Save to database";
            chkSaveToDb.UseVisualStyleBackColor = true;
            // 
            // grpFileSelection
            // 
            grpFileSelection.Controls.Add(btnAddFile);
            grpFileSelection.Controls.Add(lstSelectedFiles);
            grpFileSelection.Location = new Point(1025, 87);
            grpFileSelection.Name = "grpFileSelection";
            grpFileSelection.Size = new Size(473, 113);
            grpFileSelection.TabIndex = 3;
            grpFileSelection.TabStop = false;
            grpFileSelection.Text = "Select files";
            // 
            // btnAddFile
            // 
            btnAddFile.Location = new Point(379, 22);
            btnAddFile.Name = "btnAddFile";
            btnAddFile.Size = new Size(75, 23);
            btnAddFile.TabIndex = 1;
            btnAddFile.Text = "Add file";
            btnAddFile.UseVisualStyleBackColor = true;
            btnAddFile.Click += btnAddFile_Click;
            // 
            // lstSelectedFiles
            // 
            lstSelectedFiles.FormattingEnabled = true;
            lstSelectedFiles.ItemHeight = 15;
            lstSelectedFiles.Location = new Point(6, 22);
            lstSelectedFiles.Name = "lstSelectedFiles";
            lstSelectedFiles.Size = new Size(367, 79);
            lstSelectedFiles.TabIndex = 0;
            // 
            // btnClearOutput
            // 
            btnClearOutput.Location = new Point(1112, 334);
            btnClearOutput.Name = "btnClearOutput";
            btnClearOutput.Size = new Size(75, 40);
            btnClearOutput.TabIndex = 4;
            btnClearOutput.Text = "Clear output";
            btnClearOutput.UseVisualStyleBackColor = true;
            btnClearOutput.Click += btnClearOutput_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1510, 823);
            Controls.Add(btnExecuteQuery);
            Controls.Add(btnClearOutput);
            Controls.Add(grpFileSelection);
            Controls.Add(grpSettings);
            Controls.Add(grpQueryExecution);
            Controls.Add(txtResultsDisplay);
            Name = "Form1";
            Text = "Query handler";
            grpQueryExecution.ResumeLayout(false);
            grpQueryExecution.PerformLayout();
            grpSettings.ResumeLayout(false);
            grpSettings.PerformLayout();
            grpFileSelection.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox txtResultsDisplay;
        private GroupBox grpQueryExecution;
        private Button btnExecuteQuery;
        private TextBox txtQueryInput;
        private GroupBox grpSettings;
        private GroupBox grpFileSelection;
        private ListBox lstSelectedFiles;
        private CheckBox chkAllowDuplicates;
        private CheckBox chkPrintOnScreen;
        private CheckBox chkSaveToDb;
        private Button btnAddFile;
        private Button btnClearOutput;
    }
}