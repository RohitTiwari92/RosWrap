using Microsoft.CodeAnalysis;

namespace Core.Helper.Interfaces
{
    public interface ISyntaxNodeHelper
    {
        bool TryGetParentSyntax<TInput>(SyntaxNode syntaxNode, out TInput result) where TInput : SyntaxNode;
    }
}
