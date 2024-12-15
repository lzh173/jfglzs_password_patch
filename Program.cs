// See https://aka.ms/new-console-template for more information
// 代码来自学生机房管理助手9.0 set.exe
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
public class Program
{
    public static void Main()
    {
        // 更改这里的内容
        string string_3 = Console.ReadLine();
        // Class6.smethod_0()
        string value = "C:\\WINDOWS";
        string s = value.Substring(0, 8);
        string s2 = value.Substring(1, 8);
        DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
        descryptoServiceProvider.Key = Encoding.UTF8.GetBytes(s);
        descryptoServiceProvider.IV = Encoding.UTF8.GetBytes(s2);
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
        StreamWriter streamWriter = new StreamWriter(cryptoStream);
        streamWriter.Write(string_3);
        streamWriter.Flush();
        cryptoStream.FlushFinalBlock();
        memoryStream.Flush();
        string string_4 = Convert.ToBase64String(memoryStream.GetBuffer(), 0, checked((int)memoryStream.Length));
        // Class6.smethod_3()
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < string_4.Length; i++)
            stringBuilder.Append((char)(string_4[i] - 10));
        string_3 = stringBuilder.ToString();
        // Class6.smethod_2()
        MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
        byte[] array2 = md5CryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(string_3));
        stringBuilder.Clear();
        for (int i = 0; i < array2.Length; i++)
            stringBuilder.Append(array2[i].ToString("x2"));
        string str = stringBuilder.ToString().Substring(10);

        Console.WriteLine(str);
    }
}
// 期望输出：8a29cc29f5951530ac69f4