﻿namespace CoreLayer.DTOs.Sliders
{
	public class UpdateSliderDTO
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Domain { get; set; }
		public bool Visible { get; set; }
	}

	public enum UpdateSliderResult
	{
		Success, Error
	}
}
