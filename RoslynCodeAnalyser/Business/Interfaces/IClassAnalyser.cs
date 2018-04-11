using System.Collections.Generic;
using Core.Models;
using Microsoft.CodeAnalysis;

namespace Business.Interfaces
{
    public interface IClassAnalyser
    {
        IList<ClassAnalysisData> Analysis(Compilation compiledProject, string inputNamespaceName);
    }
}
