using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace points_to_score
{
    public partial class Main : Form
    {
        List<Point[]> DATA1 = new List<Point[]>();
        List<Point[]> DATA2 = new List<Point[]>();
        List<double> SCORE = new List<double>();


        public Main()
        {
            InitializeComponent();
            //Console.Write(table.points_to_angle(new Point(-1,1), new Point(0, 0), new Point(1, 1)));//radianで帰る
        }

        private void Click_data2(object sender, EventArgs e)
        {
            DATA2.Clear();
            textBox_data2.Text = "";
            string points_data = "";

            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = true,  // 複数選択の可否
                Filter = "csvファイル|*.csv|全てのファイル|*.*",
            };
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (var csv in dialog.FileNames.Select((value, index) => new { value, index }))
                {
                    var index = csv.index;
                    var value = csv.value;
                    read_csv(ref DATA2, value);

                }
            }

            foreach (Point[] points in DATA2)
            {
                foreach (Point point in points)
                {
                    points_data += "" + point.X + ',' + point.Y + ',' + '\t';
                }
                points_data += "\r\n";
            }
            textBox_data2.Text = points_data;
        }

        private void Click_data1(object sender, EventArgs e)
        {
            DATA1.Clear();
            textBox_data1.Text = "";
            string points_data = "";

            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = true,  // 複数選択の可否
                Filter = "csvファイル|*.csv|全てのファイル|*.*",
            };
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (var csv in dialog.FileNames.Select((value, index) => new { value, index }))
                {
                    var index = csv.index;
                    var value = csv.value;
                    read_csv(ref DATA1, value);

                }
            }

            foreach (Point[] points in DATA1)
            {
                foreach (Point point in points)
                {
                    points_data += "" + point.X + ',' + point.Y + ',' + '\t';
                }
                points_data += "\r\n";
            }
            textBox_data1.Text = points_data;

        }

        private void read_csv(ref List<Point[]> data, string path)
        {
            var csvRecords = new System.Collections.ArrayList();

            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(path))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream) csvRecords.Add(sr.ReadLine());
                }
                System.Diagnostics.Debug.WriteLine(path);

                foreach (string line in csvRecords)
                {
                    var values = line.Split(',');
                    int num_of_point = values.Length / 2;
                    Point[] point = new Point[num_of_point];

                    for (int i = 0; i < num_of_point; i++)
                        point[i] = new Point(int.Parse(values[i * 2]), int.Parse(values[i * 2 + 1]));

                    data.Add(point);

                }

            }
            catch (System.Exception e)// ファイルを開くのに失敗したとき
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            csvRecords = null;

        }

        private void Click_採点開始(object sender, EventArgs e)
        {
            if (DATA1.Count == DATA2.Count)
            {
                progressBar1.Maximum = DATA1.Count;
                採点処理();

            }
            else MessageBox.Show("dataの長さが違うよ！");
        }

        private void 採点処理()
        {
            SCORE.Clear();
            progressBar1.Value = 0;
            for (int i = 0; i < DATA1.Count; i++)
            {
                
                progressBar1.Value = i+1;
                var Points_t = DATA1[i];
                var Points_s = DATA2[i];
                List<int> score = new List<int>();

                角度採点(Points_t[0], Points_t[4], Points_t[1],
                         Points_s[0], Points_s[4], Points_s[1],ref score);
                角度採点(   Points_t[0], Points_t[4], Points_t[2],
                            Points_s[0], Points_s[4], Points_s[2], ref score);
                角度採点(   Points_t[2], Points_t[4], Points_t[3],
                            Points_s[2], Points_s[4], Points_s[3], ref score);
                角度採点(   Points_t[4], Points_t[0], Points_t[2],
                            Points_s[4], Points_s[0], Points_s[2], ref score);
                角度採点(   Points_t[2], Points_t[3], Points_t[4],
                            Points_s[2], Points_s[3], Points_s[4], ref score);
                角度採点(   Points_t[3], Points_t[1], Points_t[4],
                            Points_s[3], Points_s[1], Points_s[4], ref score);
                角度採点(   Points_t[4], Points_t[1], Points_t[0],
                            Points_s[4], Points_s[1], Points_s[0], ref score);

                string debug = i + ":";
                if (score.Count != 0)
                {
                    SCORE.Add(score.Average() * 10.0);
                    debug+=score.Average()+"：データ数"+score.Count;
                }

                Console.WriteLine(debug);
                score.Clear();

            }

            Console.WriteLine("総合平均スコア:"+ SCORE.Average()+":データ数:"+SCORE.Count);

        }

        void 角度採点(Point teacher1, Point teacher2, Point teacher3,
                      Point sample1, Point sample2, Point sample3, ref List<int> score)//お手本とサンプルの3座標を見て0~5点で返す
        {
            if (角度計算可否判定(teacher1, teacher2, teacher3, sample1, sample2, sample3))
            {
                double PI = 3.1416f;

                double angle_teacher = Math.Abs(table.points_to_angle(teacher1, teacher2, teacher3));//-は認めないようにする
                double angle_sample = Math.Abs(table.points_to_angle(sample1, sample2, sample3));
                double angle_diff = Math.Abs(angle_teacher - angle_sample);


                if (angle_diff < PI / 20) score.Add(10);
                else if (angle_diff < PI / 18) score.Add(9);
                else if (angle_diff < PI / 16) score.Add(8);
                else if (angle_diff < PI / 14) score.Add(7);
                else if (angle_diff < PI / 12) score.Add(6);
                else if (angle_diff < PI / 10) score.Add(5);
                else if (angle_diff < PI / 8) score.Add(4);
                else if (angle_diff < PI / 6) score.Add(3);
                else if (angle_diff < PI / 4) score.Add(2);
                else if (angle_diff < PI / 2) score.Add(1);
                else score.Add(0);

                Console.WriteLine(score[score.Count - 1]);
            }
            else { }

        }

        double points_to_distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        bool 角度計算可否判定(Point p1_t, Point p2_t, Point p3_t, Point p1_s, Point p2_s, Point p3_s)
        {
            bool 教師データ判定可否 = false;
            bool 生徒データ判定可否 = false;
            double 基準長さ = 100;

            double distance1_t = points_to_distance(p1_t, p2_t);
            double distance2_t = points_to_distance(p2_t, p3_t);

            double distance1_s = points_to_distance(p1_s, p2_s);
            double distance2_s = points_to_distance(p2_s, p3_s);

            if (distance1_t > 基準長さ && distance2_t > 基準長さ
                && p1_t.X != 0 && p2_t.X != 0 && p3_t.X != 0) 教師データ判定可否 = true;
            if (distance1_s > 基準長さ && distance2_s > 基準長さ
                 && p1_s.X != 0 && p2_s.X != 0 && p3_s.X != 0) 生徒データ判定可否 = true;

            if (教師データ判定可否 && 生徒データ判定可否) return true;

            else
            {
                string debug = "";
                debug += "skip_scoring";
                if (教師データ判定可否 == false)
                {
                    debug += "\t教師:";
                    if (distance1_t > 基準長さ || distance2_t > 基準長さ) debug += "距離:";
                    debug +="0";
                }
                if(生徒データ判定可否==false){
                    debug += "\t生徒:";
                    if (distance1_s > 基準長さ || distance2_s > 基準長さ) debug += "距離:";
                    else debug += "0";
                }
                Console.WriteLine(debug);
                return false;
            }
        }
    }
}