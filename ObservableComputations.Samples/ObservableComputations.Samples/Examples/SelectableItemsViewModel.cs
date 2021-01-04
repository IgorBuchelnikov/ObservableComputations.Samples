using System.Collections.ObjectModel;
using System.Linq;
using ObservableComputations.Samples.Infrastructure;

namespace ObservableComputations.Samples.Examples
{
	public class SelectableItemsViewModel
	{
		private readonly ObservableCollection<SimpleItemViewModel> _selected;
		private readonly ObservableCollection<SimpleItemViewModel> _notSelected;

		public ObservableCollection<SimpleItemViewModel> Selected => _selected;
		public ObservableCollection<SimpleItemViewModel> NotSelected => _notSelected;
		private readonly  OcConsumer _consumer = new OcConsumer();

		public SelectableItemsViewModel()
		{
			var sourceList = Enumerable.Range(1, 10).Select(i => new SimpleItem(i)).ToList();

			var viewModels = new ObservableCollection<SimpleItemViewModel>(
				sourceList.Select(simpleItem => new SimpleItemViewModel(simpleItem)));

			_selected = viewModels.Filtering(vm => vm.IsSelected).For(_consumer);

			_notSelected = viewModels.Filtering(vm => !vm.IsSelected).For(_consumer);      
		}

	}

	public class SimpleItemViewModel : NotifyPropertyChangedObject
	{
		private bool _isSelected;
		public SimpleItem Item { get;  }

		public int Number => Item.Id;

		public SimpleItemViewModel(SimpleItem item)
		{
			Item = item;
		}

		public bool IsSelected
		{
			get { return _isSelected; }
			set { SetAndRaise(ref _isSelected, value); }
		}
	}

	public class SimpleItem
	{
		public int Id { get;  }

		public SimpleItem(int id)
		{
			Id = id;
		}
	}
}
