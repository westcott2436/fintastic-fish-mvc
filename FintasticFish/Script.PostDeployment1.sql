/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\SeedData\AddressTypes-Seed.sql
:r .\SeedData\AggressionLevels-Seed.sql
:r .\SeedData\AggressionTypes-Seed.sql
:r .\SeedData\Countries-Seed.sql
:r .\SeedData\FoodTypes-Seed.sql
:r .\SeedData\Measurements-Seed.sql
:r .\SeedData\States-Seed.sql
:r .\SeedData\WaterType-Seed.sql
:r .\SeedData\SupplierTypes-Seed.sql