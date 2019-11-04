using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gamming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly char[] characters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 
                                                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                                                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                                                'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                                                'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я', 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',
                                                'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                                'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ',
                                                'э', 'ю', 'я',' ', '1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0' , '?', '.', ',', '!', '@', '#', '$', '%', 
                                                '^', '&', '*', '(', ')', '+', '=', '<', '>', '`', '!', 
                                                '\'', '"', '/', '\\', '[', ']', '{', '}', '~', '-', '\r', '\n'};

        private void Encode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                encoded.Text = XorCodingText(decoded.Text, Generate_Pseudorandom_KeyWord(decoded.Text.Length, 10));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + " " + (exc.InnerException?.InnerException?.Message ?? "no inner exc") + (exc.StackTrace ?? " no stack trace"));
            }
        }
        private string Generate_Pseudorandom_KeyWord(int length, int startSeed)
        {
            try
            {
                LCG rand = new LCG(startSeed);
                string result = "";

                for (int i = 0; i < length; i++)
                {
                    int position = rand.NextByte(characters.Length).FirstOrDefault() % characters.Length;
                    result += characters[position];
                }

                return result;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + " " + (e.InnerException?.InnerException?.Message ?? "no inner exc") + (e.StackTrace ?? " no stack trace"));
                return " ";
            }
        }

        private string XorCodingText(string input, string keyword)
        {
            int GetPosition(char elem) => Array.IndexOf(characters, elem); //get position of element from global array characters

            try
            {
                string result = "";
                int keyword_index = 0;

                foreach (char symbol in input)
                {
                    result += characters[(GetPosition(symbol) ^ GetPosition(keyword[keyword_index])) % characters.Length];
                    keyword_index = keyword_index == keyword.Length ? 0 : keyword_index++;
                }

                return result;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + " " + (e.InnerException?.InnerException?.Message ?? "no inner exc") + (e.StackTrace ?? " no stack trace"));
                return "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Count();
        }

        private class tuple
        {
            public byte Key { get; set; }
            public int Value { get; set; }

            public tuple(byte key)
            {
                this.Key = key;
                this.Value = 1;
            }

            public static bool Contains(List<tuple>tuple, byte Key)
            {
                foreach(tuple t in tuple)
                {
                    if(t.Key == Key)
                    {
                        return true;
                    }
                }
                return false;
            }

            public static void GetAverage(List<tuple> tuple)
            {
                (int, int) result = (0, 0);
                for (int count = 0; count < tuple.Count; count++)
                {
                    result.Item1 += tuple[count].Key / (count + 1);
                    result.Item2 += tuple[count].Value / (count + 1);
                }
                //return result;
                MessageBox.Show(result.Item1 + " " + result.Item2);
            }
        }

        private void Count()
        {
            LCG lcg = new LCG(1);
            List<tuple> nums = new List<tuple>();
            for(int i = 0; i < 1E6; i++)
            {
                byte rand = lcg.NextByte(255).FirstOrDefault();
                if (tuple.Contains(nums, rand))
                {
                    var xx = nums.Where(x => x.Key == rand).FirstOrDefault();
                    xx.Value += 1;
                }
                else
                {
                    nums.Add(new tuple(rand));
                }
            }
            var thread = new Thread(() => tuple.GetAverage(nums));
            thread.Start();
            using(StreamWriter writer = new StreamWriter("out.txt"))
            {
                foreach(tuple i in nums)
                {
                    writer.WriteLine($"key: {i.Key} \tvalue: {i.Value}");
                }
                writer.Close();
            }
        }
    }
}
