BEGIN TRANSACTION;
CREATE TABLE [TB_ARMAS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_TB_ARMAS] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_ARMAS]'))
    SET IDENTITY_INSERT [TB_ARMAS] ON;
INSERT INTO [TB_ARMAS] ([Id], [Dano], [Nome])
VALUES (1, 15, 'Espada Longa'),
(2, 20, 'Machado de Guerra'),
(3, 8, 'Arco Curto'),
(4, 12, 'Adaga Envenenada'),
(5, 18, 'Martelo Sagrado'),
(6, 14, 'Lança de Gelo'),
(7, 16, 'Cajado Arcano');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_ARMAS]'))
    SET IDENTITY_INSERT [TB_ARMAS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250419010828_MigracaoArma', N'9.0.4');

COMMIT;
GO

