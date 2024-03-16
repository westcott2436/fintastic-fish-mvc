CREATE TABLE [dbo].[OrdersFishes] (
    [OrderId] INT NOT NULL,
    [FishId]  INT NOT NULL,
    CONSTRAINT [FK_OrdersFishes_Fishes] FOREIGN KEY ([FishId]) REFERENCES [dbo].[Fishes] ([Id]),
    CONSTRAINT [FK_OrdersFishes_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id])
);

