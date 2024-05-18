﻿namespace CoreLayer.DTOs.Messages
{
	public class UpdateMessageDTO
	{
        public int Id { get; set; }
        public string FullName { get; set; }
		public string Email { get; set; }
		public string Number { get; set; }
		public string Description { get; set; }
	}
	public enum UpdateMessagesResult
	{
		Success, Error
	}
}
