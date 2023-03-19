CREATE TABLE CM.CareTaskResident
(
	CareTaskResidentId INT NOT NULL IDENTITY(1,1),
	CareTaskId         INT NOT NULL,
	ResidentId         INT NOT NULL,
	CONSTRAINT pkcCareTaskResident PRIMARY KEY CLUSTERED (CareTaskResidentId),
	CONSTRAINT fkCareTaskResident_CareTask FOREIGN KEY (CareTaskId) REFERENCES CM.CareTask (CareTaskId),
	CONSTRAINT fkCareTaskResident_ResidentId FOREIGN KEY (ResidentId) REFERENCES RM.Resident (ResidentId)
)