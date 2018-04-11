using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Core.InterfaceVirtualization
{
    public abstract class CSharpSyntaxRewriterWrapperForInterface : CSharpSyntaxRewriter
    {
        public List<InterfaceDeclarationSyntax> Interfaces { get; set; }
    }
}
