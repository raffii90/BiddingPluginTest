using System;
using System.Runtime.InteropServices;
using System.Text;

public class StringTestImport {
    [DllImport("StringFunctionsTest")]
    public static extern IntPtr GetConcatenatedString(string str1, string str2);
    
    [DllImport("StringFunctionsTest")]
    public static extern IntPtr RemoveCharsFromEnd(string str, int length);
    
    [DllImport("StringFunctionsTest")]
    public static extern IntPtr ReverseString(string str);
}