using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CliniQ
{
    public partial class fMainMenu : Form
    {
        public fMainMenu()
        {
            InitializeComponent();
        }

        private void BuildMenuItems()
        {
            ToolStripMenuItem[] items = new ToolStripMenuItem[2]; // You would obviously calculate this value at runtime
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new ToolStripMenuItem();
                items[i].Name = "dynamicItem" + i.ToString();
                items[i].Tag = "specialDataHere";
                items[i].Text = "Visible Menu Text Here";
                items[i].Click += new EventHandler(MenuItemClickHandler);
            }

            loginToolStripMenuItem.DropDownItems.AddRange(items);
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            // Take some action based on the data in clickedItem
        }

        private void fMainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
