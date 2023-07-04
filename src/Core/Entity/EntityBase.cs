namespace Core.Entity;

public abstract class EntityBase<TId>
{
    protected EntityBase(TId id)
    {
        Id = id;
    }

    public  TId Id { get; } 
    
   
    





}