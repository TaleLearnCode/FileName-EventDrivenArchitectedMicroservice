CREATE TABLE PM.Room
(
	RoomId               INT           NOT NULL IDENTITY(1,1),
	CommunityId          INT           NOT NULL,
	RoomNumber           NVARCHAR(100) NOT NULL,
	CONSTRAINT pkcRoom PRIMARY KEY CLUSTERED (RoomId),
	CONSTRAINT fkRoom_Community FOREIGN KEY (CommunityId) REFERENCES PM.Community (CommunityId),
)
GO

CREATE NONCLUSTERED INDEX idxRoom_CommunityId
ON PM.Room (CommunityId)
GO

EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Room',                                           @value=N'Represents a room within a community.',                                                                                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Room', @level2name=N'RoomId',                    @value=N'Identifier of the room record.',                                                                                             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Room', @level2name=N'CommunityId',               @value=N'Identifier of the associated community record.',                                                                             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Room', @level2name=N'RoomNumber',                @value=N'The number of the room.',                                                                                                    @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Room', @level2name=N'pkcRoom',                   @value=N'Defines the primary key for the Room table using the RoomId column.',                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Room', @level2name=N'fkRoom_Community',          @value=N'Defines the relationship between the Room and Community tables.',                                                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO