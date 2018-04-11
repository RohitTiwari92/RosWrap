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
        private readonly ISyntaxNodeHelper _syntaxNodeHelper;
        private readonly IMethodAnalyser<ClassDeclarationSyntax> _methodAnalyser;
        private readonly IModelListGetter<ClassDeclarationSyntax> _modelListGetter;

        public ClassAnalyser(ISyntaxNodeHelper syntaxNodeHelper,
            IMethodAnalyser<ClassDeclarationSyntax> methodAnalyser,
            IModelListGetter<ClassDeclarationSyntax> modelListGetter)
        {
            _syntaxNodeHelper = syntaxNodeHelper;
            _methodAnalyser = methodAnalyser;
            _modelListGetter = modelListGetter;
        }

        public IList<ClassAnalysisData> Analysis(Compilation compiledProject, string inputNamespaceName)
        {
            var result = new List<ClassAnalysisData>();
            var classes = _modelListGetter.GetModelList(compiledProject);
            foreach (var item in classes)
            {
                NamespaceDeclarationSyntax namespaceDeclarationSyntax;
                if (!_syntaxNodeHelper.TryGetParentSyntax(item, out namespaceDeclarationSyntax))
                    continue;

                var namespaceName = namespaceDeclarationSyntax.Name.ToString();
                if (inputNamespaceName.Equals(namespaceName))
                {
                    var mtdModelList = _methodAnalyser.Analyze(item);
                    var classModel = new ClassAnalysisData
                    {
                        ClassDeclarationSyntax = item,
                        Methods = mtdModelList.ToList()
                    };
                    result.Add(classModel);
                }
            }
            return result;
        }
    }
}
