use master;
go
create database JonathanG;
go

--drop database JonathanG;
--go

--tabla de clientes
create table JG_Clientes(
 ClienteID int Identity (1,1) primary key,
 Nombre nvarchar(150) not null,
 Telefono nvarchar(20),
 Email nvarchar(100)
);

GO
--tabla de abogados
create table JG_Abogados (
    AbogadoID int identity(1,1) primary key,
    Nombre nvarchar(150) not null,
    Telefono nvarchar(20)
);
GO

--Tabla principal
create table JG_Casos (
    CasoID INT IDENTITY(1,1) PRIMARY KEY,
    NumeroCaso NVARCHAR(50) NOT NULL UNIQUE,
    ClienteID INT NOT NULL,
    AbogadoID INT NOT NULL,
    Titulo NVARCHAR(250) NOT NULL,
    Descripcion NVARCHAR(MAX),
    Estado NVARCHAR(50) DEFAULT 'Nuevo',
    FechaInicio DATE NOT NULL,
    FechaVencimiento DATE,
    FOREIGN KEY (ClienteID) REFERENCES JG_Clientes(ClienteID),
    FOREIGN KEY (AbogadoID) REFERENCES JG_Abogados(AbogadoID)
);
GO

--Tabla de eventos
create table JG_Eventos (
    EventoID INT IDENTITY(1,1) PRIMARY KEY,
    CasoID INT NOT NULL,
    Fecha DATETIME NOT NULL,
    Descripcion NVARCHAR(500),
    FOREIGN KEY (CasoID) REFERENCES JG_Casos(CasoID) ON DELETE CASCADE
);
GO

                    ---datos de cada tabla---


INSERT INTO JG_Clientes (Nombre, Telefono, Email) VALUES
('María González', '111-1234', 'maria@email.com'),
('Carlos Pérez', '222-5678', 'carlos@email.com');
go

INSERT INTO JG_Abogados (Nombre, Telefono) VALUES
('Dr. Juan Martínez', '333-1111'),
('Dra. Ana López', '444-2222');
go

INSERT INTO JG_Casos (NumeroCaso, ClienteID, AbogadoID, Titulo, Descripcion, Estado, FechaInicio, FechaVencimiento)
VALUES 
('CASO-001', 1, 1, 'Demanda contractual', 'Incumplimiento de contrato', 'En Proceso', '2024-01-15', '2024-12-31'),
('CASO-002', 2, 2, 'Defensa penal', 'Caso penal', 'Nuevo', '2024-02-01', '2025-02-01');
go

INSERT INTO JG_Eventos (CasoID, Fecha, Descripcion) VALUES
(1, '2024-12-15 10:00', 'Audiencia en Juzgado Civil'),
(2, '2024-12-20 14:00', 'Primera comparecencia');
GO

PRINT 'Base de datos JonathanG creada exitosamente';
PRINT 'Tablas: JG_Clientes, JG_Abogados, JG_Casos, JG_Eventos';
GO






