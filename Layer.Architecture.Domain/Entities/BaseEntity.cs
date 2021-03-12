namespace Layer.Architecture.Domain.Entities
{
    /// <summary>
    /// Conterá propriedades base que servirão para demais classes do nosso domínio.
    /// </summary>
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
    }
}
