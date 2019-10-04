using System.ComponentModel.DataAnnotations;
using ZenStore.Interfaces;

namespace ZenStore.Models
{
    public class Review : IReview
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [MinLength(1)]
        [MaxLength(5)]
        public double Rating { get; set; }
        public string ProductId { get; set; }
    }
}