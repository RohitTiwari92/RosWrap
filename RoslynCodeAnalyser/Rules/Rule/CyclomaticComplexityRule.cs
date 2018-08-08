﻿using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace Rules.Rule
{
   public class CyclomaticComplexityRule : CSharpSyntaxWalker
    {

        public int Calculate(SyntaxNode node, SemanticModel semanticModel)
        {
            var analyzer = new InnerComplexityAnalyzer(semanticModel);
            var result = analyzer.Calculate(node);

            return result;
        }

        private class InnerComplexityAnalyzer : CSharpSyntaxWalker
        {
            private static readonly SyntaxKind[] Contributors = new[]
                                                            {
                                                                    SyntaxKind.CaseSwitchLabel,
                                                                    SyntaxKind.CoalesceExpression,
                                                                    SyntaxKind.ConditionalExpression,
                                                                    SyntaxKind.LogicalAndExpression,
                                                                    SyntaxKind.LogicalOrExpression,
                                                                    SyntaxKind.LogicalNotExpression
                                                                };

        // private static readonly string[] LazyTypes = new[] { "System.Threading.Tasks.Task" };
        private readonly SemanticModel _semanticModel;
        private int _counter;

        public InnerComplexityAnalyzer(SemanticModel semanticModel)
				: base(SyntaxWalkerDepth.Node)
			{
            _semanticModel = semanticModel;
            _counter = 1;
        }

        public int Calculate(SyntaxNode syntax)
        {
            if (syntax != null)
            {
                Visit(syntax);
            }

            return _counter;
        }

        public override void Visit(SyntaxNode node)
        {
            base.Visit(node);
            if (Contributors.Contains(node.Kind()))
            {
                _counter++;
            }
        }

        public override void VisitWhileStatement(WhileStatementSyntax node)
        {
            base.VisitWhileStatement(node);
            _counter++;
        }

        public override void VisitForStatement(ForStatementSyntax node)
        {
            base.VisitForStatement(node);
            _counter++;
        }

        public override void VisitForEachStatement(ForEachStatementSyntax node)
        {
            base.VisitForEachStatement(node);
            _counter++;
        }

        public override void VisitArgument(ArgumentSyntax node)
        {
            switch (node.Expression.Kind())
            {
                case SyntaxKind.ParenthesizedLambdaExpression:
                    {
                        var lambda = (ParenthesizedLambdaExpressionSyntax)node.Expression;
                        Visit(lambda.Body);
                    }

                    break;
                case SyntaxKind.SimpleLambdaExpression:
                    {
                        var lambda = (SimpleLambdaExpressionSyntax)node.Expression;
                        Visit(lambda.Body);
                    }

                    break;
            }

            base.VisitArgument(node);
        }

        public override void VisitDefaultExpression(DefaultExpressionSyntax node)
        {
            base.VisitDefaultExpression(node);
            _counter++;
        }

        public override void VisitContinueStatement(ContinueStatementSyntax node)
        {
            base.VisitContinueStatement(node);
            _counter++;
        }

        public override void VisitGotoStatement(GotoStatementSyntax node)
        {
            base.VisitGotoStatement(node);
            _counter++;
        }

        public override void VisitIfStatement(IfStatementSyntax node)
        {
            base.VisitIfStatement(node);
            _counter++;
        }

        public override void VisitCatchClause(CatchClauseSyntax node)
        {
            base.VisitCatchClause(node);
            _counter++;
        }
    }
}
}

