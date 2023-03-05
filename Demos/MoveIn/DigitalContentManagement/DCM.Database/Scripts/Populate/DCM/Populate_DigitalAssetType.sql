MERGE DCM.DigitalAssetType AS TARGET
USING (VALUES (1, 1, 1, 'image',    'Image'),
              (2, 2, 1, 'document', 'Document'),
              (3, 3, 1, 'video',    'Video'))
AS SOURCE (DigitalAssetTypeId,
           SortOrder,
           RowStatusId,
           Discriminator,
           DigitalAssetTypeName)
ON TARGET.DigitalAssetTypeId = SOURCE.DigitalAssetTypeId
WHEN MATCHED THEN UPDATE SET TARGET.DigitalAssetTypeName = SOURCE.DigitalAssetTypeName,
                             TARGET.Discriminator        = SOURCE.Discriminator,
                             TARGET.SortOrder            = SOURCE.SortOrder,
                             TARGET.RowStatusId          = SOURCE.RowStatusId
WHEN NOT MATCHED THEN INSERT (DigitalAssetTypeId,
                              DigitalAssetTypeName,
                              Discriminator,
                              SortOrder,
                              RowStatusId)
                      VALUES (SOURCE.DigitalAssetTypeId,
                              SOURCE.DigitalAssetTypeName,
                              SOURCE.Discriminator,
                              SOURCE.SortOrder,
                              SOURCE.RowStatusId);