--using db;

CREATE TABLE Trades
(
    TradeId INT PRIMARY KEY IDENTITY,
    TradeValue FLOAT NOT NULL,
    ClientSector NVARCHAR(50) NOT NULL
);

CREATE TABLE TradeCategories
(
    TradeId INT FOREIGN KEY REFERENCES Trades(TradeId),
    Category NVARCHAR(50) NOT NULL
);
