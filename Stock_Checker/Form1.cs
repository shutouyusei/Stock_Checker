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
            // チャートの表示を初期化
            ShowGraph();
            AllocConsole(); //デバック用
        }

        private　void ShowGraph()
        {
            //チャート の表示
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.ChartAreas.Clear();
            //チャートエリアの作成
            chart1.ChartAreas.Add("ChartArea1");
            //グラフタイトルの作成
            chart1.Titles.Add("株価");
            //グラフの種類を指定
            chart1.Series.Add("open");
            //グラフの種類を折れ線グラフにする
            chart1.Series["open"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //データの取得
            Show_stock show_Stock = new Show_stock();
            DateTime[] date= show_Stock.Get_date("7177");
            int[] open=show_Stock.Get_open("7177");
            for (int i = 0;i<date.Length;i++)
            {
                //グラフに表示するデータを追加
                chart1.Series["open"].Points.AddXY(date[i], open[i]);
            }
            //windowsフォームチャートを表示

            //データを追加

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
        }
    }
}
