MERGE RM.ResidentPostalAddressType AS TARGET
USING (VALUES (1, 1, 1, 1, 'Primary'),
              (2, 1, 2, 0, 'Secondary'))
AS SOURCE (PostalAddressTypeId,
           RowStatusId,
           SortOrder,
           IsDefault,
       PostalAddressTypeName)
ON TARGET.PostalAddressTypeId = SOURCE.PostalAddressTypeId
WHEN MATCHED THEN UPDATE SET TARGET.PostalAddressTypeName = SOURCE.PostalAddressTypeName,
                             TARGET.IsDefault             = SOURCE.IsDefault,
                             TARGET.SortOrder             = SOURCE.SortOrder,
                             TARGET.RowStatusId           = SOURCE.RowStatusId
WHEN NOT MATCHED THEN INSERT (PostalAddressTypeId,
                              PostalAddressTypeName,
                              IsDefault,
                              SortOrder,
                              RowStatusId)
                      VALUES (SOURCE.PostalAddressTypeId,
                              SOURCE.PostalAddressTypeName,
                              SOURCE.IsDefault,
                              SOURCE.SortOrder,
                              SOURCE.RowStatusId);
GO