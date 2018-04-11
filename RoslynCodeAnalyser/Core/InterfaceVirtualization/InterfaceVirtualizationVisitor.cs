using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Core.InterfaceVirtualization
{
    public class InterfaceVirtualizationVisitor : CSharpSyntaxRewriterWrapperForInterface
    {
        public InterfaceVirtualizationVisitor()
        {
            Interfaces = new List<InterfaceDeclarationSyntax>();
        }

        public override SyntaxNode VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            Interfaces.Add(node);
            base.VisitInterfaceDeclaration(node);
            return node;
        }
    }
}
