using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.CodeAnalysis;
using Rules.Model;
using Rules.Rule;

namespace Rules.Calculator.ClassLevelRuleCaller
{
   public class ClassCyclomaticComplexityCounter : IClassMetricscalculator
    {
       public void CalculateClassMetrics(ProjectAnalysisData prj, ClassMetrics clsMetrics, ClassAnalysisData cls,
           SemanticModel sclsmodel)
       {
            CyclomaticComplexityRule cc=new CyclomaticComplexityRule();
            clsMetrics.CyclomaticComplexity= cc.Calculate(cls.ClassDeclarationSyntax, sclsmodel);
       }
    }
}
