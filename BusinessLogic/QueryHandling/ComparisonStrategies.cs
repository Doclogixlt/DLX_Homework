

namespace BusinessLogic.QueryHandling
{
    public interface IComparisonStrategy
    {
        bool Compare(object columnValue, object comparisonValue);
    }

    public class EqualsStrategy : IComparisonStrategy
    {
        public bool Compare(object columnValue, object comparisonValue)
        {
            if (columnValue is string strColValue && comparisonValue is string strCompValue)
            {
                return strColValue.ToLower().Contains(strCompValue.ToLower());
            }
            return columnValue.Equals(comparisonValue);
        }
    }

    public class NotEqualsStrategy : IComparisonStrategy
    {
        public bool Compare(object columnValue, object comparisonValue)
        {
            if (columnValue is string strColValue && comparisonValue is string strCompValue)
            {
                return !strColValue.ToLower().Contains(strCompValue.ToLower());
            }
            return !columnValue.Equals(comparisonValue);
        }
    }

    public class GreaterThanStrategy : IComparisonStrategy
    {
        public bool Compare(object columnValue, object comparisonValue)
        {
            if (columnValue is IComparable columnComparable)
            {
                return columnComparable.CompareTo(comparisonValue) > 0;
            }
            throw new InvalidOperationException($"Cannot compare {columnValue} with {comparisonValue} using '>'");
        }
    }

    public class LessThanStrategy : IComparisonStrategy
    {
        public bool Compare(object columnValue, object comparisonValue)
        {
            if (columnValue is IComparable columnComparable && comparisonValue is IComparable comparisonComparable)
            {
                return columnComparable.CompareTo(comparisonComparable) < 0;
            }
            throw new InvalidOperationException($"Cannot compare {columnValue} with {comparisonValue} using '<'");
        }
    }

    public class GreaterThanOrEqualStrategy : IComparisonStrategy
    {
        public bool Compare(object columnValue, object comparisonValue)
        {
            if (columnValue is IComparable columnComparable && comparisonValue is IComparable comparisonComparable)
            {
                return columnComparable.CompareTo(comparisonComparable) >= 0;
            }
            throw new InvalidOperationException($"Cannot compare {columnValue} with {comparisonValue} using '>='");
        }
    }

    public class LessThanOrEqualStrategy : IComparisonStrategy
    {
        public bool Compare(object columnValue, object comparisonValue)
        {
            if (columnValue is IComparable columnComparable && comparisonValue is IComparable comparisonComparable)
            {
                return columnComparable.CompareTo(comparisonComparable) <= 0;
            }
            throw new InvalidOperationException($"Cannot compare {columnValue} with {comparisonValue} using '<='");
        }
    }
}
