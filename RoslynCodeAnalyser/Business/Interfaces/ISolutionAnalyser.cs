using Core.Models;

namespace Business.Interfaces
{
    public interface ISolutionAnalyser
    {
        SolutionAnalysisData Analyse(string solutionFilePath);
    }
}
