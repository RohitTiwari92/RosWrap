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
    class ClassDepthOfInheritanceCounter : IClassMetricscalculator
    {
        public void CalculateClassMetrics(ProjectAnalysisData prj, ClassMetrics clsMetrics, ClassAnalysisData cls, SemanticModel sclsmodel)
        {
            DepthOfInheritanceRule depthOfInheritance = new DepthOfInheritanceRule(sclsmodel);
              clsMetrics.DOI= depthOfInheritance.Calculate(cls.ClassDeclarationSyntax);
        }
    }
}
