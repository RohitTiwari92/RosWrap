using System.Collections.Generic;
using System.Linq;
using Business.Interfaces;
using Core.Models;
using Core.NamespaceVirtualization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Business
{
    public class NameSpaceAnalyser : INameSpaceAnalyser
    {
        private readonly IClassAnalyser _classAnalyser;
        private readonly IInterfaceAnalyser _interfaceAnalyser;
        private readonly IModelListGetter<NamespaceDeclarationSyntax> _modelListGetter;


        public NameSpaceAnalyser(IClassAnalyser classAnalyser,
            IInterfaceAnalyser interfaceAnalyser,
            IModelListGetter<NamespaceDeclarationSyntax> modelListGetter)
        {
            _classAnalyser = classAnalyser;
            _interfaceAnalyser = interfaceAnalyser;
            _modelListGetter = modelListGetter;
        }

        public IList<NamspaceAnalysisData> Analyse(Compilation compiledProject)
        {
            var namespaceAnalysisDataList = new List<NamspaceAnalysisData>();
            var namespaces = _modelListGetter.GetModelList(compiledProject);
            foreach (var namespaceItem in namespaces)
            {
                var classAnalyseDataList = _classAnalyser.Analysis(compiledProject, namespaceItem.Name.ToString());
                var interfaceAnalyseDataList = _interfaceAnalyser.Analysis(compiledProject,
                    namespaceItem.Name.ToString());
                namespaceAnalysisDataList.Add(
                    new NamspaceAnalysisData
                    {
                        Namespacedeclaration = namespaceItem,
                        Classes = classAnalyseDataList.ToList(),
                        Interfaces = interfaceAnalyseDataList.ToList()
                    }
                    );
            }

            return namespaceAnalysisDataList;
        }
    }
}
