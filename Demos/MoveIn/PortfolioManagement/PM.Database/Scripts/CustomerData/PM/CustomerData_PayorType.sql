SET IDENTITY_INSERT PM.PayorType ON
GO

MERGE PM.PayorType AS TARGET
USING (VALUES (2, 100, 1, 1, 'Singular Private Pay'),
              (3, 200, 1, 0, 'Semi-Private Pay'),
              (4, 300, 1, 0, 'Second Person Fee'))
AS SOURCE (PayorTypeId,
           SortOrder,
           RowStatusId,
           IsDefault,
           PayorTypeName)
ON TARGET.PayorTypeId = SOURCE.PayorTypeId
WHEN MATCHED THEN UPDATE SET TARGET.PayorTypeName = SOURCE.PayorTypeName,
                             TARGET.SortOrder     = SOURCE.SortOrder,
                             TARGET.IsDefault     = SOURCE.IsDefault,
                             TARGET.RowStatusId   = SOURCE.RowStatusId
WHEN NOT MATCHED THEN INSERT (PayorTypeId,
                              PayorTypeName,
                              IsDefault,
                              SortOrder,
                              RowStatusId)
                      VALUES (SOURCE.PayorTypeId,
                              SOURCE.PayorTypeName,
                              SOURCE.IsDefault,
                              SOURCE.SortOrder,
                              SOURCE.RowStatusId);
GO

SET IDENTITY_INSERT PM.PayorType OFF
GO