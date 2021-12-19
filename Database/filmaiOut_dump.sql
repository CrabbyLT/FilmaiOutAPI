--
-- PostgreSQL database dump
--

-- Dumped from database version 14.1
-- Dumped by pg_dump version 14.1

-- Started on 2021-12-19 11:50:53

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 215 (class 1259 OID 16634)
-- Name: comment_reports; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.comment_reports (
    id integer NOT NULL,
    text text NOT NULL,
    created_at timestamp without time zone NOT NULL,
    reviewed boolean DEFAULT false NOT NULL,
    accepted boolean DEFAULT false NOT NULL,
    fk_comments_id integer
);


ALTER TABLE public.comment_reports OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 16633)
-- Name: comment_reports_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.comment_reports_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.comment_reports_id_seq OWNER TO postgres;

--
-- TOC entry 3453 (class 0 OID 0)
-- Dependencies: 214
-- Name: comment_reports_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.comment_reports_id_seq OWNED BY public.comment_reports.id;


--
-- TOC entry 213 (class 1259 OID 16610)
-- Name: comments; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.comments (
    id integer NOT NULL,
    text text NOT NULL,
    created_at timestamp without time zone NOT NULL,
    likes integer DEFAULT 0 NOT NULL,
    dislikes integer DEFAULT 0 NOT NULL,
    disabled boolean DEFAULT false NOT NULL,
    last_edited_at timestamp without time zone NOT NULL,
    fk_posts_id integer,
    fk_users_name text,
    CONSTRAINT comments_dislikes_check CHECK ((dislikes >= 0)),
    CONSTRAINT comments_likes_check CHECK ((likes >= 0))
);


ALTER TABLE public.comments OWNER TO postgres;

--
-- TOC entry 212 (class 1259 OID 16609)
-- Name: comments_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.comments_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.comments_id_seq OWNER TO postgres;

--
-- TOC entry 3454 (class 0 OID 0)
-- Dependencies: 212
-- Name: comments_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.comments_id_seq OWNED BY public.comments.id;


--
-- TOC entry 221 (class 1259 OID 16673)
-- Name: list_movies; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.list_movies (
    id integer NOT NULL,
    fk_movie_lists integer,
    fk_movies integer
);


ALTER TABLE public.list_movies OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16672)
-- Name: list_movies_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.list_movies_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.list_movies_id_seq OWNER TO postgres;

--
-- TOC entry 3455 (class 0 OID 0)
-- Dependencies: 220
-- Name: list_movies_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.list_movies_id_seq OWNED BY public.list_movies.id;


--
-- TOC entry 217 (class 1259 OID 16650)
-- Name: movie_lists; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.movie_lists (
    id integer NOT NULL,
    text text NOT NULL,
    likes integer DEFAULT 0 NOT NULL,
    dislikes integer DEFAULT 0 NOT NULL,
    created_at timestamp without time zone NOT NULL,
    description text NOT NULL,
    CONSTRAINT movie_lists_dislikes_check CHECK ((dislikes >= 0)),
    CONSTRAINT movie_lists_likes_check CHECK ((likes >= 0))
);


ALTER TABLE public.movie_lists OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16649)
-- Name: movie_lists_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.movie_lists_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.movie_lists_id_seq OWNER TO postgres;

--
-- TOC entry 3456 (class 0 OID 0)
-- Dependencies: 216
-- Name: movie_lists_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.movie_lists_id_seq OWNED BY public.movie_lists.id;


--
-- TOC entry 225 (class 1259 OID 16715)
-- Name: movie_reports; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.movie_reports (
    id integer NOT NULL,
    generated_at timestamp without time zone NOT NULL,
    average_score numeric(4,2) DEFAULT 0 NOT NULL,
    views integer DEFAULT 0 NOT NULL,
    total_movie_lists integer DEFAULT 0 NOT NULL,
    fk_users text,
    fk_movies integer,
    CONSTRAINT movie_reports_average_score_check CHECK ((average_score >= (0)::numeric)),
    CONSTRAINT movie_reports_total_movie_lists_check CHECK ((total_movie_lists >= 0)),
    CONSTRAINT movie_reports_views_check CHECK ((views >= 0))
);


ALTER TABLE public.movie_reports OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 16714)
-- Name: movie_reports_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.movie_reports_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.movie_reports_id_seq OWNER TO postgres;

