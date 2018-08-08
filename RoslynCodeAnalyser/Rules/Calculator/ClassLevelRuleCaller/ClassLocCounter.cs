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
    
     public   class ClassLocCounter : IClassMetricscalculator
    {
      public void CalculateClassMetrics(ProjectAnalysisData prj, ClassMetrics clsMetrics, ClassAnalysisData cls,
          SemanticModel sclsmodel)
      {
         LocRule loc=new LocRule();
          clsMetrics.Loc = loc.GetLocCount(cls.ClassDeclarationSyntax);
      }
    }
}
