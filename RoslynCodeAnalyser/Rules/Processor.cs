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
                ProjectMetrics metrics = new ProjectMetrics();
                metrics.Projectname = prj.Project.Name;
                AnalyzeClass(prj, metrics);
                AnalyzeInterface(prj, metrics);
                metricsList.Add(metrics);
            }
        }

        private static void AnalyzeInterface(ProjectAnalysisData prj, ProjectMetrics metrics)
        {
            foreach (var inf in prj.Interfaces)
            {
                break;
            }
        }

        private static void AnalyzeClass(ProjectAnalysisData prj, ProjectMetrics metrics)
        {
            foreach (var cls in prj.Classes)
            {
                ClassMetrics clsMetrics = new ClassMetrics();
                CalculateClassMetrics(prj, clsMetrics, cls);
                AnalyzeMethod(prj, cls, clsMetrics);
                AnalyzePropertie(prj, cls, clsMetrics);
                metrics.ClassMetrics.Add(clsMetrics);
            }
        }

        private static void CalculateClassMetrics(ProjectAnalysisData prj, ClassMetrics clsMetrics, ClassAnalysisData cls)
        {
            clsMetrics.Classname = cls.ClassDeclarationSyntax.Identifier.ValueText;
            clsMetrics.Classdocpath = cls.ClassDeclarationSyntax.SyntaxTree.FilePath;
            clsMetrics.Namespacename = cls.Namespace.Namespacedeclaration.Name.ToString();
            SemanticModel sclsmodel =
                prj.CompiledProject.GetSemanticModel(cls.ClassDeclarationSyntax.SyntaxTree);
            LocRule locRule = new LocRule();
            clsMetrics.Loc = locRule.GetLocCount(cls.ClassDeclarationSyntax);
            CyclomaticComplexityCounter cyclomaticComplexityCounter = new CyclomaticComplexityCounter();
            clsMetrics.CyclomaticComplexity = cyclomaticComplexityCounter.Calculate(cls.ClassDeclarationSyntax,
                sclsmodel);
        }

        private static void AnalyzePropertie(ProjectAnalysisData prj, ClassAnalysisData cls, ClassMetrics clsMetrics)
        {
            foreach (var prop in cls.Properties)
            {
                break;
            }
        }

        private static void AnalyzeMethod(ProjectAnalysisData prj, ClassAnalysisData cls, ClassMetrics clsMetrics)
        {
            foreach (var mtd in cls.Methods)
            {
                CyclomaticComplexityCounter cyclomaticComplexityCounter = new CyclomaticComplexityCounter();
                LocRule locRule = new LocRule();
                MethodMetrics mtdMetrics = new MethodMetrics();
                mtdMetrics.Loc = locRule.GetLocCount(mtd.MethodDeclarationSyntax);
                SemanticModel smtdmodel =
                    prj.CompiledProject.GetSemanticModel(cls.ClassDeclarationSyntax.SyntaxTree);
                mtdMetrics.CyclomaticComplexity =
                    cyclomaticComplexityCounter.Calculate(mtd.MethodDeclarationSyntax, smtdmodel);
                MethodparametersRule mtdprmrule = new MethodparametersRule();
                mtdMetrics.Methodparameters = mtdprmrule.GetMethodparametersCount(mtd.MethodDeclarationSyntax);
                clsMetrics.MethodMetricses.Add(mtdMetrics);
            }
        }
    }
}
