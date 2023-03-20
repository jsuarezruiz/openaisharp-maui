using System.Collections.Specialized;

namespace OpenAISharp.Maui.Behaviors
{
    public class AutoScrollBehavior : Behavior<CollectionView>
    {
        CollectionView _collectionView;

        protected override void OnAttachedTo(CollectionView bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.Loaded += OnCollectionViewLoaded;

            _collectionView = bindable;
        }

        protected override void OnDetachingFrom(CollectionView bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.Loaded -= OnCollectionViewLoaded;

            _collectionView = null;
        }
        
        void OnCollectionViewLoaded(object sender, EventArgs e)
        {
            var collectionView = sender as CollectionView;

            if (collectionView?.ItemsSource is INotifyCollectionChanged collection)
                collection.CollectionChanged += OnCollectionViewCollectionChanged;
        }

        void OnCollectionViewCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var items = e.NewItems;

            if (items is null || items.Count == 0)
                return;

            _collectionView?.ScrollTo(items[0], -1, ScrollToPosition.Start, true);
        }
    }
}