--
-- TOC entry 3457 (class 0 OID 0)
-- Dependencies: 224
-- Name: movie_reports_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.movie_reports_id_seq OWNED BY public.movie_reports.id;


--
-- TOC entry 223 (class 1259 OID 16690)
-- Name: movie_reviews; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.movie_reviews (
    id integer NOT NULL,
    text text NOT NULL,
    created_at timestamp without time zone NOT NULL,
    likes integer DEFAULT 0 NOT NULL,
    dislikes integer DEFAULT 0 NOT NULL,
    score numeric(2,0) DEFAULT 0 NOT NULL,
    last_edited_at timestamp without time zone NOT NULL,
    fk_users text,
    fk_movies integer,
    CONSTRAINT movie_reviews_dislikes_check CHECK ((dislikes >= 0)),
    CONSTRAINT movie_reviews_likes_check CHECK ((likes >= 0)),
    CONSTRAINT movie_reviews_score_check CHECK ((score >= (0)::numeric))
);


ALTER TABLE public.movie_reviews OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 16689)
-- Name: movie_reviews_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.movie_reviews_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.movie_reviews_id_seq OWNER TO postgres;

--
-- TOC entry 3458 (class 0 OID 0)
-- Dependencies: 222
-- Name: movie_reviews_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.movie_reviews_id_seq OWNED BY public.movie_reviews.id;


--
-- TOC entry 219 (class 1259 OID 16663)
-- Name: movies; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.movies (
    id integer NOT NULL,
    name text NOT NULL,
    created_at timestamp without time zone NOT NULL,
    duration integer NOT NULL,
    description text NOT NULL,
    language character(20),
    CONSTRAINT movies_duration_check CHECK ((duration >= 0))
);


ALTER TABLE public.movies OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 16662)
-- Name: movies_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.movies_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.movies_id_seq OWNER TO postgres;

--
-- TOC entry 3459 (class 0 OID 0)
-- Dependencies: 218
-- Name: movies_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.movies_id_seq OWNED BY public.movies.id;


--
-- TOC entry 211 (class 1259 OID 16595)
-- Name: posts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.posts (
    id integer NOT NULL,
    name text NOT NULL,
    created_at timestamp without time zone NOT NULL,
    text text NOT NULL,
    likes integer DEFAULT 0 NOT NULL,
    dislikes integer DEFAULT 0 NOT NULL,
    views integer DEFAULT 0 NOT NULL,
    last_edited_at timestamp without time zone NOT NULL,
    CONSTRAINT posts_dislikes_check CHECK ((dislikes >= 0)),
    CONSTRAINT posts_likes_check CHECK ((likes >= 0)),
    CONSTRAINT posts_views_check CHECK ((views >= 0))
);


ALTER TABLE public.posts OWNER TO postgres;

--
-- TOC entry 210 (class 1259 OID 16594)
-- Name: posts_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.posts_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.posts_id_seq OWNER TO postgres;

--
-- TOC entry 3460 (class 0 OID 0)
-- Dependencies: 210
-- Name: posts_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.posts_id_seq OWNED BY public.posts.id;


--
-- TOC entry 228 (class 1259 OID 16758)
-- Name: subtitle; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.subtitle (
    start_at integer NOT NULL,
    text text NOT NULL,
    finish_at integer NOT NULL,
    fk_subtitle_lists integer,
    CONSTRAINT subtitle_finish_at_check CHECK ((finish_at >= 0)),
    CONSTRAINT subtitle_start_at_check CHECK ((start_at >= 0))
);


ALTER TABLE public.subtitle OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 16740)
-- Name: subtitle_lists; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.subtitle_lists (
    id integer NOT NULL,
    language character(20),
    fk_users text,
    fk_movies integer
);


ALTER TABLE public.subtitle_lists OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 16739)
-- Name: subtitle_lists_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.subtitle_lists_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.subtitle_lists_id_seq OWNER TO postgres;

--
-- TOC entry 3461 (class 0 OID 0)
-- Dependencies: 226
-- Name: subtitle_lists_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.subtitle_lists_id_seq OWNED BY public.subtitle_lists.id;


