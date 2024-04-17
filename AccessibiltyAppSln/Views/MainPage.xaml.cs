using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Maui;
using System.IO;
using System.Net;
using System.Net.Security;

namespace AccessibilityAppSln
{
	public partial class MainPage : ContentPage
	{
		static string subscriptionKey = "12f21ee63980455ab7be9c68cbaf51e3";
		static string endpoint = "https://imageclassifierbm.cognitiveservices.azure.com/";

		

		public MainPage()
		{
			InitializeComponent();
		}

	   async void UploadAndDetectButton_Clicked(object sender, EventArgs e)
	   {
			try
			{
				var photo = await MediaPicker.PickPhotoAsync();
				await LoadPhotoAsync(photo);
			}
			catch (FeatureNotSupportedException)
			{

			}
			catch(PermissionException pEx)
			{

			}
			catch(Exception ex) { 
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

			

			PhotoPath = photo.FullPath;

			//MYImage.Source = PhotoPath;
			//ComputerVisionClient client = Authenticate(endpoint, subscriptionKey);


			

			List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
			{
				VisualFeatureTypes.Categories, VisualFeatureTypes.Description,
				VisualFeatureTypes.Faces, VisualFeatureTypes.ImageType,
				VisualFeatureTypes.Tags, VisualFeatureTypes.Adult,
				VisualFeatureTypes.Color, VisualFeatureTypes.Brands,
				VisualFeatureTypes.Objects
			};

			ImageAnalysis results = await client.AnalyzeImageAsync(PhotoPath, visualFeatures: features);

			Result1.Text = results.ModelVersion;
			Result2.Text = results.Faces.ToString();



		}
	}
	
	
}
