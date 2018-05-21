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
   public interface IMethodMetricscalculator
    {
        void CalculateMethodMetrics(ProjectAnalysisData prj, ClassMetrics clsMetrics, ClassAnalysisData cls, MethodMetrics mtdMetrics,MethodDeclarationSyntax mtd, SemanticModel sclsmodel);
    }
}
