using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _connectMySQL;
using _encryption;
using MySql.Data.MySqlClient;

namespace CliniQ
{
    public partial class fMainMenu : Form
    {
        /*
         * ============================ LOG ========================================
         * ****** 16-08-2016:
         *          1.  Add Dynamic ToolStripMenuItem: ToolStripMenuItems will be generated on startup and based on 
         *              user privilege. Credit to http://stackoverflow.com/questions/1757574/dynamically-adding-toolstripmenuitems-to-a-menustrip-c-winforms
         *              user: http://stackoverflow.com/users/116176/jasonh
         *          2.  Add Dynamic event handler: Event handler that handling generated ToolStripMenuItems will be generated 
         *              on startup and based on generated ToolStripMenuItems.
         *              Credit to: http://stackoverflow.com/questions/1531594/c-sharp-dynamically-add-event-handler
         *              user: http://stackoverflow.com/users/13198/thevillageidiot
         *          3.  Add new container "LOCAL_CLASS" that contain locally created class.
         *          4.  Add new local class that cointain routine calles function.
         * 
         */

        #region KOMPONEN WAJIB
        readonly CConnection _connect = new CConnection();
        private LOCAL_CLASS.CMisc _misc_tools = new LOCAL_CLASS.CMisc();
        private MySqlConnection _connection;
        private string _sqlQuery;
        private readonly string _configurationManager = Properties.Settings.Default.Setting;
        #endregion

        private class Menus
        {
            private int id;
            private string name;
            private string text;
            private string tag;

            public Menus(int id, string name, string text, string tag)
            {
                this.id = id;
                this.name = name;
                this.text = text;
                this.tag = tag;
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string Text
            {
                get { return text; }
                set { text = value; }
            }

            public string Tag
            {
                get { return tag; }
                set { tag = value; }
            }

            public int Id
            {
                get { return id; }
                set { id = value; }
            }
        }

        List<Menus> _Menus = new List<Menus>();
        //List<ListViewItem> _listViewItems = new List<ListViewItem>(); << maybe will be used in another class

        public fMainMenu()
        {
            InitializeComponent();
        }

        private void PopulateMenu()
        {
            string errMsg = "";
            _sqlQuery = "";
            _connection = _connect.Connect(_configurationManager, ref errMsg, "123");
            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
                return;
            }

            _sqlQuery = "select * from t_menu";
            MySqlDataReader reader = _connect.Reading(_sqlQuery, _connection, ref errMsg);
            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
                return;
            }

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _Menus.Add(new Menus(Convert.ToInt16(reader[0]), reader[1].ToString(), reader[2].ToString(), 
                        reader[3].ToString()));
                }
                reader.Close();
            }
            _connection.Close();
        }

        private void BuildMenuItems()
        {
            //ToolStripMenuItem[] items = new ToolStripMenuItem[2]; // You would obviously calculate this value at runtime
            //for (int i = 0; i < items.Length; i++)
            //{
            //    items[i] = new ToolStripMenuItem();
            //    items[i].Name = "dynamicItem" + i.ToString();
            //    items[i].Tag = "specialDataHere";
            //    items[i].Text = "Visible Menu Text Here";
            //    items[i].Click += new EventHandler(MenuItemClickHandler);
            //}
            //loginToolStripMenuItem.DropDownItems.AddRange(items);
            //string errMsg = "";
            //_sqlQuery = "";
            //_connection = _connect.Connect(_configurationManager, ref errMsg, "123");
            //if (errMsg != "")
            //{
            //    MessageBox.Show(errMsg);
            //    return;
            //}

            //_sqlQuery = "select count(id) from t_menu";

            //int rowsCount = _misc_tools.RowsCounter(_sqlQuery, _connection, ref errMsg);
            //if (errMsg != "")
            //{
            //    MessageBox.Show(errMsg);
            //    return;
            //}
            ToolStripMenuItem items = new ToolStripMenuItem();
            var query = (from i in _Menus select i); //where i.Tag == "clinic" select i);
            foreach (var linqResult in query)
            {
                items = new ToolStripMenuItem();
                items.Name = linqResult.Name;
                items.Text = linqResult.Text;
                items.Tag = linqResult.Tag;
                //items[i].Click += new EventHandler(MenuItemClickHandler);
                items.Click += new EventHandler(toolStripClick);
                if (linqResult.Tag == "clinic")
                    mainCourseToolStripMenuItem.DropDownItems.Add(items);
                else if (linqResult.Tag == "tools")
                    toolsToolStripMenuItem.DropDownItems.Add(items);
            }

            //ToolStripMenuItem items = new ToolStripMenuItem(); // You would obviously calculate this value at runtime
            //    items = new ToolStripMenuItem();
            //    items.Name = "dynamicItem";
            //    items.Tag = "specialDataHere";
            //    items.Text = "Visible Menu Text Here";
            //    items.Click += new EventHandler(MenuItemClickHandler);
            //loginToolStripMenuItem.DropDownItems.Add(items);
        }

        private void toolStripClick(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            if (item.Name == "DoctorTSMI")
            {
                Form form1 = new Form();
                form1.StartPosition = FormStartPosition.CenterScreen;
                form1.Text = "asdasdasdas";
                form1.Show();
            }
            MessageBox.Show(item.Text);
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            // Take some action based on the data in clickedItem
            MessageBox.Show("Test");
        }

        private void fMainMenu_Load(object sender, EventArgs e)
        {
            PopulateMenu();
            BuildMenuItems();
        }
    }
}
