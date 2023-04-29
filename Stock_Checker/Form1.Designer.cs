using System;
using System.Windows.Forms.DataVisualization.Charting;

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
        int x = 100;
        void ShowGraph(string[] Y, string series, string code, string text)
        {
            //チャートを追加
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(100, 149);
            this.chart2.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(300, 300);
            this.chart2.TabIndex = 4;
            this.chart2.Text = "chart1";
            //チャート の表示
            chart2.Series.Clear();
            chart2.Titles.Clear();
            chart2.ChartAreas.Clear();
            //チャートエリアの作成
            chart2.ChartAreas.Add("ChartArea1");
            //グラフタイトルの作成
            chart2.Titles.Add(text);
            //グラフの種類を指定

            chart2.Series.Add(series);
            chart2.Series[series].BorderWidth = 2 - x / 100;
            //グラフの種類を折れ線グラフにする
            chart2.Series[series].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //データの取得
            Show_stock show_Stock = new Show_stock();
            DateTime[] date = show_Stock.Get_date(code);

            for (int i = 0; i < x * date.Length / 100; i++)
            {
                //グラフに表示するデータを追加
                chart2.Series[series].Points.AddXY(date[i], Y[i]);
            }
            //windowsフォームチャートを表示
            this.Controls.Add(this.chart2);
            //Console.WriteLine(this.Controls.Count);
            Form1_Load(this, EventArgs.Empty);
            Console.WriteLine("success");

        }

        //(Y軸の種類、銘柄コード、チャートのタイトル)
        public void call_show(string Y, string code, string text)
        {
            Show_stock show_Stock = new Show_stock();
            switch (Y)
            {
                case "Open":
                    string[] open = show_Stock.Get_open(code);
                    ShowGraph(open, "Open", code, text);
                    break;
                case "High":
                    string[] high = show_Stock.Get_High(code);
                    ShowGraph(high, "High", code, text);
                    break;
                case "Low":
                    string[] low = show_Stock.Get_Low(code);
                    ShowGraph(low, "Low", code, text);
                    break;
                case "Close":
                    string[] close = show_Stock.Get_Close(code);
                    ShowGraph(close, "Close", code, text);
                    break;
                case "Volume":
                    string[] volume = show_Stock.Get_Volume(code);
                    ShowGraph(volume, "Volume", code, text);
                    break;
                default:
                    break;
            }
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.Stock_code_text = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
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
            this.追加ToolStripMenuItem});
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
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(554, 227);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(335, 247);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 489);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.Stock_code_text);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion    
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Stock_code_text;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 追加ToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}

