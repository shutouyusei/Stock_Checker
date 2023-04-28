using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Checker
{
    public partial class AddGraph_form : Form
    {
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
            //グラフの種類を折れ線グラフにする
            chart1.Series["open"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //データの取得
            Show_stock show_Stock = new Show_stock();
            DateTime[] X = show_Stock.Get_date("7177");

            for (int i = 0; i < X.Length; i++)
            {
                //グラフに表示するデータを追加
                chart1.Series["open"].Points.AddXY(X[i], Y[i]);
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
                    int[] open = show_Stock.Get_open("7177");
                    ShowGraph(open);
                    break;
                case "High":
                    int[] high = show_Stock.Get_High("7177");
                    ShowGraph(high);
                    break;
                case "Low":
                    int[] low = show_Stock.Get_Low("7177");
                    ShowGraph(low);
                    break;
                case "Close":
                    int[] close = show_Stock.Get_Close("7177");
                    ShowGraph(close);
                    break;
                case "Volume":
                    int[] volume = show_Stock.Get_Volume("7177");
                    ShowGraph(volume);
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
    }
}
