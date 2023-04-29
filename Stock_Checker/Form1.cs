﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.Json;


namespace Stock_Checker
{
    public partial class Form1 : Form
    {

        [System.Runtime.InteropServices.DllImport("kernel32.dll")] // この行を追加
        private static extern bool AllocConsole();                 // この行を追加
        public Form1()
        {
            InitializeComponent();
            // チャートの表示を初期化
            AllocConsole(); //デバック用
        }
        //chartを作成
        private　void ShowGraph()
        {
            //jsonファイルを読み取る
            string json_file = System.IO.File.ReadAllText(System.IO.Directory.GetCurrentDirectory()+"/Graph.json");
            //Console.WriteLine(json_file);
            //jsonファイルをデシリアライズ
            var graphs = JsonSerializer.Deserialize<Dictionary<string, string>>(json_file);
            foreach (var item in graphs)
            {
                Console.WriteLine("{0}", item.Key);
                Console.WriteLine("{0}", item.Value);
            }

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
                   //現在はデバックのためWindowStyleをNormalに設定->Hiddenに変える
                    startInfo.WindowStyle = ProcessWindowStyle.Normal;
                    //ユーザーからの引数を用いてexe発行
                    startInfo.Arguments=stock_code;
                    Process p=Process.Start(startInfo);
                    p.WaitForExit();

                    Show_stock show_Stock = new Show_stock();
                    //string[,] csv_data =show_Stock.Read_csv(stock_code);
                    //int[] open = show_Stock.Get_Volume(stock_code);
                }

            }
            ShowGraph();
        }

        private void 追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //新しいフォームを開く
            AddGraph_form f = new AddGraph_form();
            f.Show();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
