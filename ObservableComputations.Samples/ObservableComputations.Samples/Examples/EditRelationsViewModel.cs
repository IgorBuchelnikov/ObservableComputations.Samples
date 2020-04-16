using System.Collections.ObjectModel;
using ObservableComputations.Samples.Domain;

namespace ObservableComputations.Samples.Examples
{
	public class EditRelationsViewModel
	{
		public ParentViewModel ParentViewModel { get; }
		private readonly ObservableCollection<Person> _people;
		private readonly ObservableCollection<Relation> _relations;

		public  ObservableCollection<RelationViewModel> RelationViewModels { get; }

		public EditRelationsViewModel(ParentViewModel parentViewModel, ObservableCollection<Person> people, ObservableCollection<Relation> relations)
		{
			ParentViewModel = parentViewModel;
			_people = people;
			_relations = relations;

			RelationViewModels = _people.Selecting(p => new RelationViewModel(ParentViewModel, p, _relations));
		}
	}
}
