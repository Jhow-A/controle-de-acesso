CREATE DATABASE DevMedia; 

USE DevMedia; 

CREATE TABLE Acesso 
  ( 
     id_login  INT IDENTITY PRIMARY KEY, 
     email     VARCHAR(100), 
     senha     VARCHAR(100), 
     ativo     CHAR(1), 
     perfil    VARCHAR(15), 
     nome      VARCHAR(30), 
     sobrenome VARCHAR(30) 
  ); 

INSERT INTO Acesso 
            (email, 
             senha, 
             ativo, 
             perfil, 
             nome, 
             sobrenome) 
VALUES      ('admin@admin.com', 
             '123456', 
             'S', 
             'Administrador', 
             'Admin', 
             'Sistema'); 

INSERT INTO Acesso 
VALUES      ('user@user.com', 
             '123456', 
             'S', 
             'Usuario', 
             'User', 
             'Sistema'); 

SELECT * 
FROM   Acesso; 

-- Retorna o valor atual do IDETITY
SELECT IDENT_CURRENT('acesso');
