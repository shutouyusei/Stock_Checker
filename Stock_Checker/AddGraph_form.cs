using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Checker
{
    public partial class AddGraph_form : Form
    {
        int x=100;
        string code;
       public AddGraph_form()
        {
            InitializeComponent();
            //Cssを読み取ってobj追加
            //カレントディレクトリ
            string Csv_file_dir = System.IO.Directory.GetCurrentDirectory() + "/csv_stock_data";
            //ディレクトリ内のファイルの名前をすべて取得
            string[] files = System.IO.Directory.GetFiles(Csv_file_dir);
            Console.WriteLine(files[0]);
            for (int i = 0; i < files.Length; i++)
            {
                string[] file_name = files[i].Split('\\');
                string[] file_name2 = file_name[file_name.Length - 1].Split('.');
                string file_name3 = file_name2[0].Substring(13, 4);
                this.comboBox1.Items.Add((object)file_name3);
            }
        }
        private void ShowGraph( string[] Y,string series)
        {
            //チャート の表示
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.ChartAreas.Clear();
            //チャートエリアの作成
            chart1.ChartAreas.Add("ChartArea1");
            //グラフタイトルの作成
            chart1.Titles.Add(textBox1.Text);
            //グラフの種類を指定

            chart1.Series.Add(series);
            chart1.Series[series].BorderWidth = 2-x/100;
            //グラフの種類を折れ線グラフにする
            chart1.Series[series].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //データの取得
            Show_stock show_Stock = new Show_stock();
            DateTime[] date = show_Stock.Get_date(code);

            for (int i = 0; i < x * date.Length / 100; i++)
            {
                //グラフに表示するデータを追加
                chart1.Series[series].Points.AddXY(date[i], Y[i]);
            }
            //windowsフォームチャートを表示

            //データを追加

        }

        void call_show()
        {
            Show_stock show_Stock = new Show_stock();
            if (comboBox1.SelectedItem != null)
            {
                switch (Y_Combo1.SelectedItem)
                {
                    case "Open":
                        string[] open = show_Stock.Get_open(code);
                        ShowGraph(open, "Open");
                        break;
                    case "High":
                        string[] high = show_Stock.Get_High(code);
                        ShowGraph(high, "High");
                        break;
                    case "Low":
                        string[] low = show_Stock.Get_Low(code);
                        ShowGraph(low, "Low");
                        break;
                    case "Close":
                        string[] close = show_Stock.Get_Close(code);
                        ShowGraph(close, "Close");
                        break;
                    case "Volume":
                        string[] volume = show_Stock.Get_Volume(code);
                        ShowGraph(volume, "Volume");
                        break;
                    default:
                        break;
                }
            }
        }
        private void Y_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Y_Combo1.SelectedItem != null)
            {
                call_show();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //System.Console.WriteLine(sender.ToString()+e);
            System.Console.WriteLine(trackBar1.Value.ToString());
            //System.Console.WriteLine(date[0]); 最新のデータ

            x =100-trackBar1.Value;
            call_show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            code = comboBox1.SelectedItem.ToString();
            //Console.WriteLine(code);
            call_show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Json形式でchart1の情報を出力
            //code, text,Y,series
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            call_show();
        }
    }
}
