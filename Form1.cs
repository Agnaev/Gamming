using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gamming
{
    public partial class Form1 : Form
    {
        private int state;
        private int A { get; }
        private int b { get; }
        private int C { get; }
        private int M { get; }
        private int T0 { get; }

        public Form1()
        {
            InitializeComponent();
            state = 1;
            A = 5;
            C = 3;
            b = 8;
            M = (int)Math.Pow(2, b);
            T0 = 7;
        }

        private int T(int t)
        {
            return (A * t + C) % M;
        }

        private int H(char c)
        {
            int res = 0;
            for (byte i = 0; i < 32; i++)
            {
                if ((1 & (c >> i)) > 0)
                {
                    res++;
                }
            }

            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case 1://Зашифровать
                    {
                        //groupBox1.Text = “Криптограмма“;
                        button1.Text = "Расшифровать";
                        SetChars(crypt(GetChars(), true));
                        state = 2;
                        break;
                    }
                case 2://Расшифровать
                    {
                        //groupBox1.Text = “Исходный текст“;
                        button1.Text = "Зашифровать";
                        SetChars(crypt(GetChars(), false));
                        state = 1;
                        break;
                    }
            }
        }

        private char[] GetChars()
        {
            return textBox1.Text.ToCharArray();
        }

        private void SetChars(char[] c)
        {
            textBox1.Clear();
            textBox1.Text = new string(c);
        }

        private char[] crypt(char[] msg, bool f)
        {
            int oldh = T0;
            char[] res = new char[msg.Length];
            for (int i = 0; i < msg.Length; i++)
            {
                res[i] = (char)(T(oldh) ^ msg[i]);
                oldh = H(f ? msg[i] : res[i]);
            }
            return res;
        }
    }
}
