﻿
USE [FintasticFish]
GO

--MERGE generated by 'sp_generate_merge' stored procedure
--Originally by Vyas (http://vyaskn.tripod.com/code): sp_generate_inserts (build 22)
--Adapted for SQL Server 2008+ by Daniel Nolan (https://twitter.com/dnlnln)

SET NOCOUNT ON

SET IDENTITY_INSERT [States] ON

MERGE INTO [States] AS [Target]
USING (VALUES
 (1,N'Alabama')
,(2,N'Alaska')
,(3,N'Arizona')
,(4,N'Arkansas')
,(5,N'California')
,(6,N'Colorado')
,(7,N'Connecticut')
,(8,N'Delaware')
,(9,N'Florida')
,(10,N'Georgia')
,(11,N'Hawaii')
,(12,N'Idaho')
,(13,N'Illinois')
,(14,N'Indiana')
,(15,N'Iowa')
,(16,N'Kansas')
,(17,N'Kentucky')
,(18,N'Louisiana')
,(19,N'Maine')
,(20,N'Maryland')
,(21,N'Massachusetts')
,(22,N'Michigan')
,(23,N'Minnesota')
,(24,N'Mississippi')
,(25,N'Missouri')
,(26,N'Montana')
,(27,N'Nebraska')
,(28,N'Nevada')
,(29,N'NewHampshire')
,(30,N'NewJersey')
,(31,N'NewMexico')
,(32,N'NewYork')
,(33,N'NorthCarolina')
,(34,N'NorthDakota')
,(35,N'Ohio')
,(36,N'Oklahoma')
,(37,N'Oregon')
,(38,N'Pennsylvania')
,(39,N'RhodeIsland')
,(40,N'SouthCarolina')
,(41,N'SouthDakota')
,(42,N'Tennessee')
,(43,N'Texas')
,(44,N'Utah')
,(45,N'Vermont')
,(46,N'Virginia')
,(47,N'Washington')
,(48,N'WestVirginia')
,(49,N'Wisconsin')
,(50,N'Wyoming')
) AS [Source] ([Id],[Name])
ON ([Target].[Id] = [Source].[Id])
WHEN MATCHED AND (
	NULLIF([Source].[Name], [Target].[Name]) IS NOT NULL OR NULLIF([Target].[Name], [Source].[Name]) IS NOT NULL) THEN
 UPDATE SET
  [Target].[Name] = [Source].[Name]
WHEN NOT MATCHED BY TARGET THEN
 INSERT([Id],[Name])
 VALUES([Source].[Id],[Source].[Name])
WHEN NOT MATCHED BY SOURCE THEN 
 DELETE;

DECLARE @mergeError int
 , @mergeCount int
SELECT @mergeError = @@ERROR, @mergeCount = @@ROWCOUNT
IF @mergeError != 0
 BEGIN
 PRINT 'ERROR OCCURRED IN MERGE FOR [States]. Rows affected: ' + CAST(@mergeCount AS VARCHAR(100)); -- SQL should always return zero rows affected
 END
ELSE
 BEGIN
 PRINT '[States] rows affected by MERGE: ' + CAST(@mergeCount AS VARCHAR(100));
 END
GO



SET IDENTITY_INSERT [States] OFF
SET NOCOUNT OFF
GO
