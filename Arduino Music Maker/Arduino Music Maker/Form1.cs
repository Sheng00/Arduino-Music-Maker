using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arduino_Music_Maker
{
    
    public partial class Form1 : Form
    {
        public static List<int> durations = new List<int>();
        public static List<int> freqs = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            durations.Add(int.Parse(durLabel.Text));
            freqs.Add(int.Parse(curFreq.Text));

            label4.Text = durations.Count().ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            durLabel.Text = (trackBar1.Value).ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            durLabel.Text = (trackBar1.Value * 10).ToString();
            if (progressBar1.Value < 101)
            {
                progressBar1.Value = trackBar1.Value / 10;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            curFreq.Text = "255";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            curFreq.Text = "235";

        }

        private void button15_Click(object sender, EventArgs e)
        {
            curFreq.Text = "220";

        }

        private void button14_Click(object sender, EventArgs e)
        {
            curFreq.Text = "200";

        }

        private void button13_Click(object sender, EventArgs e)
        {
            curFreq.Text = "180";


        }

        private void button12_Click(object sender, EventArgs e)
        {
            curFreq.Text = "150";

        }

        private void button11_Click(object sender, EventArgs e)
        {
            curFreq.Text = "120";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            curFreq.Text = "100";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            curFreq.Text = "80";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            curFreq.Text = "60";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            curFreq.Text = "30";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            curFreq.Text = "15";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            curFreq.Text = "0";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string data = "Frequencies: " + Environment.NewLine;
            foreach(int freq in freqs)
            {
                data += freq + ",";
            }
            data += Environment.NewLine + Environment.NewLine;
            data += "Durations: " + Environment.NewLine;
            foreach(int dur in durations)
            {
                data += dur + ",";
            }
            data += Environment.NewLine + Environment.NewLine;
            data += "Notes Count: " + label4.Text;
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\Data.txt", data);
            Process.Start(Directory.GetCurrentDirectory() + @"\Data.txt");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach(int num in freqs)
            {
                
                if(num == 255)
                {
                    Play("255.wav", index);
                }
                else if(num == 235)
                {
                    Play("235.wav", index);
                }
                else if(num == 220)
                {
                    Play("220.wav", index);
                }
                else if(num == 200)
                {
                    Play("200.wav", index);
                }
                else if(num == 180)
                {
                    Play("180.wav", index);
                }
                else if(num == 150)
                {
                    Play("150.wav", index);
                }
                else if(num == 120)
                {
                    Play("120.wav", index);
                }
                else if(num == 100)
                {
                    Play("100.wav", index);
                }
                else if(num == 80)
                {
                    Play("80.wav", index);
                }
                else if(num == 60)
                {
                    Play("60.wav", index);
                }
                else if(num == 15 || num == 30)
                {
                    Play("30.wav", index);
                }
                index++;
            }
        }

        public void Play(string loc, int index)
        {
            string dir = Directory.GetCurrentDirectory() + @"\Sounds\";
            SoundPlayer snd = new SoundPlayer();
            snd.SoundLocation = dir + loc;
            snd.Load();

            int time = durations[index];

            Stopwatch sw = new Stopwatch();
            sw.Start();
            snd.PlayLooping();
            while(sw.ElapsedMilliseconds != time)
            {

            }
            snd.Stop();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            durations.Clear();
            freqs.Clear();
            label4.Text = "0";
        }
    }
}
