using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassroomBattleSimulator
{
    public partial class BattleForm : Form
    {
        private ClassroomWarrior warrior1;
        private ClassroomWarrior warrior2;
        private Timer animationTimer;
        private bool isAnimating = false;
        private string currentAttackText = "";
        private int animationStep = 0;
        private bool isPlayer1Turn = true;
        private bool battleActive = false;

        private int player1OriginalX;
        private int player2OriginalX;
        private int player1CurrentX;
        private int player2CurrentX;
        private bool isMoving = false;
        private bool isReturning = false;
        private ClassroomWarrior currentAttacker = null;

        private bool warrior1IsHit = false;
        private bool warrior2IsHit = false;
        private Timer hitEffectTimer;

        private readonly Dictionary<string, Color> characterColors = new Dictionary<string, Color>
        {
            {"Nemo", Color.FromArgb(0, 100, 139)},      
            {"Onay", Color.FromArgb(184, 134, 11)},     
            {"Momo", Color.FromArgb(139, 0, 0)},        
            {"Ja", Color.FromArgb(72, 61, 139)},        
            {"Lilet", Color.FromArgb(34, 139, 34)}      
        };

        public BattleForm()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.DoubleBuffer |
                         ControlStyles.SupportsTransparentBackColor, true);
            this.DoubleBuffered = true;

            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox1.Parent = this;
            pictureBox2.Parent = this;
            pictureBox1.BringToFront();
            pictureBox2.BringToFront();

            SetupCharacterSelection();
            UpdateHealthDisplays();
            InitializeAnimationTimer();
            InitializeHitEffectTimer();
            UpdateTurnIndicator();
            InitializeMovementPositions();

            this.KeyPreview = true;
            this.KeyDown += BattleForm_KeyDown;
        }

        private void InitializeMovementPositions()
        {
            player1OriginalX = pictureBox1.Location.X;
            player2OriginalX = pictureBox2.Location.X;
            player1CurrentX = player1OriginalX;
            player2CurrentX = player2OriginalX;
        }

        private void InitializeHitEffectTimer()
        {
            hitEffectTimer = new Timer();
            hitEffectTimer.Interval = 300; 
            hitEffectTimer.Tick += HitEffectTimer_Tick;
        }

        private void HitEffectTimer_Tick(object sender, EventArgs e)
        {
            warrior1IsHit = false;
            warrior2IsHit = false;
            hitEffectTimer.Stop();

            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
        }

        private void BattleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!battleActive || isAnimating || isMoving) return;

            if (isPlayer1Turn && (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter))
            {
                PerformAttack(warrior1, warrior2);
            }
            else if (!isPlayer1Turn && (e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D ||
                     e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down))
            {
                PerformAttack(warrior2, warrior1);
            }
        }

        private async void PerformAttack(ClassroomWarrior attacker, ClassroomWarrior defender)
        {
            if (isAnimating || isMoving) return;

            currentAttacker = attacker;
            await AnimateMovement(attacker);

            int damage = attacker.Attack();
            string attackName = attacker.GetAttackName();

            currentAttackText = attackName.ToUpper();
            isAnimating = true;
            animationStep = 0;
            animationTimer.Start();

            await Task.Delay(800);

            defender.TakeDamage(damage);
            lstBattleLog.Items.Add($"{attacker.Name} attacks with {attackName}! {damage} damage to {defender.Name}.");
            UpdateHealthDisplays();

            if (defender == warrior1)
                warrior1IsHit = true;
            else
                warrior2IsHit = true;

            hitEffectTimer.Start();

            await AnimateReturn(attacker);
            this.Invalidate();

            lstBattleLog.TopIndex = lstBattleLog.Items.Count - 1;

            if (defender.IsDefeated)
            {
                EndBattle(attacker);
                return;
            }

            isPlayer1Turn = !isPlayer1Turn;
            UpdateTurnIndicator();
        }

        private void EndBattle(ClassroomWarrior winner)
        {
            battleActive = false;
            lstBattleLog.Items.Add($"--- {winner.Name} WINS! ---");
            lblTurnIndicator.Text = "GAME OVER!";
            lblTurnIndicator.ForeColor = Color.Red;
            MessageBox.Show($"{winner.Name} is the Winner!", "Battle Over",
                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            btnStartBattle.Enabled = true;
            EnableCharacterSelection(true);
        }

        private async Task AnimateMovement(ClassroomWarrior attacker)
        {
            isMoving = true;
            int moveSteps = 12;
            int attackDistance = 40;

            int originalY1 = pictureBox1.Top;
            int originalY2 = pictureBox2.Top;

            int centerX = (player1OriginalX + player2OriginalX) / 2;
            int player1TargetX = centerX - attackDistance;
            int player2TargetX = centerX + attackDistance;

            if (attacker == warrior1)
                pictureBox1.BringToFront();
            else
                pictureBox2.BringToFront();

            for (int i = 0; i < moveSteps; i++)
            {
                float progress = (float)i / moveSteps;

                player1CurrentX = (int)Lerp(player1OriginalX, player1TargetX, progress);
                player2CurrentX = (int)Lerp(player2OriginalX, player2TargetX, progress);

                pictureBox1.Location = new Point(player1CurrentX, originalY1);
                pictureBox2.Location = new Point(player2CurrentX, originalY2);

                int shake = (i % 2 == 0) ? 2 : -2;
                pictureBox1.Left += shake;
                pictureBox2.Left -= shake;

                this.Invalidate();
                await Task.Delay(50);
            }

            isMoving = false;
        }

        private float Lerp(float start, float end, float amount)
        {
            return start + (end - start) * amount;
        }

        private async Task AnimateReturn(ClassroomWarrior attacker)
        {
            isReturning = true;
            int returnSteps = 8;
            int attackDistance = 30;
            int centerX = (player1OriginalX + player2OriginalX) / 2;

            int currentY1 = pictureBox1.Top;
            int currentY2 = pictureBox2.Top;

            for (int i = 0; i < returnSteps; i++)
            {
                float progress = (float)i / returnSteps;

                player1CurrentX = (int)Lerp(centerX - attackDistance, player1OriginalX, progress);
                player2CurrentX = (int)Lerp(centerX + attackDistance, player2OriginalX, progress);

                pictureBox1.Location = new Point(player1CurrentX, currentY1);
                pictureBox2.Location = new Point(player2CurrentX, currentY2);

                this.Invalidate();
                await Task.Delay(40);
            }

            player1CurrentX = player1OriginalX;
            player2CurrentX = player2OriginalX;
            pictureBox1.Location = new Point(player1OriginalX, currentY1);
            pictureBox2.Location = new Point(player2OriginalX, currentY2);
            pictureBox1.BringToFront();
            pictureBox2.BringToFront();

            isReturning = false;
        }

        private void UpdateTurnIndicator()
        {
            if (!battleActive)
            {
                lblTurnIndicator.Text = "Press 'START BATTLE' to begin!";
                lblTurnIndicator.ForeColor = Color.Black;
                return;
            }

            if (isPlayer1Turn)
            {
                lblTurnIndicator.Text = $"{warrior1?.Name ?? "Player 1"}'s Turn - Press SPACE or ENTER to attack!";
                lblTurnIndicator.ForeColor = Color.Blue;
            }
            else
            {
                lblTurnIndicator.Text = $"{warrior2?.Name ?? "Player 2"}'s Turn - Press A, S, D, or Arrow Keys to attack!";
                lblTurnIndicator.ForeColor = Color.Red;
            }
        }

        private void InitializeAnimationTimer()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 100;
            animationTimer.Tick += AnimationTimer_Tick;
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationStep++;

            if (animationStep >= 20)
            {
                animationTimer.Stop();
                isAnimating = false;
                animationStep = 0;
                currentAttackText = "";
            }

            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
        }

        private void SetupCharacterSelection()
        {
            cmbPlayer1Type.Items.AddRange(new object[] { "Nemo", "Onay", "Momo", "Ja", "Lilet" });
            cmbPlayer2Type.Items.AddRange(new object[] { "Nemo", "Onay", "Momo", "Ja", "Lilet" });

            cmbPlayer1Type.SelectedIndex = 0;
            cmbPlayer2Type.SelectedIndex = 1;

            cmbPlayer1Type.SelectedIndexChanged += (s, e) => pictureBox1.Invalidate();
            cmbPlayer2Type.SelectedIndexChanged += (s, e) => pictureBox2.Invalidate();

            pictureBox1.Paint += PictureBox1_Paint;
            pictureBox2.Paint += PictureBox2_Paint;
        }

        private void EnableCharacterSelection(bool enabled)
        {
            cmbPlayer1Type.Enabled = enabled;
            cmbPlayer2Type.Enabled = enabled;
            txtPlayer1Name.Enabled = enabled;
            txtPlayer2Name.Enabled = enabled;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (cmbPlayer1Type.SelectedItem != null)
            {
                DrawStickFigure(e.Graphics, cmbPlayer1Type.SelectedItem.ToString(), pictureBox1.Size, warrior1,
                    isPlayer1Turn && battleActive, warrior1 == currentAttacker && (isMoving || isAnimating), warrior1IsHit);
            }
        }

        private void PictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (cmbPlayer2Type.SelectedItem != null)
            {
                DrawStickFigure(e.Graphics, cmbPlayer2Type.SelectedItem.ToString(), pictureBox2.Size, warrior2,
                    !isPlayer1Turn && battleActive, warrior2 == currentAttacker && (isMoving || isAnimating), warrior2IsHit);
            }
        }

        private void DrawStickFigure(Graphics g, string characterType, Size boxSize, ClassroomWarrior warrior,
           bool isCurrentPlayerTurn = false, bool isAttacking = false, bool isHit = false)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Color baseColor = characterColors[characterType];
            Color currentColor = GetCharacterColor(baseColor, warrior, isCurrentPlayerTurn, isAttacking, isHit);

            using (Pen pen = new Pen(currentColor, isCurrentPlayerTurn ? 6 : 4))
            {
                int centerX = boxSize.Width / 2;
                int centerY = boxSize.Height / 2;
                int attackOffset = GetAttackOffset();

                DrawHead(g, pen, centerX, centerY, attackOffset);
                DrawBody(g, pen, centerX, centerY, attackOffset);

                DrawArms(g, pen, centerX, centerY, attackOffset, isAttacking, warrior);
                DrawLegs(g, pen, centerX, centerY, attackOffset);

                if (isAttacking || (isMoving || isReturning))
                {
                    DrawAttackEffects(g, boxSize);
                }

                if (isHit)
                {
                    DrawHitEffect(g, boxSize, currentColor);
                }
            }
        }

        private Color GetCharacterColor(Color baseColor, ClassroomWarrior warrior,
    bool isCurrentPlayerTurn, bool isAttacking, bool isHit)
        {
            Color currentColor = baseColor;

            if (isHit)
            {
                return Color.FromArgb(255, 255, 0, 0);
            }

            if (warrior != null && warrior.Health < warrior.MaxHealth * 0.3)
            {
                currentColor = Color.FromArgb(255,
                    Math.Min(255, baseColor.R + 50),
                    Math.Max(0, baseColor.G - 30),
                    Math.Max(0, baseColor.B - 30));
            }

            return currentColor;
        }

        private void DrawHitEffect(Graphics g, Size boxSize, Color characterColor)
        {
            using (Pen glowPen = new Pen(Color.FromArgb(180, 255, 0, 0), 8))
            {
                int centerX = boxSize.Width / 2;
                int centerY = boxSize.Height / 2;
                int glowRadius = 35;

                g.DrawEllipse(glowPen, centerX - glowRadius, centerY - glowRadius,
                             glowRadius * 2, glowRadius * 2);
            }

            using (Pen sparkPen = new Pen(Color.Red, 3))
            {
                Random rand = new Random();
                for (int i = 0; i < 6; i++)
                {
                    int sparkX = boxSize.Width / 2 + rand.Next(-25, 25);
                    int sparkY = boxSize.Height / 2 + rand.Next(-25, 25);
                    g.DrawLine(sparkPen, sparkX - 4, sparkY, sparkX + 4, sparkY);
                    g.DrawLine(sparkPen, sparkX, sparkY - 4, sparkX, sparkY + 4);
                }
            }
        }

        private int GetAttackOffset()
        {
            return (isMoving || isAnimating) && animationStep > 0 ?
                   (animationStep % 4) - 2 : 0;
        }

        private void DrawHead(Graphics g, Pen pen, int centerX, int centerY, int attackOffset)
        {
            int headRadius = 15;
            g.DrawEllipse(pen, centerX - headRadius + attackOffset,
                          centerY - 40 + attackOffset,
                          headRadius * 2, headRadius * 2);
        }

        private void DrawBody(Graphics g, Pen pen, int centerX, int centerY, int attackOffset)
        {
            g.DrawLine(pen, centerX + attackOffset, centerY - 10 + attackOffset,
                      centerX + attackOffset, centerY + 20 + attackOffset);
        }

        private void DrawArms(Graphics g, Pen pen, int centerX, int centerY,
                            int attackOffset, bool isAttacking, ClassroomWarrior warrior)
        {
            int armLength = 20;
            int armY = centerY - 10;

            if (isMoving || isAnimating)
            {
                int armAnimation = (animationStep % 8) - 4;
                g.DrawLine(pen, centerX - armLength + attackOffset, armY + armAnimation + attackOffset,
                           centerX + armLength + attackOffset, armY - armAnimation + attackOffset);

                if (isAttacking && animationStep > 0)
                {
                    DrawSword(g, centerX, armY, attackOffset, armAnimation, armLength,
                             warrior == warrior1 ? 1 : -1, pen.Color);
                }
            }
            else
            {
                g.DrawLine(pen, centerX - armLength + attackOffset, armY + attackOffset,
                           centerX + armLength + attackOffset, armY + attackOffset);
            }
        }

        private void DrawSword(Graphics g, int centerX, int armY, int attackOffset,
                             int armAnimation, int armLength, int swordDirection, Color swordColor)
        {
            using (Pen swordPen = new Pen(swordColor, 4))
            using (Brush swordBrush = new SolidBrush(swordColor))
            {
                Point handleStart = new Point(centerX + (armLength * swordDirection) + attackOffset,
                                   armY - armAnimation + attackOffset);
                Point handleEnd = new Point(centerX + ((armLength + 5) * swordDirection) + attackOffset,
                                  armY - armAnimation + attackOffset);

                Point bladeTip = new Point(centerX + ((armLength + 40) * swordDirection) + attackOffset,
                                    armY - armAnimation + attackOffset - 5);

                g.DrawLine(swordPen, handleStart, handleEnd);
                g.DrawLine(swordPen, handleEnd, bladeTip);

                if (swordDirection > 0)
                {
                    g.FillPolygon(swordBrush, new Point[] {
                        bladeTip,
                        new Point(bladeTip.X - 5, bladeTip.Y + 3),
                        new Point(bladeTip.X - 5, bladeTip.Y - 3)
                    });
                }
                else
                {
                    g.FillPolygon(swordBrush, new Point[] {
                        bladeTip,
                        new Point(bladeTip.X + 5, bladeTip.Y + 3),
                        new Point(bladeTip.X + 5, bladeTip.Y - 3)
                    });
                }

                if (animationStep % 2 == 0)
                {
                    Color shineColor = Color.FromArgb(255,
                        Math.Min(255, swordColor.R + 150),
                        Math.Min(255, swordColor.G + 150),
                        Math.Min(255, swordColor.B + 150));

                    using (Pen shinePen = new Pen(shineColor, 2))
                    {
                        g.DrawLine(shinePen,
                            handleEnd.X + (swordDirection * 5), handleEnd.Y - 2,
                            handleEnd.X + (swordDirection * 20), handleEnd.Y - 2);
                    }
                }
            }
        }

        private void DrawLegs(Graphics g, Pen pen, int centerX, int centerY, int attackOffset)
        {
            int legLength = 25;
            if (isMoving || isAnimating)
            {
                int legAnimation = (animationStep % 6) - 3;
                g.DrawLine(pen, centerX + attackOffset, centerY + 20 + attackOffset,
                          centerX - legLength / 2 + legAnimation + attackOffset,
                          centerY + 20 + legLength + attackOffset);
                g.DrawLine(pen, centerX + attackOffset, centerY + 20 + attackOffset,
                          centerX + legLength / 2 - legAnimation + attackOffset,
                          centerY + 20 + legLength + attackOffset);
            }
            else
            {
                g.DrawLine(pen, centerX + attackOffset, centerY + 20 + attackOffset,
                          centerX - legLength / 2 + attackOffset, centerY + 20 + legLength + attackOffset);
                g.DrawLine(pen, centerX + attackOffset, centerY + 20 + attackOffset,
                          centerX + legLength / 2 + attackOffset, centerY + 20 + legLength + attackOffset);
            }
        }

        private void DrawAttackEffects(Graphics g, Size boxSize)
        {
            if (animationStep > 0)
            {
                using (Pen effectPen = new Pen(Color.Yellow, 2))
                {
                    int centerX = boxSize.Width / 2;
                    int centerY = boxSize.Height / 2;
                    int effectRadius = 25 + (animationStep * 2);

                    for (int i = 0; i < 6; i++)
                    {
                        double angle = (Math.PI * 2 * i) / 6;
                        int x1 = centerX + (int)(Math.Cos(angle) * effectRadius);
                        int y1 = centerY + (int)(Math.Sin(angle) * effectRadius);
                        int x2 = centerX + (int)(Math.Cos(angle) * (effectRadius + 12));
                        int y2 = centerY + (int)(Math.Sin(angle) * (effectRadius + 12));

                        g.DrawLine(effectPen, x1, y1, x2, y2);
                    }
                }

                if (animationStep > 5)
                {
                    using (Pen sparkPen = new Pen(Color.White, 3))
                    {
                        Random rand = new Random(animationStep);
                        for (int i = 0; i < 4; i++)
                        {
                            int sparkX = boxSize.Width / 2 + rand.Next(-15, 15);
                            int sparkY = boxSize.Height / 2 + rand.Next(-15, 15);
                            g.DrawLine(sparkPen, sparkX - 5, sparkY, sparkX + 5, sparkY);
                            g.DrawLine(sparkPen, sparkX, sparkY - 5, sparkX, sparkY + 5);
                        }
                    }
                }
            }
        }

        private void btnStartBattle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPlayer1Name.Text) ||
                    string.IsNullOrWhiteSpace(txtPlayer2Name.Text))
                {
                    throw new Exception("Both warriors need names!");
                }

                if (cmbPlayer1Type.SelectedIndex == -1 ||
                    cmbPlayer2Type.SelectedIndex == -1)
                {
                    throw new Exception("Please select types for both warriors!");
                }

                warrior1 = CreateWarrior(txtPlayer1Name.Text, cmbPlayer1Type.SelectedItem.ToString());
                warrior2 = CreateWarrior(txtPlayer2Name.Text, cmbPlayer2Type.SelectedItem.ToString());

                btnStartBattle.Visible = false;

                lblPlayer1Health.Text = txtPlayer1Name.Text + ": " + warrior1.Health + "/" + warrior1.MaxHealth;
                lblPlayer2Health.Text = txtPlayer2Name.Text + ": " + warrior2.Health + "/" + warrior2.MaxHealth;

                lstBattleLog.Items.Clear();
                UpdateHealthDisplays();

                InitializeMovementPositions();
                pictureBox1.Location = new Point(player1OriginalX, pictureBox1.Location.Y);
                pictureBox2.Location = new Point(player2OriginalX, pictureBox2.Location.Y);

                EnableCharacterSelection(false);

                battleActive = true;
                isPlayer1Turn = true;

                lstBattleLog.Items.Add("=== BATTLE STARTED! ===");
                lstBattleLog.Items.Add("Player 1: Use SPACE or ENTER to attack");
                lstBattleLog.Items.Add("Player 2: Use A, S, D, or Arrow Keys to attack");
                lstBattleLog.Items.Add("Watch your characters move and fight!");

                UpdateTurnIndicator();
                pictureBox1.Invalidate();
                pictureBox2.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Battle Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ClassroomWarrior CreateWarrior(string name, string type)
        {
            switch (type)
            {
                case "Nemo":
                    return new Nemo(name);
                case "Onay":
                    return new Onay(name);
                case "Momo":
                    return new Momo(name);
                case "Ja":
                    return new Ja(name);
                case "Lilet":
                    return new Lilet(name);
                default:
                    throw new Exception("Unknown warrior type!");
            }
        }

        private void UpdateHealthDisplays()
        {
            if (warrior1 != null)
            {
                healthBar1.Value = warrior1.Health;
                healthBar1.Maximum = warrior1.MaxHealth;
                lblPlayer1Health.Text = $"{txtPlayer1Name.Text}: {warrior1.Health}/{warrior1.MaxHealth}";
            }
            else
            {
                healthBar1.Value = 0;
            }

            if (warrior2 != null)
            {
                healthBar2.Value = warrior2.Health;
                healthBar2.Maximum = warrior2.MaxHealth;
                lblPlayer2Health.Text = $"{txtPlayer2Name.Text}: {warrior2.Health}/{warrior2.MaxHealth}";
            }
            else
            {
                healthBar2.Value = 0;
            }
        }
    }
}
