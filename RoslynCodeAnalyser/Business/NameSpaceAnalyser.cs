using System.Collections.Generic;
using System.Linq;
using Business.Interfaces;
using Core.Models;
using Core.NamespaceVirtualization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Business
{
    public class NameSpaceAnalyser : INameSpaceAnalyser
    {



        public NameSpaceAnalyser()
        {
         
        }

       

        public NamspaceAnalysisData Analyse(ClassDeclarationSyntax classDeclarationSyntax)
        {
            NamspaceAnalysisData modelobj=new NamspaceAnalysisData();
            SyntaxTree tree = classDeclarationSyntax.SyntaxTree;
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
            var firstMember = root.Members[0];
            var nsDeclaration = (NamespaceDeclarationSyntax)firstMember;
            modelobj.Namespacedeclaration = nsDeclaration;
            return modelobj;
        }

        public NamspaceAnalysisData Analyse(InterfaceDeclarationSyntax interfaceDeclarationSyntax)
        {
            NamspaceAnalysisData modelobj = new NamspaceAnalysisData();
            SyntaxTree tree = interfaceDeclarationSyntax.SyntaxTree;
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
            var firstMember = root.Members[0];
            var nsDeclaration = (NamespaceDeclarationSyntax)firstMember;
            modelobj.Namespacedeclaration = nsDeclaration;
            return modelobj;
        }
    }

  
}
