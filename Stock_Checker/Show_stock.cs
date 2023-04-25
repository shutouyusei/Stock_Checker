using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Checker
{
    internal class Show_stock
    {
        //現在のディレクトリを取得
        private string currentDirectory = System.IO.Directory.GetCurrentDirectory();

        //csvファイルを読み取るメソッド
        public string[,] Read_csv(string stock_code)
        {
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
            for (int i = 0; i < csv_data_length; i++)
            {
                for (int j = 0; j < csv_data_width; j++)
                {
                    Console.Write(csv_data_array[i, j] + " ");
                }
                Console.WriteLine();
            }
            return csv_data_array;
        }
    }
}
