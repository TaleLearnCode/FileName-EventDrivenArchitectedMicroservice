SET IDENTITY_INSERT LM.LeaseType ON
GO

MERGE LM.LeaseType AS TARGET
USING (VALUES (1, 2, '1 year, recurring'),
              (2, 2, '2 year, recurring'),
              (3, 2, '3 year, recurring'),
              (4, 1, '1 year, anniversary'),
              (5, 1, '18 month, anniversary'),
              (6, 1, '2 year, anniversary'),
              (7, 3, 'Daily'))
AS SOURCE (LeaseTypeId, LeaseTermTypeId, LeaseTypeName)
ON TARGET.LeaseTermTypeId = SOURCE.LeaseTermTypeId
WHEN MATCHED THEN UPDATE SET TARGET.LeaseTermTypeId = SOURCE.LeaseTermTypeId,
                             TARGET.LeaseTypeName   = SOURCE.LeaseTypeName
WHEN NOT MATCHED THEN INSERT (LeaseTypeId,
                              LeaseTermTypeId,
                              LeaseTypeName)
                      VALUES (SOURCE.LeaseTypeId,
                              SOURCE.LeaseTermTypeId,
                              SOURCE.LeaseTypeName);
GO

SET IDENTITY_INSERT LM.LeaseType OFF
GO