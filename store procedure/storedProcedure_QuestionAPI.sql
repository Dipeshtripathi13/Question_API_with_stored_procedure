CREATE TABLE Question_Entity (
    Id INT identity PRIMARY KEY,
    Question NVARCHAR(300) NOT NULL,
    Option1 NVARCHAR(255) NOT NULL,
    Option2 NVARCHAR(255) NOT NULL,
    Option3 NVARCHAR(255) NOT NULL,
    Option4 NVARCHAR(255) NOT NULL,
    Answer NVARCHAR(255) NOT NULL
)




CREATE PROC ManageQuestionEntity
    @Id INT = NULL,
    @Question NVARCHAR(300) = NULL,
    @Option1 NVARCHAR(255) = NULL,
    @Option2 NVARCHAR(255) = NULL,
    @Option3 NVARCHAR(255) = NULL,
    @Option4 NVARCHAR(255) = NULL,
    @Answer NVARCHAR(255) = NULL,
    @Action NVARCHAR(10)
AS
BEGIN
    IF @Action = 'get'
    BEGIN
        SELECT * FROM Question_Entity order by Id desc
    END
	Else if @Action = 'getid'
	begin
	select * from Question_Entity where Id=@Id
	end
    ELSE IF @Action = 'insert'
    BEGIN
        INSERT INTO Question_Entity (Question, Option1, Option2, Option3, Option4, Answer)
        VALUES (@Question, @Option1, @Option2, @Option3, @Option4, @Answer)
    END
    ELSE IF @Action = 'update'
    BEGIN
        UPDATE Question_Entity
        SET Question = @Question,
            Option1 = @Option1,
            Option2 = @Option2,
            Option3 = @Option3,
            Option4 = @Option4,
            Answer = @Answer
        WHERE Id = @Id
    END
    ELSE IF @Action = 'delete'
    BEGIN
        DELETE FROM Question_Entity WHERE Id = @Id
    END
END

select * from Question_Entity



