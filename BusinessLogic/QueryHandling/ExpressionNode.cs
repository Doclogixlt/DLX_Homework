

namespace BusinessLogic.QueryHandling
{
    public abstract class ExpressionNode { }

    public class ComparisonExpression : ExpressionNode
    {
        public string ColumnName { get; }
        public string Operator { get; }
        public IValue Value { get; }

        public ComparisonExpression(string columnName, string Operator, IValue value)
        {
            ColumnName = columnName;
            this.Operator = Operator;
            Value = value;
        }
    }

    public class LogicalExpression : ExpressionNode
    {
        public ExpressionNode Left { get; }
        public string Operator { get; }
        public ExpressionNode Right { get; }

        public LogicalExpression(ExpressionNode left, string Operator, ExpressionNode right)
        {
            Left = left;
            this.Operator = Operator;
            Right = right;
        }
    }
}
