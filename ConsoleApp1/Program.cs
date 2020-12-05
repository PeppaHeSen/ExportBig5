using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// big5 所有文字
    /// BIG5编码又称大五码，是繁体中文字符集编码标准，共收录13060个中文字，其中有二字为重复编码。
    ///BIG5采用双字节编码，使用两个字节来表示一个字符。高位字节使用了0x81-0xFE，低位字节使用了0x40-0x7E，及0xA1-0xFE。在BIG5的分区中：
    ///8140-A0FE 保留给使用者自定义字符（造字区）
    ///A140-A3BF 标点符号、希腊字母及特殊符号。其中在A259-A261，收录了度量衡单位用字：兙兛兞兝兡兣嗧瓩糎。
    ///A3C0-A3FE 保留。此区没有开放作造字区用。
    ///A440-C67E 常用汉字，先按笔划再按部首排序。
    ///C6A1-F9DC 其它汉字。
    ///F9DD-F9FE 制表符。
    ///值得留意的是，BIG5重复地收录了两个相同的字：“兀、兀”（A461及C94A)、“嗀、嗀”(DCD1及DDFC)。
    ///https://www.qqxiuzi.cn/zh/hanzi-big5-bianma.php
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Encoding big5 = Encoding.GetEncoding("big5");
            StringBuilder sb = new StringBuilder();
            int count = 0;
            byte[] charBytes = new byte[2];
            for (int i = 0xA0; i < 0xFE; i++)
            {
                for (int l = 0x40; l < 0x7E; l++)
                {
                    charBytes[0] = (byte)i;
                    charBytes[1] = (byte)l;
                    sb.Append(big5.GetString(charBytes));
                    if (count % 50 == 0)
                    {
                        sb.AppendLine();
                    }

                    count++;
                }
            }

            for (int i = 0xA0; i < 0xFE; i++)
            {
                for (int l = 0xA1; l < 0xFE; l++)
                {
                    charBytes[0] = (byte)i;
                    charBytes[1] = (byte)l;
                    sb.Append(big5.GetString(charBytes));
                    if (count % 50 == 0)
                    {
                        sb.AppendLine();
                    }

                    count++;
                }
            }

            File.WriteAllText("D://output.txt", sb.ToString());
        }         
    }
}
