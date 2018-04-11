using System.Collections.Generic;
using Business.Interfaces;
using Core.NamespaceVirtualization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Business.ModelListGenerator
{
    public class ModelNamespaceListGetter : IModelListGetter<NamespaceDeclarationSyntax>
    {
        private readonly CSharpSyntaxRewriterWrapperForNamespace _cSharpSyntaxRewriterWrapper;

        public ModelNamespaceListGetter(CSharpSyntaxRewriterWrapperForNamespace cSharpSyntaxRewriterWrapper)
        {
            _cSharpSyntaxRewriterWrapper = cSharpSyntaxRewriterWrapper;
        }

        public IEnumerable<NamespaceDeclarationSyntax> GetModelList(Compilation compiledProject)
        {
            var sample = new HashSet<NamespaceDeclarationSyntax>();
            var namespaces = new List<NamespaceDeclarationSyntax>();
            _cSharpSyntaxRewriterWrapper.Namespaces = new List<NamespaceDeclarationSyntax>();
            foreach (var syntaxTree in compiledProject.SyntaxTrees)
            {
                _cSharpSyntaxRewriterWrapper.Visit(syntaxTree.GetRoot());
            }
            namespaces.AddRange(_cSharpSyntaxRewriterWrapper.Namespaces);
            return namespaces;
        }
    }
}
