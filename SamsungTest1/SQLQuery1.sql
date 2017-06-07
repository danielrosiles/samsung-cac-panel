CREATE TABLE [dbo].[samsung_vendedores] (
    [Id_vendedores]  INT        IDENTITY (1, 1) NOT NULL,
    [nombre]         NCHAR (90) NOT NULL,
    [email]          NCHAR (90) NOT NULL,
    [numero]         NCHAR (30) NOT NULL,
    [operador]       NCHAR (30) NOT NULL,
    [region]         NCHAR (10) NOT NULL,
    [fecha_creacion] NCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_vendedores] ASC)
);