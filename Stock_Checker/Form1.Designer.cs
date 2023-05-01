using Stock_Checker;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Stock_Checker
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        int X = 100;
        //何回呼ばれたか
        int howmany = 0;
        void ShowGraph(string[] Y, string series, string code, string text,int x,int y)
        {
            //チャートを追加
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart2.Add(new System.Windows.Forms.DataVisualization.Charting.Chart());
            //this.chart2[0] = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartArea1.Name = "ChartArea1";
            this.chart2[howmany].ChartAreas.Add(chartArea1);
            legend1.Name = code;
            this.chart2[howmany].Legends.Add(legend1);
            this.chart2[howmany].Location = new System.Drawing.Point(x, y);
            this.chart2[howmany].Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = series;
            this.chart2[howmany].Series.Add(series1);
            this.chart2[howmany].Size = new System.Drawing.Size(300, 300);
            this.chart2[howmany].TabIndex = 4;
            this.chart2[howmany].Text = text;
            this.chart2[howmany].MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart2_MouseDown);
            this.chart2[howmany].MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart2_MouseMove);
            this.chart2[howmany].MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart2_MouseUp);
            //チャート の表示
            chart2[howmany].Series.Clear();
            chart2[howmany].Titles.Clear();
            chart2[howmany].ChartAreas.Clear();
            //チャートエリアの作成
            chart2[howmany].ChartAreas.Add("ChartArea1");
            //グラフタイトルの作成
            chart2[howmany].Titles.Add(text);
            //グラフの種類を指定    
            chart2[howmany].Series.Add(series);
            chart2[howmany].Series[series].BorderWidth = 2 - X / 100;
            //グラフの種類を折れ線グラフにする
            chart2[howmany].Series[series].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //データの取得
            Show_stock show_Stock = new Show_stock();
            DateTime[] date = show_Stock.Get_date(code);
          
            for (int i = 0; i < X * date.Length / 100; i++)
            {
                //グラフに表示するデータを追加
                chart2[howmany].Series[series].Points.AddXY(date[i], Y[i]);
            }
            //windowsフォームチャートを表示
            this.Controls.Add(this.chart2[howmany]);
            //Console.WriteLine(this.Controls.Count);
            Console.WriteLine(howmany);
            Console.WriteLine(chart2[howmany].Text);
            Form1_Load(this, EventArgs.Empty);
            //Console.WriteLine("success");
            howmany++;
        }

        //(Y軸の種類、銘柄コード、チャートのタイトル)
        public void call_show(string Y, string code, string text,string x,string y)
        {
            int x1 = int.Parse(x);
            int y1 = int.Parse(y);
            Show_stock show_Stock = new Show_stock();
            switch (Y)
            {
                case "Open":
                    string[] open = show_Stock.Get_open(code);
                    ShowGraph(open, "Open", code, text,x1,y1);
                    break;
                case "High":
                    string[] high = show_Stock.Get_High(code);
                    ShowGraph(high, "High", code, text, x1, y1);
                    break;
                case "Low":
                    string[] low = show_Stock.Get_Low(code);
                    ShowGraph(low, "Low", code, text, x1, y1);
                    break;
                case "Close":
                    string[] close = show_Stock.Get_Close(code);
                    ShowGraph(close, "Close", code, text, x1, y1);
                    break;
                case "Volume":
                    string[] volume = show_Stock.Get_Volume(code);
                    ShowGraph(volume, "Volume", code, text, x1, y1);
                    break;
                default:
                    break;
            }
        }
        
        
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.Stock_code_text = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(802, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Stock_code_text
            // 
            this.Stock_code_text.AllowDrop = true;
            this.Stock_code_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Stock_code_text.Location = new System.Drawing.Point(696, 31);
            this.Stock_code_text.MaxLength = 4;
            this.Stock_code_text.Name = "Stock_code_text";
            this.Stock_code_text.Size = new System.Drawing.Size(100, 19);
            this.Stock_code_text.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.編集ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(889, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 編集ToolStripMenuItem
            // 
            this.編集ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.追加ToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            this.編集ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.編集ToolStripMenuItem.Text = "編集";
            // 
            // 追加ToolStripMenuItem
            // 
            this.追加ToolStripMenuItem.Name = "追加ToolStripMenuItem";
            this.追加ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.追加ToolStripMenuItem.Text = "追加";
            this.追加ToolStripMenuItem.Click += new System.EventHandler(this.追加ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.削除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            this.削除ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.削除ToolStripMenuItem.Text = "削除";
            this.削除ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 489);
            this.Controls.Add(this.Stock_code_text);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion    
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Stock_code_text;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 追加ToolStripMenuItem;
        private List<Chart> chart2=new List<Chart>();
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
    }
}