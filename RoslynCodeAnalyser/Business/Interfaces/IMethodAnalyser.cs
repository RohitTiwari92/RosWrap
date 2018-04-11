using System.Collections.Generic;
using Core.Models;

namespace Business.Interfaces
{
    public interface IMethodAnalyser<in TInput>
    {
        IList<MethodAnalyseData> Analyze(TInput classDeclarationSyntax);
    }
}