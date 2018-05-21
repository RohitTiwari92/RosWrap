using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.CodeAnalysis;
using Rules.Calculator.MethodLevelRuleCaller;
using Rules.Model;

namespace Rules.Calculator
{
   public class MethodMetricscalculator
    {
       readonly List<IMethodMetricscalculator> _rulesList=new List<IMethodMetricscalculator>();

       public MethodMetricscalculator()
       {
           _rulesList.Add(new MethodLocRule());
           _rulesList.Add(new MethodparametersRule());
           _rulesList.Add(new MethodCyclomaticComplexityCounter());
       }

       public void Calculate(ProjectAnalysisData prj, ClassMetrics clsMetrics, ClassAnalysisData cls)
        {
            SemanticModel smtdmodel = prj.CompiledProject.GetSemanticModel(cls.ClassDeclarationSyntax.SyntaxTree);
            foreach (var mtd in cls.Methods)
            {
                MethodMetrics mtdMetrics = new MethodMetrics();
                foreach (var rule in _rulesList)
                {
                    rule.CalculateMethodMetrics(prj,clsMetrics,cls,mtdMetrics,mtd.MethodDeclarationSyntax,smtdmodel);
                }            
                clsMetrics.MethodMetricses.Add(mtdMetrics);
            }
        }
    }
}
