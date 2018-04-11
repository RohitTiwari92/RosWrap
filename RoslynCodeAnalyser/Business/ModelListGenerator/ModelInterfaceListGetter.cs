using System.Collections.Generic;
using Business.Interfaces;
using Core.InterfaceVirtualization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Business.ModelListGenerator
{
    public class ModelInterfaceListGetter : IModelListGetter<InterfaceDeclarationSyntax>
    {
        private readonly CSharpSyntaxRewriterWrapperForInterface _cSharpSyntaxRewriterWrapper;

        public ModelInterfaceListGetter(CSharpSyntaxRewriterWrapperForInterface cSharpSyntaxRewriterWrapper)
        {
            _cSharpSyntaxRewriterWrapper = cSharpSyntaxRewriterWrapper;
        }

        public IEnumerable<InterfaceDeclarationSyntax> GetModelList(Compilation compiledProject)
        {
            var interfaceModel = new List<InterfaceDeclarationSyntax>();
            _cSharpSyntaxRewriterWrapper.Interfaces = new List<InterfaceDeclarationSyntax>();
            foreach (var syntaxTree in compiledProject.SyntaxTrees)
            {
                _cSharpSyntaxRewriterWrapper.Visit(syntaxTree.GetRoot());
            }
            interfaceModel.AddRange(_cSharpSyntaxRewriterWrapper.Interfaces);
            return interfaceModel;
        }
    }
}