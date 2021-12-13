
namespace LifeGame
{
    partial class ProgramWindow
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
            this.components = new System.ComponentModel.Container();
            this.DeadToAliveCheckBox = new System.Windows.Forms.CheckedListBox();
            this.SettingsAndGameSeparator = new System.Windows.Forms.SplitContainer();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.defaultRulesButton = new System.Windows.Forms.Button();
            this.AliveToDeadCheckBox = new System.Windows.Forms.CheckedListBox();
            this.fromDeadToAlive = new System.Windows.Forms.Label();
            this.fromAliveToDead = new System.Windows.Forms.Label();
            this.rules = new System.Windows.Forms.Label();
            this.PlayingField = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SettingsAndGameSeparator)).BeginInit();
            this.SettingsAndGameSeparator.Panel1.SuspendLayout();
            this.SettingsAndGameSeparator.Panel2.SuspendLayout();
            this.SettingsAndGameSeparator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayingField)).BeginInit();
            this.SuspendLayout();
            // 
            // DeadToAliveCheckBox
            // 
            this.DeadToAliveCheckBox.CheckOnClick = true;
            this.DeadToAliveCheckBox.ColumnWidth = 120;
            this.DeadToAliveCheckBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeadToAliveCheckBox.FormattingEnabled = true;
            this.DeadToAliveCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DeadToAliveCheckBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.DeadToAliveCheckBox.Location = new System.Drawing.Point(22, 318);
            this.DeadToAliveCheckBox.MultiColumn = true;
            this.DeadToAliveCheckBox.Name = "DeadToAliveCheckBox";
            this.DeadToAliveCheckBox.Size = new System.Drawing.Size(248, 128);
            this.DeadToAliveCheckBox.TabIndex = 3;
            this.DeadToAliveCheckBox.TabStop = false;
            this.DeadToAliveCheckBox.UseTabStops = false;
            // 
            // SettingsAndGameSeparator
            // 
            this.SettingsAndGameSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SettingsAndGameSeparator.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SettingsAndGameSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsAndGameSeparator.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SettingsAndGameSeparator.IsSplitterFixed = true;
            this.SettingsAndGameSeparator.Location = new System.Drawing.Point(0, 0);
            this.SettingsAndGameSeparator.Name = "SettingsAndGameSeparator";
            // 
            // SettingsAndGameSeparator.Panel1
            // 
            this.SettingsAndGameSeparator.Panel1.AccessibleName = "";
            this.SettingsAndGameSeparator.Panel1.Controls.Add(this.stopButton);
            this.SettingsAndGameSeparator.Panel1.Controls.Add(this.startButton);
            this.SettingsAndGameSeparator.Panel1.Controls.Add(this.defaultRulesButton);
            this.SettingsAndGameSeparator.Panel1.Controls.Add(this.AliveToDeadCheckBox);
            this.SettingsAndGameSeparator.Panel1.Controls.Add(this.DeadToAliveCheckBox);
            this.SettingsAndGameSeparator.Panel1.Controls.Add(this.fromDeadToAlive);
            this.SettingsAndGameSeparator.Panel1.Controls.Add(this.fromAliveToDead);
            this.SettingsAndGameSeparator.Panel1.Controls.Add(this.rules);
            // 
            // SettingsAndGameSeparator.Panel2
            // 
            this.SettingsAndGameSeparator.Panel2.Controls.Add(this.PlayingField);
            this.SettingsAndGameSeparator.Size = new System.Drawing.Size(1236, 752);
            this.SettingsAndGameSeparator.SplitterDistance = 277;
            this.SettingsAndGameSeparator.TabIndex = 0;
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopButton.Location = new System.Drawing.Point(51, 630);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(180, 63);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startButton.Location = new System.Drawing.Point(51, 549);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(180, 63);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // defaultRulesButton
            // 
            this.defaultRulesButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.defaultRulesButton.Location = new System.Drawing.Point(51, 461);
            this.defaultRulesButton.Name = "defaultRulesButton";
            this.defaultRulesButton.Size = new System.Drawing.Size(180, 55);
            this.defaultRulesButton.TabIndex = 5;
            this.defaultRulesButton.Text = "default rules";
            this.defaultRulesButton.UseVisualStyleBackColor = true;
            // 
            // AliveToDeadCheckBox
            // 
            this.AliveToDeadCheckBox.CheckOnClick = true;
            this.AliveToDeadCheckBox.ColumnWidth = 120;
            this.AliveToDeadCheckBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AliveToDeadCheckBox.FormattingEnabled = true;
            this.AliveToDeadCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AliveToDeadCheckBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.AliveToDeadCheckBox.Location = new System.Drawing.Point(22, 125);
            this.AliveToDeadCheckBox.MultiColumn = true;
            this.AliveToDeadCheckBox.Name = "AliveToDeadCheckBox";
            this.AliveToDeadCheckBox.Size = new System.Drawing.Size(248, 128);
            this.AliveToDeadCheckBox.TabIndex = 4;
            this.AliveToDeadCheckBox.TabStop = false;
            this.AliveToDeadCheckBox.UseTabStops = false;
            // 
            // fromDeadToAlive
            // 
            this.fromDeadToAlive.AutoSize = true;
            this.fromDeadToAlive.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fromDeadToAlive.Location = new System.Drawing.Point(51, 277);
            this.fromDeadToAlive.Name = "fromDeadToAlive";
            this.fromDeadToAlive.Size = new System.Drawing.Size(180, 38);
            this.fromDeadToAlive.TabIndex = 2;
            this.fromDeadToAlive.Text = "alive <- dead";
            this.fromDeadToAlive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fromAliveToDead
            // 
            this.fromAliveToDead.AutoSize = true;
            this.fromAliveToDead.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fromAliveToDead.Location = new System.Drawing.Point(51, 84);
            this.fromAliveToDead.Name = "fromAliveToDead";
            this.fromAliveToDead.Size = new System.Drawing.Size(180, 38);
            this.fromAliveToDead.TabIndex = 1;
            this.fromAliveToDead.Text = "alive -> dead";
            this.fromAliveToDead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rules
            // 
            this.rules.AutoSize = true;
            this.rules.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rules.Location = new System.Drawing.Point(84, 19);
            this.rules.Name = "rules";
            this.rules.Size = new System.Drawing.Size(105, 48);
            this.rules.TabIndex = 0;
            this.rules.Text = "Rules";
            this.rules.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayingField
            // 
            this.PlayingField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayingField.Location = new System.Drawing.Point(0, 0);
            this.PlayingField.Name = "PlayingField";
            this.PlayingField.Size = new System.Drawing.Size(951, 748);
            this.PlayingField.TabIndex = 0;
            this.PlayingField.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            // 
            // ProgramWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 752);
            this.Controls.Add(this.SettingsAndGameSeparator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProgramWindow";
            this.Text = "Life";
            this.SettingsAndGameSeparator.Panel1.ResumeLayout(false);
            this.SettingsAndGameSeparator.Panel1.PerformLayout();
            this.SettingsAndGameSeparator.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SettingsAndGameSeparator)).EndInit();
            this.SettingsAndGameSeparator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PlayingField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SettingsAndGameSeparator;
        private System.Windows.Forms.PictureBox PlayingField;
        private System.Windows.Forms.CheckedListBox DeadToAliveCheckBox;
        private System.Windows.Forms.Label fromDeadToAlive;
        private System.Windows.Forms.Label fromAliveToDead;
        private System.Windows.Forms.Label rules;
        private System.Windows.Forms.CheckedListBox AliveToDeadCheckBox;
        private System.Windows.Forms.Button defaultRulesButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Timer timer1;
    }
}

