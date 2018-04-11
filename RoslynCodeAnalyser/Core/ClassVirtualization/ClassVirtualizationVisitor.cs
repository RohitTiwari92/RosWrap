using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Core.ClassVirtualization
{
    public class ClassVirtualizationVisitor : CSharpSyntaxRewriterWrapperForClass
    {
        public ClassVirtualizationVisitor()
        {
            Classes = new List<ClassDeclarationSyntax>();
        }

        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            Classes.Add(node); 
            base.VisitClassDeclaration(node);
            return node;
        }
    }
}
