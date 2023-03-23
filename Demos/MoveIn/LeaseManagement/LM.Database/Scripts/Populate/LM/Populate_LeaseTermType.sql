MERGE LM.LeaseTermType AS TARGET
USING (VALUES (1, 'Anniversary'),
              (2, 'Annual'),
              (3, 'Daily'))
AS SOURCE (LeaseTermTypeId, LeaseTermTypeName)
ON TARGET.LeaseTermTypeId = SOURCE.LeaseTermTypeId
WHEN MATCHED THEN UPDATE SET TARGET.LeaseTermTypeName = SOURCE.LeaseTermTypeName
WHEN NOT MATCHED BY TARGET THEN INSERT (LeaseTermTypeId,
                                        LeaseTermTypeName)
                                VALUES (SOURCE.LeaseTermTypeId,
                                        SOURCE.LeaseTermTypeName)
WHEN NOT MATCHED BY SOURCE THEN DELETE;