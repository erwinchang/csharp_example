using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public partial class FileUtils
    {
        /// <summary>
        /// There are a few interesting combinations of what will and won't combine correctly for Path.Combine, 
        /// and the MSDN page for Path.Combine explains some of these. There's one condition it won't cater for 
        /// properly though - if the 2nd parameter contains a leading '\', for instance '\file.txt', the final 
        /// result will ignore the first parameter. The output of Path.Combine("c:\directory", "\file.txt") is \file.txt'. 
        /// This is not the case if the 1st parameter contains a trailing '\'. 
        ///
        ///string part1 = @"c:\directory";
        ///string part2 = @"file.txt";
        ///
        ///(1) Console.WriteLine(Path.Combine(part1, part2));
        ///(2) Console.WriteLine(Path.Combine(part1 + @"\", part2));
        ///(3) Console.WriteLine(Path.Combine(part1 + @"\", @"\" + part2));
        ///(4) Console.WriteLine(Path.Combine(part1, @"\" + part2));
        ///
        ///The output of this is
        ///
        ///(1) c:\directory\file.txt
        ///(2) c:\directory\file.txt
        ///(3) \file.txt
        ///(4) \file.txt
        ///
        /// The FileUtils.Combine function will give the output
        ///
        ///(1) c:\directory\file.txt
        ///(2) c:\directory\file.txt
        ///(3) c:\directory\file.txt
        ///(4) c:\directory\file.txt 
        /// </summary>
        public static string Combine(string path1, string path2)
        {
            if (string.IsNullOrEmpty(path2)) return path1;
            var a = path1;
            var b = path2.Substring(0, 1) == @"\" ? path2.Substring(1, path2.Length - 1) : path2;
            var c = Path.Combine(a, b);
            return Path.Combine(path1, path2.Substring(0, 1) == @"\" ? path2.Substring(1, path2.Length - 1) : path2);
        }
    }
}
