create table if not exists studios(
    studio_id int primary key,
    studio_name varchar(40) not null,
    date_of_creation date
);
copy studios from 'D:\PPO\studios.csv' delimiter ',' csv; 

create table if not exists directors(
    director_id int primary key,
    director_name varchar(40) not null,
    age int check(age > 23 and age < 71),
    sex varchar (6),
    films_amount int check(films_amount > 0 and films_amount < 10)
);
copy directors from 'D:\PPO\directors.csv' delimiter ',' csv; 

create table if not exists genres(
    genre_id int primary key,
    genre_name varchar(40)
);
copy genres from 'D:\PPO\genres.csv' delimiter ',' csv; 

create table if not exists films(
    film_id int primary key,
    studio_id int references studios(studio_id),
    genre_id int references genres(genre_id),
    director_id int references directors(director_id),
    film_name varchar(40) not null,
    release_date date,
    budget int check(budget >= 20000 and budget <= 250000000),
    fees int check(fees >= 20000 and fees <= 1000000000),
    avg_price int check(avg_price >= 120 and avg_price <= 500)
);
copy films from 'D:\PPO\films.csv' delimiter ',' csv;

create table if not exists actors(
    actor_id int primary key,
    film_id int references films(film_id),
    actor_name varchar(40) not null,
    age int check(age > 17 and age < 71),
    sex varchar(6),
    nationality varchar(40),
    fee int check(fee >= 1000 and fee <= 1000000),
    awards int check(awards >= 0 and awards < 6)
);
copy actors from 'D:\PPO\actors.csv' delimiter ',' csv;

create table if not exists users(
    user_id int primary key,
    login varchar(40) not null,
    password varchar(40) not null,
    permissions int 
);

create table if not exists user_genres(
    user_id int references users(user_id),
    genre_id int references genres(genre_id)
);

create table if not exists user_films(
    user_id int references users(user_id),
    film_id int references films(film_id)
);








create table if not exists sites(
    site_id int primary key,
    site_name varchar(40) not null  
);
copy sites from 'D:\PPO\sites.csv' delimiter ',' csv;

create table if not exists filmssites(
    film_id int references films(film_id),
    site_id int references sites(site_id),
    film_price int check(film_price >= 0 and film_price <= 1000)
);
copy filmssites from 'D:\PPO\films_sites.csv' delimiter ',' csv;

