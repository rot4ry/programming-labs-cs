namespace Lab8
{
    partial class MainGameWindow
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
            this.gameMapPanel = new System.Windows.Forms.Panel();
            this.gameSettingsGB = new System.Windows.Forms.GroupBox();
            this.zombiesQTB = new System.Windows.Forms.TextBox();
            this.soldiersQTB = new System.Windows.Forms.TextBox();
            this.humansQTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addCharactersButton = new System.Windows.Forms.Button();
            this.gameResetButton = new System.Windows.Forms.Button();
            this.gameControlsGB = new System.Windows.Forms.GroupBox();
            this.nextRoundButton = new System.Windows.Forms.Button();
            this.roundCounterLabel = new System.Windows.Forms.Label();
            this.gameSettingsGB.SuspendLayout();
            this.gameControlsGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameMapPanel
            // 
            this.gameMapPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gameMapPanel.BackColor = System.Drawing.Color.DarkKhaki;
            this.gameMapPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameMapPanel.Location = new System.Drawing.Point(12, 12);
            this.gameMapPanel.Name = "gameMapPanel";
            this.gameMapPanel.Size = new System.Drawing.Size(420, 420);
            this.gameMapPanel.TabIndex = 0;
            // 
            // gameSettingsGB
            // 
            this.gameSettingsGB.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.gameSettingsGB.Controls.Add(this.zombiesQTB);
            this.gameSettingsGB.Controls.Add(this.soldiersQTB);
            this.gameSettingsGB.Controls.Add(this.humansQTB);
            this.gameSettingsGB.Controls.Add(this.label3);
            this.gameSettingsGB.Controls.Add(this.label2);
            this.gameSettingsGB.Controls.Add(this.label1);
            this.gameSettingsGB.Controls.Add(this.addCharactersButton);
            this.gameSettingsGB.Controls.Add(this.gameResetButton);
            this.gameSettingsGB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameSettingsGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.gameSettingsGB.ForeColor = System.Drawing.Color.IndianRed;
            this.gameSettingsGB.Location = new System.Drawing.Point(439, 13);
            this.gameSettingsGB.Name = "gameSettingsGB";
            this.gameSettingsGB.Size = new System.Drawing.Size(349, 305);
            this.gameSettingsGB.TabIndex = 1;
            this.gameSettingsGB.TabStop = false;
            this.gameSettingsGB.Text = "Game settings";
            // 
            // zombiesQTB
            // 
            this.zombiesQTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zombiesQTB.Location = new System.Drawing.Point(10, 224);
            this.zombiesQTB.MinimumSize = new System.Drawing.Size(156, 59);
            this.zombiesQTB.Name = "zombiesQTB";
            this.zombiesQTB.Size = new System.Drawing.Size(156, 62);
            this.zombiesQTB.TabIndex = 7;
            this.zombiesQTB.Text = "0";
            this.zombiesQTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // soldiersQTB
            // 
            this.soldiersQTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soldiersQTB.Location = new System.Drawing.Point(10, 139);
            this.soldiersQTB.MinimumSize = new System.Drawing.Size(156, 59);
            this.soldiersQTB.Name = "soldiersQTB";
            this.soldiersQTB.Size = new System.Drawing.Size(156, 62);
            this.soldiersQTB.TabIndex = 6;
            this.soldiersQTB.Text = "0";
            this.soldiersQTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // humansQTB
            // 
            this.humansQTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.humansQTB.Location = new System.Drawing.Point(10, 54);
            this.humansQTB.MinimumSize = new System.Drawing.Size(156, 59);
            this.humansQTB.Name = "humansQTB";
            this.humansQTB.Size = new System.Drawing.Size(156, 62);
            this.humansQTB.TabIndex = 5;
            this.humansQTB.Text = "0";
            this.humansQTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightGreen;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(6, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Amount of zombies";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightGreen;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(6, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Amount of soldiers";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGreen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Amount of humans";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addCharactersButton
            // 
            this.addCharactersButton.BackColor = System.Drawing.Color.OldLace;
            this.addCharactersButton.ForeColor = System.Drawing.Color.Firebrick;
            this.addCharactersButton.Location = new System.Drawing.Point(194, 31);
            this.addCharactersButton.Name = "addCharactersButton";
            this.addCharactersButton.Size = new System.Drawing.Size(149, 58);
            this.addCharactersButton.TabIndex = 1;
            this.addCharactersButton.Text = "Add characters";
            this.addCharactersButton.UseVisualStyleBackColor = false;
            this.addCharactersButton.Click += new System.EventHandler(this.addCharactersButton_Click);
            // 
            // gameResetButton
            // 
            this.gameResetButton.BackColor = System.Drawing.Color.OldLace;
            this.gameResetButton.ForeColor = System.Drawing.Color.Firebrick;
            this.gameResetButton.Location = new System.Drawing.Point(194, 95);
            this.gameResetButton.Name = "gameResetButton";
            this.gameResetButton.Size = new System.Drawing.Size(149, 58);
            this.gameResetButton.TabIndex = 0;
            this.gameResetButton.Text = "Reset";
            this.gameResetButton.UseVisualStyleBackColor = false;
            this.gameResetButton.Click += new System.EventHandler(this.gameResetButton_Click);
            // 
            // gameControlsGB
            // 
            this.gameControlsGB.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.gameControlsGB.Controls.Add(this.roundCounterLabel);
            this.gameControlsGB.Controls.Add(this.nextRoundButton);
            this.gameControlsGB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameControlsGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameControlsGB.ForeColor = System.Drawing.Color.IndianRed;
            this.gameControlsGB.Location = new System.Drawing.Point(439, 324);
            this.gameControlsGB.Name = "gameControlsGB";
            this.gameControlsGB.Size = new System.Drawing.Size(349, 106);
            this.gameControlsGB.TabIndex = 2;
            this.gameControlsGB.TabStop = false;
            this.gameControlsGB.Text = "Game controls";
            // 
            // nextRoundButton
            // 
            this.nextRoundButton.BackColor = System.Drawing.Color.OldLace;
            this.nextRoundButton.ForeColor = System.Drawing.Color.Firebrick;
            this.nextRoundButton.Location = new System.Drawing.Point(10, 25);
            this.nextRoundButton.Name = "nextRoundButton";
            this.nextRoundButton.Size = new System.Drawing.Size(149, 58);
            this.nextRoundButton.TabIndex = 0;
            this.nextRoundButton.Text = "Next round";
            this.nextRoundButton.UseVisualStyleBackColor = false;
            this.nextRoundButton.Click += new System.EventHandler(this.nextRoundButton_Click);
            // 
            // roundCounterLabel
            // 
            this.roundCounterLabel.BackColor = System.Drawing.Color.FloralWhite;
            this.roundCounterLabel.Location = new System.Drawing.Point(194, 25);
            this.roundCounterLabel.Name = "roundCounterLabel";
            this.roundCounterLabel.Size = new System.Drawing.Size(149, 58);
            this.roundCounterLabel.TabIndex = 1;
            this.roundCounterLabel.Text = "0";
            this.roundCounterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(800, 442);
            this.Controls.Add(this.gameControlsGB);
            this.Controls.Add(this.gameSettingsGB);
            this.Controls.Add(this.gameMapPanel);
            this.Name = "MainGameWindow";
            this.Text = "Stayed4Dead";
            this.Load += new System.EventHandler(this.MainGameWindow_Load);
            this.gameSettingsGB.ResumeLayout(false);
            this.gameSettingsGB.PerformLayout();
            this.gameControlsGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gameMapPanel;
        private System.Windows.Forms.GroupBox gameSettingsGB;
        private System.Windows.Forms.GroupBox gameControlsGB;
        private System.Windows.Forms.Button addCharactersButton;
        private System.Windows.Forms.Button gameResetButton;
        private System.Windows.Forms.Button nextRoundButton;
        private System.Windows.Forms.TextBox zombiesQTB;
        private System.Windows.Forms.TextBox soldiersQTB;
        private System.Windows.Forms.TextBox humansQTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label roundCounterLabel;
    }
}

