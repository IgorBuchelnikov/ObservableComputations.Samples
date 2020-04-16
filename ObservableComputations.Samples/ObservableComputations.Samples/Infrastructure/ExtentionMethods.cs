using System.Collections.Generic;

namespace ObservableComputations.Samples.Infrastructure
{
	public static class ExtentionMethods
	{
		public static void AddRange<TItem>(this IList<TItem> list, IEnumerable<TItem> items)
		{
			foreach (TItem item in items)
			{
				list.Add(item);
			}
		}
	}
}
