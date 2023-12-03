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
        private Timer LampTimer;

        public Form1()
        {
            InitializeComponent();
            Christmas = new ChristmasTree(canvas);
            Christmas.drawTree(0, 0);

            LampTimer = new Timer();
            LampTimer.Interval = 1000;
            LampTimer.Tick += LampTimer_Tick;
            LampTimer.Start();
        }

        private void LampTimer_Tick(object sender, EventArgs e)
        {
            Christmas.drawTree(0, 0);
        }


        private void canvas_Click(object sender, EventArgs e)
        {
        }

        private void CanvasPaint(object sender, PaintEventArgs e)
        {
            //Christmas.updateLamps();
        }

        private void radio_Click(object sender, EventArgs e)
        {
            Christmas.toggleAudio();
        }

        private void toggleStar_Click(object sender, EventArgs e)
        {
            Christmas.ifDrawStar = !Christmas.ifDrawStar;
            Christmas.drawTree(0, 0);

        }

        private void toggleBaubles_Click(object sender, EventArgs e)
        {
            Christmas.ifDrawBaubles = !Christmas.ifDrawBaubles;
            Christmas.drawTree(0, 0);

        }

        private void toggleLamps_Click(object sender, EventArgs e)
        {
            Christmas.ifDrawLamps = !Christmas.ifDrawLamps;
            Christmas.drawTree(0, 0);

        }

        private void toggleChains_Click(object sender, EventArgs e)
        {
            Christmas.ifDrawChains = !Christmas.ifDrawChains;
            Christmas.drawTree(0, 0);

        }

        private void toggleGifts_Click(object sender, EventArgs e)
        {
            Christmas.ifDrawGifts = !Christmas.ifDrawGifts;
            Christmas.drawTree(0,0);
        }
    }
}
