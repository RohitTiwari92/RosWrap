using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Core.Models
{
    public class NamspaceAnalysisData
    {
        public NamespaceDeclarationSyntax Namespacedeclaration { get; set; }
        public List<ClassAnalysisData> Classes = new List<ClassAnalysisData>();
        public List<InterfaceAnalysisData> Interfaces = new List<InterfaceAnalysisData>();
    }
}