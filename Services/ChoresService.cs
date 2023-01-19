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
        Chore chore = _repo.Create(choreData);
        return chore;
    }

    internal List<Chore> Get(string userId)
    {
        List<Chore> chores = _repo.Get();
        return chores;
    }

    internal Chore GetOne(int id, string userId)
    {
        Chore chore = _repo.GetOne(id);
        if (chore == null)
        {
            throw new Exception("No chore at that id!");
        }
        if (chore.CreatorId != userId)
        {
            throw new Exception("hey! Not yours! The ID does not match!");
        }
        return chore;
    }



    internal string Remove(int id, string userId)
    {
        Chore original = GetOne(id, userId);
        if (original.CreatorId != userId)
        {
            throw new Exception("Yo. Not yours buddy.");
        }
        //NOTE CHECK postItSharp if you'd like to see a soft delete!!
        _repo.Remove(id);
        return $"{original.Name} has turned to DUST.";
    }
}
