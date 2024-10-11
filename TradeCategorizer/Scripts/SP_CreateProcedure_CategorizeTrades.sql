--using db;

CREATE PROCEDURE CategorizeTrades
AS
BEGIN

    DELETE FROM TradeCategories;

    INSERT INTO TradeCategories (TradeId, Category)
    SELECT 
        t.TradeId,
        CASE
            WHEN t.TradeValue > 1000000 AND t.ClientSector = 'Private' THEN 'HIGHRISK'
            WHEN t.TradeValue > 1000000 AND t.ClientSector = 'Public' THEN 'MEDIUMRISK'
            WHEN t.TradeValue < 1000000 AND t.ClientSector = 'Public' THEN 'LOWRISK'
            ELSE 'UNCATEGORIZED' 
        END AS Category
    FROM Trades t;
END;


--EXEC CategorizeTrades;

--SELECT * FROM TradeCategories;