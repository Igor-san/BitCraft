
namespace BitCraft
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitterBottom = new System.Windows.Forms.Splitter();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBoxBitString = new System.Windows.Forms.TextBox();
            this.buttonSelectAddressesDataBase = new System.Windows.Forms.Button();
            this.buttonSelectRandom = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonClearCraft = new System.Windows.Forms.Button();
            this.textBoxDecString = new System.Windows.Forms.TextBox();
            this.buttonDecConvert = new System.Windows.Forms.Button();
            this.buttonHexConvert = new System.Windows.Forms.Button();
            this.buttonBinConvert = new System.Windows.Forms.Button();
            this.buttonbuttonSelectRandom2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelFoundedAddressesCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelAddressesCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop = new System.Windows.Forms.Panel();
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxHexString = new System.Windows.Forms.TextBox();
            this.splitterGrig = new System.Windows.Forms.Splitter();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageCraft = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelCraftControl = new System.Windows.Forms.Panel();
            this.tabPageFounded = new System.Windows.Forms.TabPage();
            this.textBoxFoundedAddresses = new System.Windows.Forms.TextBox();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.textBoxAddressesDataBase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.craftControl1 = new BitCraft.UserControls.CraftControl();
            this.bitcoinItem1 = new BitCraft.UserControls.BitcoinItem();
            this.statusMessagePanel = new TotoFBitCrafton.UserControls.StatusMessagePanel();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.tableLayoutPanelTop.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageCraft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelCraftControl.SuspendLayout();
            this.tabPageFounded.SuspendLayout();
            this.tabPageOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitterBottom
            // 
            this.splitterBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterBottom.Location = new System.Drawing.Point(0, 646);
            this.splitterBottom.Name = "splitterBottom";
            this.splitterBottom.Size = new System.Drawing.Size(1026, 3);
            this.splitterBottom.TabIndex = 1;
            this.splitterBottom.TabStop = false;
            // 
            // textBoxBitString
            // 
            this.textBoxBitString.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxBitString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxBitString.Font = new System.Drawing.Font("Arial", 6.056075F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxBitString.Location = new System.Drawing.Point(3, 61);
            this.textBoxBitString.Name = "textBoxBitString";
            this.textBoxBitString.Size = new System.Drawing.Size(978, 17);
            this.textBoxBitString.TabIndex = 0;
            this.textBoxBitString.Text = "0000";
            this.toolTip1.SetToolTip(this.textBoxBitString, "выбранная бинарная последовательность");
            this.textBoxBitString.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxBitString_KeyUp);
            // 
            // buttonSelectAddressesDataBase
            // 
            this.buttonSelectAddressesDataBase.FlatAppearance.BorderSize = 0;
            this.buttonSelectAddressesDataBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectAddressesDataBase.Image = global::BitCraft.Properties.Resources.open;
            this.buttonSelectAddressesDataBase.Location = new System.Drawing.Point(501, 26);
            this.buttonSelectAddressesDataBase.Name = "buttonSelectAddressesDataBase";
            this.buttonSelectAddressesDataBase.Size = new System.Drawing.Size(23, 23);
            this.buttonSelectAddressesDataBase.TabIndex = 2;
            this.toolTip1.SetToolTip(this.buttonSelectAddressesDataBase, "выбрать базу данных с адресами биткоина");
            this.buttonSelectAddressesDataBase.UseVisualStyleBackColor = true;
            this.buttonSelectAddressesDataBase.Click += new System.EventHandler(this.buttonSelectAddressesDataBase_Click);
            // 
            // buttonSelectRandom
            // 
            this.buttonSelectRandom.FlatAppearance.BorderSize = 0;
            this.buttonSelectRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectRandom.Location = new System.Drawing.Point(5, 61);
            this.buttonSelectRandom.Name = "buttonSelectRandom";
            this.buttonSelectRandom.Size = new System.Drawing.Size(17, 23);
            this.buttonSelectRandom.TabIndex = 2;
            this.buttonSelectRandom.Text = "R";
            this.toolTip1.SetToolTip(this.buttonSelectRandom, "выбрать случайные номера");
            this.buttonSelectRandom.UseVisualStyleBackColor = true;
            this.buttonSelectRandom.Click += new System.EventHandler(this.buttonSelectRandom_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.FlatAppearance.BorderSize = 0;
            this.buttonSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectAll.Location = new System.Drawing.Point(5, 32);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(17, 23);
            this.buttonSelectAll.TabIndex = 1;
            this.buttonSelectAll.Text = "A";
            this.toolTip1.SetToolTip(this.buttonSelectAll, "отметить все поле");
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonClearCraft
            // 
            this.buttonClearCraft.FlatAppearance.BorderSize = 0;
            this.buttonClearCraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearCraft.Location = new System.Drawing.Point(3, 3);
            this.buttonClearCraft.Name = "buttonClearCraft";
            this.buttonClearCraft.Size = new System.Drawing.Size(17, 23);
            this.buttonClearCraft.TabIndex = 0;
            this.buttonClearCraft.Text = "x";
            this.toolTip1.SetToolTip(this.buttonClearCraft, "очистить все поле");
            this.buttonClearCraft.UseVisualStyleBackColor = true;
            this.buttonClearCraft.Click += new System.EventHandler(this.buttonClearCraft_Click);
            // 
            // textBoxDecString
            // 
            this.textBoxDecString.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxDecString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDecString.Location = new System.Drawing.Point(3, 3);
            this.textBoxDecString.Name = "textBoxDecString";
            this.textBoxDecString.Size = new System.Drawing.Size(978, 20);
            this.textBoxDecString.TabIndex = 2;
            this.textBoxDecString.Text = "0";
            this.toolTip1.SetToolTip(this.textBoxDecString, "десятичное представление");
            this.textBoxDecString.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxDecString_KeyUp);
            // 
            // buttonDecConvert
            // 
            this.buttonDecConvert.FlatAppearance.BorderSize = 0;
            this.buttonDecConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDecConvert.Location = new System.Drawing.Point(987, 3);
            this.buttonDecConvert.Name = "buttonDecConvert";
            this.buttonDecConvert.Size = new System.Drawing.Size(17, 23);
            this.buttonDecConvert.TabIndex = 3;
            this.buttonDecConvert.Text = "D";
            this.toolTip1.SetToolTip(this.buttonDecConvert, "преобразовать десятичное представление ключа в адреса");
            this.buttonDecConvert.UseVisualStyleBackColor = true;
            this.buttonDecConvert.Click += new System.EventHandler(this.buttonDecConvert_Click);
            // 
            // buttonHexConvert
            // 
            this.buttonHexConvert.FlatAppearance.BorderSize = 0;
            this.buttonHexConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHexConvert.Location = new System.Drawing.Point(987, 32);
            this.buttonHexConvert.Name = "buttonHexConvert";
            this.buttonHexConvert.Size = new System.Drawing.Size(17, 23);
            this.buttonHexConvert.TabIndex = 4;
            this.buttonHexConvert.Text = "H";
            this.toolTip1.SetToolTip(this.buttonHexConvert, "преобразовать шестнадцатеричное представление ключа в адреса");
            this.buttonHexConvert.UseVisualStyleBackColor = true;
            this.buttonHexConvert.Click += new System.EventHandler(this.buttonHexConvert_Click);
            // 
            // buttonBinConvert
            // 
            this.buttonBinConvert.FlatAppearance.BorderSize = 0;
            this.buttonBinConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBinConvert.Location = new System.Drawing.Point(987, 61);
            this.buttonBinConvert.Name = "buttonBinConvert";
            this.buttonBinConvert.Size = new System.Drawing.Size(17, 23);
            this.buttonBinConvert.TabIndex = 5;
            this.buttonBinConvert.Text = "B";
            this.toolTip1.SetToolTip(this.buttonBinConvert, "преобразовать бинарное представление ключа в адреса");
            this.buttonBinConvert.UseVisualStyleBackColor = true;
            this.buttonBinConvert.Click += new System.EventHandler(this.buttonBinConvert_Click);
            // 
            // buttonbuttonSelectRandom2
            // 
            this.buttonbuttonSelectRandom2.FlatAppearance.BorderSize = 0;
            this.buttonbuttonSelectRandom2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonbuttonSelectRandom2.Location = new System.Drawing.Point(6, 240);
            this.buttonbuttonSelectRandom2.Name = "buttonbuttonSelectRandom2";
            this.buttonbuttonSelectRandom2.Size = new System.Drawing.Size(17, 23);
            this.buttonbuttonSelectRandom2.TabIndex = 3;
            this.buttonbuttonSelectRandom2.Text = "N";
            this.toolTip1.SetToolTip(this.buttonbuttonSelectRandom2, "Случайно из NBitcoin");
            this.buttonbuttonSelectRandom2.UseVisualStyleBackColor = true;
            this.buttonbuttonSelectRandom2.Click += new System.EventHandler(this.buttonbuttonSelectRandom2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelFoundedAddressesCount,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelAddressesCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 676);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1026, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelFoundedAddressesCount
            // 
            this.toolStripStatusLabelFoundedAddressesCount.Name = "toolStripStatusLabelFoundedAddressesCount";
            this.toolStripStatusLabelFoundedAddressesCount.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabelFoundedAddressesCount.Text = "0";
            this.toolStripStatusLabelFoundedAddressesCount.ToolTipText = "число найденных адресов";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // toolStripStatusLabelAddressesCount
            // 
            this.toolStripStatusLabelAddressesCount.Name = "toolStripStatusLabelAddressesCount";
            this.toolStripStatusLabelAddressesCount.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabelAddressesCount.Text = "0";
            this.toolStripStatusLabelAddressesCount.ToolTipText = "число адресов биткоина в базе данных";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1026, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.tableLayoutPanelTop);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1009, 87);
            this.panelTop.TabIndex = 4;
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.ColumnCount = 2;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelTop.Controls.Add(this.buttonBinConvert, 1, 2);
            this.tableLayoutPanelTop.Controls.Add(this.buttonHexConvert, 1, 1);
            this.tableLayoutPanelTop.Controls.Add(this.buttonDecConvert, 1, 0);
            this.tableLayoutPanelTop.Controls.Add(this.textBoxBitString, 0, 2);
            this.tableLayoutPanelTop.Controls.Add(this.textBoxDecString, 0, 0);
            this.tableLayoutPanelTop.Controls.Add(this.textBoxHexString, 0, 1);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 3;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(1009, 87);
            this.tableLayoutPanelTop.TabIndex = 2;
            // 
            // textBoxHexString
            // 
            this.textBoxHexString.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxHexString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxHexString.Location = new System.Drawing.Point(3, 32);
            this.textBoxHexString.Name = "textBoxHexString";
            this.textBoxHexString.Size = new System.Drawing.Size(978, 20);
            this.textBoxHexString.TabIndex = 6;
            this.textBoxHexString.Text = "0000";
            this.textBoxHexString.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxHexString_KeyUp);
            // 
            // splitterGrig
            // 
            this.splitterGrig.Location = new System.Drawing.Point(0, 24);
            this.splitterGrig.Name = "splitterGrig";
            this.splitterGrig.Size = new System.Drawing.Size(3, 622);
            this.splitterGrig.TabIndex = 7;
            this.splitterGrig.TabStop = false;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageCraft);
            this.tabControlMain.Controls.Add(this.tabPageFounded);
            this.tabControlMain.Controls.Add(this.tabPageOptions);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(3, 24);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1023, 622);
            this.tabControlMain.TabIndex = 10;
            // 
            // tabPageCraft
            // 
            this.tabPageCraft.Controls.Add(this.splitContainer1);
            this.tabPageCraft.Controls.Add(this.panelTop);
            this.tabPageCraft.Location = new System.Drawing.Point(4, 22);
            this.tabPageCraft.Name = "tabPageCraft";
            this.tabPageCraft.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCraft.Size = new System.Drawing.Size(1015, 596);
            this.tabPageCraft.TabIndex = 0;
            this.tabPageCraft.Text = "Поле";
            this.tabPageCraft.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 90);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.craftControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.bitcoinItem1);
            this.splitContainer1.Panel2.Controls.Add(this.panelCraftControl);
            this.splitContainer1.Size = new System.Drawing.Size(1009, 503);
            this.splitContainer1.SplitterDistance = 532;
            this.splitContainer1.TabIndex = 9;
            // 
            // panelCraftControl
            // 
            this.panelCraftControl.Controls.Add(this.buttonbuttonSelectRandom2);
            this.panelCraftControl.Controls.Add(this.buttonSelectRandom);
            this.panelCraftControl.Controls.Add(this.buttonSelectAll);
            this.panelCraftControl.Controls.Add(this.buttonClearCraft);
            this.panelCraftControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCraftControl.Location = new System.Drawing.Point(0, 0);
            this.panelCraftControl.Name = "panelCraftControl";
            this.panelCraftControl.Size = new System.Drawing.Size(28, 503);
            this.panelCraftControl.TabIndex = 7;
            // 
            // tabPageFounded
            // 
            this.tabPageFounded.Controls.Add(this.textBoxFoundedAddresses);
            this.tabPageFounded.Location = new System.Drawing.Point(4, 22);
            this.tabPageFounded.Name = "tabPageFounded";
            this.tabPageFounded.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFounded.Size = new System.Drawing.Size(1015, 596);
            this.tabPageFounded.TabIndex = 1;
            this.tabPageFounded.Text = "Найдено";
            this.tabPageFounded.UseVisualStyleBackColor = true;
            // 
            // textBoxFoundedAddresses
            // 
            this.textBoxFoundedAddresses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFoundedAddresses.Location = new System.Drawing.Point(3, 3);
            this.textBoxFoundedAddresses.Multiline = true;
            this.textBoxFoundedAddresses.Name = "textBoxFoundedAddresses";
            this.textBoxFoundedAddresses.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxFoundedAddresses.Size = new System.Drawing.Size(1009, 590);
            this.textBoxFoundedAddresses.TabIndex = 1;
            this.textBoxFoundedAddresses.WordWrap = false;
            // 
            // tabPageOptions
            // 
            this.tabPageOptions.Controls.Add(this.buttonSelectAddressesDataBase);
            this.tabPageOptions.Controls.Add(this.textBoxAddressesDataBase);
            this.tabPageOptions.Controls.Add(this.label1);
            this.tabPageOptions.Location = new System.Drawing.Point(4, 22);
            this.tabPageOptions.Name = "tabPageOptions";
            this.tabPageOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOptions.Size = new System.Drawing.Size(1015, 596);
            this.tabPageOptions.TabIndex = 2;
            this.tabPageOptions.Text = "Настройки";
            this.tabPageOptions.UseVisualStyleBackColor = true;
            // 
            // textBoxAddressesDataBase
            // 
            this.textBoxAddressesDataBase.Location = new System.Drawing.Point(120, 27);
            this.textBoxAddressesDataBase.Name = "textBoxAddressesDataBase";
            this.textBoxAddressesDataBase.Size = new System.Drawing.Size(370, 20);
            this.textBoxAddressesDataBase.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "База с адресами:";
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "BitCraft";
            this.notifyIconMain.Visible = true;
            // 
            // craftControl1
            // 
            this.craftControl1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.craftControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.craftControl1.Location = new System.Drawing.Point(0, 0);
            this.craftControl1.Margin = new System.Windows.Forms.Padding(2);
            this.craftControl1.Name = "craftControl1";
            this.craftControl1.Size = new System.Drawing.Size(532, 503);
            this.craftControl1.TabIndex = 0;
            this.craftControl1.NumbersChanged += new System.EventHandler(this.craftControl1_NumbersChanged);
            this.craftControl1.NewError += new System.EventHandler(this.craftControl1_NewError);
            // 
            // bitcoinItem1
            // 
            this.bitcoinItem1.Location = new System.Drawing.Point(28, 0);
            this.bitcoinItem1.Name = "bitcoinItem1";
            this.bitcoinItem1.Size = new System.Drawing.Size(389, 325);
            this.bitcoinItem1.TabIndex = 6;
            // 
            // statusMessagePanel
            // 
            this.statusMessagePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusMessagePanel.IsCollapsed = true;
            this.statusMessagePanel.Location = new System.Drawing.Point(0, 649);
            this.statusMessagePanel.Name = "statusMessagePanel";
            this.statusMessagePanel.Size = new System.Drawing.Size(1026, 27);
            this.statusMessagePanel.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 698);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.splitterGrig);
            this.Controls.Add(this.splitterBottom);
            this.Controls.Add(this.statusMessagePanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "BitCraft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.tableLayoutPanelTop.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageCraft.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelCraftControl.ResumeLayout(false);
            this.tabPageFounded.ResumeLayout(false);
            this.tabPageFounded.PerformLayout();
            this.tabPageOptions.ResumeLayout(false);
            this.tabPageOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TotoFBitCrafton.UserControls.StatusMessagePanel statusMessagePanel;
        private System.Windows.Forms.Splitter splitterBottom;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Splitter splitterGrig;
        private System.Windows.Forms.TextBox textBoxBitString;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private UserControls.BitcoinItem bitcoinItem1;
        private System.Windows.Forms.Panel panelCraftControl;
        private System.Windows.Forms.Button buttonClearCraft;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageCraft;
        private System.Windows.Forms.TabPage tabPageFounded;
        private System.Windows.Forms.TabPage tabPageOptions;
        private System.Windows.Forms.Button buttonSelectAddressesDataBase;
        private System.Windows.Forms.TextBox textBoxAddressesDataBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFoundedAddresses;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFoundedAddressesCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAddressesCount;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.Button buttonSelectRandom;
        private UserControls.CraftControl craftControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
        private System.Windows.Forms.Button buttonBinConvert;
        private System.Windows.Forms.Button buttonHexConvert;
        private System.Windows.Forms.Button buttonDecConvert;
        private System.Windows.Forms.TextBox textBoxDecString;
        private System.Windows.Forms.TextBox textBoxHexString;
        private System.Windows.Forms.Button buttonbuttonSelectRandom2;
    }
}

