
using Microsoft.CodeAnalysis;

namespace Rules.IOModel
{
   public class InputModel
    {
       public SyntaxNode node { get; set; }
        public SemanticModel semanticModel { get; set; }
    }
}
