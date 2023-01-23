namespace Core.Persistance.Repositories;

public class Entity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public int Model { get; set; }

    public Entity()
    {
    }

    public Entity(int id, string name, string color, int model) : this()
    {
        Id = id;
        Name = name;
        Color = color;
        Model = model;

    }
}