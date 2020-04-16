using System;
using System.Collections.ObjectModel;
using System.Linq;
using ObservableComputations.Samples.Infrastructure;

namespace ObservableComputations.Samples.Examples
{
    public class AggregationViewModel 
    {
        private readonly ObservableCollection<AggregationItem> _items;
        public ObservableCollection<AggregationItem> Items => _items;

        private IReadScalar<int> _max;
        private IReadScalar<double> _stdDev;
        private IReadScalar<double> _avg;
        private IReadScalar<int> _min;
        private IReadScalar<int> _sumOfOddNumbers;
        private IReadScalar<int> _sum;
        private ObservableCollection<int> _included;

        public AggregationViewModel()
        {
            var sourceList = new System.Collections.Generic.List<AggregationItem>(
	            Enumerable.Range(1, 15).Select(i => new AggregationItem(i)));

            _items = new ObservableCollection<AggregationItem>(sourceList);

            _included = _items.Filtering(i => i.IncludeInTotal).Selecting(i => i.Number);
			
            _sum = _included.Summarizing();

            _min = _included.Minimazing();

            _max = _included.Maximazing();

            _max = _included.Maximazing();

            _avg = _included.Averaging<int, double>();

            _stdDev =  new Computing<double>(() => 
	            Math.Sqrt(_included.Selecting(n => Math.Pow(n - _avg.Value, 2)).Summarizing().Value 
					/ (_included.Count - 1)));

            _sumOfOddNumbers = _included.Filtering(i => i % 2 == 1).Summarizing();

        }
        
        public ObservableCollection<int> Included => _included;													 		

        public IReadScalar<int> Sum => _sum;

        public IReadScalar<int> Min => _min;

        public IReadScalar<int> Max => _max;

        public IReadScalar<double> StdDev => _stdDev;
        
        public IReadScalar<double> Avg => _avg;

        public IReadScalar<int> SumOfOddNumbers => _sumOfOddNumbers;
    }

    public class AggregationItem : NotifyPropertyChangedObject
    {
        public int Number { get; }

        private bool _includeInTotal = true;
        
        public AggregationItem(int number)
        {
            Number = number;
        }

        public bool IncludeInTotal
        {
            get { return _includeInTotal; }
            set { SetAndRaise(ref _includeInTotal, value); }
        }
    }
}
