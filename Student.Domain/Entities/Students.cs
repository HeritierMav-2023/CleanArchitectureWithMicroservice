using System;


namespace Student.Domain.Entities
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        //public string Addresse { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string Faculty { get; set; } = string.Empty;
        
    }
}
