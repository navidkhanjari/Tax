namespace CoreLayer.DTOs.Messages
{
    public class MessagesDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public bool Read { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
