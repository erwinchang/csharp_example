using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MyProgram
    {
    }
    //https://docs.microsoft.com/zh-tw/dotnet/api/system.collections.generic.list-1.sort?view=net-6.0
    //https://py3939.pixnet.net/blog/post/28315118-%5Bc%23%5D%E8%87%AA%E8%A8%82%E7%9A%84-class-%E7%B9%BC%E6%89%BF%E8%87%AA-icomparable-%E4%BB%A5%E4%BE%BF%E5%85%B7%E6%9C%89-sorti
    public class Part : IComparable<Part>
    {
        public string PartName { get; set; }
        public int PartId { get; set; }
        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }
        public int CompareTo(Part comparePart)
        {
            return this.PartId.CompareTo(comparePart.PartId);
        }
    }
    public class Example
    {
        public static void ExMain()
        {
            List<Part> parts = new List<Part>();
            parts.Add(new Part() { PartName = "C", PartId = 2 });
            parts.Add(new Part() { PartName = "A", PartId = 1 });
            parts.Add(new Part() { PartName = "B", PartId = 3 });
            Console.WriteLine("\nBefore sort:");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }
            parts.Sort();
            Console.WriteLine("\nAfter sort by part number:");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }

            parts.Sort(delegate (Part x, Part y)
            {
                return x.PartName.CompareTo(y.PartName);
            });
            Console.WriteLine("\nAfter sort by name:");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }
        }
    }
}
