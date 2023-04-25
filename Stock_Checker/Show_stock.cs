using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Checker
{
    internal class Show_stock
    {
        //csvファイルを読み取るメソッド
        public string[,] Read_csv(string stock_code)
        {
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            //csvファイルのパスを取得
            string csv_path = currentDirectory + "/csv_stock_data/s_stock_data_" + stock_code + ".csv";
            //csvファイルを読み取る
            string[] csv_data = System.IO.File.ReadAllLines(csv_path);
            //csvファイルの行数を取得
            int csv_data_length = csv_data.Length;
            //csvファイルの列数を取得
            int csv_data_width = csv_data[0].Split(',').Length;
            //csvファイルのデータを格納する配列を宣言
            string[,] csv_data_array = new string[csv_data_length, csv_data_width];
            //csvファイルのデータを配列に格納
            for (int i = 0; i < csv_data_length; i++)
            {
                string[] csv_data_array_temp = csv_data[i].Split(',');
                for (int j = 0; j < csv_data_width; j++)
                {
                    csv_data_array[i, j] = csv_data_array_temp[j];
                }
            }
            //csvファイルのデータを表示
            //for (int i = 0; i < csv_data_length; i++)
            //{
            //    for (int j = 0; j < csv_data_width; j++)
            //    {
            //        Console.Write(csv_data_array[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            return csv_data_array;
        }

        //DateTImeを取得する

        public DateTime[] Get_date(string stock_code)
        {
            string[,] csv_data=Read_csv(stock_code);
            //Console.WriteLine(csv_data.GetLength(0));
            DateTime[] data = new DateTime[csv_data.GetLength(0)-1];
            for (int i = 1; i < csv_data.GetLength(0); i++)
            {
                //Console.WriteLine( DateTime.Parse(csv_data[i, 0]));
                data[i-1] =DateTime.Parse(csv_data[i, 0]);
            }
            //Console.WriteLine(data);
            return data;
        }

        public int[] Get_open(string stock_code)
        {
            string[,] csv_data = Read_csv(stock_code);
            //Console.WriteLine(csv_data.GetLength(0));
            int[] open = new int[csv_data.GetLength(0) - 1];
            for (int i = 1; i < csv_data.GetLength(0); i++)
            {
                //Console.WriteLine(Int32.Parse(csv_data[i, 2]));
                open[i - 1] = Int32.Parse(csv_data[i, 2]);
            }
            //Console.WriteLine(data);
            return open;
        }
        public int[] Get_High(string stock_code)
        {
            string[,] csv_data = Read_csv(stock_code);
            //Console.WriteLine(csv_data.GetLength(0));
            int[] high = new int[csv_data.GetLength(0) - 1];
            for (int i = 1; i < csv_data.GetLength(0); i++)
            {
                //Console.WriteLine(Int32.Parse(csv_data[i, 3]));
                high[i - 1] = Int32.Parse(csv_data[i, 3]);
            }
            //Console.WriteLine(data);
            return high;
        }
    }
}
