DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS posts;
DROP TABLE IF EXISTS comments;
DROP TABLE IF EXISTS comment_reports;
DROP TABLE IF EXISTS movie_lists;
DROP TABLE IF EXISTS movies;
DROP TABLE IF EXISTS list_movies;
DROP TABLE IF EXISTS movie_reviews;
DROP TABLE IF EXISTS movie_reports;
DROP TABLE IF EXISTS subtitle_lists;
DROP TABLE IF EXISTS subtitle;

CREATE TABLE users (
    name TEXT PRIMARY KEY,
    email TEXT NOT NULL UNIQUE,
    password_hash TEXT NOT NULL,
    age SMALLINT NOT NULL CHECK (age >= 0),
    administrator BOOLEAN NOT NULL DEFAULT FALSE,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    last_login_at TIMESTAMP NOT NULL
);
CREATE TABLE posts (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    text TEXT NOT NULL,
    likes INTEGER NOT NULL DEFAULT 0 CHECK (likes >= 0),
    dislikes INTEGER NOT NULL DEFAULT 0 CHECK (dislikes >= 0),
    views INTEGER NOT NULL DEFAULT 0 CHECK (views >= 0),
    last_edited_at TIMESTAMP NOT NULL DEFAULT NOW(),
    fk_users_name TEXT REFERENCES users(name) ON DELETE CASCADE
);
CREATE TABLE comments (
    id SERIAL PRIMARY KEY,
    text TEXT NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    likes INTEGER NOT NULL DEFAULT 0 CHECK (likes >= 0),
    dislikes INTEGER NOT NULL DEFAULT 0    CHECK (dislikes >= 0),
    disabled BOOLEAN NOT NULL DEFAULT FALSE,
    last_edited_at TIMESTAMP NOT NULL DEFAULT NOW(),
    fk_posts_id INTEGER REFERENCES posts(id) ON DELETE CASCADE,
    fk_users_name TEXT REFERENCES users(name) ON DELETE SET NULL
);
CREATE TABLE comment_reports (
    id SERIAL PRIMARY KEY,
    text TEXT NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    reviewed BOOLEAN NOT NULL DEFAULT FALSE,
    accepted BOOLEAN NOT NULL DEFAULT FALSE,
    fk_comments_id INTEGER REFERENCES comments(id) ON DELETE CASCADE
);
CREATE TABLE movie_lists (
    id SERIAL PRIMARY KEY,
    text TEXT NOT NULL,
    likes INTEGER NOT NULL DEFAULT 0 CHECK (likes >= 0),
    dislikes INTEGER NOT NULL DEFAULT 0 CHECK (dislikes >= 0),
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    description TEXT NOT NULL,
    fk_users_name TEXT REFERENCES users(name) ON DELETE CASCADE
);
CREATE TABLE movies (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    created_at TIMESTAMP NOT NULL,
    duration INTEGER NOT NULL CHECK (duration >= 0),
    description TEXT NOT NULL,
    language CHARACTER(20)
);
CREATE TABLE list_movies (
    id SERIAL PRIMARY KEY,
    fk_movie_lists INTEGER REFERENCES movie_lists(id) ON DELETE CASCADE,
    fk_movies INTEGER REFERENCES movies(id) ON DELETE CASCADE
);
CREATE TABLE movie_reviews (
    id SERIAL PRIMARY KEY,
    text TEXT NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    likes INTEGER NOT NULL DEFAULT 0 CHECK (likes >= 0),
    dislikes INTEGER NOT NULL DEFAULT 0 CHECK (dislikes >= 0),
    score NUMERIC(2, 0) NOT NULL DEFAULT 0 CHECK (score >= 0),
    last_edited_at TIMESTAMP NOT NULL DEFAULT NOW(),
    fk_users TEXT REFERENCES users(name) ON DELETE CASCADE,
    fk_movies INTEGER REFERENCES movies(id) ON DELETE CASCADE
);
CREATE TABLE movie_reports (
    id SERIAL PRIMARY KEY,
    generated_at TIMESTAMP NOT NULL DEFAULT NOW(),
    average_score NUMERIC(4, 2) NOT NULL DEFAULT 0 CHECK (average_score >= 0),
    views INTEGER NOT NULL DEFAULT 0 CHECK (views >= 0),
    total_movie_lists INTEGER NOT NULL DEFAULT 0 CHECK (total_movie_lists >= 0),
    fk_users TEXT REFERENCES users(name) ON DELETE CASCADE,
    fk_movies INTEGER REFERENCES movies(id) ON DELETE CASCADE
);
CREATE TABLE subtitle_lists (
    id SERIAL PRIMARY KEY,
    language CHARACTER(20),
    fk_users TEXT REFERENCES users(name) ON DELETE CASCADE,
    fk_movies INTEGER REFERENCES movies(id) ON DELETE CASCADE
);
CREATE TABLE subtitle (
    start_at INTEGER NOT NULL CHECK (start_at >= 0),
    text TEXT NOT NULL,
    finish_at INTEGER NOT NULL CHECK (finish_at >= 0),
    fk_subtitle_lists INTEGER REFERENCES subtitle_lists(id) ON DELETE CASCADE
);

