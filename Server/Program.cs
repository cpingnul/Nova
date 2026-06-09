using Nova.Common.Helper;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

static class Program
{
    static void Main()
    {
        //byte[] key = AesHelper.GenerateKey();
        //Console.WriteLine(Convert.ToBase64String(key));
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Nova.Forms.frmMain());
       
    }
}

