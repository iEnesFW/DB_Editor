using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkPrinc3_DB_Editor
{
    public partial class Home : Form
    {
        private Button currentButton;
        private bool sideBarExpand = true;
        private Form childForm;
        public Home()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToString();
            dateTimeTimer.Start();

            ActivateButton(homeButton);

        }

        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.DarkOrange;
                    currentButton.ForeColor = Color.White;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control prevButton in menuPanel.Controls)
            {
                if (prevButton.GetType()==typeof(Button))
                {
                    prevButton.BackColor = Color.FromArgb(51,51,76);
                    prevButton.ForeColor = Color.Gainsboro;
                    prevButton.Font = new System.Drawing.Font("Myanmar Text", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mainPanelTimer.Start();
            //childForm.Close();
        }

        private void mainPanelTimer_Tick(object sender, EventArgs e)
        {
            if (sideBarExpand)
            {
                menuPanel.Width -= 20;
                if (menuPanel.Width == menuPanel.MinimumSize.Width)
                {
                    menuButton.Tag = menuButton.Text;
                    menuButton.Text = "";
                    dateLabel.Visible = false;
                    foreach (Control prevButton in menuPanel.Controls)
                    {
                        if (prevButton.GetType() == typeof(Button))
                        {
                            prevButton.Tag = prevButton.Text;
                            prevButton.Text = "";
                        }
                    }
                    sideBarExpand = false;
                    mainPanelTimer.Stop();
                }
            }
            else
            {
                menuPanel.Width += 20;
               
                if (menuPanel.Width == menuPanel.MaximumSize.Width)
                {
                    menuButton.Text = menuButton.Tag?.ToString();
                    dateLabel.Visible = true;
                    foreach (Control prevButton in menuPanel.Controls)
                    {
                        if (prevButton.GetType() == typeof(Button))
                        {
                            prevButton.Text = prevButton.Tag?.ToString();
                        }
                    }
                    sideBarExpand = true;
                    mainPanelTimer.Stop();
                }
            }
        }

        private void dateTimeTimer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToString();
        }

        private void OpenChildForm(Form form)
        {
            if(childForm != null)
            {
                childForm.Close();
            }
            childForm = form;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new ExcellForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new TxtToDBForm());
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Settings());
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (childForm != null)
            {
            childForm.Close();
            }
        }
    }
}
