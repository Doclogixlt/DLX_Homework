using BusinessLogic.BusinessModels;

namespace BusinessLogic.QueryHandling
{
    public class TokenFactory
    {
        private List<ITokenStrategy> strategies;
        public TokenFactory()
        {
            strategies = new List<ITokenStrategy>
            {
                new LogicalOperatorStrategy(),
                new ColumnNameStrategy(),
                new OperatorStrategy(),
                new TextValueStrategy(),
                new IntValueStrategy(),
                new DecimalValueStrategy()
            };
        }

        public Token CreateToken(string input)
        {
            foreach (var strategy in strategies)
            {
                if (strategy.Match(input, out var token))
                    return token;
            }

            throw new InvalidOperationException($"Unknown token: {input}");
        }
    }
}
