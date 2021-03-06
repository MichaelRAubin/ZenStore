using System.ComponentModel.DataAnnotations;

namespace ZenStore.Interfaces
{
    public interface IReview
    {
        string Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }

        [Range(.5, 5)]
        double Rating { get; set; }
        string ProductId { get; set; }
    }
}