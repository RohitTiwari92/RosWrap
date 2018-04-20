using System.Collections.Generic;
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
        private readonly INameSpaceAnalyser _namespaceAnalyser;

        public InterfaceAnalyser(ISyntaxNodeHelper syntaxNodeHelper,
            IMethodAnalyser<InterfaceDeclarationSyntax> methodAnalyser,
            IModelListGetter<InterfaceDeclarationSyntax> modelListGetter,
            INameSpaceAnalyser namespaceAnalyser)
        {
            _syntaxNodeHelper = syntaxNodeHelper;
            _methodAnalyser = methodAnalyser;
            _modelListGetter = modelListGetter;
            _namespaceAnalyser = namespaceAnalyser;
        }

        public IList<InterfaceAnalysisData> Analysis(Compilation compiledProject)
        {
            var result = new List<InterfaceAnalysisData>();
            var interfaces = _modelListGetter.GetModelList(compiledProject);
            foreach (var item in interfaces)
            {
               
                    var mtdModelList = _methodAnalyser.Analyze(item);
                    var interfaceModel = new InterfaceAnalysisData
                    {
                        InterfaceDeclarationSyntax = item,
                        Methods = mtdModelList.ToList(),
                        Namespace = _namespaceAnalyser.Analyse(item)
                    };
                    result.Add(interfaceModel);
                
            }
            return result;
        }
    }
}
