using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace Core.Models
{
    public class ProjectAnalysisData
    {
        public Project Project { get; set; }
        public Compilation CompiledProject { get; set; }

        public List<NamspaceAnalysisData> Namespances = new List<NamspaceAnalysisData>();
    }
}
