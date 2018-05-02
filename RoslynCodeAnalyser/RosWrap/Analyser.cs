using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rules;
using Rules.Model;

namespace RosWrap
{
    //this project is added for velidation of input 
    public class Analyser
    {
        private readonly string _solutionpath;
        private readonly List<string> _projects;

        public Analyser(string solutionpath, List<string> projects=null)
        {
            _solutionpath = solutionpath;
            _projects = projects;
        }

        public List<ProjectMetrics> Process()
        {
            Processor process = new Processor(_solutionpath, _projects);
            return process.Process();

        }
    }
}
