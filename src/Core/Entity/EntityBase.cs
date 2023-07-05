namespace Core.Entity;

/// <summary>
/// Base class for all entities
/// </summary>
/// <typeparam name="TId"></typeparam>
public abstract class EntityBase<TId>
{
    protected EntityBase(TId id)
    {
        Id = id;
    }

    public  TId Id { get; } 
    
   
    





}