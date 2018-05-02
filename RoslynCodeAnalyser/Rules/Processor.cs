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
            foreach (var prj in result.Projects)
            {
                ProjectMetrics metrics = new ProjectMetrics();
                metrics.Projectname = prj.Project.Name;
                foreach (var cls in prj.Classes)
                {
                    ClassMetrics clsMetrics = new ClassMetrics();
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

                    foreach (var mtd in cls.Methods)
                    {

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
                    foreach (var prop in cls.Properties)
                    {
                        break;
                    }
                    metrics.ClassMetrics.Add(clsMetrics);
                }
                foreach (var inf in prj.Interfaces)
                {
                    break;
                }
                metricsList.Add(metrics);
            }

            return metricsList;
        }
    }
}
