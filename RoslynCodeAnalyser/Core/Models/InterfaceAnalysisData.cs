using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Core.Models
{
    public class InterfaceAnalysisData
    {
        public InterfaceDeclarationSyntax InterfaceDeclarationSyntax { get; set; }
        public List<MethodAnalyseData> Methods = new List<MethodAnalyseData>();
        public List<PropertyAnalysisData> Properties = new List<PropertyAnalysisData>();
        public NamspaceAnalysisData Namespace = new NamspaceAnalysisData();
    }
}
