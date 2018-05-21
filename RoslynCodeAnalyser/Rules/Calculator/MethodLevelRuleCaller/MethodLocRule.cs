using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Rules.Model;
using Rules.Rule;

namespace Rules.Calculator.MethodLevelRuleCaller
{
    class MethodLocRule : IMethodMetricscalculator
    {
        public void CalculateMethodMetrics(ProjectAnalysisData prj, ClassMetrics clsMetrics, ClassAnalysisData cls,
            MethodMetrics mtdMetrics, MethodDeclarationSyntax mtd, SemanticModel sclsmodel)
        {
            LocRule loc = new LocRule();
            mtdMetrics.Loc = loc.GetLocCount(mtd);
        }
    }
}
