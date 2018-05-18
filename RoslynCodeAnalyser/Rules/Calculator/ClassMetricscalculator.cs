using System.Collections.Generic;
using Core.Models;
using Microsoft.CodeAnalysis;
using Rules.Calculator.ClassLevelRuleCaller;
using Rules.Model;

namespace Rules.Calculator
{
   public class ClassMetricscalculator
    {
        List<IClassMetricscalculator> _rulesList =new List<IClassMetricscalculator>();
       public ClassMetricscalculator()
       {
           _rulesList.Add(new ClassCyclomaticComplexityCounter());
           _rulesList.Add(new ClassLocRule());
       }

       public void Calculate(ProjectAnalysisData prj, ClassMetrics clsMetrics, ClassAnalysisData cls)
       {
            clsMetrics.Classname = cls.ClassDeclarationSyntax.Identifier.ValueText;
            clsMetrics.Classdocpath = cls.ClassDeclarationSyntax.SyntaxTree.FilePath;
            clsMetrics.Namespacename = cls.Namespace.Namespacedeclaration.Name.ToString();
            SemanticModel sclsmodel = prj.CompiledProject.GetSemanticModel(cls.ClassDeclarationSyntax.SyntaxTree);
           foreach (var rule in _rulesList)
           {
               rule.CalculateClassMetrics(prj,clsMetrics,cls,sclsmodel);
           }
        }
    }
}
