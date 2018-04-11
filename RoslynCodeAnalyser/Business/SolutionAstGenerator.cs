using Business.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace Business
{
    public class SolutionAstGenerator : ISolutionAstGenerator

    {
        public Solution GenerateAst(string solutionFilePath)
        {
            var msWorkspace = MSBuildWorkspace.Create();
            return msWorkspace.OpenSolutionAsync(solutionFilePath).Result;
        }
    }
}
