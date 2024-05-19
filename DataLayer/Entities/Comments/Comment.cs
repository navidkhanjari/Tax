﻿namespace DataLayer.Entities.Comments
{
	public class Comment : Entity
	{
		public string CustomerFullName { get; set; }
		public string CustomerImageName { get; set; }
		public string Jobtitle { get; set; }
		public bool Visible { get; set; }
	}
}
