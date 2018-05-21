using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.CodeAnalysis;
using Rules.Model;
using Rules.Rule;

namespace Rules.Calculator
{
  public  class AnalyzeClassMetrics
    {
        public  void AnalyzeClass(ProjectAnalysisData prj, ProjectMetrics metrics)
        {
            foreach (var cls in prj.Classes)
            {
                ClassMetrics clsMetrics = new ClassMetrics();
                CalculateClassMetrics(prj, clsMetrics, cls);
                AnalyzeMethod(prj, cls, clsMetrics);
                AnalyzePropertie(prj, cls, clsMetrics);
                metrics.ClassMetrics.Add(clsMetrics);
            }
        }

        private static void AnalyzePropertie(ProjectAnalysisData prj, ClassAnalysisData cls, ClassMetrics clsMetrics)
        {
            foreach (var prop in cls.Properties)
            {
                break;
            }
        }

        private static void CalculateClassMetrics(ProjectAnalysisData prj, ClassMetrics clsMetrics, ClassAnalysisData cls)
        {
            ClassMetricscalculator calculate=new ClassMetricscalculator();
            calculate.Calculate(prj,clsMetrics,cls);
        
        }
        private static void AnalyzeMethod(ProjectAnalysisData prj, ClassAnalysisData cls, ClassMetrics clsMetrics)
        {
            MethodMetricscalculator mmc=new MethodMetricscalculator();
            mmc.Calculate(prj,clsMetrics,cls);     
        }

    }
}
