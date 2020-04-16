namespace ObservableComputations.Samples.Domain
{
    public class Relation
    {
        public Person Parent { get;  }
        public Person Child { get;  }

        public Relation(Person parent, Person child)
        {
            Parent = parent;
            Child = child;
        }
    }
}