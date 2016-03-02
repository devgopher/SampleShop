-- View: "GoodsQuantity"

DROP VIEW "GoodsQuantity";

CREATE OR REPLACE VIEW "GoodsQuantity" AS 


    SELECT 
    gds.id AS good_id,
    gds."Name" AS good_name,
    sps.id AS shop_id,
    sps."Name" AS shop_name,
    sps."Phone" AS shop_phone,
    sps."Address" AS shop_address,
    sps."Email" AS shop_email,
    CASE WHEN ( SELECT gis."Count" FROM "GoodsInShops" gis WHERE gis."Shop_id" = sps.id and gis."Good_id" = gds.id ) IS NULL
    THEN 0
    ELSE
    (SELECT gis."Count" FROM "GoodsInShops" gis WHERE gis."Shop_id" = sps.id and gis."Good_id" = gds.id)
    END good_count
   FROM 
   "Shops" sps,
   "Goods" gds

