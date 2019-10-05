using System.Collections.Generic;
using System.Data;
using Dapper;
using ZenStore.Models;

namespace ZenStore.Data
{
    public class ReviewsRepository
    {
        private readonly IDbConnection _db;

        public Review Create(Review reviewData)
        {
            var sql = @"INSERT INTO product_reviews
           (id, name, description, rating, productid)
           VALUES
           (@Id, @Name, @Description, @Rating, @ProductId);";
            var x = _db.Execute(sql, reviewData);
            return reviewData;
        }

        internal bool SaveReview(Review review)
        {
            var nRows = _db.Execute(@"
                UPDATE product_reviews SET
                name = @Name,
                description = @Description,
                rating = @Rating
                WHERE id = @Id
                ", review);
            return nRows == 1;
        }

        public Review GetReviewById(string id)
        {
            return _db.QueryFirstOrDefault<Review>(
              "SELECT * FROM product_reviews WHERE id = @id",
                new { id }
            );
        }

        public ReviewsRepository(IDbConnection db)
        {
            _db = db;
        }

    }






}