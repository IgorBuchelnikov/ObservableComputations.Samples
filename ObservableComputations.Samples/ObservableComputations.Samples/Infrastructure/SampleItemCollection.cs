using System.Collections.Generic;
using ObservableComputations.Samples.Examples;

namespace ObservableComputations.Samples.Infrastructure
{
    public class SelectableItemCollection
    {
        public List<SampleItem> Items { get; }

        public SelectableItemCollection()
        {
            Items = new List<SampleItem>
            {

                new SampleItem("Selectable Items", new SelectableItemsViewModel(),
                        "Items order in the result collections is the original collection order",
                        "SelectableItemsViewModel.cs",
                        @"https://github.com/IgorBuchelnikov/ObservableComputations.Samples/blob/master/DynamicData.Samplz/Examples/SelectableItemsViewModel.cs",
                        "SelectableItemsViewModel.cs",
                        @"https://github.com/IgorBuchelnikov/ObservableComputations.Samples/tree/master/ObservableComputations.Samples/ObservableComputations.Samples/Examples/SelectableItemsViewModel.cs"),

                new SampleItem("Aggregations", new AggregationViewModel(),
                        "Aggregate over a collection which is filtered on a property",
                        "AggregationViewModel.cs",
                        @"https://github.com/IgorBuchelnikov/ObservableComputations.Samples/blob/master/DynamicData.Samplz/Examples/AggregationViewModel.cs",
                        "AggregationViewModel.cs",
                        @"https://github.com/IgorBuchelnikov/ObservableComputations.Samples/blob/master/ObservableComputations.Samples/Examples/AggregationViewModel.cs"),

               new SampleItem("Add and remove items", new  AddRemoveItemsViewModel(), 
                        "Items order in the result collections is the asceding order of time of the last add action",
                        "FilterObservableViewModel.cs",
                        @"https://github.com/IgorBuchelnikov/ObservableComputations.Samples/blob/master/DynamicData.Samplz/Examples/FilterObservableViewModel.cs",
                        "AddRemoveItemsViewModel.cs",
                        @"https://github.com/IgorBuchelnikov/ObservableComputations.Samples/tree/master/ObservableComputations.Samples/ObservableComputations.Samples/Examples/AddRemoveItemsViewModel.cs"),

                new SampleItem("One to many join", new  ParentChildrenViewModel(), 
                        "Managing parent's children",
                        "JoinManyViewModel.cs",
                        @"https://github.com/IgorBuchelnikov/ObservableComputations.Samples/blob/master/DynamicData.Samplz/Examples/JoinViewModel.cs",
		                "ParentChildrenViewModel.cs",
		                @"https://github.com/IgorBuchelnikov/ObservableComputations.Samples/tree/master/ObservableComputations.Samples/ObservableComputations.Samples/Examples/ParentChildrenViewModel.cs")

            };
        }
    }
}
