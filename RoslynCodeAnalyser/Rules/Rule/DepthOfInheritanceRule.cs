using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Rules.Rule
{
   public class DepthOfInheritanceRule
    {
        private readonly IEnumerable<TypeKind> _inheritableTypes = new[] { TypeKind.Class, TypeKind.Struct };
        private readonly SemanticModel _semanticModel;

        public DepthOfInheritanceRule(SemanticModel semanticModel)
        {
            _semanticModel = semanticModel;
        }

        public int Calculate(TypeDeclarationSyntax type)
        {
            var num = type.IsKind(SyntaxKind.ClassDeclaration) || type.IsKind(SyntaxKind.StructDeclaration) ? 1 : 0;
            if (type.BaseList != null)
            {
                foreach (var symbolInfo in type.BaseList.Types.Select(syntax => _semanticModel.GetSymbolInfo(syntax)))
                {
                    for (var symbol = symbolInfo.Symbol as INamedTypeSymbol; symbol != null; symbol = symbol.BaseType)
                    {
                        if (_inheritableTypes.Any(x => x == symbol.TypeKind))
                        {
                            num++;
                        }
                    }
                }
            }

            return num == 0 && (type.IsKind(SyntaxKind.ClassDeclaration) || type.IsKind(SyntaxKind.StructDeclaration))
                ? 1
                : num;
        }
    }
}
