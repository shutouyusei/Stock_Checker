using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stock_Checker
{
    internal class ShowGraph
    {
        public  void graph(string  stock_code) {
            Show_stock show_Stock = new Show_stock();
            string[,] csv_data = show_Stock.Read_csv(stock_code);

        }
    }
}
