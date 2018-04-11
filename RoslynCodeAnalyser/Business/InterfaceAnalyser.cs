﻿using System.Collections.Generic;
using System.Linq;
using Business.Interfaces;
using Core.Helper.Interfaces;
using Core.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Business
{
    public class InterfaceAnalyser : IInterfaceAnalyser
    {
        private readonly ISyntaxNodeHelper _syntaxNodeHelper;
        private readonly IMethodAnalyser<InterfaceDeclarationSyntax> _methodAnalyser;
        private readonly IModelListGetter<InterfaceDeclarationSyntax> _modelListGetter;


        public InterfaceAnalyser(ISyntaxNodeHelper syntaxNodeHelper,
            IMethodAnalyser<InterfaceDeclarationSyntax> methodAnalyser,
            IModelListGetter<InterfaceDeclarationSyntax> modelListGetter)
        {
            _syntaxNodeHelper = syntaxNodeHelper;
            _methodAnalyser = methodAnalyser;
            _modelListGetter = modelListGetter;
        }

        public IList<InterfaceAnalysisData> Analysis(Compilation compiledProject, string inputNamespaceName)
        {
            var result = new List<InterfaceAnalysisData>();
            var interfaces = _modelListGetter.GetModelList(compiledProject);
            foreach (var item in interfaces)
            {
                NamespaceDeclarationSyntax namespaceDeclarationSyntax;
                if (!_syntaxNodeHelper.TryGetParentSyntax(item, out namespaceDeclarationSyntax))
                    continue;

                var namespaceName = namespaceDeclarationSyntax.Name.ToString();
                if (inputNamespaceName.Equals(namespaceName))
                {
                    var mtdModelList = _methodAnalyser.Analyze(item);
                    var interfaceModel = new InterfaceAnalysisData
                    {
                        InterfaceDeclarationSyntax = item,
                        Methods = mtdModelList.ToList()
                    };
                    result.Add(interfaceModel);
                }
            }
            return result;
        }
    }
}
