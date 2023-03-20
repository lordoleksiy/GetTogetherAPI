namespace GetTogether.DAL.Entities;

public interface IEntity<T>
{
    public T Id { get; set; }
}
