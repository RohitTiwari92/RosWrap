using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules.Model
{
    public class ProjectMetrics
    {
        public List<ClassMetrics> ClassMetrics = new List<ClassMetrics>();
        public string Projectname { get; set; }
    }
}
