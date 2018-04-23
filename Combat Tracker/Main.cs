using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Threading;

namespace Combat_Tracker
{

    public partial class Main : Form
    {
        private int characterIds = 0;
        List<Character> combatants;
        //List<Character> inCombat;

        public Main()
        {
            InitializeComponent();
            combatants = new List<Character>();
            //inCombat = new List<Character>();
        }

        private void Main_Load(object sender, EventArgs e) { }

        private void CreateCharacterButton_Click(object sender, EventArgs e)
        {
            Character current = new Character(
                    Interlocked.Increment(ref characterIds),
                    CharName.Text,
                    Convert.ToInt32(csInput.Text),
                    Convert.ToInt32(cpxInput.Text),
                    Convert.ToInt32(perInput.Text),
                    Convert.ToInt32(willInput.Text));
            combatants.Add(current);
            AddBatch(current);
        }

        private Panel CreateCharacterPanel(Character character)
        {
            Panel newPanel = new Panel();
            newPanel.Name = character.Name;
            newPanel.Location = new Point(5, 6);
            newPanel.BackColor = Color.WhiteSmoke;
            newPanel.Size = new Size(190, 64);
            newPanel.BorderStyle = BorderStyle.Fixed3D;

            Label CharacterID = new Label();
            CharacterID.Text = character.Name;
            CharacterID.Font = new Font("Sans Serif", 10, FontStyle.Bold);
            CharacterID.Location = new Point(3, 0);
            CharacterID.AutoSize = true;

            Label skillLBL = new Label();
            skillLBL.Text = "CS Skill";
            skillLBL.Margin = new Padding(0, 0, 0, 0);
            skillLBL.Padding = new Padding(0, 0, 0, 0);
            skillLBL.Location = new Point(6, 18);

            Label CharacterSkill = new Label();
            CharacterSkill.Text = character.Skill.ToString() + "/" + character.Complexity.ToString() + "+" + character.Perception.ToString();
            CharacterSkill.Location = new Point(48, 18);

            Label willLBL = new Label();
            willLBL.Text = "Will: " + character.Will.ToString();
            willLBL.Font = new Font("Sans Serif", 7, FontStyle.Regular);
            willLBL.Location = new Point(6, 32);

            Label modLBL = new Label();
            modLBL.Text = "Wounds:";
            modLBL.Font = new Font("Sans Serif", 7, FontStyle.Regular);
            modLBL.Location = new Point(45, 32);

            newPanel.Controls.Add(modLBL);
            newPanel.Controls.Add(willLBL);
            newPanel.Controls.Add(CharacterSkill);
            newPanel.Controls.Add(skillLBL);
            newPanel.Controls.Add(CharacterID);

            TextBox modTXT = new TextBox();
            modTXT.TextChanged += new EventHandler(modTXT_TextChanged);
            modTXT.Location = new Point(92, 28);
            modTXT.Size = new Size(25, 5);
            newPanel.Controls.Add(modTXT);
            modTXT.BringToFront();

            Button register = new Button();
            register.Name = character.ID.ToString();
            register.Text = "Enter Combat";
            register.Font = new Font("Sans Serif", 7, FontStyle.Regular);
            register.Location = new Point(125, 28);
            register.Size = new Size(50, 20);
            register.Click += new EventHandler(register_Click);
            newPanel.Controls.Add(register);

            Button down = new Button();
            down.Text = "Down";
            down.Font = new Font("Sans Serif", 7, FontStyle.Regular);
            down.Location = new Point(125, 3);
            down.Size = new Size(50, 20);
            down.Click += new EventHandler(down_Click);
            newPanel.Controls.Add(down);
            down.BringToFront();

            register.BringToFront();

            return newPanel;
        }

        private void PopulateCombat(List<Character> x)
        {
            CombatOrder.Controls.Clear();

            foreach (Character com in x)
            {
                Panel CombatPanel = new Panel();
                CombatPanel.Name = com.Name;
                CombatPanel.Location = new Point(10, 10);
                CombatPanel.BackColor = Color.WhiteSmoke;
                CombatPanel.Size = new Size(234, 75);
                CombatPanel.BorderStyle = BorderStyle.Fixed3D;
                CombatOrder.Controls.Add(CombatPanel);

                Panel characterPanel = CreateCharacterPanel(com);
                CombatPanel.Controls.Add(characterPanel);

                GroupBox rollBox = new GroupBox();
                rollBox.Size = new Size(30, 70);
                rollBox.Location = new Point(195, 0);
                CombatPanel.Controls.Add(rollBox);

                Button up = new Button();
                up.Location = new Point(2, 10);
                up.Size = new Size(25, 15);
                up.BackgroundImage = Properties.Resources.up_arrow;
                up.BackgroundImageLayout = ImageLayout.Stretch;
                up.Click += new EventHandler(upOrder_Click);
                rollBox.Controls.Add(up);
                up.BringToFront();

                Label combatRoll = new Label();
                combatRoll.Location = new Point(2, 30);
                combatRoll.Size = new Size(25, 15);
                combatRoll.Text = com.CombatStep.ToString();
                combatRoll.Font = new Font("Sans Serif", 9, FontStyle.Bold);
                combatRoll.TextAlign = ContentAlignment.MiddleCenter;
                rollBox.Controls.Add(combatRoll);
                combatRoll.BringToFront();

                Button down = new Button();
                down.Location = new Point(2, 50);
                down.Size = new Size(25, 15);
                down.BackgroundImage = Properties.Resources.down_arrow;
                down.BackgroundImageLayout = ImageLayout.Stretch;
                down.Click += new EventHandler(downOrder_Click);
                rollBox.Controls.Add(down);
                down.BringToFront();
            }
        }

