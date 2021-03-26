using System.Collections.Generic;
using System.Linq;

namespace WpfNavigable.Front
{
    public static class BoardExtensions
    {
        private const string DEFAULT_SEPARATOR = ",";

        public static string AddSepartor(this string serializedUnseparatedPostion, string separator = DEFAULT_SEPARATOR) =>
            string.IsNullOrWhiteSpace(serializedUnseparatedPostion)
            ? string.Empty
            : string.Join(separator, serializedUnseparatedPostion.Select(x => x));

        public static (int, int) ToRowAndColumn(this string serializedUnseparatedPostion) =>
            string.IsNullOrWhiteSpace(serializedUnseparatedPostion)
            ? ToPostions(new List<string>())
            : ToPostions(serializedUnseparatedPostion.AddSepartor()
                .Split(DEFAULT_SEPARATOR));

        public static (int,int) ToPostions(IList<string> rawPostionsList)
        {
            if(rawPostionsList == null || rawPostionsList.Count<2)
            {
                return (-1, -1);
            }
            var result = rawPostionsList
                .Select(rp => SafeParse(rp))
                .ToArray();
            return (result[0], result[1]);
        }

        private static int SafeParse(string rp)
        {
            if(!int.TryParse(rp, out int result))
            {
                return -1;
            }
            return result;

        }
    }
}
