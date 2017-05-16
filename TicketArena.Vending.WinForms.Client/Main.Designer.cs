namespace TicketArena.Vending.WinForms.Client
{
    partial class Main
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCandy = new System.Windows.Forms.RadioButton();
            this.rbChips = new System.Windows.Forms.RadioButton();
            this.rbCola = new System.Windows.Forms.RadioButton();
            this.gbCoins = new System.Windows.Forms.GroupBox();
            this.rbDummyCoin = new System.Windows.Forms.RadioButton();
            this.rbDollar = new System.Windows.Forms.RadioButton();
            this.rbHalfDollar = new System.Windows.Forms.RadioButton();
            this.rbQuarter = new System.Windows.Forms.RadioButton();
            this.rbDime = new System.Windows.Forms.RadioButton();
            this.rbNickel = new System.Windows.Forms.RadioButton();
            this.btnAddCoin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.rtbEvents = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbCoins.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCandy);
            this.groupBox1.Controls.Add(this.rbChips);
            this.groupBox1.Controls.Add(this.rbCola);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available products";
            // 
            // rbCandy
            // 
            this.rbCandy.AutoSize = true;
            this.rbCandy.Location = new System.Drawing.Point(36, 100);
            this.rbCandy.Name = "rbCandy";
            this.rbCandy.Size = new System.Drawing.Size(85, 17);
            this.rbCandy.TabIndex = 1;
            this.rbCandy.TabStop = true;
            this.rbCandy.Tag = "0.65";
            this.rbCandy.Text = "Candy $0.65";
            this.rbCandy.UseVisualStyleBackColor = true;
            this.rbCandy.CheckedChanged += new System.EventHandler(this.rbCandy_CheckedChanged);
            // 
            // rbChips
            // 
            this.rbChips.AutoSize = true;
            this.rbChips.Location = new System.Drawing.Point(36, 67);
            this.rbChips.Name = "rbChips";
            this.rbChips.Size = new System.Drawing.Size(81, 17);
            this.rbChips.TabIndex = 1;
            this.rbChips.TabStop = true;
            this.rbChips.Tag = "0.50";
            this.rbChips.Text = "Chips $0.50";
            this.rbChips.UseVisualStyleBackColor = true;
            this.rbChips.CheckedChanged += new System.EventHandler(this.rbChips_CheckedChanged);
            // 
            // rbCola
            // 
            this.rbCola.AutoSize = true;
            this.rbCola.Location = new System.Drawing.Point(36, 34);
            this.rbCola.Name = "rbCola";
            this.rbCola.Size = new System.Drawing.Size(76, 17);
            this.rbCola.TabIndex = 0;
            this.rbCola.TabStop = true;
            this.rbCola.Tag = "1.00";
            this.rbCola.Text = "Cola $1.00";
            this.rbCola.UseVisualStyleBackColor = true;
            this.rbCola.CheckedChanged += new System.EventHandler(this.rbCola_CheckedChanged);
            // 
            // gbCoins
            // 
            this.gbCoins.Controls.Add(this.rbDummyCoin);
            this.gbCoins.Controls.Add(this.rbDollar);
            this.gbCoins.Controls.Add(this.rbHalfDollar);
            this.gbCoins.Controls.Add(this.rbQuarter);
            this.gbCoins.Controls.Add(this.rbDime);
            this.gbCoins.Controls.Add(this.rbNickel);
            this.gbCoins.Location = new System.Drawing.Point(12, 218);
            this.gbCoins.Name = "gbCoins";
            this.gbCoins.Size = new System.Drawing.Size(406, 107);
            this.gbCoins.TabIndex = 1;
            this.gbCoins.TabStop = false;
            this.gbCoins.Text = "Coins simulator";
            // 
            // rbDummyCoin
            // 
            this.rbDummyCoin.AutoSize = true;
            this.rbDummyCoin.Location = new System.Drawing.Point(260, 58);
            this.rbDummyCoin.Name = "rbDummyCoin";
            this.rbDummyCoin.Size = new System.Drawing.Size(83, 17);
            this.rbDummyCoin.TabIndex = 3;
            this.rbDummyCoin.Text = "Dummy coin";
            this.rbDummyCoin.UseVisualStyleBackColor = true;
            // 
            // rbDollar
            // 
            this.rbDollar.AutoSize = true;
            this.rbDollar.Location = new System.Drawing.Point(260, 35);
            this.rbDollar.Name = "rbDollar";
            this.rbDollar.Size = new System.Drawing.Size(82, 17);
            this.rbDollar.TabIndex = 3;
            this.rbDollar.Text = "Dollar (1.00)";
            this.rbDollar.UseVisualStyleBackColor = true;
            // 
            // rbHalfDollar
            // 
            this.rbHalfDollar.AutoSize = true;
            this.rbHalfDollar.Location = new System.Drawing.Point(134, 58);
            this.rbHalfDollar.Name = "rbHalfDollar";
            this.rbHalfDollar.Size = new System.Drawing.Size(110, 17);
            this.rbHalfDollar.TabIndex = 3;
            this.rbHalfDollar.Text = "Half Dollar (0.50c)";
            this.rbHalfDollar.UseVisualStyleBackColor = true;
            // 
            // rbQuarter
            // 
            this.rbQuarter.AutoSize = true;
            this.rbQuarter.Location = new System.Drawing.Point(134, 35);
            this.rbQuarter.Name = "rbQuarter";
            this.rbQuarter.Size = new System.Drawing.Size(96, 17);
            this.rbQuarter.TabIndex = 3;
            this.rbQuarter.Text = "Quarter (0.25c)";
            this.rbQuarter.UseVisualStyleBackColor = true;
            // 
            // rbDime
            // 
            this.rbDime.AutoSize = true;
            this.rbDime.Location = new System.Drawing.Point(27, 58);
            this.rbDime.Name = "rbDime";
            this.rbDime.Size = new System.Drawing.Size(85, 17);
            this.rbDime.TabIndex = 3;
            this.rbDime.Text = "Dime (0.10c)";
            this.rbDime.UseVisualStyleBackColor = true;
            // 
            // rbNickel
            // 
            this.rbNickel.AutoSize = true;
            this.rbNickel.Checked = true;
            this.rbNickel.Location = new System.Drawing.Point(27, 35);
            this.rbNickel.Name = "rbNickel";
            this.rbNickel.Size = new System.Drawing.Size(91, 17);
            this.rbNickel.TabIndex = 3;
            this.rbNickel.TabStop = true;
            this.rbNickel.Text = "Nickel (0.05c)";
            this.rbNickel.UseVisualStyleBackColor = true;
            // 
            // btnAddCoin
            // 
            this.btnAddCoin.Location = new System.Drawing.Point(424, 225);
            this.btnAddCoin.Name = "btnAddCoin";
            this.btnAddCoin.Size = new System.Drawing.Size(75, 23);
            this.btnAddCoin.TabIndex = 0;
            this.btnAddCoin.Text = "Add coin";
            this.btnAddCoin.UseVisualStyleBackColor = true;
            this.btnAddCoin.Click += new System.EventHandler(this.btnAddCoin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Display:";
            // 
            // lblDisplay
            // 
            this.lblDisplay.Location = new System.Drawing.Point(72, 177);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(242, 13);
            this.lblDisplay.TabIndex = 5;
            this.lblDisplay.Text = "INSERT COIN";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(424, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 73);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Return coin(s)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Amount:$";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(390, 178);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(28, 13);
            this.lblAmount.TabIndex = 7;
            this.lblAmount.Text = "0.00";
            // 
            // rtbEvents
            // 
            this.rtbEvents.Location = new System.Drawing.Point(12, 360);
            this.rtbEvents.Name = "rtbEvents";
            this.rtbEvents.Size = new System.Drawing.Size(487, 238);
            this.rtbEvents.TabIndex = 8;
            this.rtbEvents.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Events and coin return:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 610);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbEvents);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDisplay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbCoins);
            this.Controls.Add(this.btnAddCoin);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(527, 470);
            this.Name = "Main";
            this.Text = "Vending Machine Simulator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbCoins.ResumeLayout(false);
            this.gbCoins.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCandy;
        private System.Windows.Forms.RadioButton rbChips;
        private System.Windows.Forms.RadioButton rbCola;
        private System.Windows.Forms.GroupBox gbCoins;
        private System.Windows.Forms.Button btnAddCoin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbDummyCoin;
        private System.Windows.Forms.RadioButton rbDollar;
        private System.Windows.Forms.RadioButton rbHalfDollar;
        private System.Windows.Forms.RadioButton rbQuarter;
        private System.Windows.Forms.RadioButton rbDime;
        private System.Windows.Forms.RadioButton rbNickel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.RichTextBox rtbEvents;
        private System.Windows.Forms.Label label2;
    }
}

