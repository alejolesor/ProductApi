
create table if not exists product(
 id serial PRIMARY KEY,
 "name" VARCHAR (50) NOT NULL,
 description VARCHAR (100) NOT NULL,
 category VARCHAR (50) NOT NULL,
 price decimal NOT NULL,
 stock INT NOT NULL
);


insert into Product("name", description, category, price, stock) values('ale', 'tests', 'completed', 2000, 1)