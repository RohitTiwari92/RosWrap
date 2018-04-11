using Business.Interfaces;
using Core.ClassVirtualization;
using Core.InterfaceVirtualization;
using Core.NamespaceVirtualization;
using StructureMap;

namespace Business.DiRegistry
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            Scan(s =>
            {
                s.TheCallingAssembly();
                s.SingleImplementationsOfInterface();
                s.WithDefaultConventions();
                s.AssembliesAndExecutablesFromApplicationBaseDirectory();
                s.ConnectImplementationsToTypesClosing(typeof(IMethodAnalyser<>));
                s.ConnectImplementationsToTypesClosing(typeof(IModelListGetter<>));
            });
            For<CSharpSyntaxRewriterWrapperForNamespace>().Use<NamespaceVirtualizationVisitor>();
            For<CSharpSyntaxRewriterWrapperForClass>().Use<ClassVirtualizationVisitor>();
            For<CSharpSyntaxRewriterWrapperForInterface>().Use<InterfaceVirtualizationVisitor>();
        }
    }
}
