using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace zhuhai.util
{
    class RandomCodeGenerator
    {
        /// <summary>
        /// 得到一个随机数并且返回这个随机数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string CheckCode(ref string s)
        {
            int number;
            char code;
            //空字符串且为只读属性
            string checkCode = String.Empty;
            //新建一个随机数产生器
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                //随机产生一个整数 
                number = random.Next();
                //如果随机数是偶数 取余
                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    //如果随机数是奇数 选择从[A-Z]
                    code = (char)('A' + (char)(number % 26));
                //4个字符的组合
                checkCode += " " + code.ToString();
                s = s + code.ToString();
            }
            //返回字符串checkCode
            return checkCode;
        }

        //画出图形
        public void CodeImage(ref string s, System.Windows.Forms.PictureBox pictureBox)
        {
            //生成随机字符串
           string checkCode = this.CheckCode(ref s);
            if (checkCode == null || checkCode.Trim() == String.Empty)
                return;
            //建立一个位图文件 确立长宽
            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 8.5)), 20);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的背景噪音线
                for (int i = 0; i < 3; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
                }
                //把产生的随机数以字体的形式写入画面
                Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold));
                g.DrawString(checkCode, font, new SolidBrush(Color.Red), 2, 2);
                //画图片的前景噪音点
                for (int i = 0; i < 150; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                pictureBox.Width = image.Width;
                pictureBox.Height = image.Height;
                pictureBox.BackgroundImage = image;
            }
            catch
            {

            }
        }
    }
}
