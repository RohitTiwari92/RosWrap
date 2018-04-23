using System.Collections.Generic;
using System.Linq;
using Business.Interfaces;
using Core.Models;
using Microsoft.CodeAnalysis;


namespace Business
{
    public class ProjectAnalyser : IProjectAnalyser
    {
        private readonly INameSpaceAnalyser _namespaceAnalyser;
        private readonly IClassAnalyser _classAnalyser;
        private readonly IInterfaceAnalyser _interfaceAnalyser;
        public ProjectAnalyser(IClassAnalyser classAnalyser, IInterfaceAnalyser interfaceAnalyser)
        {
            _classAnalyser = classAnalyser;
            _interfaceAnalyser = interfaceAnalyser;
        }

        public IList<ProjectAnalysisData> Analyse(Solution solutionAst,List<string> PrjList=null)
        {
            var projectAnalysisDataList = new List<ProjectAnalysisData>();
            List<Project> projectList;
            if (PrjList == null)
            {
                 projectList = solutionAst.Projects.ToList();
            }
            else
            {
                projectList = solutionAst.Projects.Where(x=>(PrjList.Contains( x.Name))).ToList();
            }
            foreach (var project in projectList)
            {
                var projectAnalysisData = new ProjectAnalysisData
                {
                    CompiledProject = project.GetCompilationAsync().Result,
                    Project = project,
                    Classes = _classAnalyser.Analysis(project.GetCompilationAsync().Result).ToList(),
                    Interfaces = _interfaceAnalyser.Analysis(project.GetCompilationAsync().Result).ToList()
                    
                };

                projectAnalysisDataList.Add(projectAnalysisData);
            }
            return projectAnalysisDataList;
        }

    }
}
