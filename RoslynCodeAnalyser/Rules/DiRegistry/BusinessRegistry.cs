using Business.Interfaces;
using Core.ClassVirtualization;
using Core.InterfaceVirtualization;
using Core.NamespaceVirtualization;
using Rules.Calculator.ClassLevelRuleCaller;
using Rules.Calculator.MethodLevelRuleCaller;
using StructureMap;

namespace Rules.DiRegistry
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            Scan(s =>
            {
                s.AddAllTypesOf<IClassMetricscalculator>();
                s.AddAllTypesOf<IMethodMetricscalculator>();
                s.TheCallingAssembly();
               
            });
           
        }
    }
}
