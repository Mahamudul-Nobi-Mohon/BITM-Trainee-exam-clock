using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ExamTimpeShowForBITM
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer t;
        private int h;
        private int m;
        private int s = 60;

        public Form1()
        {
            InitializeComponent();
        }

        private void startTimeButton_Click(object sender, EventArgs e)
        {
            try
            {
                 remainingTimeLabel.Text = "00:00:00";
            
                int input = Convert.ToInt32(startTimeTextBox.Text);
           
                m = input - 1;

                if (remainingTimeLabel.Text == "00:00:00")
                {

                    t.Start();
                    startTimeButton.Enabled = false;
                }
            
            }
            catch (Exception)
            {

                MessageBox.Show("Please set a start time.");
            }
           
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            if (m > -1)
            {
                Invoke(new Action(() =>
                {
                    s -= 1;
                    if (s == 0)
                    {
                        s = 60;
                        m -= 1;

                    }
                   
                    if (m == -1 || m < -1)
                    {
                        remainingTimeLabel.Text = "00:00:00";
                        remainingTimeLabel.ForeColor = Color.Red;
                       
                    }
                    else
                    {
                        remainingTimeLabel.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'),
                            m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                        remainingTimeLabel.ForeColor = Color.Green;
                    }
                }));
            }

            if (m == -1 || m < -1)
            {
                s = 0;
                t.Stop();
                MessageBox.Show("Please Stop Writing. ", "Time Elapsed");
               
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
            Application.DoEvents();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            s = 60;
            m = 0;
            h = 0;
            remainingTimeLabel.Text = "00:00:00";
            startTimeButton.Enabled = true;
            t.Stop();
            Application.DoEvents();
        }

        

    }


}
