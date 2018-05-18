using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.CodeAnalysis;
using Rules.Model;
using Rules.Rule;

namespace Rules.Calculator
{
  public  class AnalyzeClassMetrics
    {
        public  void AnalyzeClass(ProjectAnalysisData prj, ProjectMetrics metrics)
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

        private static void AnalyzePropertie(ProjectAnalysisData prj, ClassAnalysisData cls, ClassMetrics clsMetrics)
        {
            foreach (var prop in cls.Properties)
            {
                break;
            }
        }

        private static void CalculateClassMetrics(ProjectAnalysisData prj, ClassMetrics clsMetrics, ClassAnalysisData cls)
        {
            ClassMetricscalculator calculate=new ClassMetricscalculator();
            calculate.Calculate(prj,clsMetrics,cls);
        
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
