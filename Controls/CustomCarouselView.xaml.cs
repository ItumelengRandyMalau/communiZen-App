using Microsoft.Maui.Controls;

namespace Zenfull.Controls
{
    public partial class CustomCarouselView : ContentView
    {
        private IDispatcherTimer autoPlayTimer;
        private int currentIndex;

        public static readonly BindableProperty ImagesProperty =
            BindableProperty.Create(nameof(Images), typeof(List<ImageSource>), typeof(CustomCarouselView), null,
                propertyChanged: OnImagesChanged);

        public List<ImageSource> Images
        {
            get => (List<ImageSource>)GetValue(ImagesProperty);
            set => SetValue(ImagesProperty, value);
        }

        public CustomCarouselView()
        {
            InitializeComponent();
            SetupAutoPlayTimer();

            // Add touch handling for manual scrolling
            ScrollContainer.Scrolled += OnScrolled;
        }

        private static void OnImagesChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var carousel = (CustomCarouselView)bindable;
            carousel.SetupImages();
        }

        private void SetupImages()
        {
            if (Images == null) return;

            ImageContainer.Children.Clear();

            foreach (var image in Images)
            {
                var imageButton = new ImageButton
                {
                    Source = image,
                    WidthRequest = 200,
                    HeightRequest = 150,
                    Margin = new Thickness(0),
                    Padding = new Thickness(0)
                };

                // Add ZoomBehavior
     

                // Add tap handling
                imageButton.Clicked += ImageButton_Clicked;

                ImageContainer.Children.Add(imageButton);
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            // Handle image button click
            if (sender is ImageButton imageButton)
            {
                // Pause auto-play when user interacts
                StopAutoPlay();
            }
        }

        private void OnScrolled(object sender, ScrolledEventArgs e)
        {
            // Pause auto-play when user manually scrolls
            StopAutoPlay();
        }

        private void SetupAutoPlayTimer()
        {
            autoPlayTimer = Application.Current!.Dispatcher.CreateTimer();
            autoPlayTimer.Interval = TimeSpan.FromMilliseconds(3000);
            autoPlayTimer.Tick += AutoPlayTimer_Tick;
            StartAutoPlay();
        }

        private void StartAutoPlay()
        {
            autoPlayTimer.Start();
        }

        private void StopAutoPlay()
        {
            autoPlayTimer.Stop();
        }

        private void AutoPlayTimer_Tick(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (currentIndex < ImageContainer.Children.Count - 1)
                    currentIndex++;
                else
                    currentIndex = 0;

                var element = ImageContainer.Children[currentIndex];
      
            });
        }
    }
}