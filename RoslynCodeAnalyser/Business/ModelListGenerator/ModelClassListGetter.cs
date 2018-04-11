using System.Collections.Generic;
using Business.Interfaces;
using Core.ClassVirtualization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Business.ModelListGenerator
{
    public class ModelListGetter : IModelListGetter<ClassDeclarationSyntax>
    {
        private readonly CSharpSyntaxRewriterWrapperForClass _cSharpSyntaxRewriterWrapper;

        public ModelListGetter(CSharpSyntaxRewriterWrapperForClass cSharpSyntaxRewriterWrapper)
        {
            _cSharpSyntaxRewriterWrapper = cSharpSyntaxRewriterWrapper;
        }


        public IEnumerable<ClassDeclarationSyntax> GetModelList(Compilation compiledProject)
        {
            var classModel = new List<ClassDeclarationSyntax>();
            _cSharpSyntaxRewriterWrapper.Classes = new List<ClassDeclarationSyntax>();
            foreach (var syntaxTree in compiledProject.SyntaxTrees)
            {
                _cSharpSyntaxRewriterWrapper.Visit(syntaxTree.GetRoot());
            }
            classModel.AddRange(_cSharpSyntaxRewriterWrapper.Classes);
            return classModel;
        }
    }
}
