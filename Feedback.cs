namespace Evaluate
{
    public class Feedback
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string FeedbackContent { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
