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

-- FOREIGN KEY (productid)
--     REFERENCES products(id),

--     PRIMARY KEY(id)
-- );

-- CREATE TABLE IF NOT EXISTS orders(
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     canceled TINYINT DEFAULT 0,
--     shipped TINYINT DEFAUKT 0,
--     orderin DATETIME NOT NULL,
--     orderout DATETIME, 
--     ordercanceledat DATETIME,

--     PRIMARY KEY(id)
-- );

-- CREATE TABLE IF NOT EXISTS order_items(
--     id VARCHAR(255) NOT NULL,
--     itemid VARCHAR(255) NOT NULL,
--     orderid VARCHAR(255 NOT NULL),

--     FOREIGN KEY (itemid)
--         REFERENCES products(id),
--     FOREIGN KEY(orderid)
--         REFERENCES orders(id),

--     PRIMARY KEY(id)
-- );

--need to add join statements - return a list of orders in <>

    