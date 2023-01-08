CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `PredictedServes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Names` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Sets` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Games` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Points` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Side` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Position` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_PredictedServes` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230108123359_InitialMigration', '6.0.12');

COMMIT;

