using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using StructureMap;
using Business.DiRegistry;
using Business.Interfaces;
using Microsoft.CodeAnalysis;
using Rules.Model;
using Rules.Rule;
using Rules.Calculator;

namespace Rules
{
    public class Processor
    {
        private readonly string _solutionpath;
        private readonly List<string> _projects;

        public Processor(string solutionpath, List<string> projects=null)
        {
            _solutionpath = solutionpath;
            _projects = projects;
        }

        public List<ProjectMetrics> Process()
        {
            var container = new Container();
            container.Configure(p => { p.AddRegistry<BusinessRegistry>(); });
            var solutionAnalyser = container.GetInstance<ISolutionAnalyser>();
            SolutionAnalysisData result = solutionAnalyser.Analyse(_solutionpath, _projects);
            List<ProjectMetrics> metricsList = new List<ProjectMetrics>();
            AnalyzeProject(result, metricsList);
            return metricsList;
        }

        private static void AnalyzeProject(SolutionAnalysisData result, List<ProjectMetrics> metricsList)
        {
            foreach (var prj in result.Projects)
            {
                AnalyzeClassMetrics ac =new AnalyzeClassMetrics();
                AnalyzeInterfaceMetrics ai = new AnalyzeInterfaceMetrics();
                ProjectMetrics metrics = new ProjectMetrics();
                metrics.Projectname = prj.Project.Name;
                ac.AnalyzeClass(prj, metrics);
                ai.AnalyzeInterface(prj, metrics);
                metricsList.Add(metrics);
            }
        }

   

   

   

     


    }
}
