using System.Collections.ObjectModel;
using ObservableComputations.Samples.Domain;

namespace ObservableComputations.Samples.Examples
{
	public class EditRelationsViewModel
	{
		public ParentViewModel ParentViewModel { get; }
		private readonly ObservableCollection<Person> _people;
		private readonly ObservableCollection<Relation> _relations;
		private readonly OcConsumer _consumer;

		public  ObservableCollection<RelationViewModel> RelationViewModels { get; }

		public EditRelationsViewModel(ParentViewModel parentViewModel, ObservableCollection<Person> people, ObservableCollection<Relation> relations, OcConsumer consumer)
		{
			_consumer = consumer;
			ParentViewModel = parentViewModel;
			_people = people;
			_relations = relations;

			RelationViewModels = 
				_people
				.Selecting(p => new RelationViewModel(ParentViewModel, p, _relations, _consumer))
				.For(_consumer);
		}
	}
}
