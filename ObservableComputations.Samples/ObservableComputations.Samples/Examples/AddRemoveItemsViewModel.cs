using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ObservableComputations.Samples.Infrastructure;

namespace ObservableComputations.Samples.Examples
{
    public class AddRemoveItemsViewModel
    {
        private readonly ObservableCollection<FootballPlayer> _availablePlayers;

        private readonly ObservableCollection<FootballPlayer> _myTeamPeople;

        public ObservableCollection<FootballPlayer> AvailablePlayers => _availablePlayers;
        public ObservableCollection<FootballPlayer> MyTeam => _myTeamPeople;

        public AddRemoveItemsViewModel()
        {
            var people = CreateFootballerList().Ordering(person => person.LastModifiedDateTime);

            _availablePlayers = people.Filtering(person => !person.IsIncluded);

            _myTeamPeople = people.Filtering(person => person.IsIncluded);
        }

        private ObservableCollection<FootballPlayer> CreateFootballerList()
        {
            var people = new ObservableCollection<FootballPlayer>(
	            new[]
	            {
	                new FootballPlayer("Hennessey"),
	                new FootballPlayer("Chester"),
	                new FootballPlayer("Williams"),
	                new FootballPlayer("Davies"),
	                new FootballPlayer("Gunter"),
	                new FootballPlayer("Allen"),
	                new FootballPlayer("Ledley"),
	                new FootballPlayer("Ramsey"),
	                new FootballPlayer("Taylor"),
	                new FootballPlayer("Bale"),
	                new FootballPlayer("King"),
	                new FootballPlayer("Hennessey"),
	                new FootballPlayer("Collins"),

	                new FootballPlayer("Courtois"),
	                new FootballPlayer("Meunier"),
	                new FootballPlayer("Alderweireld"),
	                new FootballPlayer("Denayer"),
	                new FootballPlayer("J Lukaku"),
	                new FootballPlayer("Nainggolan"),
	                new FootballPlayer("Witsel"),
	                new FootballPlayer("Carrasco"),
	                new FootballPlayer("De Bruyne"),
	                new FootballPlayer("Hazard"),
	                new FootballPlayer("R Lukaku"),
	                new FootballPlayer("Merten"),
	                new FootballPlayer("Fellain"),
	                new FootballPlayer("Batshuayiat"),
	            });

            return people;
        }
    }

    public class FootballPlayer : NotifyPropertyChangedObject
    {
	    public string Name { get;  }

	    private bool _isIncluded;
        public bool IsIncluded
        {
	        get => _isIncluded;
	        set
	        {
		        if (SetAndRaise(ref _isIncluded, value))
		        {
			        LastModifiedDateTime = DateTime.Now;
		        }
	        }
        }

        private DateTime _lastModifiedDateTime;
        public DateTime LastModifiedDateTime
        {
	        get => _lastModifiedDateTime;
	        set => SetAndRaise(ref _lastModifiedDateTime, value);
        }

        public ICommand IncludeCommand { get; }
        public ICommand ExcludeCommand { get; }

        public FootballPlayer(string name)
        {
	        LastModifiedDateTime = DateTime.Now;
            Name = name;

            IncludeCommand = new Command(() => IsIncluded = true );
            ExcludeCommand = new Command(() => IsIncluded = false);
        }
    }
}
