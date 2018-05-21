using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.CodeAnalysis;
using Rules.Model;
using Rules.Rule;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Rules.Calculator.MethodLevelRuleCaller
{
    class MethodCyclomaticComplexityCounter :IMethodMetricscalculator
    {
        public void CalculateMethodMetrics(ProjectAnalysisData prj, ClassMetrics clsMetrics, ClassAnalysisData cls,
            MethodMetrics mtdMetrics, MethodDeclarationSyntax mtd, SemanticModel sclsmodel)
        {
            CyclomaticComplexityCounter cc = new CyclomaticComplexityCounter();
            mtdMetrics.CyclomaticComplexity = cc.Calculate(mtd, sclsmodel);
        }
    }
}
