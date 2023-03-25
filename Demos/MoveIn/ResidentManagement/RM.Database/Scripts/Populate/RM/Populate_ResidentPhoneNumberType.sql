MERGE RM.ResidentPhoneNumberType AS TARGET
USING (VALUES (1, 1, 1, 1, 'Primary'),
              (2, 1, 2, 0, 'Secondary'))
AS SOURCE (PhoneNumberTypeId,
           RowStatusId,
           SortOrder,
           IsDefault,
       PhoneNumberTypeName)
ON TARGET.PhoneNumberTypeId = SOURCE.PhoneNumberTypeId
WHEN MATCHED THEN UPDATE SET TARGET.PhoneNumberTypeName = SOURCE.PhoneNumberTypeName,
                             TARGET.IsDefault           = SOURCE.IsDefault,
                             TARGET.SortOrder           = SOURCE.SortOrder,
                             TARGET.RowStatusId         = SOURCE.RowStatusId
WHEN NOT MATCHED THEN INSERT (PhoneNumberTypeId,
                              PhoneNumberTypeName,
                              IsDefault,
                              SortOrder,
                              RowStatusId)
                      VALUES (SOURCE.PhoneNumberTypeId,
                              SOURCE.PhoneNumberTypeName,
                              SOURCE.IsDefault,
                              SOURCE.SortOrder,
                              SOURCE.RowStatusId);
GO