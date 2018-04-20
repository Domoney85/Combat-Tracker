using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace Combat_Tracker
{

    public partial class Main : Form
    {
        ArrayList combatants;
        List<Character> inCombat;
        List<Character> sortedCombat;

        public Main()
        {
            InitializeComponent();
            combatants = new ArrayList();
            inCombat = new List<Character>();
            sortedCombat = new List<Character>();
        }

        private void Main_Load(object sender, EventArgs e) { }

        private void CreatePNL_Click(object sender, EventArgs e)
        {
            Character current = new Character(
                    CharName.Text,
                    Convert.ToInt32(csInput.Text),
                    Convert.ToInt32(cpxInput.Text),
                    Convert.ToInt32(perInput.Text),
                    Convert.ToInt32(willInput.Text));
            combatants.Add(current);
            AddBatch(current);
        }

        private void PanelCreate(Character current)
        {
            Panel CharPanel = new Panel();

            CharPanel.Name = current.Name;
            CharPanel.Location = new Point(10, 10);
            CharPanel.BackColor = Color.WhiteSmoke;
            CharPanel.Size = new Size(190, 55);
            CharPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            flowLayoutPanel1.Controls.Add(CharPanel);

            Label CharacterID = new Label();
            Label CharacterSkill = new Label();
            Label skillLBL = new Label();
            Label cpxLBL = new Label();
            Label willLBL = new Label();
            Label modLBL = new Label();

            CharacterID.Text = current.Name;
            CharacterID.Font = new Font("Sans Serif", 10, FontStyle.Bold);
            CharacterID.Location = new Point(3, 0);
            CharacterID.AutoSize = true;

            skillLBL.Text = "CS Skill";
            skillLBL.Margin = new Padding(0, 0, 0, 0);
            skillLBL.Padding = new Padding(0, 0, 0, 0);
            skillLBL.Location = new Point(6, 18);

            CharacterSkill.Text = current.Skill.ToString() + "/" + current.Complexity.ToString() + "+" + current.Perception.ToString();
            CharacterSkill.Location = new Point(48, 18);

            willLBL.Text = "Will: " + current.Will.ToString();
            willLBL.Location = new Point(6, 32);

            modLBL.Text = "Mod:";
            modLBL.Font = new Font("Sans Serif", 7, FontStyle.Regular);
            modLBL.Location = new Point(55, 32);

            CharPanel.Controls.Add(modLBL);
            CharPanel.Controls.Add(willLBL);
            CharPanel.Controls.Add(CharacterSkill);
            CharPanel.Controls.Add(skillLBL);
            CharPanel.Controls.Add(CharacterID);

            TextBox modTXT = new TextBox();
            modTXT.TextChanged += new System.EventHandler(modTXT_TextChanged);
            modTXT.Location = new Point(92, 28);
            modTXT.Size = new Size(25, 5);
            CharPanel.Controls.Add(modTXT);
            modTXT.BringToFront();

            Button register = new Button();
            register.Name = "register";
            register.Text = "Enter Combat";
            register.Font = new Font("Sans Serif", 7, FontStyle.Regular);
            register.Location = new Point(125, 28);
            register.Size = new Size(50, 20);
            register.Click += new System.EventHandler(register_Click);
            CharPanel.Controls.Add(register);
            register.BringToFront();

            Button down = new Button();
            down.Text = "Down";
            down.Font = new Font("Sans Serif", 7, FontStyle.Regular);
            down.Location = new Point(125, 3);
            down.Size = new Size(50, 20);
            down.Click += new System.EventHandler(down_Click);
            CharPanel.Controls.Add(down);
            down.BringToFront();
        }

        private void modTXT_TextChanged(object sender, EventArgs e)
        {
            int wounded = 0;
            TextBox woundBox = (TextBox)sender;
            if (int.TryParse(woundBox.Text, out int n))
            {
                wounded = n;
            }
            foreach (Character c in combatants)
            {
                if (woundBox.Parent.Name == c.Name)
                {
                    c.ApplyWounds(wounded);
                }
            }
            foreach (Character c in inCombat)
            {
                if (woundBox.Parent.Name == c.Name)
                {
                    c.ApplyWounds(wounded);
                }
            }
            var sortedQuery = inCombat.OrderByDescending(k => k.CombatStep);
            sortedCombat.Clear();
            CombatOrder.Controls.Clear();
            sortedCombat = sortedQuery.ToList();
            PopulateCombat(sortedCombat);
        }
        private void register_Click(object sender, EventArgs e)
        {
            Button x = (Button)sender;
            if (x.Text == "Enter Combat")
            {
                x.Parent.BackColor = Color.DarkGray;
                x.Text = "Leave Combat";

            }
            else
            {
                x.Parent.BackColor = Color.WhiteSmoke;
                x.Text = "Enter Combat";
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            combatants.Clear();
        }

        private void enterAllInCombatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Panel ctrl in flowLayoutPanel1.Controls)
            {
                foreach (Control x in ctrl.Controls)
                {
                    if (x is Button)
                    {
                        if (x.Name == "register")
                        {
                            x.Parent.BackColor = Color.DarkGray;
                            x.Text = "Leave Combat";
                        }
                    }
                }
            }
        }

        private void removeAllInCombatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Panel ctrl in flowLayoutPanel1.Controls)
            {
                foreach (Control x in ctrl.Controls)
                {
                    if (x is Button)
                    {
                        if (x.Name == "register")
                        {
                            x.Parent.BackColor = Color.WhiteSmoke;
                            x.Text = "Enter Combat";
                        }
                    }
                }
            }
        }

        private void StartRound_Click(object sender, EventArgs e)
        {
            inCombat.Clear();
            foreach (Character n in combatants)
                n.CombatStep = 0;
            CombatOrder.Controls.Clear();
            foreach (Panel ctrl in flowLayoutPanel1.Controls)
            {
                foreach (Control x in ctrl.Controls)
                {
                    if (x is Button)
                    {
                        if (x.Text == "Leave Combat")
                        {
                            string newName = ctrl.Name;

                            foreach (Character com in combatants)
                            {
                                if (newName == com.Name)
                                {
                                    if (!com.IsDown)
                                    {
                                        com.SetCombatStep();
                                        inCombat.Add(com);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            var sortedQuery = inCombat.OrderByDescending(k => k.CombatStep);
            sortedCombat = sortedQuery.ToList();
            PopulateCombat(sortedCombat);
        }

        private void PopulateCombat(List<Character> x)
        {
            foreach (Character com in x)
            {
                Panel CharPanel = new Panel();
                CharPanel.Name = com.Name;
                CharPanel.Location = new Point(10, 10);
                CharPanel.BackColor = Color.WhiteSmoke;
                CharPanel.Size = new Size(190, 66);
                CharPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                CombatOrder.Controls.Add(CharPanel);

                GroupBox rollBox = new GroupBox();
                rollBox.Size = new Size(47, 33);
                rollBox.Location = new Point(63, 26);
                rollBox.Text = "Roll";
                CharPanel.Controls.Add(rollBox);

                Label CharacterID = new Label();
                CharacterID.Text = com.Name;
                CharacterID.Font = new Font("Sans Serif", 10, FontStyle.Bold);
                CharacterID.Location = new Point(3, 0);
                CharacterID.AutoSize = true;
                CharPanel.Controls.Add(CharacterID);

                Label combatRoll = new Label();
                combatRoll.Location = new Point(13, 11);
                combatRoll.Size = new Size(25, 15);
                combatRoll.Text = com.CombatStep.ToString();
                combatRoll.Font = new Font("Sans Serif", 9, FontStyle.Bold);
                rollBox.Controls.Add(combatRoll);
                combatRoll.BringToFront();

                Button up = new Button();
                // up.Text = "up";
                up.Location = new Point(170, 4);
                up.Size = new Size(14, 25);
                up.BackColor = Color.Black;
                up.BackgroundImage = Properties.Resources.ArrowUp;
                up.BackgroundImageLayout = ImageLayout.Stretch;
                up.Click += new System.EventHandler(upOrder_Click);

                Button down = new Button();
                // down.Text = "down";
                down.Location = new Point(170, 30);
                down.Size = new Size(14, 25);
                down.BackColor = Color.Black;
                down.BackgroundImage = Properties.Resources.arrowdown;
                down.BackgroundImageLayout = ImageLayout.Stretch;
                CharPanel.Controls.Add(up);
                up.BringToFront();
                CharPanel.Controls.Add(down);
                down.BringToFront();
                down.Click += new System.EventHandler(downOrder_Click);
            }
        }

        private void down_Click(object sender, EventArgs e)
        {
            Button down = (Button)sender;
            foreach (Character x in combatants)
            {
                if (x.Name == down.Parent.Name)
                {
                    if (!x.IsDown)
                    {
                        x.IsDown = true;
                        down.Parent.BackColor = Color.LightSalmon;
                        down.Text = "revive";
                        foreach (Panel o in CombatOrder.Controls)
                        {
                            if (o.Name == down.Parent.Name)
                            {
                                o.BackColor = Color.LightSalmon;
                            }
                        }
                    }
                    else
                    {
                        x.IsDown = true;
                        down.Parent.BackColor = Color.WhiteSmoke;
                        down.Text = "Down";
                        foreach (Panel o in CombatOrder.Controls)
                        {
                            if (o.Name == down.Parent.Name)
                            {
                                o.BackColor = Color.WhiteSmoke;
                            }
                        }
                    }
                }
            }
        }

        private void saveCombatGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fdlg = new SaveFileDialog();
            fdlg.Filter = "txt files (*.txt)|*.txt";


            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(fdlg.FileName);
                {
                    if (File.Exists(fdlg.FileName))
                    {
                        foreach (Character x in inCombat)
                        {
                            sw.WriteLine(x.Name);
                            sw.WriteLine(x.Skill);
                            sw.WriteLine(x.Complexity);
                            sw.WriteLine(x.Perception);
                            sw.WriteLine(x.Will);
                        }
                    }
                    sw.Close();
                }
            }
        }

        private void loadBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Filter = "txt files (*.txt)|*.txt";
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader sw = new StreamReader(fdlg.FileName);
                {
                    if (File.Exists(fdlg.FileName))
                    {
                        while (sw.Peek() >= 0)
                        {
                            Character current = new Character(
                            sw.ReadLine(),
                            Convert.ToInt32(sw.ReadLine()),
                            Convert.ToInt32(sw.ReadLine()),
                            Convert.ToInt32(sw.ReadLine()),
                            Convert.ToInt32(sw.ReadLine())
                            );
                            combatants.Add(current);
                            AddBatch(current);
                        }



                    }

                }
            }

        }
        private void AddBatch(Character c)
        {

            foreach (Character x in combatants)
            {

                if (x.RName == c.RName)
                {
                    c.SetCount();
                }

            }
            PanelCreate(c);
        }
        private void upOrder_Click(object sender, EventArgs e)
        {

            Button up = (Button)sender;

            foreach (Character c in inCombat)
            {
                if (up.Parent.Name == c.Name)
                {
                    c.BumpUp();
                }
            }
            var sortedQuery = inCombat.OrderByDescending(k => k.CombatStep);
            sortedCombat.Clear();
            CombatOrder.Controls.Clear();
            sortedCombat = sortedQuery.ToList();
            PopulateCombat(sortedCombat);

        }
        private void downOrder_Click(object sender, EventArgs e)
        {

            Button down = (Button)sender;

            foreach (Character c in inCombat)
            {
                if (down.Parent.Name == c.Name)
                {
                    c.BumpDown();
                }
            }
            var sortedQuery = inCombat.OrderByDescending(k => k.CombatStep);
            sortedCombat.Clear();
            CombatOrder.Controls.Clear();
            sortedCombat = sortedQuery.ToList();
            PopulateCombat(sortedCombat);

        }

        private void enterAllInCombatButton_Click(object sender, EventArgs e)
        {
            foreach (Panel ctrl in flowLayoutPanel1.Controls)
            {
                foreach (Control x in ctrl.Controls)
                {
                    if (x is Button)
                    {
                        if (x.Name == "register")
                        {
                            x.Parent.BackColor = Color.DarkGray;
                            x.Text = "Leave Combat";
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TestForm form = new TestForm();
            form.Show();
        }
    }
}
