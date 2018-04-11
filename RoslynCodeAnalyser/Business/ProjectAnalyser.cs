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

        public ProjectAnalyser(INameSpaceAnalyser namespaceAnalyser)
        {
            _namespaceAnalyser = namespaceAnalyser;
        }

        public IList<ProjectAnalysisData> Analyse(Solution solutionAst)
        {
            var projectAnalysisDataList = new List<ProjectAnalysisData>();
            var projectList = solutionAst.Projects.ToList();

            foreach (var project in projectList)
            {
                var projectAnalysisData = new ProjectAnalysisData
                {
                    CompiledProject = project.GetCompilationAsync().Result,
                    Project = project,
                    Namespances = _namespaceAnalyser.Analyse(project.GetCompilationAsync().Result).ToList()
                };

                projectAnalysisDataList.Add(projectAnalysisData);
            }
            return projectAnalysisDataList;
        }

    }
}
