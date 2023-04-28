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
        }
        private void ShowGraph( int[] Y)
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
            chart1.Series["open"].BorderWidth = 2-x/100;
            //グラフの種類を折れ線グラフにする
            chart1.Series["open"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //データの取得
            Show_stock show_Stock = new Show_stock();
            DateTime[] date = show_Stock.Get_date(code);

            for (int i = 0; i < x * date.Length / 100; i++)
            {
                //グラフに表示するデータを追加
                chart1.Series["open"].Points.AddXY(date[i], Y[i]);
            }
            //windowsフォームチャートを表示

            //データを追加

        }

        void call_show()
        {
            Show_stock show_Stock = new Show_stock();

            switch (Y_Combo1.SelectedItem)
            {
                case "Open":
                    int[] open = show_Stock.Get_open(code);
                    ShowGraph(open);
                    break;
                case "High":
                    int[] high = show_Stock.Get_High(code);
                    ShowGraph( high);
                    break;
                case "Low":
                    int[] low = show_Stock.Get_Low(code);
                    ShowGraph( low);
                    break;
                case "Close":
                    int[] close = show_Stock.Get_Close(code);
                    ShowGraph( close);
                    break;
                case "Volume":
                    int[] volume = show_Stock.Get_Volume(code);
                    ShowGraph( volume);
                    break;
                default:
                    break;
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
        }
    }
}
