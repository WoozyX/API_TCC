IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Clientes] (
    [Id] int NOT NULL IDENTITY,
    [Imei_Cliente] nvarchar(max) NOT NULL,
    [Email_Cliente] nvarchar(max) NOT NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Username] nvarchar(max) NULL,
    [Sexo_Cliente] nvarchar(max) NULL,
    [Telefone_Cliente] nvarchar(max) NULL,
    [Nascimento_Cliente] nvarchar(max) NULL,
    [Plano_Cliente] int NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [StatusPagamentos] (
    [Id] int NOT NULL IDENTITY,
    [dsStatusPagamento] nvarchar(max) NULL,
    CONSTRAINT [PK_StatusPagamentos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TipoRelacionamento] (
    [Id] int NOT NULL IDENTITY,
    [DsTipoRelacionamento] nvarchar(max) NULL,
    CONSTRAINT [PK_TipoRelacionamento] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TiposOcorrencias] (
    [Id] int NOT NULL IDENTITY,
    [dsTiposOcorrencias] nvarchar(max) NOT NULL,
    [icTipoOcorrencia] varbinary(max) NULL,
    CONSTRAINT [PK_TiposOcorrencias] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Contato] (
    [Id] int NOT NULL IDENTITY,
    [Nome_Contato] nvarchar(max) NOT NULL,
    [Tel_contato] nvarchar(max) NOT NULL,
    [ClienteId] int NOT NULL,
    CONSTRAINT [PK_Contato] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contato_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Imagens] (
    [Id] int NOT NULL IDENTITY,
    [Imagem] nvarchar(max) NULL,
    [ClienteId] int NOT NULL,
    CONSTRAINT [PK_Imagens] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Imagens_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [LogMovimentacao] (
    [Id] int NOT NULL IDENTITY,
    [Latitude] nvarchar(max) NULL,
    [Longitude] nvarchar(max) NULL,
    [ClienteId] int NOT NULL,
    CONSTRAINT [PK_LogMovimentacao] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_LogMovimentacao_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Relacionamento] (
    [Id] int NOT NULL IDENTITY,
    [InRelacionamento] nvarchar(max) NOT NULL,
    [FimRelacionamento] nvarchar(max) NOT NULL,
    [ClienteId] int NOT NULL,
    CONSTRAINT [PK_Relacionamento] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Relacionamento_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Pagamento] (
    [Id] int NOT NULL IDENTITY,
    [MrPagamento] nvarchar(max) NOT NULL,
    [DtPagamento] nvarchar(max) NULL,
    [PxPagamento] nvarchar(max) NOT NULL,
    [VlPagamento] real NOT NULL,
    [ClienteId] int NOT NULL,
    [StatusPagamentoId] int NULL,
    [StatusPagId] int NOT NULL,
    CONSTRAINT [PK_Pagamento] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pagamento_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Pagamento_StatusPagamentos_StatusPagamentoId] FOREIGN KEY ([StatusPagamentoId]) REFERENCES [StatusPagamentos] ([Id])
);
GO

CREATE TABLE [Registro] (
    [Id] int NOT NULL IDENTITY,
    [Latitude] nvarchar(max) NOT NULL,
    [Longitude] nvarchar(max) NOT NULL,
    [MtRegistro] nvarchar(max) NOT NULL,
    [MtRegistrado] nvarchar(max) NOT NULL,
    [TiposOcorrenciasId] int NOT NULL,
    CONSTRAINT [PK_Registro] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Registro_TiposOcorrencias_TiposOcorrenciasId] FOREIGN KEY ([TiposOcorrenciasId]) REFERENCES [TiposOcorrencias] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DsTipoRelacionamento') AND [object_id] = OBJECT_ID(N'[TipoRelacionamento]'))
    SET IDENTITY_INSERT [TipoRelacionamento] ON;
INSERT INTO [TipoRelacionamento] ([Id], [DsTipoRelacionamento])
VALUES (1, N'Standard'),
(2, N'Premium');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DsTipoRelacionamento') AND [object_id] = OBJECT_ID(N'[TipoRelacionamento]'))
    SET IDENTITY_INSERT [TipoRelacionamento] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'dsTiposOcorrencias', N'icTipoOcorrencia') AND [object_id] = OBJECT_ID(N'[TiposOcorrencias]'))
    SET IDENTITY_INSERT [TiposOcorrencias] ON;
INSERT INTO [TiposOcorrencias] ([Id], [dsTiposOcorrencias], [icTipoOcorrencia])
VALUES (1, N'Furto', NULL),
(2, N'Agressão', NULL),
(3, N'Assédio', NULL),
(4, N'Roubo', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'dsTiposOcorrencias', N'icTipoOcorrencia') AND [object_id] = OBJECT_ID(N'[TiposOcorrencias]'))
    SET IDENTITY_INSERT [TiposOcorrencias] OFF;
GO

CREATE INDEX [IX_Contato_ClienteId] ON [Contato] ([ClienteId]);
GO

CREATE INDEX [IX_Imagens_ClienteId] ON [Imagens] ([ClienteId]);
GO

CREATE INDEX [IX_LogMovimentacao_ClienteId] ON [LogMovimentacao] ([ClienteId]);
GO

CREATE INDEX [IX_Pagamento_ClienteId] ON [Pagamento] ([ClienteId]);
GO

CREATE INDEX [IX_Pagamento_StatusPagamentoId] ON [Pagamento] ([StatusPagamentoId]);
GO

CREATE INDEX [IX_Registro_TiposOcorrenciasId] ON [Registro] ([TiposOcorrenciasId]);
GO

CREATE INDEX [IX_Relacionamento_ClienteId] ON [Relacionamento] ([ClienteId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220507174924_Migração', N'6.0.4');
GO

COMMIT;
GO

