using Microsoft.Maui;

namespace AccessibilityAppSln
{
	public partial class MainPage : ContentPage
	{
		
		public MainPage()
		{
			InitializeComponent();
		}

	   async void UploadAndDetectButton_Clicked(object sender, EventArgs e)
	   {
			if (MediaPicker.Default.IsCaptureSupported)
			{
				FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

				if (photo != null)
				{
					// save the file into local storage
					string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

					using Stream sourceStream = await photo.OpenReadAsync();
					using FileStream localFileStream = File.OpenWrite(localFilePath);

					await sourceStream.CopyToAsync(localFileStream);
				}
			}

			
	   }
		string PhotoPath;
		private async Task  LoadPhotoAsync(FileResult photo)
		{

			if(photo == null)
			{
				PhotoPath = null;
				return;
			}

			/*var newFile= Path.Combine(FileSystem.CacheDirectory, photo.FileName);
			using(var stream  = await photo.OpenReadAsync())
			using (var newStream = File.OpenWrite(newFile)) 
				await stream.CopyToAsync(newStream);*/

			PhotoPath = photo.FullPath;

			MYImage.Source = PhotoPath;
			
			


		
		}
	}

}
