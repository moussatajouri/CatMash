
if exists ( select 1 from sysobjects where id = OBJECT_ID('T_Vote') and type = 'U')
drop table T_Vote
Go


if exists ( select 1 from sysobjects where id = OBJECT_ID('T_Cat') and type = 'U')
drop table T_Cat
Go


CREATE TABLE [T_Cat] (
    [CatId] INT NOT NULL IDENTITY,
    [Url] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Cart] PRIMARY KEY ([CatId]),
);
GO

CREATE TABLE [T_Vote] (
    [VoteId] int NOT NULL IDENTITY,
    [WinCatId] int NOT NULL,
	[LostCatId] int NOT NULL,
    [CreationDate] datetime NULL
    CONSTRAINT [PK_Vote] PRIMARY KEY ([VoteId]),
    CONSTRAINT [FK_Vote_WinCat_CatId] FOREIGN KEY ([WinCatId]) REFERENCES [T_Cat] ([CatId]),
	CONSTRAINT [FK_Vote_LostCat_CatId] FOREIGN KEY ([LostCatId]) REFERENCES [T_Cat] ([CatId])
);
GO