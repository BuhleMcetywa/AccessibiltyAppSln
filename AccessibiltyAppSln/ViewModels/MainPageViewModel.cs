using AccessibiltyAppSln.Models;
using AccessibiltyAppSln.Services;
using Azure.AI.Vision.ImageAnalysis;
//using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace AccessibiltyAppSln.ViewModels
{

	public class MainPageViewModel : BaseViewModel
	{
		private ComputerVisionServices _computerVisionService;
		private Photo? _selectedPhoto;

		public MainPageViewModel(ComputerVisionServices computerVisionServices)
		{
			_computerVisionService = computerVisionServices;
			UploadAndDetectCommand = new Command(UploadAndDetect);
		}

		private void UploadAndDetect(object obj)
		{
			UploadAndDetectAsync();


		}

		public Command UploadAndDetectCommand { get; set; }

		

		private string _captions;

		public string Captions
		{
			get { return _captions; }
			set { _captions = value;

				OnPropertyChanged();
			}
		}

		private bool _isBusy;

		public bool IsBusy
		{
			get { return _isBusy; }
			set { _isBusy = value;
			
							OnPropertyChanged();
						}
		}


		public async Task UploadAndDetectAsync()
		{
			IsBusy = true;
			try
			{
				

				if (MediaPicker.Default.IsCaptureSupported)
				{
					FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

					if (photo != null)
					{
						

						using Stream sourceStream = await photo.OpenReadAsync();

						var result = await _computerVisionService.AnalyzeImageAsync(sourceStream);

						string captions =string.Empty;

						foreach (var caption in result.DenseCaptions.Values)
						{
							captions += caption.Text + "\n";
						}

						Captions = captions;





					
					}
					IsBusy = false;
				}


			}
			catch (FeatureNotSupportedException)
			{

			}
			catch (PermissionException pEx)
			{

			}
			catch (Exception ex)
			{

			}
		}
	}
}
			
				
			