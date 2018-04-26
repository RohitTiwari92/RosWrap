using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Rules.Rule
{
    public class GetLocRule
    {
        public int GetLocCount(SyntaxNode node)
        {
            var classtext = node.SyntaxTree.GetText();
            return classtext.Lines.Count;
        }
    }
}
