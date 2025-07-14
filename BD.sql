CREATE DATABASE BD_Integrantes;
GO

USE BD_Integrantes;
GO

CREATE TABLE Integrante (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Usuario NVARCHAR(100) NOT NULL,
    Contraseña NVARCHAR(100) NOT NULL,
    Genero NVARCHAR(20),
    Color NVARCHAR(50),
    Equipo NVARCHAR(100),
    Pais NVARCHAR(100),
    Telefono NVARCHAR(20)
);
GO

INSERT INTO Integrante (Usuario, Contraseña, Genero, Color, Equipo, Pais, Telefono) VALUES
('SantiDobro', 'Dybala10', 'Masculino', 'Azul', 'River Plate', 'Argentina', '+541112345678'),
('LiorTanel', 'Aldosivi123', 'Masculino', 'Rojo', 'Aldosivi', 'Argentina', '+541198765432');
GO
