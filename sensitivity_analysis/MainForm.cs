using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sensitivity_analysis
{
    public partial class MainForm : Form
    {
        private Button activeButton;
        private Form activePage;
        public MainForm()
        {
            InitializeComponent();
        }

        private void ChangeActiveButton(object btnSender)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = Color.FromArgb(51, 82, 107);
            }
            activeButton = (Button)btnSender;
            activeButton.BackColor = Color.FromArgb(61, 98, 128);
        }

        private void OpenPage(Form page, object btnSender)
        {
            if (activePage != null)
            { 
                activePage.Close();
            }
            activePage = page;
            page.TopLevel = false;
            page.FormBorderStyle = FormBorderStyle.None;
            page.Dock = DockStyle.Fill;
            this.pageDisplay.Controls.Add(page);
            this.pageDisplay.Tag = page;
            page.BringToFront();
            page.Show();
        }
        private void btn2vars_Click(object sender, EventArgs e)
        {
            ChangeActiveButton(sender);
            this.Size = new Size(650+220, 600);
            OpenPage(new Pages._2vars(), sender);
        }

        private void btn3vars_Click(object sender, EventArgs e)
        {
            ChangeActiveButton(sender);
            this.Size = new Size(650 + 220, 740);
            OpenPage(new Pages._3vars(), sender);
        }
    }
}
