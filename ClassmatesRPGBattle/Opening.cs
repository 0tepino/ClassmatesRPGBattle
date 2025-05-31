using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassroomBattleSimulator 
{
    public partial class Opening : Form
    {
        public Opening()
        {
            InitializeComponent();
        }

        private void btnStartBattle_Click(object sender, EventArgs e)
        {
            this.Hide();

            BattleForm battleForm = new BattleForm();
            battleForm.FormClosed += (s, args) => this.Close(); 
            battleForm.Show();
        }
    }
}