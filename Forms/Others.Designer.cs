
namespace BitCraft.Forms
{
    partial class Others
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
            this.buttonToAddress = new System.Windows.Forms.Button();
            this.textBoxRipemde160 = new System.Windows.Forms.TextBox();
            this.buttonConvertToRipemde160 = new System.Windows.Forms.Button();
            this.textBoxBtcAddress = new System.Windows.Forms.TextBox();
            this.textBoxToAddress = new System.Windows.Forms.TextBox();
            this.groupBoxCompressed = new System.Windows.Forms.GroupBox();
            this.buttonSegwitP2SHBalance = new System.Windows.Forms.Button();
            this.buttonSegwitBalance = new System.Windows.Forms.Button();
            this.buttonLegacyBalance = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSegwitP2SH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSegwit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLegacy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPrivateKey = new System.Windows.Forms.TextBox();
            this.groupBoxCompressed.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonToAddress
            // 
            this.buttonToAddress.Location = new System.Drawing.Point(534, 94);
            this.buttonToAddress.Name = "buttonToAddress";
            this.buttonToAddress.Size = new System.Drawing.Size(96, 23);
            this.buttonToAddress.TabIndex = 9;
            this.buttonToAddress.Text = "ToAddress";
            this.buttonToAddress.UseVisualStyleBackColor = true;
            this.buttonToAddress.Click += new System.EventHandler(this.buttonToAddress_Click);
            // 
            // textBoxRipemde160
            // 
            this.textBoxRipemde160.Location = new System.Drawing.Point(410, 68);
            this.textBoxRipemde160.Name = "textBoxRipemde160";
            this.textBoxRipemde160.Size = new System.Drawing.Size(382, 20);
            this.textBoxRipemde160.TabIndex = 8;
            this.textBoxRipemde160.Text = "880e219b6bb9720d1fed4ded0feda5f458dd9748";
            // 
            // buttonConvertToRipemde160
            // 
            this.buttonConvertToRipemde160.Location = new System.Drawing.Point(534, 39);
            this.buttonConvertToRipemde160.Name = "buttonConvertToRipemde160";
            this.buttonConvertToRipemde160.Size = new System.Drawing.Size(108, 23);
            this.buttonConvertToRipemde160.TabIndex = 7;
            this.buttonConvertToRipemde160.Text = "ToRipemde160";
            this.buttonConvertToRipemde160.UseVisualStyleBackColor = true;
            this.buttonConvertToRipemde160.Click += new System.EventHandler(this.buttonConvertToRipemde160_Click);
            // 
            // textBoxBtcAddress
            // 
            this.textBoxBtcAddress.Location = new System.Drawing.Point(410, 13);
            this.textBoxBtcAddress.Name = "textBoxBtcAddress";
            this.textBoxBtcAddress.Size = new System.Drawing.Size(382, 20);
            this.textBoxBtcAddress.TabIndex = 6;
            this.textBoxBtcAddress.Text = "bc1q3q8zrxmth9eq68ldfhkslmd973vdm96gg8h02v";
            // 
            // textBoxToAddress
            // 
            this.textBoxToAddress.Location = new System.Drawing.Point(410, 133);
            this.textBoxToAddress.Name = "textBoxToAddress";
            this.textBoxToAddress.Size = new System.Drawing.Size(382, 20);
            this.textBoxToAddress.TabIndex = 10;
            // 
            // groupBoxCompressed
            // 
            this.groupBoxCompressed.Controls.Add(this.buttonSegwitP2SHBalance);
            this.groupBoxCompressed.Controls.Add(this.buttonSegwitBalance);
            this.groupBoxCompressed.Controls.Add(this.buttonLegacyBalance);
            this.groupBoxCompressed.Controls.Add(this.label4);
            this.groupBoxCompressed.Controls.Add(this.textBoxSegwitP2SH);
            this.groupBoxCompressed.Controls.Add(this.label3);
            this.groupBoxCompressed.Controls.Add(this.textBoxSegwit);
            this.groupBoxCompressed.Controls.Add(this.label2);
            this.groupBoxCompressed.Controls.Add(this.textBoxLegacy);
            this.groupBoxCompressed.Controls.Add(this.label1);
            this.groupBoxCompressed.Controls.Add(this.textBoxPrivateKey);
            this.groupBoxCompressed.Location = new System.Drawing.Point(12, 94);
            this.groupBoxCompressed.Name = "groupBoxCompressed";
            this.groupBoxCompressed.Size = new System.Drawing.Size(357, 226);
            this.groupBoxCompressed.TabIndex = 11;
            this.groupBoxCompressed.TabStop = false;
            this.groupBoxCompressed.Text = "Bitcoin Compressed";
            // 
            // buttonSegwitP2SHBalance
            // 
            this.buttonSegwitP2SHBalance.FlatAppearance.BorderSize = 0;
            this.buttonSegwitP2SHBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSegwitP2SHBalance.Image = global::BitCraft.Properties.Resources.icons8_bitcoin_money_digital_wallet_logotype_of_mobile_application_24;
            this.buttonSegwitP2SHBalance.Location = new System.Drawing.Point(346, 161);
            this.buttonSegwitP2SHBalance.Name = "buttonSegwitP2SHBalance";
            this.buttonSegwitP2SHBalance.Size = new System.Drawing.Size(25, 25);
            this.buttonSegwitP2SHBalance.TabIndex = 10;
            this.buttonSegwitP2SHBalance.Text = "button1";
            this.buttonSegwitP2SHBalance.UseVisualStyleBackColor = true;
            // 
            // buttonSegwitBalance
            // 
            this.buttonSegwitBalance.FlatAppearance.BorderSize = 0;
            this.buttonSegwitBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSegwitBalance.Image = global::BitCraft.Properties.Resources.icons8_bitcoin_money_digital_wallet_logotype_of_mobile_application_24;
            this.buttonSegwitBalance.Location = new System.Drawing.Point(345, 117);
            this.buttonSegwitBalance.Name = "buttonSegwitBalance";
            this.buttonSegwitBalance.Size = new System.Drawing.Size(25, 25);
            this.buttonSegwitBalance.TabIndex = 9;
            this.buttonSegwitBalance.Text = "button1";
            this.buttonSegwitBalance.UseVisualStyleBackColor = true;
            // 
            // buttonLegacyBalance
            // 
            this.buttonLegacyBalance.FlatAppearance.BorderSize = 0;
            this.buttonLegacyBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLegacyBalance.Image = global::BitCraft.Properties.Resources.icons8_биткоин_32;
            this.buttonLegacyBalance.Location = new System.Drawing.Point(346, 72);
            this.buttonLegacyBalance.Name = "buttonLegacyBalance";
            this.buttonLegacyBalance.Size = new System.Drawing.Size(25, 25);
            this.buttonLegacyBalance.TabIndex = 8;
            this.buttonLegacyBalance.Text = "button1";
            this.buttonLegacyBalance.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "SegwitP2SH Address";
            // 
            // textBoxSegwitP2SH
            // 
            this.textBoxSegwitP2SH.Location = new System.Drawing.Point(3, 164);
            this.textBoxSegwitP2SH.Name = "textBoxSegwitP2SH";
            this.textBoxSegwitP2SH.Size = new System.Drawing.Size(338, 20);
            this.textBoxSegwitP2SH.TabIndex = 6;
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
            // textBoxSegwit
            // 
            this.textBoxSegwit.Location = new System.Drawing.Point(3, 120);
            this.textBoxSegwit.Name = "textBoxSegwit";
            this.textBoxSegwit.Size = new System.Drawing.Size(338, 20);
            this.textBoxSegwit.TabIndex = 4;
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
            // textBoxLegacy
            // 
            this.textBoxLegacy.Location = new System.Drawing.Point(3, 75);
            this.textBoxLegacy.Name = "textBoxLegacy";
            this.textBoxLegacy.Size = new System.Drawing.Size(338, 20);
            this.textBoxLegacy.TabIndex = 2;
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
            // textBoxPrivateKey
            // 
            this.textBoxPrivateKey.Location = new System.Drawing.Point(3, 32);
            this.textBoxPrivateKey.Name = "textBoxPrivateKey";
            this.textBoxPrivateKey.Size = new System.Drawing.Size(338, 20);
            this.textBoxPrivateKey.TabIndex = 0;
            // 
            // Others
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxCompressed);
            this.Controls.Add(this.textBoxToAddress);
            this.Controls.Add(this.buttonToAddress);
            this.Controls.Add(this.textBoxRipemde160);
            this.Controls.Add(this.buttonConvertToRipemde160);
            this.Controls.Add(this.textBoxBtcAddress);
            this.Name = "Others";
            this.Text = "Others";
            this.groupBoxCompressed.ResumeLayout(false);
            this.groupBoxCompressed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonToAddress;
        private System.Windows.Forms.TextBox textBoxRipemde160;
        private System.Windows.Forms.Button buttonConvertToRipemde160;
        private System.Windows.Forms.TextBox textBoxBtcAddress;
        private System.Windows.Forms.TextBox textBoxToAddress;
        private System.Windows.Forms.GroupBox groupBoxCompressed;
        private System.Windows.Forms.Button buttonSegwitP2SHBalance;
        private System.Windows.Forms.Button buttonSegwitBalance;
        private System.Windows.Forms.Button buttonLegacyBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSegwitP2SH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSegwit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLegacy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPrivateKey;
    }
}