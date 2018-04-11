using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Business.Interfaces
{
    public interface IModelListGetter<out TOutput>
    {
        IEnumerable<TOutput> GetModelList(Compilation compiledProject);
    }
}