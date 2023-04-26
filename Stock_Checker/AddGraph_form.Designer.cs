namespace Stock_Checker
{
    partial class AddGraph_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.X_Combo = new System.Windows.Forms.ComboBox();
            this.Y_Combo1 = new System.Windows.Forms.ComboBox();
            this.Y_Combo2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(460, 257);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "y";
            // 
            // X_Combo
            // 
            this.X_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.X_Combo.FormattingEnabled = true;
            this.X_Combo.Items.AddRange(new object[] {
            "Date",
            "Open",
            "High",
            "Close",
            "Volume"});
            this.X_Combo.Location = new System.Drawing.Point(44, 293);
            this.X_Combo.Name = "X_Combo";
            this.X_Combo.Size = new System.Drawing.Size(121, 20);
            this.X_Combo.TabIndex = 5;
            this.X_Combo.SelectedIndexChanged += new System.EventHandler(this.X_Combo_SelectedIndexChanged);
            // 
            // Y_Combo1
            // 
            this.Y_Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y_Combo1.FormattingEnabled = true;
            this.Y_Combo1.Items.AddRange(new object[] {
            "Open",
            "High",
            "Close",
            "Volume"});
            this.Y_Combo1.Location = new System.Drawing.Point(44, 319);
            this.Y_Combo1.Name = "Y_Combo1";
            this.Y_Combo1.Size = new System.Drawing.Size(121, 20);
            this.Y_Combo1.TabIndex = 6;
            this.Y_Combo1.SelectedIndexChanged += new System.EventHandler(this.Y_Combo_SelectedIndexChanged);
            // 
            // Y_Combo2
            // 
            this.Y_Combo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y_Combo2.FormattingEnabled = true;
            this.Y_Combo2.Items.AddRange(new object[] {
            "Open",
            "High",
            "Close",
            "Volume"});
            this.Y_Combo2.Location = new System.Drawing.Point(195, 319);
            this.Y_Combo2.Name = "Y_Combo2";
            this.Y_Combo2.Size = new System.Drawing.Size(121, 20);
            this.Y_Combo2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "y";
            // 
            // AddGraph_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.Y_Combo2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Y_Combo1);
            this.Controls.Add(this.X_Combo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "AddGraph_form";
            this.Text = "Form2";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox X_Combo;
        private System.Windows.Forms.ComboBox Y_Combo1;
        private System.Windows.Forms.ComboBox Y_Combo2;
        private System.Windows.Forms.Label label3;
    }
}