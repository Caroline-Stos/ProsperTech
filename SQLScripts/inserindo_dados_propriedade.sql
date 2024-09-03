/* script de inserção de dados prévios */

INSERT INTO Geladeira (Marca, Modelo) 
VALUES ('Brastemp','Frost Free Brastemp Duplex');

INSERT INTO Andar (GeladeiraId, NomeAndar)
VALUES 
	(1, 'CarnesAndar'),
	(1, 'LaticAndar'),
	(1, 'FruitAndar');

INSERT INTO Container (AndarId, NomeContainer)
VALUES
	(1, 'Container_1'),
	(1, 'Container_2'),
	(2, 'Container_3'),
	(2, 'Container_4'),
	(3, 'Container_5'),
	(3, 'Container_6');

INSERT INTO Posicao (ContainerId, NomePosicao)
VALUES 
	(1, 'Posicao_1'),
	(1, 'Posicao_2'),
	(1, 'Posicao_3'),
	(1,'Posicao_4'),

	(2, 'Posicao_1'),
	(2, 'Posicao_2'),
	(2, 'Posicao_3'),
	(2,'Posicao_4'),

	(3, 'Posicao_1'),
	(3, 'Posicao_2'),
	(3, 'Posicao_3'),
	(3,'Posicao_4'),

	(4, 'Posicao_1'),
	(4, 'Posicao_2'),
	(4, 'Posicao_3'),
	(4,'Posicao_4'),

	(5, 'Posicao_1'),
	(5, 'Posicao_2'),
	(5, 'Posicao_3'),
	(5,'Posicao_4'),

	(6, 'Posicao_1'),
	(6, 'Posicao_2'),
	(6, 'Posicao_3'),
	(6, 'Posicao_4');