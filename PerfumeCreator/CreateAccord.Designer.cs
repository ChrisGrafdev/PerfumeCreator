namespace PerfumeCreator
{
    partial class FormCreateAccord
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
            tableLayoutAccCreate = new TableLayoutPanel();
            textBoxAccCreateComment = new TextBox();
            labelAccCreateComment = new Label();
            comboBoxAccCreateNoteLevel = new ComboBox();
            labelAccCreateNoteLevel = new Label();
            labelAccCreateCategory = new Label();
            labelAccCreateName = new Label();
            textBoxAccCreateName = new TextBox();
            comboBoxAccCreateCategory = new ComboBox();
            tableLayoutPanelAccCreateSaveCancel = new TableLayoutPanel();
            buttonAccCreateSave = new Button();
            buttonAccCreateCancel = new Button();
            tableLayoutAccCreate.SuspendLayout();
            tableLayoutPanelAccCreateSaveCancel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutAccCreate
            // 
            tableLayoutAccCreate.ColumnCount = 2;
            tableLayoutAccCreate.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutAccCreate.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutAccCreate.Controls.Add(textBoxAccCreateComment, 1, 3);
            tableLayoutAccCreate.Controls.Add(labelAccCreateComment, 0, 3);
            tableLayoutAccCreate.Controls.Add(comboBoxAccCreateNoteLevel, 1, 2);
            tableLayoutAccCreate.Controls.Add(labelAccCreateNoteLevel, 0, 2);
            tableLayoutAccCreate.Controls.Add(labelAccCreateCategory, 0, 1);
            tableLayoutAccCreate.Controls.Add(labelAccCreateName, 0, 0);
            tableLayoutAccCreate.Controls.Add(textBoxAccCreateName, 1, 0);
            tableLayoutAccCreate.Controls.Add(comboBoxAccCreateCategory, 1, 1);
            tableLayoutAccCreate.Controls.Add(tableLayoutPanelAccCreateSaveCancel, 1, 4);
            tableLayoutAccCreate.Dock = DockStyle.Fill;
            tableLayoutAccCreate.Location = new Point(0, 0);
            tableLayoutAccCreate.Name = "tableLayoutAccCreate";
            tableLayoutAccCreate.RowCount = 5;
            tableLayoutAccCreate.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutAccCreate.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutAccCreate.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutAccCreate.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutAccCreate.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutAccCreate.Size = new Size(397, 209);
            tableLayoutAccCreate.TabIndex = 0;
            // 
            // textBoxAccCreateComment
            // 
            textBoxAccCreateComment.Dock = DockStyle.Fill;
            textBoxAccCreateComment.Location = new Point(161, 93);
            textBoxAccCreateComment.Multiline = true;
            textBoxAccCreateComment.Name = "textBoxAccCreateComment";
            textBoxAccCreateComment.Size = new Size(233, 78);
            textBoxAccCreateComment.TabIndex = 4;
            // 
            // labelAccCreateComment
            // 
            labelAccCreateComment.AutoSize = true;
            labelAccCreateComment.Dock = DockStyle.Fill;
            labelAccCreateComment.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAccCreateComment.Location = new Point(3, 90);
            labelAccCreateComment.Name = "labelAccCreateComment";
            labelAccCreateComment.Size = new Size(152, 84);
            labelAccCreateComment.TabIndex = 0;
            labelAccCreateComment.Text = "Comment";
            labelAccCreateComment.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxAccCreateNoteLevel
            // 
            comboBoxAccCreateNoteLevel.Dock = DockStyle.Fill;
            comboBoxAccCreateNoteLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAccCreateNoteLevel.FormattingEnabled = true;
            comboBoxAccCreateNoteLevel.Location = new Point(161, 63);
            comboBoxAccCreateNoteLevel.Name = "comboBoxAccCreateNoteLevel";
            comboBoxAccCreateNoteLevel.Size = new Size(233, 23);
            comboBoxAccCreateNoteLevel.TabIndex = 3;
            // 
            // labelAccCreateNoteLevel
            // 
            labelAccCreateNoteLevel.AutoSize = true;
            labelAccCreateNoteLevel.Dock = DockStyle.Fill;
            labelAccCreateNoteLevel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccCreateNoteLevel.Location = new Point(3, 60);
            labelAccCreateNoteLevel.Name = "labelAccCreateNoteLevel";
            labelAccCreateNoteLevel.Size = new Size(152, 30);
            labelAccCreateNoteLevel.TabIndex = 0;
            labelAccCreateNoteLevel.Text = "Note Level";
            labelAccCreateNoteLevel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelAccCreateCategory
            // 
            labelAccCreateCategory.AutoSize = true;
            labelAccCreateCategory.Dock = DockStyle.Fill;
            labelAccCreateCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccCreateCategory.Location = new Point(3, 30);
            labelAccCreateCategory.Name = "labelAccCreateCategory";
            labelAccCreateCategory.Size = new Size(152, 30);
            labelAccCreateCategory.TabIndex = 0;
            labelAccCreateCategory.Text = "Scent Category";
            labelAccCreateCategory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelAccCreateName
            // 
            labelAccCreateName.AutoSize = true;
            labelAccCreateName.Dock = DockStyle.Fill;
            labelAccCreateName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccCreateName.Location = new Point(3, 0);
            labelAccCreateName.Name = "labelAccCreateName";
            labelAccCreateName.Size = new Size(152, 30);
            labelAccCreateName.TabIndex = 0;
            labelAccCreateName.Text = "Accord Name";
            labelAccCreateName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxAccCreateName
            // 
            textBoxAccCreateName.Dock = DockStyle.Fill;
            textBoxAccCreateName.Location = new Point(161, 3);
            textBoxAccCreateName.Name = "textBoxAccCreateName";
            textBoxAccCreateName.Size = new Size(233, 23);
            textBoxAccCreateName.TabIndex = 1;
            // 
            // comboBoxAccCreateCategory
            // 
            comboBoxAccCreateCategory.Dock = DockStyle.Fill;
            comboBoxAccCreateCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAccCreateCategory.FormattingEnabled = true;
            comboBoxAccCreateCategory.Location = new Point(161, 33);
            comboBoxAccCreateCategory.Name = "comboBoxAccCreateCategory";
            comboBoxAccCreateCategory.Size = new Size(233, 23);
            comboBoxAccCreateCategory.TabIndex = 2;
            // 
            // tableLayoutPanelAccCreateSaveCancel
            // 
            tableLayoutPanelAccCreateSaveCancel.ColumnCount = 2;
            tableLayoutPanelAccCreateSaveCancel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelAccCreateSaveCancel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelAccCreateSaveCancel.Controls.Add(buttonAccCreateSave, 0, 0);
            tableLayoutPanelAccCreateSaveCancel.Controls.Add(buttonAccCreateCancel, 1, 0);
            tableLayoutPanelAccCreateSaveCancel.Dock = DockStyle.Fill;
            tableLayoutPanelAccCreateSaveCancel.Location = new Point(161, 177);
            tableLayoutPanelAccCreateSaveCancel.Name = "tableLayoutPanelAccCreateSaveCancel";
            tableLayoutPanelAccCreateSaveCancel.RowCount = 1;
            tableLayoutPanelAccCreateSaveCancel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelAccCreateSaveCancel.Size = new Size(233, 29);
            tableLayoutPanelAccCreateSaveCancel.TabIndex = 8;
            // 
            // buttonAccCreateSave
            // 
            buttonAccCreateSave.Dock = DockStyle.Fill;
            buttonAccCreateSave.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonAccCreateSave.Location = new Point(3, 3);
            buttonAccCreateSave.Name = "buttonAccCreateSave";
            buttonAccCreateSave.Size = new Size(110, 23);
            buttonAccCreateSave.TabIndex = 5;
            buttonAccCreateSave.Text = "Save";
            buttonAccCreateSave.UseVisualStyleBackColor = true;
            buttonAccCreateSave.Click += buttonAccCreateSave_Click;
            // 
            // buttonAccCreateCancel
            // 
            buttonAccCreateCancel.Dock = DockStyle.Fill;
            buttonAccCreateCancel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonAccCreateCancel.Location = new Point(119, 3);
            buttonAccCreateCancel.Name = "buttonAccCreateCancel";
            buttonAccCreateCancel.Size = new Size(111, 23);
            buttonAccCreateCancel.TabIndex = 6;
            buttonAccCreateCancel.Text = "Cancel";
            buttonAccCreateCancel.UseVisualStyleBackColor = true;
            buttonAccCreateCancel.Click += buttonAccCreateCancel_Click;
            // 
            // FormCreateAccord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 209);
            Controls.Add(tableLayoutAccCreate);
            Name = "FormCreateAccord";
            Text = "Create Accord";
            tableLayoutAccCreate.ResumeLayout(false);
            tableLayoutAccCreate.PerformLayout();
            tableLayoutPanelAccCreateSaveCancel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutAccCreate;
        private Label labelAccCreateCategory;
        private Label labelAccCreateName;
        private TextBox textBoxAccCreateName;
        private ComboBox comboBoxAccCreateCategory;
        private TextBox textBoxAccCreateComment;
        private Label labelAccCreateComment;
        private ComboBox comboBoxAccCreateNoteLevel;
        private Label labelAccCreateNoteLevel;
        private TableLayoutPanel tableLayoutPanelAccCreateSaveCancel;
        private Button buttonAccCreateSave;
        private Button buttonAccCreateCancel;
    }
}