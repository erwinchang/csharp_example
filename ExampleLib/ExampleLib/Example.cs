using System;

namespace ExampleLib
{
    public class Example
    {
        //https://marcus116.blogspot.com/2019/01/unittest-nunit.html
        public string Reverse(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
