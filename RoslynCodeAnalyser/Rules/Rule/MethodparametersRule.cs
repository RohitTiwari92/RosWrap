using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Rules.Rule
{
    public class GetMethodparametersRule
    {
        public int GetMethodparametersCount(MethodDeclarationSyntax methodDeclarationSyntax)
        {
           return methodDeclarationSyntax.ParameterList.Parameters.Count;
        }
        public ParameterListSyntax GetMethodparameters(MethodDeclarationSyntax methodDeclarationSyntax)
        {
            return methodDeclarationSyntax.ParameterList;
        }

    }
}
