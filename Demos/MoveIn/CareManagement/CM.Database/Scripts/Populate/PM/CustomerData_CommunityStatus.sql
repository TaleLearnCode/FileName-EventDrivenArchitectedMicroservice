MERGE PM.CommunityStatus AS TARGET
USING (VALUES (1, '3', 30, 1, 'Closed'),
              (2, '2', 20, 1, 'Open'),
              (3, '1', 10, 1, 'Pending'))
AS SOURCE (CommunityStatusId,
           ExternalId,
           SortOrder,
           RowStatusId,
           CommunityStatusName)
ON TARGET.CommunityStatusId = SOURCE.CommunityStatusId
WHEN MATCHED THEN UPDATE SET TARGET.CommunityStatusName = SOURCE.CommunityStatusName,
                             TARGET.SortOrder    = SOURCE.SortOrder,
                             TARGET.RowStatusId  = SOURCE.RowStatusId
WHEN NOT MATCHED THEN INSERT (CommunityStatusId,
                              CommunityStatusName,
                              SortOrder,
                              RowStatusId)
                      VALUES (SOURCE.CommunityStatusId,
                              SOURCE.CommunityStatusName,
                              SOURCE.SortOrder,
                              SOURCE.RowStatusId);
GO