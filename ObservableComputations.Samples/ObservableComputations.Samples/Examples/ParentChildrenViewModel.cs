using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using ObservableComputations.Samples.Domain;
using ObservableComputations.Samples.Infrastructure;

namespace ObservableComputations.Samples.Examples
{
    public class ParentChildrenViewModel
    {
        private readonly ObservableCollection<Person> _people = new ObservableCollection<Person>();
        private readonly ObservableCollection<Relation> _relations = new ObservableCollection<Relation>();

		private readonly  OcConsumer _consumer = new OcConsumer();

        public ObservableCollection<ParentViewModel> Data { get; }

        public ParentChildrenViewModel()
        {
	        Action<ParentViewModel> editAction = async pvm => await EditPerson(pvm);
	        Data = _people.Selecting(p => new ParentViewModel(p, _people, _relations, editAction, _consumer)).For(_consumer);

            LoadInitialData();
        }

        private async Task EditPerson(ParentViewModel parentViewModel)
        {
            var editor = new EditRelationsViewModel(parentViewModel, _people, _relations, _consumer);
            await DialogHost.Show(editor);
        }

        private void LoadInitialData()
        {
	        _people.AddRange(Enumerable.Range(1, 15).Select(i => new Person("Person " + i, i + 10)));

            _relations.AddRange(new[]
            {
	            new Relation(_people[1], _people[2]),
	            new Relation(_people[1], _people[8]),
	            new Relation(_people[2], _people[2]),
	            new Relation(_people[5], _people[6]),
	            new Relation(_people[6], _people[10]),
	            new Relation(_people[10], _people[0]),
	            new Relation(_people[10], _people[1]),
            });
 
        }
    }
}
