

namespace BusinessLogic.BusinessModels
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }

    public enum TokenType
    {
        ColumnName,
        Operator,
        TextValue,
        IntValue,
        DecimalValue,
        LogicalOperator
    }
}
