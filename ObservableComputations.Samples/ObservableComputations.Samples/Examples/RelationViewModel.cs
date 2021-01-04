using System.Collections.ObjectModel;
using System.Linq;
using ObservableComputations.Samples.Domain;

namespace ObservableComputations.Samples.Examples
{
    public class RelationViewModel
    {
	    private readonly ParentViewModel _parent;
	    private readonly Person _child;
	    private readonly ObservableCollection<Relation> _relations;
		private readonly OcConsumer _consumer;

	    public RelationViewModel(ParentViewModel parent, Person child, ObservableCollection<Relation> relations, OcConsumer consumer)
	    {
			_consumer = consumer;
		    _parent = parent;
		    _child = child;
		    _relations = relations;

		    IsSelected = _relations.AnyComputing(r => r.Parent == _parent.Parent && r.Child == _child).For(_consumer);

		    IsSelected.SetValueRequestHandler = selected =>
		    {
				if (selected) _relations.Add(new Relation(_parent.Parent, _child));
				else _relations.Remove(_relations.Single(r => r.Parent == _parent.Parent && r.Child == child));
		    };
	    }

	    public ScalarComputing<bool> IsSelected { get; }

	    public override string ToString()
	    {
		    return _child.Name;
	    }
    }
}
