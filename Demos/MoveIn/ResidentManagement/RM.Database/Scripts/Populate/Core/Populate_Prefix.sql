MERGE Core.Prefix AS TARGET
USING (VALUES ( 1, 1,  10, 'Capt'),
              ( 2, 1,  30, 'Col'),
              ( 3, 1,  50, 'Dr.'),
              ( 4, 1,  60, 'Fr.'),
              ( 5, 1,  70, 'Hon.'),
              ( 6, 1,  90, 'Miss'),
              ( 7, 1, 100, 'Mr.'),
              ( 8, 1, 110, 'Mrs.'),
              ( 9, 1, 120, 'Ms.'),
              (10, 1, 130, 'Pastor'),
              (11, 1, 140, 'Prof.'),
              (12, 1, 150, 'Rabbi'),
              (13, 1, 160, 'Rev.'),
              (14, 1, 170, 'Sgt'),
              (15, 1, 180, 'Sr.'),
              (16, 1,  80, 'Major'),
              (17, 1,  40, 'Deacon'))
AS SOURCE (PrefixId,
           RowStatusId,
           SortOrder,
           PrefixValue)
ON TARGET.PrefixId = SOURCE.PrefixId
WHEN MATCHED THEN UPDATE SET TARGET.PrefixValue = SOURCE.PrefixValue,
                             TARGET.SortOrder   = SOURCE.SortOrder,
                             TARGET.RowStatusId = SOURCE.RowStatusId
WHEN NOT MATCHED THEN INSERT (PrefixId,
                              PrefixValue,
                              SortOrder,
                              RowStatusId)
                      VALUES (SOURCE.PrefixId,
                              SOURCE.PrefixValue,
                              SOURCE.SortOrder,
                              SOURCE.RowStatusId)
WHEN NOT MATCHED BY SOURCE THEN DELETE;