INSERT INTO users (name, email, password_hash, age, administrator, created_at, last_login_at) VALUES ('admin', 'admin@admin.lt', 'admin', '20', true, '2021-12-01 09:15:00', '2021-12-10 10:10:00'), ('Jonas331', 'jonas@jonelis.lt', 'jonas123', '13', false, '2021-12-06 19:37:00', '2021-12-12 11:10:00'), ('Joana', 'joana@111.lt', 'kate123', '33', false, '2021-12-07 20:12:30', '2021-12-19 04:59:00'), ('Citroenas', 'pastas@eta.edt', 'bmwkietas111', '40', true, '2021-12-02 22:15:33', '2021-12-04 04:44:44'), ('Bemwsas', '1912@wooowy.edt', 'audifanas123', '23', false, '2021-12-05 15:29:09', '2021-12-14 14:00:20'), ('Audinius', 'regitra@google.lt', 'hardpassword123', '39', false, '2021-12-04 22:19:33', '2021-12-04 23:44:44'), ('Makstytvis', 'google@google.lt', '200006000', '26', false, '2021-12-08 18:15:33', '2021-12-09 19:44:44'), ('Johnas', 'john@doe.co', 'johnny113', '55', false, '2021-12-06 19:12:33', '2021-12-09 12:44:20'), ('Benas', 'benas123@google.lt', 'catty909', '21', false, '2021-12-08 14:12:33', '2021-12-19 12:44:20'), ('Travvvis', 'travis@scott.na', 'cancelled111', '22', false, '2021-12-01 13:25:33', '2021-12-20 12:44:20');

INSERT INTO posts (name, created_at, text, likes, dislikes, views, last_edited_at, fk_users_name) VALUES ('About Inception', '2021-12-15 09:00:11', 'Inception is a 2010 science fiction action film written and directed by Christopher Nolan, who also produced the film with Emma Thomas, his wife. The film stars Leonardo DiCaprio as a professional thief who steals information by infiltrating the subconscious of his targets. He is offered a chance to have his criminal history erased as payment for the implantation of another persons idea into a targets subconscious. The ensemble cast includes Ken Watanabe, Joseph Gordon-Levitt, Marion Cotillard, Elliot Page, Tom Hardy, Dileep Rao, Cillian Murphy, Tom Berenger, and Michael Caine.', 25, 9, 60, '2021-12-09 09:12:11', 'Citroenas'), ('About Interstellar', '2021-12-12 04:12:20', 'Interstellar is a 2014 epic science fiction film co-written, directed and produced by Christopher Nolan. It stars Matthew McConaughey, Anne Hathaway, Jessica Chastain, Bill Irwin, Ellen Burstyn, and Michael Caine. Set in a dystopian future where humanity is struggling to survive, the film follows a group of astronauts who travel through a wormhole near Saturn in search of a new home for mankind.', 29, 4, 59, '2021-12-19 10:18:44', 'admin'), ('About Tenet', '2021-12-11 11:11:11', 'Tenet is a 2020 science fiction action thriller film written and directed by Christopher Nolan, who produced it with Emma Thomas. A co-production between the United Kingdom and the United States, it stars John David Washington, Robert Pattinson, Elizabeth Debicki, Dimple Kapadia, Michael Caine, and Kenneth Branagh. The film follows a secret agent who learns to manipulate the flow of time to prevent an attack from the future that threatens to annihilate the present world.', 9, 14, 40, '2021-12-12 11:11:11', 'admin');

