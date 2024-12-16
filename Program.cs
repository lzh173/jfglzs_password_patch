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
        Console.WriteLine("                 _           _                _     _    __ ______ ____  \r\n               | |         | |              | |   | |  /_ |____  |___ \\ \r\n   ___ ___   __| | ___     | |__  _   _     | |___| |__ | |   / /  __) |\r\n  / __/ _ \\ / _` |/ _ \\    | '_ \\| | | |    | |_  / '_ \\| |  / /  |__ < \r\n | (_| (_) | (_| |  __/    | |_) | |_| |    | |/ /| | | | | / /   ___) |\r\n  \\___\\___/ \\__,_|\\___|    |_.__/ \\__, |    |_/___|_| |_|_|/_/   |____/ \r\n                                   __/ |                                \r\n                                  |___/           \r\n请输入明文密码");
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
