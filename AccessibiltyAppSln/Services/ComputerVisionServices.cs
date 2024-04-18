using Azure.AI.Vision.ImageAnalysis;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessibiltyAppSln.Models;

namespace AccessibiltyAppSln.Services
{
	public class ComputerVisionServices









	{

		//private Photo _selectedPhoto;

		/*public Photo SelectedPhoto
		{
			get => _selectedPhoto;
			set
			{
				_selectedPhoto = value;
				OnPropertyChanged();
			}
		*/
		/*private _client;

		
			string endPoint = "https://imageclassifierbm.cognitiveservices.azure.com/";
		string subscriptionKey =;
		_client = Authenticate(endPoint, subscriptionKey);



		public async Task<ImageAnalysis> AnalyzeImageAsync(string imagePath, IList<VisualFeatureTypes> features)
		{

			using var stream = new FileStream(imagePath, FileMode.Open);
			return await _client.AnalyzeImageInStreamAsync(stream, (IList<VisualFeatureTypes?>)features);
		}

		async Task AnalyzeImageAsync(string photoPath, List<VisualFeatureTypes?> features)
		{
			throw new NotImplementedException();
		}

		ComputerVisionClient Authenticate(string endpoint, string subscriptionKey)
		{
			ComputerVisionClient client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey)) { Endpoint = endpoint };
			return client;
		}*/
		public async Task<ImageAnalysisResult> AnalyzeImageAsync(Stream photoStream)
		{
			string key = "12f21ee63980455ab7be9c68cbaf51e3";
			string endpoint = "https://imageclassifierbm.cognitiveservices.azure.com/";

			ImageAnalysisClient client = new ImageAnalysisClient(
				new Uri(endpoint),
				new AzureKeyCredential(key));

			//  Image from File Sample

			//	using FileStream stream = new FileStream("<your image file>", FileMode.Open); //how do I add PhotoPath here?


			BinaryData imageData = BinaryData.FromStream(photoStream);

			ImageAnalysisResult result = await client.AnalyzeAsync(imageData,
					VisualFeatures.Caption | VisualFeatures.Read | VisualFeatures.Objects | VisualFeatures.DenseCaptions,
					new ImageAnalysisOptions { GenderNeutralCaption = true });

			

			return result;
		}



		



			
		
	}
}
