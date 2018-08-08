using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosWrap;
using Rules;

namespace TestCallerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Analyser analyser=new Analyser(@"C:\Users\r.tiwari\Documents\Visual Studio 2015\Projects\TempPr\replaceoldpsnumber\replaceoldpsnumber.sln");
            var results = analyser.Process();
            foreach (var result in results)
            {
                Console.WriteLine(result.Projectname);
                foreach (var cls in result.ClassMetrics)
                {
                    Console.WriteLine(cls.Classname + " : " +  cls.Loc + " DOI : "+cls.DOI);
                }
            }
            Console.ReadKey();
        }
    }
}
