using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        private ChristmasTree Christmas;
        public Form1()
        {
            InitializeComponent();
            Christmas = new ChristmasTree(canvas);
            Christmas.drawTree(0, 0);
        }

        private void canvas_Click(object sender, EventArgs e)
        {
        }

        private void CanvasPaint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
