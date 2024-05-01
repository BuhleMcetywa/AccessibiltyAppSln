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

		
		public async Task<ImageAnalysisResult> AnalyzeImageAsync(Stream photoStream)
		{
			string key = "12f21ee63980455ab7be9c68cbaf51e3";
			string endpoint = "https://imageclassifierbm.cognitiveservices.azure.com/";

			ImageAnalysisClient client = new ImageAnalysisClient(
				new Uri(endpoint),
				new AzureKeyCredential(key));

			

			BinaryData imageData = BinaryData.FromStream(photoStream);

			ImageAnalysisResult result = await client.AnalyzeAsync(imageData,
					VisualFeatures.Caption | VisualFeatures.Read | VisualFeatures.Objects | VisualFeatures.DenseCaptions,
					new ImageAnalysisOptions { GenderNeutralCaption = true });

			

			return result;
		}

		// Sta
		



		



			
		
	}
}
