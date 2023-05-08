using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stock_Checker
{
     class Get_stock
    {
        public void fetch_stock()
        {
            //csvファイルの取得
            //Cssを読み取ってobj追加
            //カレントディレクトリ
            string Csv_file_dir = System.IO.Directory.GetCurrentDirectory() + "/csv_stock_data";
            //ディレクトリ内のファイルの名前をすべて取得
            string[] files = System.IO.Directory.GetFiles(Csv_file_dir);
            //Console.WriteLine(files[0]);
            //ファイル名からコードを取得
            for (int i = 0; i < files.Length; i++)
            {
                string[] file_name = files[i].Split('\\');
                string[] file_name2 = file_name[file_name.Length - 1].Split('.');
                string file_name3 = file_name2[0].Substring(13, 4);
                //process.start
                //現在のディレクトリを取得
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                //Console.WriteLine(currentDirectory);

                ProcessStartInfo startInfo = new ProcessStartInfo(currentDirectory + "/Stock_data/Fetch_stock_py.exe");
                //現在はデバックのためWindowStyleをNormalに設定->Hiddenに変える
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //ユーザーからの引数を用いてexe発行
                startInfo.Arguments = file_name3;
                Process p = Process.Start(startInfo);
            }
        }


    }
}
