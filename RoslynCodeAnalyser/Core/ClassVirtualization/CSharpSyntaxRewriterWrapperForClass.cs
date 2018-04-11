using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Core.ClassVirtualization
{
    public class CSharpSyntaxRewriterWrapperForClass : CSharpSyntaxRewriter
    {
        public List<ClassDeclarationSyntax> Classes { get; set; }
    }
}
