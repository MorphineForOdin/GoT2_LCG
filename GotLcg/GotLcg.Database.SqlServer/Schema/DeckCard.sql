﻿CREATE TABLE [dbo].[DeckCard]
(
	[DeckId] UNIQUEIDENTIFIER NOT NULL,
	[CardId] UNIQUEIDENTIFIER NOT NULL,
	[Amount] INT NOT NULL CONSTRAINT [DEF_DeckCard_Amount] DEFAULT 1, 
    [CreatedDate] DATETIME2 NOT NULL CONSTRAINT [DEF_DeckCard_CreatedDate] DEFAULT GETUTCDATE(), 
    [ModifiedDate] DATETIME2 NOT NULL CONSTRAINT [DEF_DeckCard_ModifiedDate] DEFAULT GETUTCDATE(),
	CONSTRAINT [PK_DeckCard] PRIMARY KEY NONCLUSTERED ([DeckId], [CardId]),
    CONSTRAINT [FK_DeckCard_Deck] FOREIGN KEY ([DeckId]) REFERENCES [Deck]([Id]),
    CONSTRAINT [FK_DeckCard_Card] FOREIGN KEY ([CardId]) REFERENCES [Card]([Id])
)
