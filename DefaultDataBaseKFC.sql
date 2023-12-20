--
-- PostgreSQL database dump
--

-- Dumped from database version 15.5
-- Dumped by pg_dump version 15.5

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

--
-- Name: KFas; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "KFas" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';


ALTER DATABASE "KFas" OWNER TO postgres;

\connect "KFas"

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
-- Name: Dishes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Dishes" (
    "IdDish" integer NOT NULL,
    "Name" character varying(30) NOT NULL,
    "Price" double precision NOT NULL
);


ALTER TABLE public."Dishes" OWNER TO postgres;

--
-- Name: Dishes_IdDish_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Dishes" ALTER COLUMN "IdDish" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Dishes_IdDish_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: OrderDish; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."OrderDish" (
    "IdList" integer NOT NULL,
    "IdDish" integer NOT NULL,
    "IdOrder" integer NOT NULL,
    "Count" integer NOT NULL
);


ALTER TABLE public."OrderDish" OWNER TO postgres;

--
-- Name: OrderDish_IdList_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."OrderDish" ALTER COLUMN "IdList" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."OrderDish_IdList_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Orders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Orders" (
    "IdOrder" integer NOT NULL,
    "Place" character varying(20) NOT NULL,
    "Price" double precision NOT NULL,
    "DateAndTime" timestamp without time zone NOT NULL,
    "Status" character varying(30) NOT NULL,
    "TypePayment" character varying(30),
    "CountClient" integer NOT NULL
);


ALTER TABLE public."Orders" OWNER TO postgres;

--
-- Name: Orders_IdOrder_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Orders" ALTER COLUMN "IdOrder" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Orders_IdOrder_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Posts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Posts" (
    "IdPost" integer NOT NULL,
    "Name" character varying(20) NOT NULL
);


ALTER TABLE public."Posts" OWNER TO postgres;

--
-- Name: Posts_IdPost_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Posts" ALTER COLUMN "IdPost" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Posts_IdPost_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: StatusesUser; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."StatusesUser" (
    "IdStatus" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);


ALTER TABLE public."StatusesUser" OWNER TO postgres;

--
-- Name: StatusesUser_IdStatus_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."StatusesUser" ALTER COLUMN "IdStatus" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."StatusesUser_IdStatus_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: UserShift; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserShift" (
    "IdList" integer NOT NULL,
    "IdUser" integer NOT NULL,
    "IdShift" integer NOT NULL,
    "Place" character varying(50) NOT NULL
);


ALTER TABLE public."UserShift" OWNER TO postgres;

--
-- Name: UserShift_IdList_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."UserShift" ALTER COLUMN "IdList" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."UserShift_IdList_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Login" character varying(30) NOT NULL,
    "Password" character varying(30) NOT NULL,
    "FName" character varying(50) NOT NULL,
    "SName" character varying(50),
    "LName" character varying(50) NOT NULL,
    "Photo" character varying(500),
    "EmplContract" character varying(500),
    "IdUser" integer NOT NULL,
    "IdPost" integer NOT NULL,
    "IdStatus" integer NOT NULL
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- Name: UsersOrders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UsersOrders" (
    "IdList" integer NOT NULL,
    "IdUser" integer NOT NULL,
    "IdOrder" integer NOT NULL
);


ALTER TABLE public."UsersOrders" OWNER TO postgres;

--
-- Name: UsersOrders_IdList_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."UsersOrders" ALTER COLUMN "IdList" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."UsersOrders_IdList_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Users_IdUser_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Users" ALTER COLUMN "IdUser" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Users_IdUser_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: WorkShifts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."WorkShifts" (
    "IdShift" integer NOT NULL,
    "Start" timestamp without time zone NOT NULL,
    "End" timestamp without time zone NOT NULL
);


ALTER TABLE public."WorkShifts" OWNER TO postgres;

--
-- Name: WorkShifts_IdShift_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."WorkShifts" ALTER COLUMN "IdShift" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."WorkShifts_IdShift_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Data for Name: Dishes; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Dishes" OVERRIDING SYSTEM VALUE VALUES (1, 'Кекс', 30);
INSERT INTO public."Dishes" OVERRIDING SYSTEM VALUE VALUES (2, 'Синабон', 100);
INSERT INTO public."Dishes" OVERRIDING SYSTEM VALUE VALUES (4, 'Чай', 50);


--
-- Data for Name: OrderDish; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: Orders; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: Posts; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Posts" OVERRIDING SYSTEM VALUE VALUES (1, 'Администратор');
INSERT INTO public."Posts" OVERRIDING SYSTEM VALUE VALUES (2, 'Повар');
INSERT INTO public."Posts" OVERRIDING SYSTEM VALUE VALUES (3, 'Официант');


