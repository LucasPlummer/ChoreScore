namespace ChoreScore.Services;
public class ChoresService
{

    private readonly ChoresRepository _repo;

    public ChoresService(ChoresRepository repo)
    {
        _repo = repo;
    }

    internal Chore Create(Chore choreData)
    {
        Chore newChore = _repo.Create(choreData);
        return newChore;
    }

    // internal Chore Create(Chore choreData)
    // {

    // }
    internal List<Chore> Get()
    {
        List<Chore> chores = _repo.Get();
        return chores;
    }

    internal string Remove(int id)
    {
        string message = _repo.Remove(id);
        return message;
    }
}
