using AccessibiltyAppSln.Services;
using AccessibiltyAppSln.ViewModels;

namespace AccessibiltyAppSln.Views
{
	public partial class MainPage : ContentPage
	{


		public MainPage(MainPageViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm; 
		//		new MainPageViewModel(new ComputerVisionServices());
		}

		private void UploadAndDetectButton_Clicked(object sender, EventArgs e)
		{

		}
	}
}
