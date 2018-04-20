using System.Collections.Generic;
using System.Linq;
using Business.Interfaces;
using Core.Helper.Interfaces;
using Core.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Business
{
    public class ClassAnalyser : IClassAnalyser
    {
        private readonly INameSpaceAnalyser _namespaceAnalyser;
        private readonly ISyntaxNodeHelper _syntaxNodeHelper;
        private readonly IMethodAnalyser<ClassDeclarationSyntax> _methodAnalyser;
        private readonly IModelListGetter<ClassDeclarationSyntax> _modelListGetter;

        public ClassAnalyser(ISyntaxNodeHelper syntaxNodeHelper,
            IMethodAnalyser<ClassDeclarationSyntax> methodAnalyser,
            IModelListGetter<ClassDeclarationSyntax> modelListGetter,
            INameSpaceAnalyser namespaceAnalyser)
        {
            _syntaxNodeHelper = syntaxNodeHelper;
            _methodAnalyser = methodAnalyser;
            _modelListGetter = modelListGetter;
            _namespaceAnalyser = namespaceAnalyser;
        }

        public IList<ClassAnalysisData> Analysis(Compilation compiledProject)
        {
            var result = new List<ClassAnalysisData>();
            var classes = _modelListGetter.GetModelList(compiledProject);
            foreach (var item in classes)
            {            
                    var mtdModelList = _methodAnalyser.Analyze(item);
                    var classModel = new ClassAnalysisData
                    {
                        ClassDeclarationSyntax = item,
                        Methods = mtdModelList.ToList(),
                        Namespace = _namespaceAnalyser.Analyse(item)
                    };
                    result.Add(classModel);
                
            }
            return result;
        }
    }
}
