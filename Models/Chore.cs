namespace ChoreScore.Models;


public class Chore
{
    public Chore(int id, string name, int difficulty, string location)
    {
        Id = id;
        Name = name;
        Difficulty = difficulty;
        Location = location;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Difficulty { get; set; }
    public string Location { get; set; }
}
