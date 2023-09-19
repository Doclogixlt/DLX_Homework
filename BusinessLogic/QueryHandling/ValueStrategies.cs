

namespace BusinessLogic.QueryHandling
{
    public interface IValue
    {
        object GetValue();
    }

    public class StringValue : IValue
    {
        private string value;

        public StringValue(string value)
        {
            this.value = value;
        }

        public object GetValue()
        {
            return value;
        }
    }

    public class IntValue : IValue
    {
        private int value;

        public IntValue(int value)
        {
            this.value = value;
        }

        public object GetValue()
        {
            return value;
        }
    }

    public class DecimalValue : IValue
    {
        private decimal value;

        public DecimalValue(decimal value)
        {
            this.value = value;
        }

        public object GetValue()
        {
            return value;
        }
    }
}
