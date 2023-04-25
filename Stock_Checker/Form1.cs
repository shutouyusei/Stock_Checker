using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Stock_Checker
{
    public partial class Form1 : Form
    {

        [System.Runtime.InteropServices.DllImport("kernel32.dll")] // この行を追加
        private static extern bool AllocConsole();                 // この行を追加
        public Form1()
        {
            InitializeComponent();
            AllocConsole(); //デバック用
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stock_code=Stock_code_text.Text;
            if (stock_code.Length == 4)
            {
                int code;
                if(int.TryParse(stock_code, out code))
                {
                    //現在のディレクトリを取得
                    string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                    //Console.WriteLine(currentDirectory);

                    ProcessStartInfo startInfo = new ProcessStartInfo(currentDirectory+"/Stock_data/Fetch_stock_py.exe");
                    startInfo.WindowStyle = ProcessWindowStyle.Normal;
                    //ユーザーからの引数を用いてexe発行
                    startInfo.Arguments=stock_code;
                    Process.Start(startInfo);
                }

            }
        }
    }
}
