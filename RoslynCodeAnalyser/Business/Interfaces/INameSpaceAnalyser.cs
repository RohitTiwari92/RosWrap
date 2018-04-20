using System.Collections.Generic;
using Core.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Business.Interfaces
{
    public interface INameSpaceAnalyser
    {
        NamspaceAnalysisData Analyse(ClassDeclarationSyntax classDeclarationSyntax);
        NamspaceAnalysisData Analyse(InterfaceDeclarationSyntax interfaceDeclarationSyntax);
    }
}
