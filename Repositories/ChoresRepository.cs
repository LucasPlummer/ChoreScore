namespace ChoreScore.Repositories;



public class ChoresRepository
{

    private readonly IDbConnection _db;

    public ChoresRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Chore Create(Chore choreData)
    {
        string sql = @"
        INSERT INTO chores
        (name, difficulty, location, creatorId)
        VALUES
        (@name, @difficulty, @location, @creatorId);
        SELECT LAST_INSERT_ID();
        ";
        int id = _db.ExecuteScalar<int>(sql, choreData);
        choreData.Id = id;
        return choreData;
    }
    internal List<Chore> Get()
    {
        string sql = @"
        SELECT
        ch.*,
        ac.*
        FROM chores ch
        JOIN accounts ac ON ac.id = ch.creatorId;
        ";
        List<Chore> chores = _db.Query<Chore, Account, Chore>
        (sql, (chore, account) =>
        {
            chore.Creator = account;
            return chore;
        }
        ).ToList();

        return chores;
    }

    internal Chore GetOne(int id)
    {
        string sql = @"
        SELECT
        ch.*,
        ac.* 
        FROM chores ch 
        JOIN accounts ac ON ac.id = ch.creatorId 
        WHERE ch.id = @id;
        ";
        return _db.Query<Chore, Account, Chore>(sql, (chore, account) =>
        {
            chore.Creator = account;
            return chore;
        }, new { id }).FirstOrDefault();
    }

    internal void Remove(int id)
    {
        string sql = @"
        DELETE FROM chores
        WHERE id = @id;
        ";
        _db.Execute(sql, new { id });
    }
}
