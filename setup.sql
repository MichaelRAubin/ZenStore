-- CREATE TABLE IF NOT EXISTS products(
-- id VARCHAR(255) NOT NULL,
-- name VARCHAR(255) NOT NULL,
-- description VARCHAR(255),
-- price decimal(10,2),

-- PRIMARY KEY(id)
-- );

-- CREATE TABLE IF NOT EXISTS product_reviews(
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255),
--     rating DOUBLE(2,1),
--     productid VARCHAR(255),

--     PRIMARY KEY(id)
-- )
-- NOTE - need to create an orders table and a product_orders table
-- Need Foreign Key in product_reviews back to products

-- Need 2 Foreign Key product id & order id