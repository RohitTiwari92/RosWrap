using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace Core.Models
{
    public class SolutionAnalysisData
    {
        public Solution SolutionAst { get; set; }
        public List<ProjectAnalysisData> Projects = new List<ProjectAnalysisData>();
    }
}
