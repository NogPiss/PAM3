﻿BEGIN TRANSACTION;
ALTER TABLE [TB_PERSONAGENS] ADD [Derrotas] int NOT NULL DEFAULT 0;

ALTER TABLE [TB_PERSONAGENS] ADD [Disputas] int NOT NULL DEFAULT 0;

ALTER TABLE [TB_PERSONAGENS] ADD [Victorias] int NOT NULL DEFAULT 0;

ALTER TABLE [TB_ARMAS] ADD [PersonagemId] int NOT NULL DEFAULT 0;

UPDATE [TB_ARMAS] SET [PersonagemId] = 1
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


UPDATE [TB_ARMAS] SET [PersonagemId] = 2
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


UPDATE [TB_ARMAS] SET [PersonagemId] = 3
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


UPDATE [TB_ARMAS] SET [PersonagemId] = 4
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


UPDATE [TB_ARMAS] SET [PersonagemId] = 5
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


UPDATE [TB_ARMAS] SET [PersonagemId] = 6
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


UPDATE [TB_ARMAS] SET [PersonagemId] = 7
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [Derrotas] = 0, [Disputas] = 0, [Victorias] = 0
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [Derrotas] = 0, [Disputas] = 0, [Victorias] = 0
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [Derrotas] = 0, [Disputas] = 0, [Victorias] = 0
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [Derrotas] = 0, [Disputas] = 0, [Victorias] = 0
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [Derrotas] = 0, [Disputas] = 0, [Victorias] = 0
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [Derrotas] = 0, [Disputas] = 0, [Victorias] = 0
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [Derrotas] = 0, [Disputas] = 0, [Victorias] = 0
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


UPDATE [TB_USUARIOS] SET [PasswordHash] = 0x187FCA83725CCD2039F418C3015D6F242F26B77437757BDF224087DF43DB83D5A2C70AEAE0E8774E2CFC880D75DB83C11E737AB2A79148AAB21A2902FB01CCA8, [PasswordSalt] = 0x444070BCCC50107FD42000FF2981A5676E5104FDD63AACF97F197079C1F71DD917C6B19AE9E86BEF0633A3CF91032AF5739BB3EE21F50C3D1C9585116A8A89C1077C2AE191209D84B2386B41219F05C16657DD0DAF03C89B930D68343D99BC9FC94BD894DD63ED4ED5C917AE78BAF54C87443389500EE1E40C03F5610FB0B0A2
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


CREATE UNIQUE INDEX [IX_TB_ARMAS_PersonagemId] ON [TB_ARMAS] ([PersonagemId]);

ALTER TABLE [TB_ARMAS] ADD CONSTRAINT [FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [TB_PERSONAGENS] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250419173940_MigracaoUmParaUm', N'9.0.4');

COMMIT;
GO

