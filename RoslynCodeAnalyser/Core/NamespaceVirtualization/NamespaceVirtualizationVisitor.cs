using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Core.NamespaceVirtualization
{
    public class NamespaceVirtualizationVisitor : CSharpSyntaxRewriterWrapperForNamespace
    {
        public NamespaceVirtualizationVisitor()
        {
            Namespaces = new List<NamespaceDeclarationSyntax>();
        }
        
        public override SyntaxNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            Namespaces.Add(node);
            base.VisitNamespaceDeclaration(node);
            return node;
        }
    }
}