--
-- TOC entry 209 (class 1259 OID 16583)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    name text NOT NULL,
    email text NOT NULL,
    age smallint NOT NULL,
    administrator boolean DEFAULT false NOT NULL,
    created_at timestamp without time zone NOT NULL,
    last_login_at timestamp without time zone NOT NULL,
    password_hash text NOT NULL,
    CONSTRAINT users_age_check CHECK ((age >= 0))
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 3227 (class 2604 OID 16637)
-- Name: comment_reports id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment_reports ALTER COLUMN id SET DEFAULT nextval('public.comment_reports_id_seq'::regclass);


--
-- TOC entry 3221 (class 2604 OID 16613)
-- Name: comments id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comments ALTER COLUMN id SET DEFAULT nextval('public.comments_id_seq'::regclass);


--
-- TOC entry 3237 (class 2604 OID 16676)
-- Name: list_movies id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.list_movies ALTER COLUMN id SET DEFAULT nextval('public.list_movies_id_seq'::regclass);


--
-- TOC entry 3230 (class 2604 OID 16653)
-- Name: movie_lists id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movie_lists ALTER COLUMN id SET DEFAULT nextval('public.movie_lists_id_seq'::regclass);


--
-- TOC entry 3245 (class 2604 OID 16718)
-- Name: movie_reports id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movie_reports ALTER COLUMN id SET DEFAULT nextval('public.movie_reports_id_seq'::regclass);


--
-- TOC entry 3238 (class 2604 OID 16693)
-- Name: movie_reviews id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movie_reviews ALTER COLUMN id SET DEFAULT nextval('public.movie_reviews_id_seq'::regclass);


--
-- TOC entry 3235 (class 2604 OID 16666)
-- Name: movies id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movies ALTER COLUMN id SET DEFAULT nextval('public.movies_id_seq'::regclass);


--
-- TOC entry 3214 (class 2604 OID 16598)
-- Name: posts id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.posts ALTER COLUMN id SET DEFAULT nextval('public.posts_id_seq'::regclass);


--
-- TOC entry 3252 (class 2604 OID 16743)
-- Name: subtitle_lists id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subtitle_lists ALTER COLUMN id SET DEFAULT nextval('public.subtitle_lists_id_seq'::regclass);


--
-- TOC entry 3434 (class 0 OID 16634)
-- Dependencies: 215
-- Data for Name: comment_reports; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.comment_reports (id, text, created_at, reviewed, accepted, fk_comments_id) FROM stdin;
\.


--
-- TOC entry 3432 (class 0 OID 16610)
-- Dependencies: 213
-- Data for Name: comments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.comments (id, text, created_at, likes, dislikes, disabled, last_edited_at, fk_posts_id, fk_users_name) FROM stdin;
\.


--
-- TOC entry 3440 (class 0 OID 16673)
-- Dependencies: 221
-- Data for Name: list_movies; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.list_movies (id, fk_movie_lists, fk_movies) FROM stdin;
\.


--
-- TOC entry 3436 (class 0 OID 16650)
-- Dependencies: 217
-- Data for Name: movie_lists; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.movie_lists (id, text, likes, dislikes, created_at, description) FROM stdin;
\.


--
-- TOC entry 3444 (class 0 OID 16715)
-- Dependencies: 225
-- Data for Name: movie_reports; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.movie_reports (id, generated_at, average_score, views, total_movie_lists, fk_users, fk_movies) FROM stdin;
\.


--
-- TOC entry 3442 (class 0 OID 16690)
-- Dependencies: 223
-- Data for Name: movie_reviews; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.movie_reviews (id, text, created_at, likes, dislikes, score, last_edited_at, fk_users, fk_movies) FROM stdin;
\.


--
-- TOC entry 3438 (class 0 OID 16663)
-- Dependencies: 219
-- Data for Name: movies; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.movies (id, name, created_at, duration, description, language) FROM stdin;
\.


--
-- TOC entry 3430 (class 0 OID 16595)
-- Dependencies: 211
-- Data for Name: posts; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.posts (id, name, created_at, text, likes, dislikes, views, last_edited_at) FROM stdin;
1	Test title	2021-12-18 21:37:12.257093	This is an example post with example text :)	0	0	0	0001-01-01 00:00:00
2	example	2021-12-18 22:03:34.821532	something	0	0	0	0001-01-01 00:00:00
3	string	2021-12-18 22:05:14.810412	string	0	0	0	0001-01-01 00:00:00
5	dgfkjsdhgfksd	2021-12-18 22:09:06.334848	string	0	0	0	0001-01-01 00:00:00
6	string	2021-12-18 22:10:35.232052	string	0	0	0	0001-01-01 00:00:00
7	strinsg	2021-12-18 22:11:16.367411	string	0	0	0	0001-01-01 00:00:00
\.


