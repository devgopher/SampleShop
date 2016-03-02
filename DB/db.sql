--
-- PostgreSQL database dump
--

-- Dumped from database version 9.4.6
-- Dumped by pg_dump version 9.4.6
-- Started on 2016-03-02 17:55:09

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- TOC entry 1 (class 3079 OID 11855)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2024 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 173 (class 1259 OID 16451)
-- Name: Goods; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "Goods" (
    id bigint NOT NULL,
    "Name" character varying(45)
);


ALTER TABLE "Goods" OWNER TO postgres;

--
-- TOC entry 2025 (class 0 OID 0)
-- Dependencies: 173
-- Name: COLUMN "Goods".id; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN "Goods".id IS 'ID';


--
-- TOC entry 174 (class 1259 OID 16454)
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
-- TOC entry 2027 (class 0 OID 0)
-- Dependencies: 174
-- Name: COLUMN "GoodsInShops".id; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN "GoodsInShops".id IS 'ID';


--
-- TOC entry 2028 (class 0 OID 0)
-- Dependencies: 174
-- Name: COLUMN "GoodsInShops"."Count"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN "GoodsInShops"."Count" IS 'An amounts of goodies of this category';


--
-- TOC entry 2029 (class 0 OID 0)
-- Dependencies: 174
-- Name: COLUMN "GoodsInShops"."Shop_id"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN "GoodsInShops"."Shop_id" IS 'Shop ID';


--
-- TOC entry 175 (class 1259 OID 16457)
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
-- TOC entry 2031 (class 0 OID 0)
-- Dependencies: 175
-- Name: COLUMN "Shops".id; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN "Shops".id IS 'ID';


--
-- TOC entry 176 (class 1259 OID 16510)
-- Name: GoodsQuantity; Type: VIEW; Schema: public; Owner: shop_server
--

CREATE VIEW "GoodsQuantity" AS
 SELECT DISTINCT gds."Name" AS good_name,
    gds.id AS good_id,
    sps.id AS shop_id,
    sps."Name" AS shop_name,
    sps."Phone" AS shop_phone,
    sps."Address" AS shop_address,
    sps."Email" AS shop_email,
        CASE
            WHEN (( SELECT count(*) AS count
               FROM "GoodsInShops"
              WHERE (("GoodsInShops"."Shop_id" = sps.id) AND ("GoodsInShops"."Good_id" = gds.id))) > 0) THEN ( SELECT "GoodsInShops"."Count"
               FROM "GoodsInShops"
              WHERE (("GoodsInShops"."Shop_id" = sps.id) AND ("GoodsInShops"."Good_id" = gds.id)))
            ELSE 0
        END AS good_count
   FROM "GoodsInShops" gis,
    "Goods" gds,
    "Shops" sps
  WHERE ((sps.id = gis."Shop_id") AND (gis."Good_id" = gds.id))
  ORDER BY gds."Name";


ALTER TABLE "GoodsQuantity" OWNER TO shop_server;

--
-- TOC entry 2014 (class 0 OID 16451)
-- Dependencies: 173
-- Data for Name: Goods; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "Goods" (id, "Name") FROM stdin;
1	молоко "Домик в Деревне"
2	сыр "Пармезан"
\.


--
-- TOC entry 2015 (class 0 OID 16454)
-- Dependencies: 174
-- Data for Name: GoodsInShops; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "GoodsInShops" (id, "Count", "Shop_id", "Good_id") FROM stdin;
2	12	2	1
3	123	3	2
4	43	3	1
5	12	1	1
1	100	1	2
6	222	32	1
7	0	32	2
\.


--
-- TOC entry 2016 (class 0 OID 16457)
-- Dependencies: 175
-- Data for Name: Shops; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "Shops" (id, "Name", "Phone", "Address", "Email") FROM stdin;
3	Новый продуктовый	+7495-4550203	г. Королев. ул. Циолковского, дом 12	jkdjd@mail.com
2	"1-й Продуктовый" Мичуринский	+7495-7770067	г. Москва, Мичуринский пр-т, дом 12	\N
1	AAA	+7929-2093454	4434	ferfer@kidf.com
4	СвеЖ	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
5	СвеЖ	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
6	СвеЖ	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
7	СвеЖ	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
8	СвеЖ	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
9	СвеЖ	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
10	СвеЖ	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
11	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
12	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
13	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
14	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
15	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
16	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
17	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
18	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
19	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
20	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
21	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
22	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
23	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
24	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
25	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
26	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
27	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
28	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
29	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
30	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
31	СвеЖ2	+7-495-684-55-00	г. Москва, ул. космонавтов, дом 1	kosmo@svej.com
32	Свеж5	+7-495-900-00-00	г. Москва, ул. Енисейская, 2	svej_enisej@svej.com
\.


