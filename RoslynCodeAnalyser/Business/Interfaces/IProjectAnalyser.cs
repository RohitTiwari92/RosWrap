using System.Collections.Generic;
using Core.Models;
using Microsoft.CodeAnalysis;

namespace Business.Interfaces
{
    public interface IProjectAnalyser
    {
        IList<ProjectAnalysisData> Analyse(Solution solutionAst,List<string> Pojectlist=null);
    }
}
