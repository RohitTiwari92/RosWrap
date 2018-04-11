using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Core.NamespaceVirtualization
{
    public abstract class CSharpSyntaxRewriterWrapperForNamespace : CSharpSyntaxRewriter
    {
        public List<NamespaceDeclarationSyntax> Namespaces { get; set; }
    }
}
