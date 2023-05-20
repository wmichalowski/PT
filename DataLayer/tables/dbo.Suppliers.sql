CREATE TABLE [dbo].[Suppliers] (
    [SupplierId]  INT   NOT NULL,
    [Name]        NTEXT NOT NULL,
    [Address]     NTEXT NOT NULL,
    [PhoneNumber] TEXT  NULL,
    [Email]       TEXT  NULL,
    PRIMARY KEY CLUSTERED ([SupplierId] ASC)
);

