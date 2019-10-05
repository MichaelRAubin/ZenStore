using System;
using System.Collections.Generic;
using ZenStore.Data;
using ZenStore.Models;

namespace ZenStore.Services
{
    public class ReviewsService
    {
        private readonly ReviewsRepository _repo;

        public Review AddReview(Review reviewData)
        {
            reviewData.Id = Guid.NewGuid().ToString();
            _repo.Create(reviewData);
            return reviewData;
        }

        public Review GetReviewById(string id)
        {
            var review = _repo.GetReviewById(id);
            if (review == null)
            {
                throw new Exception("Bad review ID");
            }
            return review;
        }

        public Review EditReview(Review reviewData)
        {
            var review = GetReviewById(reviewData.Id);
            review.Name = reviewData.Name;
            review.Description = reviewData.Description;
            review.Rating = reviewData.Rating;

            bool success = _repo.SaveReview(review);
            if (!success)
            {
                throw new Exception("Could not edit review");
            }
            return review;
        }

        public IEnumerable<Review> GetProductReviews(string productid)
        {
            var reviews = _repo.GetReviews(productid);
            if (reviews == null)
            {
                throw new Exception("Bad Product ID");
            }
            return reviews;
        }

        public ReviewsService(ReviewsRepository repo)
        {
            _repo = repo;
        }
    }
}