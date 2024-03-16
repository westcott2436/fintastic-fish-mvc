CREATE TABLE [dbo].[FishesFoods] (
    [FishId] INT NOT NULL,
    [FoodId] INT NOT NULL,
    CONSTRAINT [FK_FishesFoods_Fishes] FOREIGN KEY ([FishId]) REFERENCES [dbo].[Fishes] ([Id]),
    CONSTRAINT [FK_FishesFoods_Foods] FOREIGN KEY ([FoodId]) REFERENCES [dbo].[Foods] ([Id])
);

