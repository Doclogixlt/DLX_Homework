using BusinessLogic.BusinessModels;

namespace BusinessLogic.QueryHandling
{
    public static class Evaluator
    {
        public static bool Evaluate(ExpressionNode node, LogEntry entry)
        {
            if (node is ComparisonExpression comparisonNode)
            {
                return EvaluateComparison(comparisonNode, entry);
            }
            else if (node is LogicalExpression logicalNode)
            {
                return EvaluateLogical(logicalNode, entry);
            }
            else
            {
                throw new InvalidOperationException("Unknown node type");
            }
        }

        private static bool EvaluateComparison(ComparisonExpression node, LogEntry entry)
        {
            var columnValue = entry.GetPropertyValue(node.ColumnName);
            var comparisonValue = ConvertToComparableType(columnValue, node.Value);

            IComparisonStrategy strategy = GetStrategy(node.Operator);
            return strategy.Compare(columnValue, comparisonValue);
        }

        private static bool EvaluateLogical(LogicalExpression node, LogEntry entry)
        {
            var leftResult = Evaluate(node.Left, entry);
            var rightResult = Evaluate(node.Right, entry);

            return node.Operator switch
            {
                "AND" => leftResult && rightResult,
                "OR" => leftResult || rightResult,
                _ => throw new InvalidOperationException($"Unknown operator: {node.Operator}")
            };
        }


        private static IComparisonStrategy GetStrategy(string operatorSymbol)
        {
            return operatorSymbol switch
            {
                "=" => new EqualsStrategy(),
                "!=" => new NotEqualsStrategy(),
                ">" => new GreaterThanStrategy(),
                "<" => new LessThanStrategy(),
                ">=" => new GreaterThanOrEqualStrategy(),
                "<=" => new LessThanOrEqualStrategy(),
                _ => throw new InvalidOperationException($"Unknown operator: {operatorSymbol}")
            };
        }

        private static object ConvertToComparableType(object columnValue, IValue comparisonValue)
        {
            var comparisonValueObj = comparisonValue.GetValue();

            if (columnValue is int && comparisonValueObj is int intCompValue)
            {
                return intCompValue;
            }
            else if (columnValue is decimal  && comparisonValueObj is decimal decimalCompValue)
            {
                return decimalCompValue;
            }
            else if (columnValue is int || columnValue is decimal)
            {
                if (decimal.TryParse(comparisonValueObj.ToString(), out var decimalValue))
                {
                    return decimalValue;
                }
            }
            else if (columnValue is string && comparisonValueObj is string strCompValue)
            {
                return strCompValue;
            }

            return comparisonValueObj;
        }

    }
}
