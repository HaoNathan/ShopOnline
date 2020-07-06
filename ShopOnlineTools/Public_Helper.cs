using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ShopOnlineTools
{
    public class PublicHelper
    {
       
        #region 方法
        /// <summary>
        /// 获取验证码图片
        /// </summary>
        /// <param name="strImageCode">验证码</param>
        /// <returns>验证码图片字节流</returns>
        public static byte[] GetImageCode(out string strImageCode)
        {
            strImageCode = string.Empty;

            #region 定义变量
            //随机数对象
            Random objRandom = new Random();

            //随机数字
            int intRandomNum = 0;
            #endregion

            #region 获取验证码
            for (int i = 0; i < 4; i++)
            {
                intRandomNum = objRandom.Next(0, 10);

                strImageCode += intRandomNum.ToString();
            }
            #endregion

            #region 获取验证码图片

            #region 设置图片
            //创建空白图片
            Bitmap image = new Bitmap(55, 23);

            //创建绘画对象
            Graphics objGraph = Graphics.FromImage(image);

            //设置绘画画面
            objGraph.Clear(Color.White);
            #endregion

            #region 绘画内容
            objRandom = new Random();

            //输出噪点
            for (int i = 0; i < 100; i++)
            {
                int x = objRandom.Next(image.Width);

                int y = objRandom.Next(image.Height);

                objGraph.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
            }

            //输出字体与颜色
            Color[] objColorList = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };

            string[] strFontList = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };

            for (int i = 0; i < strImageCode.Length; i++)
            {
                int intColorIndex = objRandom.Next(7);

                int intFontIndex = objRandom.Next(5);

                Font objFont = new Font(strFontList[intFontIndex], 12, FontStyle.Bold);

                //画刷
                Brush objBrush = new SolidBrush(objColorList[intColorIndex]);

                int intTemp = 4;

                if ((intTemp + 1) % 2 == 0)
                {
                    intTemp = 2;
                }

                objGraph.DrawString(strImageCode.Substring(i, 1), objFont, objBrush, 3 + (i * 12), intTemp);
            }

            //绘制边框
            objGraph.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);
            #endregion

            #region 保存数据
            //图片流
            MemoryStream objStream = new MemoryStream();

            image.Save(objStream, ImageFormat.Jpeg);
            #endregion

            #endregion

            return objStream.ToArray();
        }
        #endregion
    }
}
