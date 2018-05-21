using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Rules.Model;

namespace Rules.Calculator.MethodLevelRuleCaller
{
    class MethodparametersRule :IMethodMetricscalculator
    {
        public void CalculateMethodMetrics(ProjectAnalysisData prj, ClassMetrics clsMetrics, ClassAnalysisData cls,
            MethodMetrics mtdMetrics, MethodDeclarationSyntax mtd, SemanticModel sclsmodel)
        {
            Rule.MethodparametersRule mtdprmrule = new Rule.MethodparametersRule();
            mtdMetrics.Methodparameters = mtdprmrule.GetMethodparametersCount(mtd);
        }
    }
}