--
-- Data for Name: StatusesUser; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."StatusesUser" OVERRIDING SYSTEM VALUE VALUES (2, 'Уволен');
INSERT INTO public."StatusesUser" OVERRIDING SYSTEM VALUE VALUES (1, 'Нанят');


--
-- Data for Name: UserShift; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Users" OVERRIDING SYSTEM VALUE VALUES ('1', '1', 'Иван', 'Иванович', 'Иванов', 'AssetsUser/878EDA30-56CC-4B28-9833-287063AC15CF-6346aa2209273.jpeg', 'AssetsUser/Screenshot 2023-12-17.png', 1, 1, 1);


--
-- Data for Name: UsersOrders; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: WorkShifts; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Name: Dishes_IdDish_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Dishes_IdDish_seq"', 4, true);


--
-- Name: OrderDish_IdList_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."OrderDish_IdList_seq"', 11, true);


--
-- Name: Orders_IdOrder_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Orders_IdOrder_seq"', 8, true);


--
-- Name: Posts_IdPost_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Posts_IdPost_seq"', 3, true);


--
-- Name: StatusesUser_IdStatus_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."StatusesUser_IdStatus_seq"', 2, true);


--
-- Name: UserShift_IdList_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."UserShift_IdList_seq"', 1, false);


--
-- Name: UsersOrders_IdList_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."UsersOrders_IdList_seq"', 6, true);


--
-- Name: Users_IdUser_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Users_IdUser_seq"', 7, true);


--
-- Name: WorkShifts_IdShift_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."WorkShifts_IdShift_seq"', 1, false);


--
-- Name: Dishes Dishes_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Dishes"
    ADD CONSTRAINT "Dishes_pk" PRIMARY KEY ("IdDish");


--
-- Name: OrderDish OrderDish_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrderDish"
    ADD CONSTRAINT "OrderDish_pk" PRIMARY KEY ("IdList");


--
-- Name: Orders Orders_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "Orders_pk" PRIMARY KEY ("IdOrder");


--
-- Name: Posts Posts_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Posts"
    ADD CONSTRAINT "Posts_pk" PRIMARY KEY ("IdPost");


--
-- Name: StatusesUser StatusesUser_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."StatusesUser"
    ADD CONSTRAINT "StatusesUser_pk" PRIMARY KEY ("IdStatus");


--
-- Name: UserShift UserShift_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserShift"
    ADD CONSTRAINT "UserShift_pk" PRIMARY KEY ("IdList");


--
-- Name: UsersOrders UsersOrders_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UsersOrders"
    ADD CONSTRAINT "UsersOrders_pk" PRIMARY KEY ("IdList");


--
-- Name: Users Users_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pk" PRIMARY KEY ("IdUser");


--
-- Name: WorkShifts WorkShifts_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."WorkShifts"
    ADD CONSTRAINT "WorkShifts_pk" PRIMARY KEY ("IdShift");


--
-- Name: OrderDish OrderDish_Dishes_IdDish_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrderDish"
    ADD CONSTRAINT "OrderDish_Dishes_IdDish_fk" FOREIGN KEY ("IdDish") REFERENCES public."Dishes"("IdDish");


--
-- Name: OrderDish OrderDish_Orders_IdOrder_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrderDish"
    ADD CONSTRAINT "OrderDish_Orders_IdOrder_fk" FOREIGN KEY ("IdOrder") REFERENCES public."Orders"("IdOrder");


--
-- Name: UserShift UserShift_Users_IdUser_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserShift"
    ADD CONSTRAINT "UserShift_Users_IdUser_fk" FOREIGN KEY ("IdUser") REFERENCES public."Users"("IdUser");


--
-- Name: UserShift UserShift_WorkShifts_IdShift_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserShift"
    ADD CONSTRAINT "UserShift_WorkShifts_IdShift_fk" FOREIGN KEY ("IdShift") REFERENCES public."WorkShifts"("IdShift");


--
-- Name: UsersOrders UsersOrders_Orders_IdOrder_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UsersOrders"
    ADD CONSTRAINT "UsersOrders_Orders_IdOrder_fk" FOREIGN KEY ("IdOrder") REFERENCES public."Orders"("IdOrder");


--
-- Name: UsersOrders UsersOrders_Users_IdUser_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UsersOrders"
    ADD CONSTRAINT "UsersOrders_Users_IdUser_fk" FOREIGN KEY ("IdUser") REFERENCES public."Users"("IdUser");


--
-- Name: Users Users_Posts_IdPost_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_Posts_IdPost_fk" FOREIGN KEY ("IdPost") REFERENCES public."Posts"("IdPost");


--
-- Name: Users Users_StatusesUser_IdStatus_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_StatusesUser_IdStatus_fk" FOREIGN KEY ("IdStatus") REFERENCES public."StatusesUser"("IdStatus");


--
-- PostgreSQL database dump complete
--

