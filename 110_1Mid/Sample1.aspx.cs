using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _110_1Mid {
    public partial class Sample1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) 
        {
            if (IsPostBack == false) 
            {
                string s_Ver = mt_GenVeriStr();
                mt_ImgPointer(ref Image1, s_Ver);
                hd_Num.Value = mt_2MD5(s_Ver);
            }
        }

        // To generate a 4 digital number
        public string mt_GenVeriStr() {
            string s_Res = "";
            Random o_Ran = new Random();
            for (int i_Ct = 0; i_Ct < 4; i_Ct++) {
                int i_Tmp = o_Ran.Next(0, 10);
                s_Res = s_Res + i_Tmp.ToString();
            }
            return s_Res;
        }

        // To pointer the url to the image object; the content of
        // the image is the 4 digital number above
        public void mt_ImgPointer(ref Image o_Ig, string s_Str) {
            System.Drawing.Font o_Font = new System.Drawing.Font("Times New Roman", 12.0f);
            System.Drawing.Image o_IS = new System.Drawing.Bitmap(30, 10);
            System.Drawing.Graphics o_Drawing = System.Drawing.Graphics.FromImage(o_IS);
            System.Drawing.SizeF o_TextSize = o_Drawing.MeasureString(s_Str, o_Font);
            o_IS.Dispose();
            o_Drawing.Dispose();

            o_IS = new System.Drawing.Bitmap((int)o_TextSize.Width, (int)o_TextSize.Height);
            o_Drawing = System.Drawing.Graphics.FromImage(o_IS);

            //paint the background
            o_Drawing.Clear(System.Drawing.Color.Aqua);

            //create a brush for the text
            System.Drawing.Brush o_TextBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            o_Drawing.DrawString(s_Str, o_Font, o_TextBrush, 0, 0);

            o_Drawing.Save();
            string s_Url = HttpContext.Current.Server.MapPath("~") + "Images/";
            string s_FileName = DateTime.Now.ToString("mmddyyyy_hhmmss") + ".png";
            string s_Path = s_Url + DateTime.Now.ToString("mmddyyyy_hhmmss") + ".png";
            o_IS.Save(s_Path, System.Drawing.Imaging.ImageFormat.Png);
            o_Ig.ImageUrl = "~/Images/" + s_FileName;

            o_TextBrush.Dispose();
            o_IS.Dispose();
            o_Drawing.Dispose();
        }

        // To convert a plain-text string into a md5 string
        public string mt_2MD5(string s_Str) {
            System.Security.Cryptography.MD5 cryptoMD5 = System.Security.Cryptography.MD5.Create();
            byte[] ba_Bytes = System.Text.Encoding.UTF8.GetBytes(s_Str);
            byte[] ba_Hash = cryptoMD5.ComputeHash(ba_Bytes);

            string s_Md5 = BitConverter.ToString(ba_Hash)
                .Replace("-", String.Empty)
                .ToUpper();
            return s_Md5;
        }
    }
}