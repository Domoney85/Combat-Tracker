using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combat_Tracker
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            InitializeFileListView();
        }

        private void InitializeFileListView()
        {
            //fileListView.Scrollable = true;
            fileListView.View = View.Details;
            fileListView.HeaderStyle = ColumnHeaderStyle.None;

            ColumnHeader header = new ColumnHeader();
            header.Text = "test header";
            header.Name = "col1";
            fileListView.Columns.Add(header);
            fileListView.Items.AddRange(new ListViewItem[]
            {
                new ListViewItem("item1", 0),
                new ListViewItem("item2", 1)
            });
        }
    }
}
