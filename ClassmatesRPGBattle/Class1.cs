using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassroomBattleSimulator
{
    public abstract class ClassroomWarrior
    {
        private int health;
        public abstract string GetAttackName();

        public string Name { get; set; }
        public int MaxHealth { get; protected set; }

        public int Health
        {
            get { return health; }
            set { health = Math.Max(0, Math.Min(value, MaxHealth)); }
        }

        public abstract int Attack();

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public bool IsDefeated
        {
            get { return Health <= 0; }
        }

        public class HealthBar : Control
        {
            private int _value;
            private int _maximum = 100;

            public int Value
            {
                get => _value;
                set
                {
                    _value = value;
                    Invalidate(); 
                }
            }

            public int Maximum
            {
                get => _maximum;
                set
                {
                    _maximum = value;
                    Invalidate();
                }
            }

            public HealthBar()
            {
                this.DoubleBuffered = true;
                this.Height = 20;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                e.Graphics.FillRectangle(Brushes.LightGray, 0, 0, this.Width, this.Height);

                float percent = (float)Value / Maximum;
                int healthWidth = (int)(this.Width * percent);

                Color healthColor = percent > 0.6 ? Color.Green :
                                   percent > 0.3 ? Color.Orange : Color.Red;

                using (Brush healthBrush = new SolidBrush(healthColor))
                {
                    e.Graphics.FillRectangle(healthBrush, 0, 0, healthWidth, this.Height);
                }

                e.Graphics.DrawRectangle(Pens.Black, 0, 0, this.Width - 1, this.Height - 1);

                string text = $"{Value}/{Maximum}";
                SizeF textSize = e.Graphics.MeasureString(text, this.Font);
                PointF textLocation = new PointF(
                    (this.Width - textSize.Width) / 2,
                    (this.Height - textSize.Height) / 2);
                e.Graphics.DrawString(text, this.Font, Brushes.Black, textLocation);
            }
        }

        protected ClassroomWarrior(string name, int maxHealth)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
        }
    }

    public class Nemo : ClassroomWarrior
    {
        private readonly string[] attackNames = new[]
        {
        "Ultimate Snipe",
        "Swan Song",
        "Blazing Finale",
        "Death Sonata"
        };

        private Random random = new Random();

        public Nemo(string name) : base(name, 100) { }
        public override int Attack()
        {
            if (random.NextDouble() < 0.5)
            {
                return random.Next(12, 19); 
            }
            return random.Next(5, 9); 
        }

        public override string GetAttackName()
        {
            return attackNames[random.Next(attackNames.Length)];
        }
    }

    public class Onay : ClassroomWarrior
    {

        private readonly string[] attackNames = new[]
        {
        "Divine Judgment",
        "Phantom Shuriken",
        "Implosion",
        "Sacred Hammer"
        };

        private Random random = new Random();

        public Onay(string name) : base(name, 100) { }

        public override int Attack()
        {
            if (random.NextDouble() < 0.5)
            {
                return random.Next(15, 23);
            }
            return random.Next(5, 11);
        }
        public override string GetAttackName()
        {
            return attackNames[random.Next(attackNames.Length)];
        }
    }

    public class Momo : ClassroomWarrior
    {

        private readonly string[] attackNames = new[]
        {
        "Destruction Rush",
        "Circling Eagle",
        "Blood Ode",
        "Abysm Strike"
        };

        private Random random = new Random();

        public Momo(string name) : base(name, 100) { }

        public override int Attack()
        {
            if (random.NextDouble() < 0.4)
            {
                return random.Next(15, 24);
            }
            return random.Next(5, 6);
        }
        public override string GetAttackName()
        {
            return attackNames[random.Next(attackNames.Length)];
        }
    }

    public class Ja : ClassroomWarrior
    {
        private readonly string[] attackNames = new[]
        {
        "Super Magic",
        "Spatial Migration",
        "Violet Requiem",
        "Energy Wave"
        };
        
        private Random random = new Random();

        public Ja(string name) : base(name, 100) { }

        public override int Attack()
        {
            if (random.NextDouble() < 0.6)
            {
                return random.Next(14, 16);
            }
            return random.Next(5, 10);
        }
        public override string GetAttackName()
        {
            return attackNames[random.Next(attackNames.Length)];
        }
    }
    public class Lilet : ClassroomWarrior
    {
        private readonly string[] attackNames = new[]
        {
        "Dragon Flurry",
        "Spear Strike",
        "Sword Spike",
        "Shadowblade Slaughter"
        };

        private Random random = new Random();

        public Lilet(string name) : base(name, 100) { }

        public override int Attack()
        {
            if (random.NextDouble() < 0.4)
            {
                return random.Next(11, 21);
            }
            return random.Next(5, 10);
        }
        public override string GetAttackName()
        {
            return attackNames[random.Next(attackNames.Length)];
        }
    }
}
