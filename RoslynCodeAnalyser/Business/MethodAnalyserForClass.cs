using System.Collections.Generic;
using System.Linq;
using Business.Interfaces;
using Core.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Business
{
    public class MethodAnalyserForClass : IMethodAnalyser<ClassDeclarationSyntax>
    {
        public IList<MethodAnalyseData> Analyze(ClassDeclarationSyntax classDeclarationSyntax)
        {
            var  methodDeclairationSyntaxList = classDeclarationSyntax
                .SyntaxTree
                .GetRoot()
                .DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .ToList();

            return methodDeclairationSyntaxList
                .Select(methodDeclairationSyntax => new MethodAnalyseData { MethodDeclarationSyntax = methodDeclairationSyntax})
                .ToList();
        }
    }
}
