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
        private static extern bool AllocConsole();
        // この行を追加
        List<string>[] change_chart = new List<string>[20];
        public Form1()
        {
            InitializeComponent();
            // チャートの表示を初期化
            AllocConsole(); //デバック用
            ShowGraph();
            for (int i = 0; i < 20; i++)
            {
                change_chart[i] = new List<string>();
            }
            foreach (Chart chart in chart2)
            {
                //chartの座標を記録
                //chart.Location.X
                //chart.Location.Y
                //Json形式でchart1の情報を出力
                //code, text,Y,series

                System.Windows.Forms.DataVisualization.Charting.Series series = chart.Series[0];
                //Console.WriteLine(series.Name);
                //Console.WriteLine(series.Legend);
                string data = series.Name.ToString() + "," + series.Legend.ToString() + "," + chart.Text + "," + chart.Location.X + "," + chart.Location.Y + "," + chart.Size.Width + "," + chart.Size.Height;
                change_chart[0].Add(data);
            }
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
                call_show(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
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
        int is_sizing = 0;
        int change = 1;




        void change_list()
        {
            if (change <= 19)
            {
                for (int i = change; i < 20; i++)
                {
                    change_chart[i].Clear();
                }
                changed = 0;
                foreach (Chart chart in chart2)
                {
                    //chartの座標を記録
                    //chart.Location.X
                    //chart.Location.Y
                    //Json形式でchart1の情報を出力
                    //code, text,Y,series

                    System.Windows.Forms.DataVisualization.Charting.Series series = chart.Series[0];
                    //Console.WriteLine(series.Name);
                    //Console.WriteLine(series.Legend);
                    string data = series.Name.ToString() + "," + series.Legend.ToString() + "," + chart.Text + "," + chart.Location.X + "," + chart.Location.Y + "," + chart.Size.Width + "," + chart.Size.Height;
                    change_chart[change].Add(data);
                }
                    change++;

            }
            else
            {
                for (int i=0; i<19; i++)
                {
                    change_chart[i] = change_chart[i + 1];
                }
                change_chart[19]=new List<string>();
                Console.WriteLine("ss");
                foreach (Chart chart in chart2)
                {

                    //chartの座標を記録
                    //chart.Location.X
                    //chart.Location.Y
                    //Json形式でchart1の情報を出力
                    //code, text,Y,series

                    System.Windows.Forms.DataVisualization.Charting.Series series = chart.Series[0];
                    //Console.WriteLine(series.Name);
                    //Console.WriteLine(series.Legend);
                    string data = series.Name.ToString() + "," + series.Legend.ToString() + "," + chart.Text + "," + chart.Location.X + "," + chart.Location.Y + "," + chart.Size.Width + "," + chart.Size.Height;
                    change_chart[19].Add(data);
                }
            }
        }
        private void chart2_MouseDown(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.DataVisualization.Charting.Chart chart = (System.Windows.Forms.DataVisualization.Charting.Chart)sender;
            Chart = chart;
            if (e.Button == MouseButtons.Right)
            {
                //formの左端の座標
                contextMenuStrip1.Show(chart.Location.X+e.Location.X+30 + this.Location.X, chart.Location.Y + e.Location.Y + this.Location.Y);

                return;
            }
            //サイズ変更


            System.Windows.Forms.Cursor.Current = Cursors.SizeAll;
            _isDraging = true;
            _diffPoint = e.Location;
            if (is_hover)
            {
                if (e.Location.X <= 5)
                {
                    //カーソルをサイズ変更に変更
                    System.Windows.Forms.Cursor.Current = Cursors.SizeWE;
                    is_sizing= 1;
                }
                else if (e.Location.X >= chart.Size.Width - 7)
                {
                    //カーソルをサイズ変更に変更
                    System.Windows.Forms.Cursor.Current = Cursors.SizeWE;
                    is_sizing = 2;
                }
                else if (e.Location.Y <= 5)
                {
                    //カーソルをサイズ変更に変更
                    System.Windows.Forms.Cursor.Current = Cursors.SizeNS;
                    is_sizing = 3;
                }
                else if (e.Location.Y >= chart.Size.Height - 6)
                {
                    //カーソルをサイズ変更に変更
                    System.Windows.Forms.Cursor.Current = Cursors.SizeNS;
                    is_sizing = 4;
                }
                if (e.Location.X <= 5 && e.Location.Y <= 5)
                {
                    System.Windows.Forms.Cursor.Current = Cursors.SizeNWSE;
                    is_sizing = 5;
                }
                else if (e.Location.X <= 5 && e.Location.Y >= chart.Size.Height - 6)
                {
                    System.Windows.Forms.Cursor.Current = Cursors.SizeNESW;
                    is_sizing = 6;
                }
                else if (e.Location.X >= chart.Size.Width - 7 && e.Location.Y <= 5)
                {
                    System.Windows.Forms.Cursor.Current = Cursors.SizeNESW;
                    is_sizing = 7;
                }
                else if (e.Location.X >= chart.Size.Width - 7 && e.Location.Y >= chart.Size.Height - 6)
                {
                    System.Windows.Forms.Cursor.Current = Cursors.SizeNWSE;
                    is_sizing = 8;
                }

            }
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


            if (is_hover)
            {
                switch (is_sizing){
                    case 0:
                        int x = chart.Location.X + e.X - _diffPoint.Value.X;
                        int y = chart.Location.Y + e.Y - _diffPoint.Value.Y;
                        if (x <= 0) x = 0;
                        if (y <= 0) y = 0;
                        chart.Location = new Point(x, y);
                        return;
                    case 1:
                        Console.WriteLine(e.X);
                        //カーソルをサイズ変更に変更
                        System.Windows.Forms.Cursor.Current = Cursors.SizeWE;
                        int W1 = chart.Size.Width - e.X + _diffPoint.Value.X;
                        int H1 = chart.Size.Height;
                        if (W1 <= 10) W1 = 10;
                        if (H1<= 10) H1 = 10;
                        chart.Size = new Size(W1, H1);
                        int X1 = chart.Location.X + e.X - _diffPoint.Value.X;
                        int Y1 = chart.Location.Y;
                        if (X1 <= 0) x = 0;
                        if (Y1 <= 0) y = 0;
                        chart.Location = new Point(X1, Y1);
                        return;
                    case 2:
                        Console.WriteLine(_diffPoint.Value.X);
                        //カーソルをサイズ変更に変更
                        System.Windows.Forms.Cursor.Current = Cursors.SizeWE;
                        int W2 =  e.X;
                        int H2 = chart.Size.Height;
                        if (W2 <= 10) W2 = 10;
                        if (H2 <= 10) H2 = 10;
                        chart.Size = new Size(W2, H2);
                        return;
                    case 3:
                        //カーソルをサイズ変更に変更
                        System.Windows.Forms.Cursor.Current = Cursors.SizeNS;
                        int W3 = chart.Size.Width;
                        int H3 = chart.Size.Height - e.Y + _diffPoint.Value.Y;
                        if (W3 <= 10) W3 =10;
                        if (H3 <= 10) H3 = 10;
                        chart.Size = new Size(W3, H3);
                        int X3 = chart.Location.X;
                        int Y3 = chart.Location.Y + e.Y - _diffPoint.Value.Y;
                        if (X3 <= 0) x = 0;
                        if (Y3 <= 0) y = 0;
                        chart.Location = new Point(X3, Y3);
                        return;
                    case 4:
                        //カーソルをサイズ変更に変更
                        System.Windows.Forms.Cursor.Current = Cursors.SizeNS;
                        int W4 = chart.Size.Width;
                        int H4 = e.Y;
                        if (W4 <= 10) W4 =10;
                        if (H4 <= 10) H4 = 10;
                        chart.Size = new Size(W4, H4);
                        int X4 = chart.Location.X + e.X - _diffPoint.Value.X;
                        return;
                    case 5:
                        //カーソルをサイズ変更に変更
                        System.Windows.Forms.Cursor.Current = Cursors.SizeNWSE;
                        int W5 = chart.Size.Width - e.X + _diffPoint.Value.X;
                        int H5 = chart.Size.Height - e.Y + _diffPoint.Value.Y;
                        if (W5 <= 10) W5 =10;
                        if (H5 <= 10) H5 = 10;
                        chart.Size = new Size(W5, H5);
                        int X5 = chart.Location.X + e.X - _diffPoint.Value.X;
                        int Y5 = chart.Location.Y + e.Y - _diffPoint.Value.Y;
                        if (X5 <= 0) x = 0;
                        if (Y5 <= 0) y = 0;
                        chart.Location = new Point(X5, Y5);
                        return;
                    case 6:
                        //カーソルをサイズ変更に変更
                        System.Windows.Forms.Cursor.Current = Cursors.SizeNESW;
                        int W6= chart.Size.Width - e.X + _diffPoint.Value.X;
                        int H6 =   e.Y ;
                        if (W6 <= 10) W6 = 10;
                        if (H6 <= 10) H6 = 10;
                        chart.Size = new Size(W6, H6);
                        int X6 = chart.Location.X + e.X - _diffPoint.Value.X;
                        int Y6 = chart.Location.Y;
                        if (X6 <= 0) x = 0;
                        if (Y6 <= 0) y = 0;
                        chart.Location = new Point(X6, Y6);
                        return;
                    case 7:
                        //カーソルをサイズ変更に変更
                        System.Windows.Forms.Cursor.Current = Cursors.SizeNESW;
                        int W7 =  e.X;
                        int H7 = chart.Size.Height - e.Y + _diffPoint.Value.Y;
                        if (W7 <= 10) W7 = 10;
                        if (H7 <= 10) H7 = 10;
                        chart.Size = new Size(W7, H7);
                        int X7 = chart.Location.X;
                        int Y7 = chart.Location.Y + e.Y - _diffPoint.Value.Y;
                        if (X7 <= 0) x = 0;
                        if (Y7 <= 0) y = 0;
                        chart.Location = new Point(X7, Y7);
                        return;
                    case 8:
                        //カーソルをサイズ変更に変更
                        System.Windows.Forms.Cursor.Current = Cursors.SizeNWSE;
                        int W8 = e.X;
                        int H8 = e.Y;
                        if (W8 <= 10) W8 = 10;
                        if (H8 <= 10) H8 = 10;
                        chart.Size = new Size(W8, H8);
                        int X8 = chart.Location.X;
                        int Y8 = chart.Location.Y;
                        if (X8 <= 0) x = 0;
                        if (Y8 <= 0) y = 0;
                        chart.Location = new Point(X8, Y8);
                        return;
                }

            }

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
            is_sizing = 0;
            //元に戻すのための状態遷移の配列管理
            change_list();
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
                string data = series.Name.ToString() + "," + series.Legend.ToString() + "," + chart.Text+","+chart.Location.X+","+chart.Location.Y+","+chart.Size.Width+","+chart.Size.Height;
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
            Chart = null;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Chart!=null)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    削除ToolStripMenuItem_Click(Chart, null);
                }
            }
        }
        int changed= 0;
        private void 元に戻すToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (change >= 2)
            {
                //chartをすべて削除
                foreach (Chart chart in chart2)
                {
                    chart.Dispose();
                }
                chart2.Clear();
                howmany=0;
                foreach (string ch in change_chart[change-2])
                {
                    //appear(ch);
                    //    Console.WriteLine("{0}", item.Key);
                    //    Console.WriteLine("{0}", item.Value);
                    //item.Valueを","で分割"
                    string[] values = ch.Split(',');
                    //Console.WriteLine(values[0]);
                    call_show(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                }
                change--;
                changed++;
            }
        }

        private void 複製ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //コピー
            System.Windows.Forms.DataVisualization.Charting.Series series = Chart.Series[0];
            //Console.WriteLine(series.Name);
            //Console.WriteLine(series.Legend);
            string data = series.Name.ToString() + "," + series.Legend.ToString() + "," + Chart.Text + "," + Chart.Location.X + "," + Chart.Location.Y + "," + Chart.Size.Width + "," + Chart.Size.Height;
            Console.WriteLine(data);
            //クリップボードに追加
            Clipboard.SetText(data);
        }

        private void 切り取りToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //切り取り

        }

        private void やり直しToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (changed>0)
            {
                //chartをすべて削除
                foreach (Chart chart in chart2)
                {
                    chart.Dispose();
                }
                chart2.Clear();
                howmany = 0;
                foreach (string ch in change_chart[change])
                {
                    //appear(ch);
                    //    Console.WriteLine("{0}", item.Key);
                    //    Console.WriteLine("{0}", item.Value);
                    //item.Valueを","で分割"
                    string[] values = ch.Split(',');
                    //Console.WriteLine(values[0]);
                    call_show(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                }
                change++;
                changed--;
            }
        }
    }
}
