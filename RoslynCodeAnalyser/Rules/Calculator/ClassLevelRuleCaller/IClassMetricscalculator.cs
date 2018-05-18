using Core.Models;
using Microsoft.CodeAnalysis;
using Rules.Model;

namespace Rules.Calculator.ClassLevelRuleCaller
{
    public interface IClassMetricscalculator
    {
        void CalculateClassMetrics(ProjectAnalysisData prj, ClassMetrics clsMetrics, ClassAnalysisData cls, SemanticModel sclsmodel);
    }
}
