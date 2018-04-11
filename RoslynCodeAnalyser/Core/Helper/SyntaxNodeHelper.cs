using Core.Helper.Interfaces;
using Microsoft.CodeAnalysis;

namespace Core.Helper
{
    public class SyntaxNodeHelper : ISyntaxNodeHelper
    {
        public bool TryGetParentSyntax<TInput>(SyntaxNode syntaxNode, out TInput result) where TInput : SyntaxNode
        {
            result = null;
            if (syntaxNode == null)
                return false;

            try
            {
                syntaxNode = syntaxNode.Parent;
                if (syntaxNode == null)
                    return false;

                if (syntaxNode.GetType() == typeof(TInput))
                {
                    result = syntaxNode as TInput;
                    return true;
                }

                return TryGetParentSyntax(syntaxNode, out result);
            }
            catch
            {
                return false;
            }
        }
    }
}
