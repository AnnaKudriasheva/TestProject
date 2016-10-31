using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChildWindows
{
    public partial class ChildForm : Form
    {
        int sort = 0;
        int barCount = 30;
        int[] arr = new int[30];
       

        void SlowSort()
        {
            for (int t = 0; t <= 100; t++)
            {
                int temp;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    Thread.Sleep(100);
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i] > arr[j])
                        {
                            temp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
                return;
            }
            
        }

        void QuickSort()
        {
            for (int t = 0; t <= 100; t++)
            {
                int j;
                int step = arr.Length / 2;
                while (step > 0)
                {
                    Thread.Sleep(100);
                    for (int i = 0; i < (arr.Length - step); i++)
                    {
                        j = i;
                        while ((j >= 0) && (arr[j] > arr[j + step]))
                        {
                            int tmp = arr[j];
                            arr[j] = arr[j + step];
                            arr[j + step] = tmp;
                            j -= step;
                        }
                    }
                    step = step / 2;
                }
                return;
            }
        }

        public ChildForm(ParentForm form)
        {
            InitializeComponent();
            this.MdiParent = form;
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, 100);
            }
        }

        public ChildForm(ParentForm form, int quickSort)
        {
            sort = quickSort;
            InitializeComponent();
            this.MdiParent = form;
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, 100);
            }
        }
        
        private void ChildForm_Shown(object sender, EventArgs e)
        {
            if (sort == 1)
            {
                Thread t = new Thread(QuickSort);
                t.Start();
            }
            else
            {
                Thread t = new Thread(SlowSort);
                t.Start();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        Pen b = new Pen(Color.Blue, 2);

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            int h = pictureBox1.Height;
            int w = pictureBox1.Width;

            int wBar = w / barCount;
            for (int i = 0; i < barCount; i++)
            {
                {
                    int length = arr[i];
                    e.Graphics.DrawRectangle(b, wBar * i, h - length, wBar / 2, length);
                }

            }
        }
    }
}
