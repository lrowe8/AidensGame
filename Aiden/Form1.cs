using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aiden
{
    public partial class Form1 : Form
    {
        Button m_button;
        public Form1()
        {
            InitializeComponent();

            /*m_button = new Button();
            m_button.Location = new Point(20, 20);
            m_button.Height = 50;
            m_button.Width = 50;
            m_button.Text = "Hello";
            m_button.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(Form1_PreviewKeyDown);
            m_button.KeyDown += new System.Windows.Forms.KeyEventHandler(Form1_KeyDown);
            Controls.Add(m_button);*/
            //Bitmap bmp = new Bitmap(Properties.Resources.background);
            //Graphics.DrawImage(bmp, 60, 10);
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
                default:
                    e.IsInputKey = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int leftPos = m_button.Location.X;
            int topPos = m_button.Location.Y;

            switch(e.KeyCode)
            {
                case Keys.Left:
                    leftPos -= 5;
                    break;
                case Keys.Right:
                    leftPos += 5;
                    break;
                case Keys.Up:
                    topPos -= 5;
                    break;
                case Keys.Down:
                    topPos += 5;
                    break;
            }

            m_button.Location = new Point(leftPos, topPos);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(Properties.Resources.background);
            Graphics g = Graphics.FromImage(bmp);
            float bmpHeight = (float)bmp.Height;
            float bmpWidth = (float)bmp.Width;

            float formHeight = ((float)ClientRectangle.Height / 2.0f);
            int newbmpHeight = (int)formHeight;
            int newBmpWidth = (int)(formHeight * (bmpWidth / bmpHeight));

            Graphics graphicsObj = e.Graphics;
            graphicsObj.DrawImage(bmp, 0, formHeight, newBmpWidth, newbmpHeight);
            graphicsObj.Dispose();
        }
    }
}
