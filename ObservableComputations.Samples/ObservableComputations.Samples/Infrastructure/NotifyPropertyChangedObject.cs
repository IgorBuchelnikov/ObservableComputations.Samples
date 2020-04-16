using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ObservableComputations.Samples.Infrastructure
{
	public class NotifyPropertyChangedObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual bool SetAndRaise<TProperty>(ref TProperty bakingField, TProperty newValue, [CallerMemberName] string propertyName = null)
		{
			if (!EqualityComparer<TProperty>.Default.Equals(bakingField, newValue))
			{
				bakingField = newValue;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
				return true;
			}

			return false;

		}
	}
}
