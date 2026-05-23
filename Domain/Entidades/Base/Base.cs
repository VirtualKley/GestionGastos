namespace Domain.Entidades.Base;

public abstract class BaseEntity
{
    public bool Activo {get; set;} = true;
    public DateTime FechaCreacion {get; set;} = DateTime.UtcNow;
    public DateTime? FechaEliminacion {get; set;} = null;
}