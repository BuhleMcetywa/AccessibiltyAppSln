using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessibiltyAppSln.Services
{
	public class ComputerVisionServices
	{
		private ComputerVisionClient _client;

		ComputerVisionClient client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey))
		{
			Endpoint = endpoint
		};

		ComputerVisionClient Authenticate(string endpoint, string subscriptionKey)
		{
			ComputerVisionClient client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey)) { Endpoint = endpoint };
			return client;
		}
		

		public async Task<ImageAnalysis> AnalyzeImageAsync(string imagePath, List<VisualFeatureTypes?> features)
		{
			return await _client.AnalyzeImageAsync(imagePath, visualFeatures: features);
		}

		internal async Task AnalyzeImageAsync(object photoPath, List<VisualFeatureTypes?> features)
		{
			throw new NotImplementedException();
		}
	}
}
