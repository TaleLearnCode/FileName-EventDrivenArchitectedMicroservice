SET IDENTITY_INSERT PM.AncillaryCareCategory ON
GO

MERGE PM.AncillaryCareCategory AS TARGET
USING (VALUES ( 1, 'Medication Management',        'MED'),
              ( 2, 'Incontinence Management',      'INC'),
              ( 5, 'Private Duty Management',      'PRIV'),
              ( 6, 'Companion Care Management',    'COMP'),
              ( 7, 'Enhanced Supportive Services', 'ENH'),
              ( 8, 'Diabetic Management',          'DIAB'),
              ( 9, 'Discreet Supplies',            'DISC'),
              (10, 'Mechanical Lifts',             'LIFT'),
              (11, 'Nursing Services',             NULL),
              (12, 'Non-Approved Packaging',       NULL),
              (13, 'Medication Management (SAMM)', NULL),
              (14, 'Continence Supplies',          'CON'))
AS SOURCE (AncillaryCareCategoryId,
           AncillaryCareCategoryName,
           AncillaryCareCategoryCode)
ON TARGET.AncillaryCareCategoryId = SOURCE.AncillaryCareCategoryId
WHEN MATCHED THEN UPDATE SET TARGET.AncillaryCareCategoryName = SOURCE.AncillaryCareCategoryName,
                             TARGET.AncillaryCareCategoryCode = SOURCE.AncillaryCareCategoryCode
WHEN NOT MATCHED THEN INSERT (AncillaryCareCategoryId,
                              AncillaryCareCategoryName,
                              AncillaryCareCategoryCode)
                      VALUES (SOURCE.AncillaryCareCategoryId,
                              SOURCE.AncillaryCareCategoryName,
                              SOURCE.AncillaryCareCategoryCode);

SET IDENTITY_INSERT PM.AncillaryCareCategory OFF
GO