INSERT INTO comments (text, created_at, likes, dislikes, disabled, last_edited_at, fk_posts_id, fk_users_name) VALUES ('Wow, what a great post, thanks!', '2021-12-19 12:11:14', 4, 0, false, '2021-12-19 09:09:09', 1, 'Travvvis'), ('What a piece of shit, garbage', '2021-12-16 12:11:14', 0, 20, true, '2021-12-16 19:09:09', 1, 'Johnas'), ('Another great Christophan Nolan film!', '2021-12-20 15:23:22', 22, 3, false, '2021-12-21 19:09:09', 2, 'Audinius'), ('Even though others hated it, I loved it!', '2021-12-19 18:23:22', 8, 1, false, '2021-12-20 00:09:09', 3, 'Audinius'), ('Worst direcctor film, yet.', '2021-12-17 16:16:20', 12, 3, false, '2021-12-17 17:09:09', 3, 'Benas');

INSERT INTO comment_reports (text, created_at, reviewed, accepted, fk_comments_id) VALUES ('Very negative comment, I dont like it.', '2021-12-16 13:13:13', true, true, 2), ('I dont agree with this person.', '2021-12-17 17:30:23', true, false, 5), ('How dare he say it.', '2021-12-18 19:20:23', false, false, 5);

INSERT INTO movie_lists (text, likes, dislikes, created_at, description, fk_users_name) VALUES ('Christopher Nolans films', 20, 5, '2021-12-19 03:04:05', 'I simply love Christopher Nolan', 'Audinius'), ('My personal favorites', 3, 0, '2021-12-10 07:15:00', 'Im a huge film enjoyer, and this is my favorite movies. Enjoy.', 'Bemwsas');

INSERT INTO movies (name, created_at, duration, description, language) VALUES ('Inception', '2010-10-12', '7689', 'A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.', 'English'), ('Tenet', '2020-06-05', '9000', 'Armed with only one word, Tenet, and fighting for the survival of the entire world, a Protagonist journeys through a twilight world of international espionage on a mission that will unfold in something beyond real time.', 'English'), ('Interstellar', '2014-03-15', '10323', 'A team of explorers travel through a wormhole in space in an attempt to ensure humanitys survival.', 'English'), ('Ashes in the Snow', '2018-12-15', '5211', 'In 1941, a 16-year-old aspiring artist and her family are deported to Siberia amidst Stalins brutal dismantling of the Baltic region. One girls passion for art and her never-ending hope will break the silence of history.', 'Lithuanian');

INSERT INTO list_movies (fk_movie_lists, fk_movies) VALUES (1, 1), (1, 2), (1, 3), (2, 3), (2, 4);

INSERT INTO movie_reviews (text, created_at, likes, dislikes, score, last_edited_at, fk_users, fk_movies) VALUES ('What a great film. Christopher Nolan never dissapoints me.', '2021-12-06 09:47:13', 8, 1,  10, '2021-12-06 09:47:13', 'Audinius', 2);

INSERT INTO movie_reports (generated_at, average_score, views, total_movie_lists, fk_users, fk_movies) VALUES ('2021-12-07', 10, 27, 1, 'admin', 2);

INSERT INTO subtitle_lists (language, fk_users, fk_movies) VALUES ('English', 'Audinius', 2);

INSERT INTO subtitle (start_at, text, finish_at, fk_subtitle_lists) VALUES (10, 'Hello', 20, 1), (200, '*intense music*', 220, 1);
