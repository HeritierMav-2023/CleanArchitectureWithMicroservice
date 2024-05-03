

namespace Book.Domain.Entities
{
    /// <summary>
    /// Books Class Entités représentent les objets métier de l'application
    /// </summary>
    public class Books: BaseAuditableEntity
    {
        public string Title { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;
        public int NoOfPage { get; set; } = 0;
        public string Faculty { get; set; } = string.Empty;
        public double Prix { get; set; }
    }
}
