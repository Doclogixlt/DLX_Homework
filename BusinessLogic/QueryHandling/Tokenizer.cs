using BusinessLogic.BusinessModels;
using System.Text.RegularExpressions;

namespace BusinessLogic.QueryHandling
{
    public class Tokenizer
    {
        private TokenFactory _tokenFactory;
        public Tokenizer()
        {
            _tokenFactory = new TokenFactory();
        }

        public List<Token> Tokenize(string input)
        {
            var tokens = new List<Token>();
            var matches = Regex.Matches(input, @"'[^']*'|[^\s']+");

            foreach (Match match in matches)
            {
                tokens.Add(_tokenFactory.CreateToken(match.Value));
            }

            return tokens;
        }
    }
}
