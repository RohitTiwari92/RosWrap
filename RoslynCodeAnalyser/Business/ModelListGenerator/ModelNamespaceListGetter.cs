﻿using System.Collections.Generic;
using System.Linq;
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
            
            var namespaces = new List<NamespaceDeclarationSyntax>();
            _cSharpSyntaxRewriterWrapper.Namespaces = new List<NamespaceDeclarationSyntax>();
            foreach (var syntaxTree in compiledProject.SyntaxTrees)
            {

                _cSharpSyntaxRewriterWrapper.Visit(syntaxTree.GetRoot());
                foreach (var nmps in _cSharpSyntaxRewriterWrapper.Namespaces)
                {
                   if(!namespaces.Any(x=>x.SyntaxTree.Equals(nmps.SyntaxTree)))
                    {
                        namespaces.Add(nmps);
                    }
                   
                }
            }
           return namespaces;
             
        }
    }
}
