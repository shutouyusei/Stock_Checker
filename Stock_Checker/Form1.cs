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
using System.Text.Json;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            ShowGraph();
        }
        //chartを作成
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now + " Form1_Load");
        }
        private void ShowGraph()
        {
            //jsonファイルを読み取る
            string json_file = System.IO.File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "/Graph.json");
            //Console.WriteLine(json_file);
            //jsonファイルをデシリアライズ
            var graphs = JsonSerializer.Deserialize<Dictionary<string, string>>(json_file);
            foreach (var item in graphs)
            {
                //    Console.WriteLine("{0}", item.Key);
                //    Console.WriteLine("{0}", item.Value);
                //item.Valueを","で分割"
                string[] values = item.Value.Split(',');
                //Console.WriteLine(values[0]);
                call_show(values[0], values[1], values[2], values[3], values[4]);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string stock_code = Stock_code_text.Text;
            if (stock_code.Length == 4)
            {
                int code;
                if (int.TryParse(stock_code, out code))
                {

                    //現在のディレクトリを取得
                    string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                    //Console.WriteLine(currentDirectory);

                    ProcessStartInfo startInfo = new ProcessStartInfo(currentDirectory + "/Stock_data/Fetch_stock_py.exe");
                    //現在はデバックのためWindowStyleをNormalに設定->Hiddenに変える
                    startInfo.WindowStyle = ProcessWindowStyle.Normal;
                    //ユーザーからの引数を用いてexe発行
                    startInfo.Arguments = stock_code;
                    Process p = Process.Start(startInfo);
                    p.WaitForExit();

                    Show_stock show_Stock = new Show_stock();
                    //string[,] csv_data =show_Stock.Read_csv(stock_code);
                    //int[] open = show_Stock.Get_Volume(stock_code);

                }

            }
        }

        private void 追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //新しいフォームを開く
            Graph f = new Graph();
            f.Show();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        //チャートドラッグの処理

        bool _isDraging = false;
        Point? _diffPoint = null;
        Chart Chart;
        bool is_hover = false;
        private void chart2_MouseDown(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.DataVisualization.Charting.Chart chart = (System.Windows.Forms.DataVisualization.Charting.Chart)sender;
            if (e.Button == MouseButtons.Right)
            {
                //formの左端の座標
                contextMenuStrip1.Show(chart.Location.X+e.Location.X+30 + this.Location.X, chart.Location.Y + e.Location.Y + this.Location.Y);
                Chart = chart;
                return;
            }
            //サイズ変更



            System.Windows.Forms.Cursor.Current = Cursors.SizeAll;
            _isDraging = true;
            _diffPoint = e.Location;
            //Console.WriteLine(e.Location.ToString());
            //どのコントロールをクリックしたか取得
            //Console.WriteLine((System.Windows.Forms.DataVisualization.Charting.Chart)sender);
            //Console.WriteLine(e.Location.ToString());
            //Console.WriteLine(chart.Size.Width);
        }

        private void chart2_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.DataVisualization.Charting.Chart chart = (System.Windows.Forms.DataVisualization.Charting.Chart)sender;
            if (!_isDraging)
            {
                if (is_hover)
                {
                    if (e.Location.X <= 5)
                    {
                        //カーソルをサイズ変更に変更
                        System.Windows.Forms.Cursor.Current = Cursors.SizeWE;
                    }
                    else if (e.Location.X >= chart.Size.Width - 7)
                    {
                       //カーソルをサイズ変更に変更
                         System.Windows.Forms.Cursor.Current = Cursors.SizeWE;
                    }
                    else if (e.Location.Y <= 5)
                    {
                        //カーソルをサイズ変更に変更
                        System.Windows.Forms.Cursor.Current = Cursors.SizeNS;
                    }
                    else if (e.Location.Y >= chart.Size.Height - 6)
                    {
                        //カーソルをサイズ変更に変更
                        System.Windows.Forms.Cursor.Current = Cursors.SizeNS;
                    }
                    if (e.Location.X <= 5&& e.Location.Y <= 5) {
                        System.Windows.Forms.Cursor.Current = Cursors.SizeNWSE;
                    }
                    else if (e.Location.X <= 5&& e.Location.Y >= chart.Size.Height - 6)
                    {
                        System.Windows.Forms.Cursor.Current = Cursors.SizeNESW;
                    }
                    else if (e.Location.X >= chart.Size.Width - 7&& e.Location.Y <= 5)
                    {
                        System.Windows.Forms.Cursor.Current = Cursors.SizeNESW;
                    }
                    else if (e.Location.X >= chart.Size.Width - 7&& e.Location.Y >= chart.Size.Height - 6)
                    {
                        System.Windows.Forms.Cursor.Current = Cursors.SizeNWSE;
                    }

                }
                return;
            }
            int x = chart.Location.X + e.X - _diffPoint.Value.X;
            int y = chart.Location.Y + e.Y - _diffPoint.Value.Y;
            if (x <= 0) x = 0;
            if (y <= 0) y = 0;
            chart.Location = new Point(x, y);
        }

        private void chart2_MouseHover(object sender, EventArgs e)
        {
            is_hover = true;
        }
        private　void chart2_MouseLeave(object sender, EventArgs e)
        {
            is_hover = false;
        }
        private void chart2_MouseUp(object sender, MouseEventArgs e)
        {
            _isDraging = false;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dictionaryを作成
           //jsonファイルを読み取る
            string json_file = System.IO.File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "/Graph.json");
            //Console.WriteLine(json_file);
            //jsonファイルをデシリアライズ
            var graphs = JsonSerializer.Deserialize<Dictionary<string, string>>(json_file);
            //jsonクリア
            graphs.Clear();
            //listすべての座標を記録
            foreach (Chart chart in chart2)
            {
                //chartの座標を記録
                //chart.Location.X
                //chart.Location.Y
                //Json形式でchart1の情報を出力
                //code, text,Y,series

                System.Windows.Forms.DataVisualization.Charting.Series series= chart.Series[0];
                //Console.WriteLine(series.Name);
                //Console.WriteLine(series.Legend);
                string data = series.Name.ToString() + "," + series.Legend.ToString() + "," + chart.Text+","+chart.Location.X+","+chart.Location.Y;
                int num = graphs.Count();

                //追加
                graphs.Add(num.ToString(), data);
            }
            string json = JsonSerializer.Serialize(graphs);
            string Json_file_dir = System.IO.Directory.GetCurrentDirectory() + "/Graph.json";
            //jsonファイルに書き込み
            System.IO.File.WriteAllText(Json_file_dir, json);
        }

        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("削除");
            //チャートを削除
            Console.WriteLine(chart2.Remove(Chart));
            chart2.Remove(Chart);
            Chart.Dispose();
            howmany--;
        }
    }
}
