

using System.Collections.Generic;

namespace Rules.Model
{
   public class ClassMetrics
    {
        public int CyclomaticComplexity { get; set; }
        public string Classname { get; set; }
        public string Classdocpath { get; set; }

        public string Namespacename { get; set; }

        public int Loc { get; set; }

        public List<MethodMetrics> MethodMetricses =new List<MethodMetrics>();
        public string Projectname { get; set; }
    }
}
