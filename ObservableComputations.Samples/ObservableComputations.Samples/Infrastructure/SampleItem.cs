namespace ObservableComputations.Samples.Infrastructure
{
    public class SampleItem
    {
        public string Title { get;  }
        public string Description { get;  }
        public object Content { get;  }

        public string DynamicDataCodeFileDisplay { get; }

        public string DynamicDataCodeFileUrl { get; }

        public string ObservableComputationsDataCodeFileDisplay { get; }

        public string ObservableComputationsCodeFileUrl { get; }


        public SampleItem(string title, object content, string description, string dynamicDataCodeFileDisplay, string dynamicDataCodeFileUrl, string observableComputationsDataCodeFileDisplay, string observableComputationsCodeFileUrl)
        {
            Title = title;
            Description = description;
            DynamicDataCodeFileDisplay = dynamicDataCodeFileDisplay;
            DynamicDataCodeFileUrl = dynamicDataCodeFileUrl;
            ObservableComputationsDataCodeFileDisplay = observableComputationsDataCodeFileDisplay;
            ObservableComputationsCodeFileUrl = observableComputationsCodeFileUrl;
            Content = content;
        }
    }
}
