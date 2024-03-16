CREATE TABLE [dbo].[OrdersFoods] (
    [OrderId] INT NOT NULL,
    [FoodId]  INT NOT NULL,
    CONSTRAINT [FK_OrdersFoods_Foods] FOREIGN KEY ([FoodId]) REFERENCES [dbo].[Foods] ([Id]),
    CONSTRAINT [FK_OrdersFoods_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id])
);

