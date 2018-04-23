using System.Collections.Generic;
using Core.Models;

namespace Business.Interfaces
{
    public interface ISolutionAnalyser
    {
        SolutionAnalysisData Analyse(string solutionFilePath, List<string> Pojectlist = null);
    }
}
