using AccessibiltyAppSln.Models;
using AccessibiltyAppSln.Services;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessibiltyAppSln.ViewModels
{

	public class MainPageViewModel: BaseViewModel
	{
		private  ComputerVisionServices _computerVisionService;
		private Photo _selectedPhoto;

		public MainPageViewModel(ComputerVisionServices computerVisionServices)
		{
			_computerVisionService = computerVisionServices;
			UploadAndDetectCommand = new Command(UploadAndDetect);
		}

		private void UploadAndDetect(object obj)
		{
		
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

		public string PhotoPath { get;  set; }

		public async Task UploadAndDetectAsync()
		{
			try
			{
				var photo = await MediaPicker.PickPhotoAsync();
				if (photo != null)
				{
					PhotoPath = photo.FullPath;
					
			};

					
				};
					var result = await _computerVisionService.AnalyzeImageAsync(PhotoPath, features);
					// Do something with the result
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