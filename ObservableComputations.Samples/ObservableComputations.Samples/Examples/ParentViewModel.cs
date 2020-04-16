using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ObservableComputations.Samples.Domain;
using ObservableComputations.Samples.Infrastructure;

namespace ObservableComputations.Samples.Examples
{
    public class ParentViewModel
    {
	    private readonly ObservableCollection<Person> _people;
	    private readonly ObservableCollection<Relation> _relations;

        public Person Parent { get;  }

        public ObservableCollection<Person> Children { get;  }
		public IReadScalar<string> ChildrenNames { get; }
		public ICommand EditCommand { get; }

		public ObservableCollection<RelationViewModel> GetRelationViewModels()
		{
			return _people.Selecting(p => new RelationViewModel(this, p, _relations));
		}
        
        public ParentViewModel(Person parent, ObservableCollection<Person> people, ObservableCollection<Relation> relations, Action<ParentViewModel> editAction)
        {
	        _people = people;
	        _relations = relations;

            Parent = parent;

            Children = relations.Filtering(r => r.Parent == parent).Selecting(r => r.Child);

            ChildrenNames = new Computing<string>(() => 
	            Children.Count == 0 
				 ? "<None>" 
				 : Children
					 .Selecting(c => c.Name)
					 .Ordering(cn => cn)
					 .StringsConcatenating(", ").Value);

            EditCommand = new Command(() => editAction(this));
        }
    }
}