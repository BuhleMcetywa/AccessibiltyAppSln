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

		public Photo SelectedPhoto
		{
			get => _selectedPhoto;
			set
			{
				_selectedPhoto = value;
				OnPropertyChanged();
			}
		}

		private string _captions;

		public string Captions
		{
			get { return _captions; }
			set { _captions = value;

				OnPropertyChanged();
			}
		}




		public async Task UploadAndDetectAsync()
		{
			try
			{
				/*		var photo = await MediaPicker.PickPhotoAsync();
						if (photo != null)
						{
							SelectedPhoto.PhotoPath = photo.FullPath;

						var result = await _computerVisionService.AnalyzeImageAsync(SelectedPhoto.PhotoPath);

						SelectedPhoto.ImageDescription = result.DenseCaptions.ToString();

						}

						*/

				if (MediaPicker.Default.IsCaptureSupported)
				{
					FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

					if (photo != null)
					{
						// save the file into local storage
					//	string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

						using Stream sourceStream = await photo.OpenReadAsync();

						var result = await _computerVisionService.AnalyzeImageAsync(sourceStream);

						string captions =string.Empty;

						foreach (var caption in result.DenseCaptions.Values)
						{
							captions += caption.Text + "\n";
						}

						Captions = captions;





					//	using FileStream localFileStream = File.OpenWrite(localFilePath);

						//		await sourceStream.CopyToAsync(localFileStream);
					}
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
			
				
			