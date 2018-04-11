using System.Collections.Generic;
using Core.Models;
using Microsoft.CodeAnalysis;

namespace Business.Interfaces
{
    public interface INameSpaceAnalyser
    {
        IList<NamspaceAnalysisData> Analyse(Compilation compiledProject);
    }
}
