MERGE RM.Relation AS TARGET
USING (VALUES (1, 1, 1, 'Self'),
              (2, 2, 1, 'Spouse'),
              (3, 3, 1, 'Child'),
              (4, 4, 1, 'Guardian'),
              (5, 5, 1, 'Other — Related'),
              (6, 6, 1, 'Other — Not Related'))
AS SOURCE (RelationId,
           SortOrder,
           RowStatusId,
           RelationName)
ON TARGET.RelationId = SOURCE.RelationId
WHEN MATCHED THEN UPDATE SET TARGET.RelationName = SOURCE.RelationName,
                             TARGET.SortOrder    = SOURCE.SortOrder,
                             TARGET.RowStatusId  = SOURCE.RowStatusId
WHEN NOT MATCHED THEN INSERT (RelationId,
                              RelationName,
                              SortOrder,
                              RowStatusId)
                      VALUES (SOURCE.RelationId,
                              SOURCE.RelationName,
                              SOURCE.SortOrder,
                              SOURCE.RowStatusId)
WHEN NOT MATCHED BY SOURCE THEN DELETE;