--
-- TOC entry 1895 (class 2606 OID 16484)
-- Name: GoodsInShops_Shop_id_Good_id_key; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "GoodsInShops"
    ADD CONSTRAINT "GoodsInShops_Shop_id_Good_id_key" UNIQUE ("Shop_id", "Good_id");


--
-- TOC entry 1897 (class 2606 OID 16461)
-- Name: GoodsInShops_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "GoodsInShops"
    ADD CONSTRAINT "GoodsInShops_pkey" PRIMARY KEY (id);


--
-- TOC entry 1893 (class 2606 OID 16463)
-- Name: Goods_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "Goods"
    ADD CONSTRAINT "Goods_pkey" PRIMARY KEY (id);


--
-- TOC entry 1901 (class 2606 OID 16465)
-- Name: Shops_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "Shops"
    ADD CONSTRAINT "Shops_pkey" PRIMARY KEY (id);


--
-- TOC entry 1891 (class 1259 OID 16466)
-- Name: Goods_id_idx; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX "Goods_id_idx" ON "Goods" USING btree (id);


--
-- TOC entry 1898 (class 1259 OID 16467)
-- Name: fki_good_id_fk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX fki_good_id_fk ON "GoodsInShops" USING btree ("Good_id");


--
-- TOC entry 1899 (class 1259 OID 16468)
-- Name: fki_shop_id_fk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX fki_shop_id_fk ON "GoodsInShops" USING btree ("Shop_id");


--
-- TOC entry 1902 (class 2606 OID 16469)
-- Name: good_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "GoodsInShops"
    ADD CONSTRAINT good_id_fk FOREIGN KEY ("Good_id") REFERENCES "Goods"(id);


--
-- TOC entry 1903 (class 2606 OID 16474)
-- Name: shop_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "GoodsInShops"
    ADD CONSTRAINT shop_id_fk FOREIGN KEY ("Shop_id") REFERENCES "Shops"(id);


--
-- TOC entry 2023 (class 0 OID 0)
-- Dependencies: 7
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


--
-- TOC entry 2026 (class 0 OID 0)
-- Dependencies: 173
-- Name: Goods; Type: ACL; Schema: public; Owner: postgres
--

REVOKE ALL ON TABLE "Goods" FROM PUBLIC;
REVOKE ALL ON TABLE "Goods" FROM postgres;
GRANT ALL ON TABLE "Goods" TO postgres;
GRANT SELECT,INSERT,DELETE,TRIGGER,UPDATE ON TABLE "Goods" TO shop_server;


--
-- TOC entry 2030 (class 0 OID 0)
-- Dependencies: 174
-- Name: GoodsInShops; Type: ACL; Schema: public; Owner: postgres
--

REVOKE ALL ON TABLE "GoodsInShops" FROM PUBLIC;
REVOKE ALL ON TABLE "GoodsInShops" FROM postgres;
GRANT ALL ON TABLE "GoodsInShops" TO postgres;
GRANT SELECT,INSERT,DELETE,TRIGGER,UPDATE ON TABLE "GoodsInShops" TO shop_server;


--
-- TOC entry 2032 (class 0 OID 0)
-- Dependencies: 175
-- Name: Shops; Type: ACL; Schema: public; Owner: postgres
--

REVOKE ALL ON TABLE "Shops" FROM PUBLIC;
REVOKE ALL ON TABLE "Shops" FROM postgres;
GRANT ALL ON TABLE "Shops" TO postgres;
GRANT SELECT,INSERT,DELETE,TRIGGER,UPDATE ON TABLE "Shops" TO shop_server;


-- Completed on 2016-03-02 17:55:12

--
-- PostgreSQL database dump complete
--

