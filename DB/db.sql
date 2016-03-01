--
-- PostgreSQL database dump
--

-- Dumped from database version 9.4.0
-- Dumped by pg_dump version 9.4.0
-- Started on 2016-03-02 01:27:51

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

DROP DATABASE "SampleShop";
--
-- TOC entry 2014 (class 1262 OID 65536)
-- Name: SampleShop; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "SampleShop" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Russian_Russia.1251' LC_CTYPE = 'Russian_Russia.1251';


ALTER DATABASE "SampleShop" OWNER TO postgres;

\connect "SampleShop"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- TOC entry 5 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO postgres;

--
-- TOC entry 2015 (class 0 OID 0)
-- Dependencies: 5
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON SCHEMA public IS 'standard public schema';


--
-- TOC entry 175 (class 3079 OID 11855)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2017 (class 0 OID 0)
-- Dependencies: 175
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 174 (class 1259 OID 65546)
-- Name: Goods; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "Goods" (
    id bigint NOT NULL,
    "Name" character varying(45)
);


ALTER TABLE "Goods" OWNER TO postgres;

--
-- TOC entry 2018 (class 0 OID 0)
-- Dependencies: 174
-- Name: COLUMN "Goods".id; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN "Goods".id IS 'ID';


--
-- TOC entry 173 (class 1259 OID 65543)
-- Name: GoodsInShops; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "GoodsInShops" (
    id bigint NOT NULL,
    "Count" integer,
    "Shop_id" bigint,
    "Good_id" bigint
);


ALTER TABLE "GoodsInShops" OWNER TO postgres;

--
-- TOC entry 2020 (class 0 OID 0)
-- Dependencies: 173
-- Name: COLUMN "GoodsInShops".id; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN "GoodsInShops".id IS 'ID';


--
-- TOC entry 2021 (class 0 OID 0)
-- Dependencies: 173
-- Name: COLUMN "GoodsInShops"."Count"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN "GoodsInShops"."Count" IS 'An amounts of goodies of this category';


--
-- TOC entry 2022 (class 0 OID 0)
-- Dependencies: 173
-- Name: COLUMN "GoodsInShops"."Shop_id"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN "GoodsInShops"."Shop_id" IS 'Shop ID';


--
-- TOC entry 172 (class 1259 OID 65537)
-- Name: Shops; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "Shops" (
    id bigint NOT NULL,
    "Name" character varying(45),
    "Phone" character varying(45),
    "Address" character varying(45),
    "Email" character varying(45)
);


ALTER TABLE "Shops" OWNER TO postgres;

--
-- TOC entry 2024 (class 0 OID 0)
-- Dependencies: 172
-- Name: COLUMN "Shops".id; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN "Shops".id IS 'ID';


--
-- TOC entry 2009 (class 0 OID 65546)
-- Dependencies: 174
-- Data for Name: Goods; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO "Goods" (id, "Name") VALUES (1, 'молоко "Домик в Деревне"');
INSERT INTO "Goods" (id, "Name") VALUES (2, 'сыр "Пармезан"');


--
-- TOC entry 2008 (class 0 OID 65543)
-- Dependencies: 173
-- Data for Name: GoodsInShops; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO "GoodsInShops" (id, "Count", "Shop_id", "Good_id") VALUES (1, 100, 1, 1);
INSERT INTO "GoodsInShops" (id, "Count", "Shop_id", "Good_id") VALUES (2, 12, 2, 1);
INSERT INTO "GoodsInShops" (id, "Count", "Shop_id", "Good_id") VALUES (3, 123, 3, 2);
INSERT INTO "GoodsInShops" (id, "Count", "Shop_id", "Good_id") VALUES (4, 43, 3, 1);


