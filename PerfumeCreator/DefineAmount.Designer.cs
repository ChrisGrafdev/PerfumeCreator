namespace PerfumeCreator
{
    partial class FormDefineAmount
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
            tableLayoutPanelAddAmount = new TableLayoutPanel();
            groupBoxFragrance = new GroupBox();
            labelAddAmountFragrance = new Label();
            tableLayoutPanelAddAmountIntern = new TableLayoutPanel();
            textBoxAddAmountValue = new TextBox();
            comboBoxAddAmountUnit = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonAddAmountSave = new Button();
            buttonAddAmountCancel = new Button();
            tableLayoutPanelAddAmount.SuspendLayout();
            groupBoxFragrance.SuspendLayout();
            tableLayoutPanelAddAmountIntern.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelAddAmount
            // 
            tableLayoutPanelAddAmount.ColumnCount = 1;
            tableLayoutPanelAddAmount.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelAddAmount.Controls.Add(groupBoxFragrance, 0, 0);
            tableLayoutPanelAddAmount.Controls.Add(tableLayoutPanelAddAmountIntern, 0, 1);
            tableLayoutPanelAddAmount.Controls.Add(tableLayoutPanel1, 0, 2);
            tableLayoutPanelAddAmount.Dock = DockStyle.Fill;
            tableLayoutPanelAddAmount.Location = new Point(0, 0);
            tableLayoutPanelAddAmount.Name = "tableLayoutPanelAddAmount";
            tableLayoutPanelAddAmount.RowCount = 3;
            tableLayoutPanelAddAmount.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanelAddAmount.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanelAddAmount.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanelAddAmount.Size = new Size(302, 126);
            tableLayoutPanelAddAmount.TabIndex = 0;
            // 
            // groupBoxFragrance
            // 
            groupBoxFragrance.Controls.Add(labelAddAmountFragrance);
            groupBoxFragrance.Dock = DockStyle.Fill;
            groupBoxFragrance.Location = new Point(3, 3);
            groupBoxFragrance.Name = "groupBoxFragrance";
            groupBoxFragrance.Size = new Size(296, 49);
            groupBoxFragrance.TabIndex = 0;
            groupBoxFragrance.TabStop = false;
            groupBoxFragrance.Text = "Fragrance";
            // 
            // labelAddAmountFragrance
            // 
            labelAddAmountFragrance.AutoSize = true;
            labelAddAmountFragrance.Dock = DockStyle.Fill;
            labelAddAmountFragrance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAddAmountFragrance.Location = new Point(3, 19);
            labelAddAmountFragrance.Name = "labelAddAmountFragrance";
            labelAddAmountFragrance.Size = new Size(20, 17);
            labelAddAmountFragrance.TabIndex = 0;
            labelAddAmountFragrance.Text = "...";
            labelAddAmountFragrance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelAddAmountIntern
            // 
            tableLayoutPanelAddAmountIntern.ColumnCount = 2;
            tableLayoutPanelAddAmountIntern.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelAddAmountIntern.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelAddAmountIntern.Controls.Add(textBoxAddAmountValue, 0, 0);
            tableLayoutPanelAddAmountIntern.Controls.Add(comboBoxAddAmountUnit, 1, 0);
            tableLayoutPanelAddAmountIntern.Dock = DockStyle.Fill;
            tableLayoutPanelAddAmountIntern.Location = new Point(3, 58);
            tableLayoutPanelAddAmountIntern.Name = "tableLayoutPanelAddAmountIntern";
            tableLayoutPanelAddAmountIntern.RowCount = 1;
            tableLayoutPanelAddAmountIntern.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelAddAmountIntern.Size = new Size(296, 29);
            tableLayoutPanelAddAmountIntern.TabIndex = 3;
            // 
            // textBoxAddAmountValue
            // 
            textBoxAddAmountValue.Dock = DockStyle.Fill;
            textBoxAddAmountValue.Location = new Point(3, 3);
            textBoxAddAmountValue.Name = "textBoxAddAmountValue";
            textBoxAddAmountValue.Size = new Size(142, 23);
            textBoxAddAmountValue.TabIndex = 1;
            // 
            // comboBoxAddAmountUnit
            // 
            comboBoxAddAmountUnit.Dock = DockStyle.Fill;
            comboBoxAddAmountUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAddAmountUnit.FormattingEnabled = true;
            comboBoxAddAmountUnit.Location = new Point(151, 3);
            comboBoxAddAmountUnit.Name = "comboBoxAddAmountUnit";
            comboBoxAddAmountUnit.Size = new Size(142, 23);
            comboBoxAddAmountUnit.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(buttonAddAmountSave, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonAddAmountCancel, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 93);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(296, 30);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // buttonAddAmountSave
            // 
            buttonAddAmountSave.Dock = DockStyle.Fill;
            buttonAddAmountSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAddAmountSave.Location = new Point(3, 3);
            buttonAddAmountSave.Name = "buttonAddAmountSave";
            buttonAddAmountSave.Size = new Size(142, 24);
            buttonAddAmountSave.TabIndex = 3;
            buttonAddAmountSave.Text = "Save";
            buttonAddAmountSave.UseVisualStyleBackColor = true;
            buttonAddAmountSave.Click += buttonAddAmountSave_Click;
            // 
            // buttonAddAmountCancel
            // 
            buttonAddAmountCancel.Dock = DockStyle.Fill;
            buttonAddAmountCancel.Location = new Point(151, 3);
            buttonAddAmountCancel.Name = "buttonAddAmountCancel";
            buttonAddAmountCancel.Size = new Size(142, 24);
            buttonAddAmountCancel.TabIndex = 4;
            buttonAddAmountCancel.Text = "Cancel";
            buttonAddAmountCancel.UseVisualStyleBackColor = true;
            buttonAddAmountCancel.Click += buttonAddAmountCancel_Click;
            // 
            // FormDefineAmount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 126);
            Controls.Add(tableLayoutPanelAddAmount);
            MaximumSize = new Size(318, 165);
            MinimumSize = new Size(318, 165);
            Name = "FormDefineAmount";
            Text = "Define Amount";
            tableLayoutPanelAddAmount.ResumeLayout(false);
            groupBoxFragrance.ResumeLayout(false);
            groupBoxFragrance.PerformLayout();
            tableLayoutPanelAddAmountIntern.ResumeLayout(false);
            tableLayoutPanelAddAmountIntern.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelAddAmount;
        private Label labelAddAmountFragrance;
        private GroupBox groupBoxFragrance;
        private TextBox textBoxAddAmountValue;
        private TableLayoutPanel tableLayoutPanelAddAmountIntern;
        private ComboBox comboBoxAddAmountUnit;
        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonAddAmountSave;
        private Button buttonAddAmountCancel;
    }
}