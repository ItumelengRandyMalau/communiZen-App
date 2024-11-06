using System.Windows.Input;

namespace Zenfull.ViewModel
{
    public class MainPageViewModel
    {
        public List<ImageSource> CarouselImages { get; } = new()
    {
        ImageSource.FromFile("chatbot"),
        ImageSource.FromFile("locatehelp"),
        ImageSource.FromFile("aboutzen")
    };
    }
}



