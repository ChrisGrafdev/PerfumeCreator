namespace PerfumeCreator
{
    partial class FormPerfumeCreator
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
            mainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            generalSettingsToolStripMenuItem = new ToolStripMenuItem();
            viewportMaterialUnitToolStripMenuItem = new ToolStripMenuItem();
            dropsToolStripMenuItem = new ToolStripMenuItem();
            milligramToolStripMenuItem = new ToolStripMenuItem();
            mainStatusStrip = new StatusStrip();
            toolStripStatusLabelMain = new ToolStripStatusLabel();
            splitContainerL0 = new SplitContainer();
            tableLayoutMain = new TableLayoutPanel();
            butAddMolecule = new Button();
            butAddAccord = new Button();
            butAddPerfume = new Button();
            treeViewMolecule = new TreeView();
            treeViewAccord = new TreeView();
            tableLayoutSide = new TableLayoutPanel();
            groupBoxDilutionCalc = new GroupBox();
            tableLayoutDilutionCalc = new TableLayoutPanel();
            buttonDiluentCalcCalculate = new Button();
            textBoxDilutionCalcFinalPercent = new TextBox();
            textBoxDilutionCalcInputAmount = new TextBox();
            comboBoxDilutionCalcInputUnit = new ComboBox();
            labelPercent = new Label();
            buttonDiluentCalcSetResult = new Button();
            groupBoxFragranceAmount = new GroupBox();
            labelDilutionCalcFragranceResult = new Label();
            groupBoxDiluentAmount = new GroupBox();
            labelDilutionCalcDiluentResult = new Label();
            comboBoxDilutionCalcMode = new ComboBox();
            splitContainer1 = new SplitContainer();
            mainMenuStrip.SuspendLayout();
            mainStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerL0).BeginInit();
            splitContainerL0.Panel1.SuspendLayout();
            splitContainerL0.Panel2.SuspendLayout();
            splitContainerL0.SuspendLayout();
            tableLayoutMain.SuspendLayout();
            tableLayoutSide.SuspendLayout();
            groupBoxDilutionCalc.SuspendLayout();
            tableLayoutDilutionCalc.SuspendLayout();
            groupBoxFragranceAmount.SuspendLayout();
            groupBoxDiluentAmount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(1264, 24);
            mainMenuStrip.TabIndex = 0;
            mainMenuStrip.Text = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, exportToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(107, 22);
            openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(107, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(107, 22);
            exportToolStripMenuItem.Text = "Export";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generalSettingsToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // generalSettingsToolStripMenuItem
            // 
            generalSettingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewportMaterialUnitToolStripMenuItem });
            generalSettingsToolStripMenuItem.Name = "generalSettingsToolStripMenuItem";
            generalSettingsToolStripMenuItem.Size = new Size(159, 22);
            generalSettingsToolStripMenuItem.Text = "General Settings";
            // 
            // viewportMaterialUnitToolStripMenuItem
            // 
            viewportMaterialUnitToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dropsToolStripMenuItem, milligramToolStripMenuItem });
            viewportMaterialUnitToolStripMenuItem.Name = "viewportMaterialUnitToolStripMenuItem";
            viewportMaterialUnitToolStripMenuItem.Size = new Size(191, 22);
            viewportMaterialUnitToolStripMenuItem.Text = "Viewport material unit";
            // 
            // dropsToolStripMenuItem
            // 
            dropsToolStripMenuItem.Checked = true;
            dropsToolStripMenuItem.CheckState = CheckState.Checked;
            dropsToolStripMenuItem.Name = "dropsToolStripMenuItem";
            dropsToolStripMenuItem.Size = new Size(154, 22);
            dropsToolStripMenuItem.Text = "Drops";
            dropsToolStripMenuItem.Click += dropsToolStripMenuItem_Click;
            // 
            // milligramToolStripMenuItem
            // 
            milligramToolStripMenuItem.Name = "milligramToolStripMenuItem";
            milligramToolStripMenuItem.Size = new Size(154, 22);
            milligramToolStripMenuItem.Text = "Milligram (mg)";
            milligramToolStripMenuItem.Click += milligramToolStripMenuItem_Click;
            // 
            // mainStatusStrip
            // 
            mainStatusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelMain });
            mainStatusStrip.Location = new Point(0, 659);
            mainStatusStrip.Name = "mainStatusStrip";
            mainStatusStrip.Size = new Size(1264, 22);
            mainStatusStrip.TabIndex = 1;
            mainStatusStrip.Text = "mainStatusStrip";
            // 
            // toolStripStatusLabelMain
            // 
            toolStripStatusLabelMain.Name = "toolStripStatusLabelMain";
            toolStripStatusLabelMain.Size = new Size(26, 17);
            toolStripStatusLabelMain.Text = "Idle";
            // 
            // splitContainerL0
            // 
            splitContainerL0.Dock = DockStyle.Fill;
            splitContainerL0.FixedPanel = FixedPanel.Panel2;
            splitContainerL0.Location = new Point(0, 24);
            splitContainerL0.Name = "splitContainerL0";
            // 
            // splitContainerL0.Panel1
            // 
            splitContainerL0.Panel1.Controls.Add(tableLayoutMain);
            // 
            // splitContainerL0.Panel2
            // 
            splitContainerL0.Panel2.Controls.Add(tableLayoutSide);
            splitContainerL0.Size = new Size(1264, 635);
            splitContainerL0.SplitterDistance = 900;
            splitContainerL0.TabIndex = 2;
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.ColumnCount = 3;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutMain.Controls.Add(butAddMolecule, 2, 0);
            tableLayoutMain.Controls.Add(butAddAccord, 1, 0);
            tableLayoutMain.Controls.Add(butAddPerfume, 0, 0);
            tableLayoutMain.Controls.Add(treeViewMolecule, 2, 1);
            tableLayoutMain.Controls.Add(treeViewAccord, 1, 1);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 2;
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.Size = new Size(900, 635);
            tableLayoutMain.TabIndex = 0;
            // 
            // butAddMolecule
            // 
            butAddMolecule.Dock = DockStyle.Fill;
            butAddMolecule.Location = new Point(543, 3);
            butAddMolecule.Name = "butAddMolecule";
            butAddMolecule.Size = new Size(354, 24);
            butAddMolecule.TabIndex = 2;
            butAddMolecule.Text = "Add Molecule";
            butAddMolecule.UseVisualStyleBackColor = true;
            butAddMolecule.Click += butAddMolecule_Click;
            // 
            // butAddAccord
            // 
            butAddAccord.Dock = DockStyle.Fill;
            butAddAccord.Location = new Point(273, 3);
            butAddAccord.Name = "butAddAccord";
            butAddAccord.Size = new Size(264, 24);
            butAddAccord.TabIndex = 1;
            butAddAccord.Text = "New Accord";
            butAddAccord.UseVisualStyleBackColor = true;
            // 
            // butAddPerfume
            // 
            butAddPerfume.Dock = DockStyle.Fill;
            butAddPerfume.Location = new Point(3, 3);
            butAddPerfume.Name = "butAddPerfume";
            butAddPerfume.Size = new Size(264, 24);
            butAddPerfume.TabIndex = 0;
            butAddPerfume.Text = "New Perfume";
            butAddPerfume.UseVisualStyleBackColor = true;
            // 
            // treeViewMolecule
            // 
            treeViewMolecule.Dock = DockStyle.Fill;
            treeViewMolecule.Location = new Point(543, 33);
            treeViewMolecule.Name = "treeViewMolecule";
            treeViewMolecule.Size = new Size(354, 599);
            treeViewMolecule.TabIndex = 3;
            treeViewMolecule.ItemDrag += treeViewMolecule_ItemDrag;
            // 
            // treeViewAccord
            // 
            treeViewAccord.AllowDrop = true;
            treeViewAccord.Dock = DockStyle.Fill;
            treeViewAccord.Location = new Point(273, 33);
            treeViewAccord.Name = "treeViewAccord";
            treeViewAccord.Size = new Size(264, 599);
            treeViewAccord.TabIndex = 4;
            treeViewAccord.ItemDrag += treeViewAccord_ItemDrag;
            treeViewAccord.NodeMouseDoubleClick += treeViewAccord_NodeMouseDoubleClick;
            treeViewAccord.DragDrop += treeViewAccord_DragDrop;
            treeViewAccord.DragEnter += treeViewAccord_DragEnter;
            // 
            // tableLayoutSide
            // 
            tableLayoutSide.ColumnCount = 1;
            tableLayoutSide.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutSide.Controls.Add(groupBoxDilutionCalc, 0, 0);
            tableLayoutSide.Dock = DockStyle.Fill;
            tableLayoutSide.Location = new Point(0, 0);
            tableLayoutSide.Name = "tableLayoutSide";
            tableLayoutSide.RowCount = 2;
            tableLayoutSide.RowStyles.Add(new RowStyle(SizeType.Absolute, 195F));
            tableLayoutSide.RowStyles.Add(new RowStyle());
            tableLayoutSide.Size = new Size(360, 635);
            tableLayoutSide.TabIndex = 0;
            // 
            // groupBoxDilutionCalc
            // 
            groupBoxDilutionCalc.Controls.Add(tableLayoutDilutionCalc);
            groupBoxDilutionCalc.Controls.Add(comboBoxDilutionCalcMode);
            groupBoxDilutionCalc.Dock = DockStyle.Fill;
            groupBoxDilutionCalc.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxDilutionCalc.Location = new Point(3, 3);
            groupBoxDilutionCalc.Name = "groupBoxDilutionCalc";
            groupBoxDilutionCalc.Size = new Size(354, 189);
            groupBoxDilutionCalc.TabIndex = 2;
            groupBoxDilutionCalc.TabStop = false;
            groupBoxDilutionCalc.Text = "Dilution Calculator";
            // 
            // tableLayoutDilutionCalc
            // 
            tableLayoutDilutionCalc.ColumnCount = 2;
            tableLayoutDilutionCalc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutDilutionCalc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutDilutionCalc.Controls.Add(buttonDiluentCalcCalculate, 0, 3);
            tableLayoutDilutionCalc.Controls.Add(textBoxDilutionCalcFinalPercent, 0, 1);
            tableLayoutDilutionCalc.Controls.Add(textBoxDilutionCalcInputAmount, 0, 0);
            tableLayoutDilutionCalc.Controls.Add(comboBoxDilutionCalcInputUnit, 1, 0);
            tableLayoutDilutionCalc.Controls.Add(labelPercent, 1, 1);
            tableLayoutDilutionCalc.Controls.Add(buttonDiluentCalcSetResult, 1, 3);
            tableLayoutDilutionCalc.Controls.Add(groupBoxFragranceAmount, 0, 2);
            tableLayoutDilutionCalc.Controls.Add(groupBoxDiluentAmount, 1, 2);
            tableLayoutDilutionCalc.Dock = DockStyle.Fill;
            tableLayoutDilutionCalc.Location = new Point(3, 46);
            tableLayoutDilutionCalc.Name = "tableLayoutDilutionCalc";
            tableLayoutDilutionCalc.RowCount = 4;
            tableLayoutDilutionCalc.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutDilutionCalc.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutDilutionCalc.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutDilutionCalc.RowStyles.Add(new RowStyle());
            tableLayoutDilutionCalc.Size = new Size(348, 140);
            tableLayoutDilutionCalc.TabIndex = 1;
            // 
            // buttonDiluentCalcCalculate
            // 
            buttonDiluentCalcCalculate.Dock = DockStyle.Fill;
            buttonDiluentCalcCalculate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDiluentCalcCalculate.Location = new Point(3, 108);
            buttonDiluentCalcCalculate.Name = "buttonDiluentCalcCalculate";
            buttonDiluentCalcCalculate.Size = new Size(168, 29);
            buttonDiluentCalcCalculate.TabIndex = 8;
            buttonDiluentCalcCalculate.Text = "Calculate";
            buttonDiluentCalcCalculate.UseVisualStyleBackColor = true;
            buttonDiluentCalcCalculate.Click += buttonDiluentCalcCalculate_Click;
            // 
            // textBoxDilutionCalcFinalPercent
            // 
            textBoxDilutionCalcFinalPercent.Dock = DockStyle.Fill;
            textBoxDilutionCalcFinalPercent.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxDilutionCalcFinalPercent.Location = new Point(3, 33);
            textBoxDilutionCalcFinalPercent.Name = "textBoxDilutionCalcFinalPercent";
            textBoxDilutionCalcFinalPercent.RightToLeft = RightToLeft.No;
            textBoxDilutionCalcFinalPercent.Size = new Size(168, 25);
            textBoxDilutionCalcFinalPercent.TabIndex = 2;
            textBoxDilutionCalcFinalPercent.Text = "10";
            textBoxDilutionCalcFinalPercent.TextAlign = HorizontalAlignment.Right;
            textBoxDilutionCalcFinalPercent.TextChanged += textBoxDilutionCalcFinalPercent_TextChanged;
            // 
            // textBoxDilutionCalcInputAmount
            // 
            textBoxDilutionCalcInputAmount.Dock = DockStyle.Fill;
            textBoxDilutionCalcInputAmount.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxDilutionCalcInputAmount.Location = new Point(3, 3);
            textBoxDilutionCalcInputAmount.Name = "textBoxDilutionCalcInputAmount";
            textBoxDilutionCalcInputAmount.RightToLeft = RightToLeft.No;
            textBoxDilutionCalcInputAmount.Size = new Size(168, 25);
            textBoxDilutionCalcInputAmount.TabIndex = 0;
            textBoxDilutionCalcInputAmount.Text = "1";
            textBoxDilutionCalcInputAmount.TextAlign = HorizontalAlignment.Right;
            textBoxDilutionCalcInputAmount.TextChanged += textBoxDilutionCalcInputAmount_TextChanged;
            // 
            // comboBoxDilutionCalcInputUnit
            // 
            comboBoxDilutionCalcInputUnit.Dock = DockStyle.Fill;
            comboBoxDilutionCalcInputUnit.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxDilutionCalcInputUnit.FormattingEnabled = true;
            comboBoxDilutionCalcInputUnit.Location = new Point(177, 3);
            comboBoxDilutionCalcInputUnit.Name = "comboBoxDilutionCalcInputUnit";
            comboBoxDilutionCalcInputUnit.Size = new Size(168, 25);
            comboBoxDilutionCalcInputUnit.TabIndex = 1;
            // 
            // labelPercent
            // 
            labelPercent.AutoSize = true;
            labelPercent.Dock = DockStyle.Fill;
            labelPercent.Location = new Point(177, 30);
            labelPercent.Name = "labelPercent";
            labelPercent.Size = new Size(168, 30);
            labelPercent.TabIndex = 3;
            labelPercent.Text = "%";
            labelPercent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonDiluentCalcSetResult
            // 
            buttonDiluentCalcSetResult.Dock = DockStyle.Fill;
            buttonDiluentCalcSetResult.Enabled = false;
            buttonDiluentCalcSetResult.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDiluentCalcSetResult.Location = new Point(177, 108);
            buttonDiluentCalcSetResult.Name = "buttonDiluentCalcSetResult";
            buttonDiluentCalcSetResult.Size = new Size(168, 29);
            buttonDiluentCalcSetResult.TabIndex = 5;
            buttonDiluentCalcSetResult.Text = "Write Results";
            buttonDiluentCalcSetResult.UseVisualStyleBackColor = true;
            buttonDiluentCalcSetResult.Click += buttonDiluentCalcSetResult_Click;
            // 
            // groupBoxFragranceAmount
            // 
            groupBoxFragranceAmount.Controls.Add(labelDilutionCalcFragranceResult);
            groupBoxFragranceAmount.Dock = DockStyle.Fill;
            groupBoxFragranceAmount.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBoxFragranceAmount.Location = new Point(3, 63);
            groupBoxFragranceAmount.Name = "groupBoxFragranceAmount";
            groupBoxFragranceAmount.Size = new Size(168, 39);
            groupBoxFragranceAmount.TabIndex = 9;
            groupBoxFragranceAmount.TabStop = false;
            groupBoxFragranceAmount.Text = "Fragrance Amount";
            // 
            // labelDilutionCalcFragranceResult
            // 
            labelDilutionCalcFragranceResult.AutoSize = true;
            labelDilutionCalcFragranceResult.Dock = DockStyle.Fill;
            labelDilutionCalcFragranceResult.Location = new Point(3, 19);
            labelDilutionCalcFragranceResult.Name = "labelDilutionCalcFragranceResult";
            labelDilutionCalcFragranceResult.Size = new Size(94, 15);
            labelDilutionCalcFragranceResult.TabIndex = 7;
            labelDilutionCalcFragranceResult.Text = "Fragrance Result";
            labelDilutionCalcFragranceResult.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBoxDiluentAmount
            // 
            groupBoxDiluentAmount.Controls.Add(labelDilutionCalcDiluentResult);
            groupBoxDiluentAmount.Dock = DockStyle.Fill;
            groupBoxDiluentAmount.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBoxDiluentAmount.Location = new Point(177, 63);
            groupBoxDiluentAmount.Name = "groupBoxDiluentAmount";
            groupBoxDiluentAmount.Size = new Size(168, 39);
            groupBoxDiluentAmount.TabIndex = 10;
            groupBoxDiluentAmount.TabStop = false;
            groupBoxDiluentAmount.Text = "Diluent Amount";
            // 
            // labelDilutionCalcDiluentResult
            // 
            labelDilutionCalcDiluentResult.AutoSize = true;
            labelDilutionCalcDiluentResult.Dock = DockStyle.Fill;
            labelDilutionCalcDiluentResult.Location = new Point(3, 19);
            labelDilutionCalcDiluentResult.Name = "labelDilutionCalcDiluentResult";
            labelDilutionCalcDiluentResult.Size = new Size(80, 15);
            labelDilutionCalcDiluentResult.TabIndex = 8;
            labelDilutionCalcDiluentResult.Text = "Diluent Result";
            labelDilutionCalcDiluentResult.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxDilutionCalcMode
            // 
            comboBoxDilutionCalcMode.Dock = DockStyle.Top;
            comboBoxDilutionCalcMode.FormattingEnabled = true;
            comboBoxDilutionCalcMode.Location = new Point(3, 21);
            comboBoxDilutionCalcMode.Name = "comboBoxDilutionCalcMode";
            comboBoxDilutionCalcMode.Size = new Size(348, 25);
            comboBoxDilutionCalcMode.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Size = new Size(1191, 995);
            splitContainer1.SplitterDistance = 809;
            splitContainer1.TabIndex = 0;
            // 
            // FormPerfumeCreator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(splitContainerL0);
            Controls.Add(mainStatusStrip);
            Controls.Add(mainMenuStrip);
            MainMenuStrip = mainMenuStrip;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormPerfumeCreator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Perfume Creator";
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            mainStatusStrip.ResumeLayout(false);
            mainStatusStrip.PerformLayout();
            splitContainerL0.Panel1.ResumeLayout(false);
            splitContainerL0.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerL0).EndInit();
            splitContainerL0.ResumeLayout(false);
            tableLayoutMain.ResumeLayout(false);
            tableLayoutSide.ResumeLayout(false);
            groupBoxDilutionCalc.ResumeLayout(false);
            tableLayoutDilutionCalc.ResumeLayout(false);
            tableLayoutDilutionCalc.PerformLayout();
            groupBoxFragranceAmount.ResumeLayout(false);
            groupBoxFragranceAmount.PerformLayout();
            groupBoxDiluentAmount.ResumeLayout(false);
            groupBoxDiluentAmount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private StatusStrip mainStatusStrip;
        private SplitContainer splitContainerL0;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutMain;
        private Button butAddMolecule;
        private Button butAddAccord;
        private Button butAddPerfume;
        private TableLayoutPanel tableLayoutSide;
        private GroupBox groupBoxDilutionCalc;
        private ComboBox comboBoxDilutionCalcMode;
        private TableLayoutPanel tableLayoutDilutionCalc;
        private TextBox textBoxDilutionCalcInputAmount;
        private ComboBox comboBoxDilutionCalcInputUnit;
        private TextBox textBoxDilutionCalcFinalPercent;
        private Label labelPercent;
        private Button buttonDiluentCalcSetResult;
        private Label labelResultFragranceAmount;
        private Button buttonDiluentCalcCalculate;
        private GroupBox groupBoxFragranceAmount;
        private Label labelDilutionCalcFragranceResult;
        private GroupBox groupBoxDiluentAmount;
        private Label labelDilutionCalcDiluentResult;
        private ToolStripStatusLabel toolStripStatusLabelMain;
        private TreeView treeViewMolecule;
        private TreeView treeViewAccord;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem generalSettingsToolStripMenuItem;
        private ToolStripMenuItem viewportMaterialUnitToolStripMenuItem;
        private ToolStripMenuItem dropsToolStripMenuItem;
        private ToolStripMenuItem milligramToolStripMenuItem;
    }
}
