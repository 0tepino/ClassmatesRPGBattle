using System.Drawing;
using System.Windows.Forms;
using static ClassroomBattleSimulator.ClassroomWarrior;

namespace ClassroomBattleSimulator
{
    partial class BattleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleForm));
            this.txtPlayer1Name = new System.Windows.Forms.TextBox();
            this.txtPlayer2Name = new System.Windows.Forms.TextBox();
            this.cmbPlayer1Type = new System.Windows.Forms.ComboBox();
            this.cmbPlayer2Type = new System.Windows.Forms.ComboBox();
            this.btnStartBattle = new System.Windows.Forms.Button();
            this.lstBattleLog = new System.Windows.Forms.ListBox();
            this.lblPlayer1Health = new System.Windows.Forms.Label();
            this.lblPlayer2Health = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.healthBar1 = new ClassroomBattleSimulator.ClassroomWarrior.HealthBar();
            this.healthBar2 = new ClassroomBattleSimulator.ClassroomWarrior.HealthBar();
            this.lblTurnIndicator = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPlayer1Name
            // 
            this.txtPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtPlayer1Name.Location = new System.Drawing.Point(78, 111);
            this.txtPlayer1Name.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlayer1Name.Name = "txtPlayer1Name";
            this.txtPlayer1Name.Size = new System.Drawing.Size(199, 26);
            this.txtPlayer1Name.TabIndex = 0;
            // 
            // txtPlayer2Name
            // 
            this.txtPlayer2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtPlayer2Name.Location = new System.Drawing.Point(646, 111);
            this.txtPlayer2Name.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlayer2Name.Name = "txtPlayer2Name";
            this.txtPlayer2Name.Size = new System.Drawing.Size(199, 26);
            this.txtPlayer2Name.TabIndex = 1;
            // 
            // cmbPlayer1Type
            // 
            this.cmbPlayer1Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayer1Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbPlayer1Type.FormattingEnabled = true;
            this.cmbPlayer1Type.Location = new System.Drawing.Point(78, 161);
            this.cmbPlayer1Type.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPlayer1Type.Name = "cmbPlayer1Type";
            this.cmbPlayer1Type.Size = new System.Drawing.Size(199, 28);
            this.cmbPlayer1Type.TabIndex = 2;
            // 
            // cmbPlayer2Type
            // 
            this.cmbPlayer2Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayer2Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbPlayer2Type.FormattingEnabled = true;
            this.cmbPlayer2Type.Location = new System.Drawing.Point(646, 161);
            this.cmbPlayer2Type.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPlayer2Type.Name = "cmbPlayer2Type";
            this.cmbPlayer2Type.Size = new System.Drawing.Size(199, 28);
            this.cmbPlayer2Type.TabIndex = 3;
            // 
            // btnStartBattle
            // 
            this.btnStartBattle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.btnStartBattle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartBattle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnStartBattle.ForeColor = System.Drawing.Color.White;
            this.btnStartBattle.Location = new System.Drawing.Point(374, 111);
            this.btnStartBattle.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartBattle.Name = "btnStartBattle";
            this.btnStartBattle.Size = new System.Drawing.Size(176, 74);
            this.btnStartBattle.TabIndex = 4;
            this.btnStartBattle.Text = "START BATTLE!";
            this.btnStartBattle.UseVisualStyleBackColor = false;
            this.btnStartBattle.Click += new System.EventHandler(this.btnStartBattle_Click);
            // 
            // lstBattleLog
            // 
            this.lstBattleLog.BackColor = System.Drawing.Color.Black;
            this.lstBattleLog.Enabled = false;
            this.lstBattleLog.Font = new System.Drawing.Font("Consolas", 10F);
            this.lstBattleLog.ForeColor = System.Drawing.Color.White;
            this.lstBattleLog.FormattingEnabled = true;
            this.lstBattleLog.HorizontalScrollbar = true;
            this.lstBattleLog.ItemHeight = 20;
            this.lstBattleLog.Location = new System.Drawing.Point(78, 530);
            this.lstBattleLog.Margin = new System.Windows.Forms.Padding(4);
            this.lstBattleLog.Name = "lstBattleLog";
            this.lstBattleLog.Size = new System.Drawing.Size(767, 104);
            this.lstBattleLog.TabIndex = 5;
            // 
            // lblPlayer1Health
            // 
            this.lblPlayer1Health.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer1Health.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblPlayer1Health.Location = new System.Drawing.Point(78, 228);
            this.lblPlayer1Health.Name = "lblPlayer1Health";
            this.lblPlayer1Health.Size = new System.Drawing.Size(199, 23);
            this.lblPlayer1Health.TabIndex = 6;
            this.lblPlayer1Health.Text = "100/100";
            this.lblPlayer1Health.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer2Health
            // 
            this.lblPlayer2Health.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer2Health.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblPlayer2Health.Location = new System.Drawing.Point(646, 228);
            this.lblPlayer2Health.Name = "lblPlayer2Health";
            this.lblPlayer2Health.Size = new System.Drawing.Size(199, 23);
            this.lblPlayer2Health.TabIndex = 7;
            this.lblPlayer2Health.Text = "100/100";
            this.lblPlayer2Health.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(78, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Player 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(645, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Player 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(78, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Pick Character:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(644, 141);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Pick Character:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(107, 289);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(677, 289);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(139, 120);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(78, 500);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Battle Log:";
            // 
            // lblCountdown
            // 
            this.lblCountdown.BackColor = System.Drawing.Color.Transparent;
            this.lblCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblCountdown.ForeColor = System.Drawing.Color.Red;
            this.lblCountdown.Location = new System.Drawing.Point(374, 192);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(176, 40);
            this.lblCountdown.TabIndex = 15;
            this.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCountdown.Visible = false;
            // 
            // healthBar1
            // 
            this.healthBar1.Location = new System.Drawing.Point(78, 254);
            this.healthBar1.Maximum = 100;
            this.healthBar1.Name = "healthBar1";
            this.healthBar1.Size = new System.Drawing.Size(199, 25);
            this.healthBar1.TabIndex = 16;
            this.healthBar1.Value = 100;
            // 
            // healthBar2
            // 
            this.healthBar2.Location = new System.Drawing.Point(646, 254);
            this.healthBar2.Maximum = 100;
            this.healthBar2.Name = "healthBar2";
            this.healthBar2.Size = new System.Drawing.Size(199, 25);
            this.healthBar2.TabIndex = 17;
            this.healthBar2.Value = 100;
            // 
            // lblTurnIndicator
            // 
            this.lblTurnIndicator.BackColor = System.Drawing.Color.Transparent;
            this.lblTurnIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnIndicator.ForeColor = System.Drawing.Color.Black;
            this.lblTurnIndicator.Location = new System.Drawing.Point(78, 445);
            this.lblTurnIndicator.Name = "lblTurnIndicator";
            this.lblTurnIndicator.Size = new System.Drawing.Size(767, 30);
            this.lblTurnIndicator.TabIndex = 21;
            this.lblTurnIndicator.Text = "Get ready to battle!";
            this.lblTurnIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Location = new System.Drawing.Point(0, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(923, 687);
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // BattleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(924, 685);
            this.Controls.Add(this.lblTurnIndicator);
            this.Controls.Add(this.healthBar2);
            this.Controls.Add(this.healthBar1);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPlayer2Health);
            this.Controls.Add(this.lblPlayer1Health);
            this.Controls.Add(this.lstBattleLog);
            this.Controls.Add(this.btnStartBattle);
            this.Controls.Add(this.cmbPlayer2Type);
            this.Controls.Add(this.cmbPlayer1Type);
            this.Controls.Add(this.txtPlayer2Name);
            this.Controls.Add(this.txtPlayer1Name);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BattleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Classroom Battle Simulator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlayer1Name;
        private System.Windows.Forms.TextBox txtPlayer2Name;
        private System.Windows.Forms.ComboBox cmbPlayer1Type;
        private System.Windows.Forms.ComboBox cmbPlayer2Type;
        private System.Windows.Forms.Button btnStartBattle;
        private System.Windows.Forms.ListBox lstBattleLog;
        private System.Windows.Forms.Label lblPlayer1Health;
        private System.Windows.Forms.Label lblPlayer2Health;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCountdown;
        private ClassroomBattleSimulator.ClassroomWarrior.HealthBar healthBar1;
        private ClassroomBattleSimulator.ClassroomWarrior.HealthBar healthBar2;
        private System.Windows.Forms.Label lblTurnIndicator;
        private PictureBox pictureBox3;
    }
}