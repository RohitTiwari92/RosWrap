using System.Collections.Generic;
using Core.Models;
using Microsoft.CodeAnalysis;

namespace Business.Interfaces
{
    public interface IInterfaceAnalyser
    {
        IList<InterfaceAnalysisData> Analysis(Compilation compiledProject);
    }
}