        private void modTXT_TextChanged(object sender, EventArgs e)
        {
            int wounds = 0;
            TextBox woundTextBox = (TextBox)sender;

            // adds wounds
            if (int.TryParse(woundTextBox.Text, out int n))
            {
                wounds = n;
            }

            // finds the combatant and adds wounds
            foreach (Character c in combatants)
            {
                if (woundTextBox.Parent.Name == c.Name)
                {
                    c.ApplyWounds(wounds);
                }
            }

            // finds the combat list and adds wounds
            //foreach (Character c in inCombat)
            //{
            //    if (woundTextBox.Parent.Name == c.Name)
            //    {
            //        c.ApplyWounds(wounds);
            //    }
            //}

            // this probably isn't needed. the order shouldn't change until 
            // next combat round
            /*
            var sortedQuery = inCombat.OrderByDescending(k => k.CombatStep);
            sortedCombat.Clear();
            CombatOrder.Controls.Clear();
            sortedCombat = sortedQuery.ToList();
            PopulateCombat(sortedCombat);
            */
        }

        private void register_Click(object sender, EventArgs e)
        {
            Button x = (Button)sender;
            foreach (Character c in combatants)
            {
                if (c.ID.ToString().Equals(x.Name))
                {
                    if (x.Text == "Enter Combat")
                    {
                        x.Parent.BackColor = Color.DarkGray;
                        x.Text = "Leave Combat";
                        c.InCombat = true;
                    }
                    else
                    {
                        x.Parent.BackColor = Color.WhiteSmoke;
                        x.Text = "Enter Combat";
                        c.InCombat = false;
                    }
                }
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
                        combatants.Where(c => x.Name.Equals(c.ID.ToString()))
                                .ToList()
                                .ForEach(ch =>
                                {
                                    ch.InCombat = true;
                                });

                        if (x.Name == "Enter Combat")
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
                        combatants.Where(c => x.Name.Equals(c.ID.ToString()))
                                .ToList()
                                .ForEach(ch =>
                                {
                                    ch.InCombat = false;
                                });

                        if (x.Name == "Leave Combat")
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
            //inCombat.Clear();
            foreach (Character n in combatants)
                n.CombatStep = 0;

            foreach (Panel ctrl in flowLayoutPanel1.Controls)
            {
                foreach (Control x in ctrl.Controls)
                {
                    if (x is Button)
                    {
                        if (x.Text == "Leave Combat")
                        {
                            string newName = ctrl.Name;
                            {
                                foreach (Character com in combatants)
                                {
                                    if (newName == com.Name)
                                    {
                                        if (!com.IsDown)
                                        {
                                            com.SetCombatStep();
                                            com.InCombat = true;
                                            //inCombat.Add(com);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            PopulateCombat(combatants
                    .OrderByDescending(k => k.CombatStep)
                    .Where(k => k.InCombat)
                    .ToList());
            //PopulateCombat(inCombat.OrderByDescending(k => k.CombatStep).ToList());
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
                        foreach (Character x in combatants.Where(c => c.InCombat))
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
                                    Interlocked.Increment(ref characterIds),
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
            flowLayoutPanel1.Controls.Add(CreateCharacterPanel(c));
        }

        private void downOrder_Click(object sender, EventArgs e)
        {

            Button down = (Button)sender;

            foreach (Character c in combatants.Where(c => c.InCombat))
            {
                if (down.Parent.Name == c.Name)
                {
                    c.BumpDown();
                }
            }
            PopulateCombat(combatants.Where(c => c.InCombat).OrderByDescending(k => k.CombatStep).ToList());
        }

        private void upOrder_Click(object sender, EventArgs e)
        {

            Button up = (Button)sender;

            foreach (Character c in combatants.Where(c => c.InCombat))
            {
                if (up.Parent.Name == c.Name)
                {
                    c.BumpUp();
                }
            }
            PopulateCombat(combatants.Where(c => c.InCombat).OrderByDescending(k => k.CombatStep).ToList());
        }

        private void enterAllInCombatButton_Click(object sender, EventArgs e)
        {
            foreach (Panel ctrl in flowLayoutPanel1.Controls)
            {
                foreach (Control x in ctrl.Controls)
                {
                    if (x is Button)
                    {

                        combatants.Where(c => x.Name.Equals(c.ID.ToString()))
                                .ToList()
                                .ForEach(ch =>
                                {
                                    ch.InCombat = true;
                                });

                        if (x.Text == "Enter Combat")
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
