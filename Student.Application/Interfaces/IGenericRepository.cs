using System;


namespace Student.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<string> CreateAsync(T student);

        //void Add(T student);
        Task<string> UpdateAsync(T student, int id);
        //Task<string> DeleteAsync(T student);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetbyIdAsync(int id);

    }
}
