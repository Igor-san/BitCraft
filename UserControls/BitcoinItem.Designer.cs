
namespace BitCraft.UserControls
{
    partial class BitcoinItem
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxCompressed = new System.Windows.Forms.GroupBox();
            this.buttonSegwitBalanceCompressed = new System.Windows.Forms.Button();
            this.buttonLegacyBalanceCompressed = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSegwitCompressed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLegacyCompressed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPrivateKeyCompressed = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonLegacyBalanceUnCompressed = new System.Windows.Forms.Button();
            this.buttonSegwitP2SHBalanceCompressed = new System.Windows.Forms.Button();
            this.textBoxPrivateKeyUnCompressed = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxLegacyUnCompressed = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSegwitP2SHCompressed = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxUnCompressed = new System.Windows.Forms.GroupBox();
            this.groupBoxCompressed.SuspendLayout();
            this.groupBoxUnCompressed.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCompressed
            // 
            this.groupBoxCompressed.Controls.Add(this.buttonSegwitP2SHBalanceCompressed);
            this.groupBoxCompressed.Controls.Add(this.label6);
            this.groupBoxCompressed.Controls.Add(this.buttonSegwitBalanceCompressed);
            this.groupBoxCompressed.Controls.Add(this.buttonLegacyBalanceCompressed);
            this.groupBoxCompressed.Controls.Add(this.label3);
            this.groupBoxCompressed.Controls.Add(this.textBoxSegwitP2SHCompressed);
            this.groupBoxCompressed.Controls.Add(this.textBoxSegwitCompressed);
            this.groupBoxCompressed.Controls.Add(this.label2);
            this.groupBoxCompressed.Controls.Add(this.textBoxLegacyCompressed);
            this.groupBoxCompressed.Controls.Add(this.label1);
            this.groupBoxCompressed.Controls.Add(this.textBoxPrivateKeyCompressed);
            this.groupBoxCompressed.Location = new System.Drawing.Point(3, 3);
            this.groupBoxCompressed.Name = "groupBoxCompressed";
            this.groupBoxCompressed.Size = new System.Drawing.Size(381, 216);
            this.groupBoxCompressed.TabIndex = 0;
            this.groupBoxCompressed.TabStop = false;
            this.groupBoxCompressed.Text = "Bitcoin Compressed";
            // 
            // buttonSegwitBalanceCompressed
            // 
            this.buttonSegwitBalanceCompressed.FlatAppearance.BorderSize = 0;
            this.buttonSegwitBalanceCompressed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSegwitBalanceCompressed.Image = global::BitCraft.Properties.Resources.icons8_bitcoin_money_digital_wallet_logotype_of_mobile_application_24;
            this.buttonSegwitBalanceCompressed.Location = new System.Drawing.Point(347, 117);
            this.buttonSegwitBalanceCompressed.Name = "buttonSegwitBalanceCompressed";
            this.buttonSegwitBalanceCompressed.Size = new System.Drawing.Size(25, 25);
            this.buttonSegwitBalanceCompressed.TabIndex = 9;
            this.toolTip1.SetToolTip(this.buttonSegwitBalanceCompressed, "проверить баланс");
            this.buttonSegwitBalanceCompressed.UseVisualStyleBackColor = true;
            this.buttonSegwitBalanceCompressed.Click += new System.EventHandler(this.buttonSegwitBalanceCompressed_Click);
            // 
            // buttonLegacyBalanceCompressed
            // 
            this.buttonLegacyBalanceCompressed.FlatAppearance.BorderSize = 0;
            this.buttonLegacyBalanceCompressed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLegacyBalanceCompressed.Image = global::BitCraft.Properties.Resources.icons8_bitcoin_money_digital_wallet_logotype_of_mobile_application_24;
            this.buttonLegacyBalanceCompressed.Location = new System.Drawing.Point(347, 72);
            this.buttonLegacyBalanceCompressed.Name = "buttonLegacyBalanceCompressed";
            this.buttonLegacyBalanceCompressed.Size = new System.Drawing.Size(25, 25);
            this.buttonLegacyBalanceCompressed.TabIndex = 8;
            this.toolTip1.SetToolTip(this.buttonLegacyBalanceCompressed, "проверить баланс");
            this.buttonLegacyBalanceCompressed.UseVisualStyleBackColor = true;
            this.buttonLegacyBalanceCompressed.Click += new System.EventHandler(this.buttonLegacyBalanceCompressed_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Segwit Address";
            // 
            // textBoxSegwitCompressed
            // 
            this.textBoxSegwitCompressed.Location = new System.Drawing.Point(6, 120);
            this.textBoxSegwitCompressed.Name = "textBoxSegwitCompressed";
            this.textBoxSegwitCompressed.Size = new System.Drawing.Size(338, 20);
            this.textBoxSegwitCompressed.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Legacy Address";
            // 
            // textBoxLegacyCompressed
            // 
            this.textBoxLegacyCompressed.Location = new System.Drawing.Point(6, 75);
            this.textBoxLegacyCompressed.Name = "textBoxLegacyCompressed";
            this.textBoxLegacyCompressed.Size = new System.Drawing.Size(338, 20);
            this.textBoxLegacyCompressed.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PrivateKey";
            // 
            // textBoxPrivateKeyCompressed
            // 
            this.textBoxPrivateKeyCompressed.Location = new System.Drawing.Point(6, 32);
            this.textBoxPrivateKeyCompressed.Name = "textBoxPrivateKeyCompressed";
            this.textBoxPrivateKeyCompressed.Size = new System.Drawing.Size(368, 20);
            this.textBoxPrivateKeyCompressed.TabIndex = 0;
            // 
            // buttonLegacyBalanceUnCompressed
            // 
            this.buttonLegacyBalanceUnCompressed.FlatAppearance.BorderSize = 0;
            this.buttonLegacyBalanceUnCompressed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLegacyBalanceUnCompressed.Image = global::BitCraft.Properties.Resources.icons8_bitcoin_money_digital_wallet_logotype_of_mobile_application_24;
            this.buttonLegacyBalanceUnCompressed.Location = new System.Drawing.Point(347, 72);
            this.buttonLegacyBalanceUnCompressed.Name = "buttonLegacyBalanceUnCompressed";
            this.buttonLegacyBalanceUnCompressed.Size = new System.Drawing.Size(25, 25);
            this.buttonLegacyBalanceUnCompressed.TabIndex = 8;
            this.toolTip1.SetToolTip(this.buttonLegacyBalanceUnCompressed, "проверить баланс");
            this.buttonLegacyBalanceUnCompressed.UseVisualStyleBackColor = true;
            this.buttonLegacyBalanceUnCompressed.Click += new System.EventHandler(this.buttonLegacyBalanceUnCompressed_Click);
            // 
            // buttonSegwitP2SHBalanceCompressed
            // 
            this.buttonSegwitP2SHBalanceCompressed.FlatAppearance.BorderSize = 0;
            this.buttonSegwitP2SHBalanceCompressed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSegwitP2SHBalanceCompressed.Image = global::BitCraft.Properties.Resources.icons8_bitcoin_money_digital_wallet_logotype_of_mobile_application_24;
            this.buttonSegwitP2SHBalanceCompressed.Location = new System.Drawing.Point(347, 165);
            this.buttonSegwitP2SHBalanceCompressed.Name = "buttonSegwitP2SHBalanceCompressed";
            this.buttonSegwitP2SHBalanceCompressed.Size = new System.Drawing.Size(25, 25);
            this.buttonSegwitP2SHBalanceCompressed.TabIndex = 9;
            this.toolTip1.SetToolTip(this.buttonSegwitP2SHBalanceCompressed, "проверить баланс");
            this.buttonSegwitP2SHBalanceCompressed.UseVisualStyleBackColor = true;
            this.buttonSegwitP2SHBalanceCompressed.Click += new System.EventHandler(this.buttonSegwitBalanceUnCompressed_Click);
            // 
            // textBoxPrivateKeyUnCompressed
            // 
            this.textBoxPrivateKeyUnCompressed.Location = new System.Drawing.Point(6, 32);
            this.textBoxPrivateKeyUnCompressed.Name = "textBoxPrivateKeyUnCompressed";
            this.textBoxPrivateKeyUnCompressed.Size = new System.Drawing.Size(368, 20);
            this.textBoxPrivateKeyUnCompressed.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "PrivateKey";
            // 
            // textBoxLegacyUnCompressed
            // 
            this.textBoxLegacyUnCompressed.Location = new System.Drawing.Point(6, 75);
            this.textBoxLegacyUnCompressed.Name = "textBoxLegacyUnCompressed";
            this.textBoxLegacyUnCompressed.Size = new System.Drawing.Size(338, 20);
            this.textBoxLegacyUnCompressed.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Legacy Address";
            // 
            // textBoxSegwitP2SHCompressed
            // 
            this.textBoxSegwitP2SHCompressed.Location = new System.Drawing.Point(6, 168);
            this.textBoxSegwitP2SHCompressed.Name = "textBoxSegwitP2SHCompressed";
            this.textBoxSegwitP2SHCompressed.Size = new System.Drawing.Size(338, 20);
            this.textBoxSegwitP2SHCompressed.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Segwit P2SH Address";
            // 
            // groupBoxUnCompressed
            // 
            this.groupBoxUnCompressed.Controls.Add(this.buttonLegacyBalanceUnCompressed);
            this.groupBoxUnCompressed.Controls.Add(this.label7);
            this.groupBoxUnCompressed.Controls.Add(this.textBoxLegacyUnCompressed);
            this.groupBoxUnCompressed.Controls.Add(this.label8);
            this.groupBoxUnCompressed.Controls.Add(this.textBoxPrivateKeyUnCompressed);
            this.groupBoxUnCompressed.Location = new System.Drawing.Point(0, 225);
            this.groupBoxUnCompressed.Name = "groupBoxUnCompressed";
            this.groupBoxUnCompressed.Size = new System.Drawing.Size(381, 107);
            this.groupBoxUnCompressed.TabIndex = 12;
            this.groupBoxUnCompressed.TabStop = false;
            this.groupBoxUnCompressed.Text = "Bitcoin Un Compressed";
            // 
            // BitcoinItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxUnCompressed);
            this.Controls.Add(this.groupBoxCompressed);
            this.Name = "BitcoinItem";
            this.Size = new System.Drawing.Size(388, 341);
            this.groupBoxCompressed.ResumeLayout(false);
            this.groupBoxCompressed.PerformLayout();
            this.groupBoxUnCompressed.ResumeLayout(false);
            this.groupBoxUnCompressed.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCompressed;
        private System.Windows.Forms.Button buttonLegacyBalanceCompressed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSegwitCompressed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLegacyCompressed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPrivateKeyCompressed;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonSegwitBalanceCompressed;
        private System.Windows.Forms.TextBox textBoxPrivateKeyUnCompressed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxLegacyUnCompressed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSegwitP2SHCompressed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonLegacyBalanceUnCompressed;
        private System.Windows.Forms.Button buttonSegwitP2SHBalanceCompressed;
        private System.Windows.Forms.GroupBox groupBoxUnCompressed;
    }
}