--
-- TOC entry 3447 (class 0 OID 16758)
-- Dependencies: 228
-- Data for Name: subtitle; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.subtitle (start_at, text, finish_at, fk_subtitle_lists) FROM stdin;
\.


--
-- TOC entry 3446 (class 0 OID 16740)
-- Dependencies: 227
-- Data for Name: subtitle_lists; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.subtitle_lists (id, language, fk_users, fk_movies) FROM stdin;
\.


--
-- TOC entry 3428 (class 0 OID 16583)
-- Dependencies: 209
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (name, email, age, administrator, created_at, last_login_at, password_hash) FROM stdin;
TestUser	testuser@mail.com	20	f	2021-12-18 19:46:44.904487	0001-01-01 00:00:00	fdksjhfkjsdahgkjdsgh
\.


--
-- TOC entry 3462 (class 0 OID 0)
-- Dependencies: 214
-- Name: comment_reports_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.comment_reports_id_seq', 1, false);


--
-- TOC entry 3463 (class 0 OID 0)
-- Dependencies: 212
-- Name: comments_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.comments_id_seq', 2, true);


--
-- TOC entry 3464 (class 0 OID 0)
-- Dependencies: 220
-- Name: list_movies_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.list_movies_id_seq', 1, false);


--
-- TOC entry 3465 (class 0 OID 0)
-- Dependencies: 216
-- Name: movie_lists_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.movie_lists_id_seq', 1, false);


--
-- TOC entry 3466 (class 0 OID 0)
-- Dependencies: 224
-- Name: movie_reports_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.movie_reports_id_seq', 1, false);


--
-- TOC entry 3467 (class 0 OID 0)
-- Dependencies: 222
-- Name: movie_reviews_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.movie_reviews_id_seq', 1, false);


--
-- TOC entry 3468 (class 0 OID 0)
-- Dependencies: 218
-- Name: movies_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.movies_id_seq', 1, false);


--
-- TOC entry 3469 (class 0 OID 0)
-- Dependencies: 210
-- Name: posts_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.posts_id_seq', 7, true);


--
-- TOC entry 3470 (class 0 OID 0)
-- Dependencies: 226
-- Name: subtitle_lists_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.subtitle_lists_id_seq', 1, false);


--
-- TOC entry 3264 (class 2606 OID 16643)
-- Name: comment_reports comment_reports_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment_reports
    ADD CONSTRAINT comment_reports_pkey PRIMARY KEY (id);


--
-- TOC entry 3262 (class 2606 OID 16622)
-- Name: comments comments_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comments
    ADD CONSTRAINT comments_pkey PRIMARY KEY (id);


--
-- TOC entry 3270 (class 2606 OID 16678)
-- Name: list_movies list_movies_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.list_movies
    ADD CONSTRAINT list_movies_pkey PRIMARY KEY (id);


--
-- TOC entry 3266 (class 2606 OID 16661)
-- Name: movie_lists movie_lists_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movie_lists
    ADD CONSTRAINT movie_lists_pkey PRIMARY KEY (id);


--
-- TOC entry 3274 (class 2606 OID 16728)
-- Name: movie_reports movie_reports_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movie_reports
    ADD CONSTRAINT movie_reports_pkey PRIMARY KEY (id);


--
-- TOC entry 3272 (class 2606 OID 16703)
-- Name: movie_reviews movie_reviews_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movie_reviews
    ADD CONSTRAINT movie_reviews_pkey PRIMARY KEY (id);


--
-- TOC entry 3268 (class 2606 OID 16671)
-- Name: movies movies_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movies
    ADD CONSTRAINT movies_pkey PRIMARY KEY (id);


--
-- TOC entry 3260 (class 2606 OID 16608)
-- Name: posts posts_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.posts
    ADD CONSTRAINT posts_pkey PRIMARY KEY (id);


