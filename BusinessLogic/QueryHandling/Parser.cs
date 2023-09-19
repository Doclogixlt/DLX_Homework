using BusinessLogic.BusinessModels;

namespace BusinessLogic.QueryHandling
{
    public class QueryParser
    {
        private List<Token> tokens;
        private int currentTokenIndex;

        public QueryParser(List<Token> tokens)
        {
            this.tokens = tokens;
            currentTokenIndex = 0;
        }

        public ExpressionNode Parse()
        {
            return ParseExpression();
        }

        private ExpressionNode ParseExpression()
        {
            var left = ParseComparisonExpression();

            while (currentTokenIndex < tokens.Count && tokens[currentTokenIndex].Type == TokenType.LogicalOperator)
            {
                string Operator = tokens[currentTokenIndex].Value;
                currentTokenIndex++;
                var right = ParseComparisonExpression();
                left = new LogicalExpression(left, Operator, right);
            }

            return left;
        }


        private ExpressionNode ParseComparisonExpression()
        {
            string columnName = tokens[currentTokenIndex].Value;
            currentTokenIndex++;
            string Operator = tokens[currentTokenIndex].Value;
            currentTokenIndex++;
            string valueStr = tokens[currentTokenIndex].Value;

            IValue valueObj;
            switch (tokens[currentTokenIndex].Type)
            {
                case TokenType.IntValue:
                    valueObj = new IntValue(int.Parse(valueStr));
                    break;
                case TokenType.DecimalValue:
                    valueObj = new DecimalValue(decimal.Parse(valueStr));
                    break;
                default:
                    valueObj = new StringValue(valueStr);
                    break;
            }
            currentTokenIndex++;

            return new ComparisonExpression(columnName, Operator, valueObj);
        }
    }
}
