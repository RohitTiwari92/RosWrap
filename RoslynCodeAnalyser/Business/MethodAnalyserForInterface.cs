using System.Collections.Generic;
using System.Linq;
using Business.Interfaces;
using Core.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Business
{
    public class MethodAnalyserForInterface : IMethodAnalyser<InterfaceDeclarationSyntax>
    {
        public IList<MethodAnalyseData> Analyze(InterfaceDeclarationSyntax interfaceDeclarationSyntax)
        {
            var methodDeclairationSyntaxList = interfaceDeclarationSyntax
               .SyntaxTree
               .GetRoot()
               .DescendantNodes()
               .OfType<MethodDeclarationSyntax>()
               .ToList();

            return methodDeclairationSyntaxList
                .Select(methodDeclairationSyntax => new MethodAnalyseData { MethodDeclarationSyntax = methodDeclairationSyntax })
                .ToList();
        }
    }
}
