using Microsoft.CodeAnalysis;

namespace Business.Interfaces
{
    public interface ISolutionAstGenerator
    {
        Solution GenerateAst(string solutionFilePath);
    }
}
