CREATE TABLE person (
    id_person INT PRIMARY KEY,
    nama VARCHAR(100) NOT NULL,
	alamat VARCHAR(255),
    email VARCHAR(255)
);


INSERT INTO person (id_person, nama, alamat, email) 
VALUES
(1, 'Fadhila', 'Situbondo', 'fadhila@gmail.com'),
(2, 'Amalia', 'Situbondo', 'amalia@gmail.com'),
(3, 'Fatihah', 'Jember', 'fatihah@gmail.com');

select * from person