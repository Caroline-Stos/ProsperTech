/* script de criação das tabelas */

CREATE TABLE Geladeira (
    GeladeiraId INT PRIMARY KEY IDENTITY(1,1),
    Marca NVARCHAR(100),
    Modelo NVARCHAR(100),
);

CREATE TABLE Andar (
    AndarId INT PRIMARY KEY IDENTITY(1,1),
	GeladeiraId INT NOT NULL,
    NomeAndar NVARCHAR(30),
	CONSTRAINT FK_Andar_Geladeira FOREIGN KEY (GeladeiraId) REFERENCES Geladeira(GeladeiraId)
);

CREATE TABLE Container (
    ContainerId INT PRIMARY KEY IDENTITY(1,1),
	AndarId INT NOT NULL,
    NomeContainer NVARCHAR(100),
	CONSTRAINT FK_Container_Andar FOREIGN KEY (AndarId) REFERENCES Andar(AndarId)
);

CREATE TABLE Posicao (
	PosicaoId INT PRIMARY KEY IDENTITY(1,1),
	ContainerId INT NOT NULL,
	NomePosicao NVARCHAR(30),
	CONSTRAINT FK_Posicao_Container FOREIGN KEY (ContainerId) REFERENCES Container(ContainerId)
);

CREATE TABLE Item (
    ItemId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    ContainerId INT NOT NULL,
	PosicaoId INT NOT NULL,
    NomeItem NVARCHAR(100) NOT NULL,
    CONSTRAINT FK_Item_Container FOREIGN KEY (ContainerId) REFERENCES Container(ContainerId),
	CONSTRAINT FK_Item_Posicao FOREIGN KEY (PosicaoId) REFERENCES Posicao(PosicaoId),
);