--
-- TOC entry 3276 (class 2606 OID 16747)
-- Name: subtitle_lists subtitle_lists_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subtitle_lists
    ADD CONSTRAINT subtitle_lists_pkey PRIMARY KEY (id);


--
-- TOC entry 3256 (class 2606 OID 16593)
-- Name: users users_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_email_key UNIQUE (email);


--
-- TOC entry 3258 (class 2606 OID 16591)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (name);


--
-- TOC entry 3279 (class 2606 OID 16644)
-- Name: comment_reports comment_reports_fk_comments_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment_reports
    ADD CONSTRAINT comment_reports_fk_comments_id_fkey FOREIGN KEY (fk_comments_id) REFERENCES public.comments(id) ON DELETE CASCADE;


--
-- TOC entry 3277 (class 2606 OID 16623)
-- Name: comments comments_fk_posts_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comments
    ADD CONSTRAINT comments_fk_posts_id_fkey FOREIGN KEY (fk_posts_id) REFERENCES public.posts(id) ON DELETE CASCADE;


--
-- TOC entry 3278 (class 2606 OID 16628)
-- Name: comments comments_fk_users_name_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comments
    ADD CONSTRAINT comments_fk_users_name_fkey FOREIGN KEY (fk_users_name) REFERENCES public.users(name) ON DELETE SET NULL;


--
-- TOC entry 3280 (class 2606 OID 16679)
-- Name: list_movies list_movies_fk_movie_lists_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.list_movies
    ADD CONSTRAINT list_movies_fk_movie_lists_fkey FOREIGN KEY (fk_movie_lists) REFERENCES public.movie_lists(id) ON DELETE CASCADE;


--
-- TOC entry 3281 (class 2606 OID 16684)
-- Name: list_movies list_movies_fk_movies_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.list_movies
    ADD CONSTRAINT list_movies_fk_movies_fkey FOREIGN KEY (fk_movies) REFERENCES public.movies(id) ON DELETE CASCADE;


--
-- TOC entry 3285 (class 2606 OID 16734)
-- Name: movie_reports movie_reports_fk_movies_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movie_reports
    ADD CONSTRAINT movie_reports_fk_movies_fkey FOREIGN KEY (fk_movies) REFERENCES public.movies(id) ON DELETE CASCADE;


--
-- TOC entry 3284 (class 2606 OID 16729)
-- Name: movie_reports movie_reports_fk_users_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movie_reports
    ADD CONSTRAINT movie_reports_fk_users_fkey FOREIGN KEY (fk_users) REFERENCES public.users(name) ON DELETE CASCADE;


--
-- TOC entry 3283 (class 2606 OID 16709)
-- Name: movie_reviews movie_reviews_fk_movies_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movie_reviews
    ADD CONSTRAINT movie_reviews_fk_movies_fkey FOREIGN KEY (fk_movies) REFERENCES public.movies(id) ON DELETE CASCADE;


--
-- TOC entry 3282 (class 2606 OID 16704)
-- Name: movie_reviews movie_reviews_fk_users_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movie_reviews
    ADD CONSTRAINT movie_reviews_fk_users_fkey FOREIGN KEY (fk_users) REFERENCES public.users(name) ON DELETE CASCADE;


--
-- TOC entry 3288 (class 2606 OID 16765)
-- Name: subtitle subtitle_fk_subtitle_lists_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subtitle
    ADD CONSTRAINT subtitle_fk_subtitle_lists_fkey FOREIGN KEY (fk_subtitle_lists) REFERENCES public.subtitle_lists(id) ON DELETE CASCADE;


--
-- TOC entry 3287 (class 2606 OID 16753)
-- Name: subtitle_lists subtitle_lists_fk_movies_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subtitle_lists
    ADD CONSTRAINT subtitle_lists_fk_movies_fkey FOREIGN KEY (fk_movies) REFERENCES public.movies(id) ON DELETE CASCADE;


--
-- TOC entry 3286 (class 2606 OID 16748)
-- Name: subtitle_lists subtitle_lists_fk_users_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subtitle_lists
    ADD CONSTRAINT subtitle_lists_fk_users_fkey FOREIGN KEY (fk_users) REFERENCES public.users(name) ON DELETE CASCADE;


-- Completed on 2021-12-19 11:50:53

--
-- PostgreSQL database dump complete
--

