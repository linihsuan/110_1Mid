using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _110_1Mid {
    public partial class Sample1Com : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) 
        {
            if (IsPostBack == false) 
            {
                {
                    lb_Msg.Text += Request.Form.Get("td_Id") + "<br />";
                    lb_Msg.Text += Request.Form.Get("tb_Ps") + "<br />";

                    if (Request.Form.Get("cl_Inter") == "網頁廣告")
                    {
                        lb_Msg.Text += lb_Msg.Text + "網頁廣告" + "<br />";
                    }
                    if (Request.Form.Get("cl_Inter") == "電視")
                    {
                        lb_Msg.Text += lb_Msg.Text + "電視" + "<br />";
                    }
                    if (Request.Form.Get("cl_Inter") == "其他")
                    {
                        lb_Msg.Text += lb_Msg.Text + "其他" + "<br />";
                    }

                    lb_Msg.Text += Request.Form.Get("tb_Num") + "<br />";
                    lb_Msg.Text += Request.Form.Get("hd_Num") + "<br />";
                    lb_Msg.Text += mt_2MD5(Request.Form.Get("tb_Num"));
                }
            }
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