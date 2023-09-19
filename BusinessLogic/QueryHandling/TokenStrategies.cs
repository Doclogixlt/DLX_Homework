using BusinessLogic.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic.QueryHandling
{
    public interface ITokenStrategy
    {
        bool Match(string input, out Token token);
    }

    public abstract class BaseStrategy : ITokenStrategy
    {
        protected abstract Regex Pattern { get; }
        protected abstract TokenType TokenType { get; }
        public virtual bool Match(string input, out Token token)
        {
            if (Pattern.IsMatch(input))
            {
                token = new Token(TokenType, input);
                return true;
            }

            token = null;
            return false;
        }
    }

    public class ColumnNameStrategy : BaseStrategy
    {
        private static readonly Regex _pattern = new Regex(@"^[a-zA-Z_][a-zA-Z_0-9]*$", RegexOptions.Compiled);

        protected override Regex Pattern => _pattern;
        protected override TokenType TokenType => TokenType.ColumnName;
    }

    public class OperatorStrategy : BaseStrategy
    {
        private static readonly Regex _pattern = new Regex(@"^(=|<|>|<=|>=|!=)$", RegexOptions.Compiled);

        protected override Regex Pattern => _pattern;
        protected override TokenType TokenType => TokenType.Operator;
    }

    public class TextValueStrategy : BaseStrategy
    {
        private static readonly Regex _pattern = new Regex(@"^'[^']*'$", RegexOptions.Compiled);
        protected override Regex Pattern => _pattern;
        protected override TokenType TokenType => TokenType.TextValue;

        public override bool Match(string input, out Token token)
        {
            if (Pattern.IsMatch(input))
            {
                string sanitizedInput = SanitizeInput(input);
                token = new Token(TokenType, sanitizedInput);
                return true;
            }

            token = null;
            return false;
        }

        private string SanitizeInput(string input)
        {
            if (input.StartsWith("'") && input.EndsWith("'"))
            {
                return input.Substring(1, input.Length - 2);
            }
            return input;
        }
    }

    public class IntValueStrategy : BaseStrategy
    {
        private static readonly Regex _pattern = new Regex(@"^-?[0-9]+$", RegexOptions.Compiled);
        protected override Regex Pattern => _pattern;
        protected override TokenType TokenType => TokenType.IntValue;
    }

    public class DecimalValueStrategy : BaseStrategy
    {
        private static readonly Regex _pattern = new Regex(@"^-?[0-9]*\.[0-9]+$", RegexOptions.Compiled);
        protected override Regex Pattern => _pattern;
        protected override TokenType TokenType => TokenType.DecimalValue;
    }


    public class LogicalOperatorStrategy : BaseStrategy
    {
        private static readonly Regex _pattern = new Regex(@"^(AND|OR|NOT)$", RegexOptions.Compiled);
        protected override Regex Pattern => _pattern;
        protected override TokenType TokenType => TokenType.LogicalOperator;
    }
}
