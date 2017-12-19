using System.Collections.Generic;

namespace TDD.NumberManager
{
    public interface INumberToWordManager
    {
        List<string> Convert(IList<int> numbers);
    }
}