--
-- TOC entry 2007 (class 0 OID 65537)
-- Dependencies: 172
-- Data for Name: Shops; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (3, 'Новый продуктовый', '+7495-4550203', 'г. Королев. ул. Циолковского, дом 12', 'jkdjd@mail.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (2, '"1-й Продуктовый" Мичуринский', '+7495-7770067', 'г. Москва, Мичуринский пр-т, дом 12', NULL);
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (1, 'AAA', '+7929-2093454', '4434', 'ferfer@kidf.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (4, 'СвеЖ', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (5, 'СвеЖ', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (6, 'СвеЖ', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (7, 'СвеЖ', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (8, 'СвеЖ', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (9, 'СвеЖ', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (10, 'СвеЖ', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (11, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (12, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (13, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (14, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (15, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (16, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (17, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (18, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (19, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (20, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (21, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (22, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (23, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (24, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (25, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (26, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (27, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (28, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (29, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (30, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (31, 'СвеЖ2', '+7-495-684-55-00', 'г. Москва, ул. космонавтов, дом 1', 'kosmo@svej.com');
INSERT INTO "Shops" (id, "Name", "Phone", "Address", "Email") VALUES (32, 'Свеж5', '+7-495-900-00-00', 'г. Москва, ул. Енисейская, 2', 'svej_enisej@svej.com');


--
-- TOC entry 1890 (class 2606 OID 65552)
-- Name: GoodsInShops_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "GoodsInShops"
    ADD CONSTRAINT "GoodsInShops_pkey" PRIMARY KEY (id);


--
-- TOC entry 1895 (class 2606 OID 65554)
-- Name: Goods_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "Goods"
    ADD CONSTRAINT "Goods_pkey" PRIMARY KEY (id);


--
-- TOC entry 1888 (class 2606 OID 65550)
-- Name: Shops_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "Shops"
    ADD CONSTRAINT "Shops_pkey" PRIMARY KEY (id);


--
-- TOC entry 1893 (class 1259 OID 65567)
-- Name: Goods_id_idx; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX "Goods_id_idx" ON "Goods" USING btree (id);


--
-- TOC entry 1891 (class 1259 OID 65560)
-- Name: fki_good_id_fk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX fki_good_id_fk ON "GoodsInShops" USING btree ("Good_id");


--
-- TOC entry 1892 (class 1259 OID 65566)
-- Name: fki_shop_id_fk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX fki_shop_id_fk ON "GoodsInShops" USING btree ("Shop_id");


--
-- TOC entry 1896 (class 2606 OID 65555)
-- Name: good_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "GoodsInShops"
    ADD CONSTRAINT good_id_fk FOREIGN KEY ("Good_id") REFERENCES "Goods"(id);


--
-- TOC entry 1897 (class 2606 OID 65561)
-- Name: shop_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "GoodsInShops"
    ADD CONSTRAINT shop_id_fk FOREIGN KEY ("Shop_id") REFERENCES "Shops"(id);


--
-- TOC entry 2016 (class 0 OID 0)
-- Dependencies: 5
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


--
-- TOC entry 2019 (class 0 OID 0)
-- Dependencies: 174
-- Name: Goods; Type: ACL; Schema: public; Owner: postgres
--

REVOKE ALL ON TABLE "Goods" FROM PUBLIC;
REVOKE ALL ON TABLE "Goods" FROM postgres;
GRANT ALL ON TABLE "Goods" TO postgres;
GRANT SELECT,INSERT,DELETE,TRIGGER,UPDATE ON TABLE "Goods" TO shop_server;


--
-- TOC entry 2023 (class 0 OID 0)
-- Dependencies: 173
-- Name: GoodsInShops; Type: ACL; Schema: public; Owner: postgres
--

REVOKE ALL ON TABLE "GoodsInShops" FROM PUBLIC;
REVOKE ALL ON TABLE "GoodsInShops" FROM postgres;
GRANT ALL ON TABLE "GoodsInShops" TO postgres;
GRANT SELECT,INSERT,DELETE,TRIGGER,UPDATE ON TABLE "GoodsInShops" TO shop_server;


--
-- TOC entry 2025 (class 0 OID 0)
-- Dependencies: 172
-- Name: Shops; Type: ACL; Schema: public; Owner: postgres
--

REVOKE ALL ON TABLE "Shops" FROM PUBLIC;
REVOKE ALL ON TABLE "Shops" FROM postgres;
GRANT ALL ON TABLE "Shops" TO postgres;
GRANT SELECT,INSERT,DELETE,TRIGGER,UPDATE ON TABLE "Shops" TO shop_server;


-- Completed on 2016-03-02 01:27:51

--
-- PostgreSQL database dump complete
--

