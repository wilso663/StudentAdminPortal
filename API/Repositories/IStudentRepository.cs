using API.Models.Domain;

namespace API.Repositories
{
    public interface IStudentRepository
    {
        public Task<List<Student>> GetAllAsync();
        public Task<Student?> GetByIdAsync(Guid id);
        public Task<Student> CreateAsync(Student student);
        public Task<Student?> UpdateAsync(Guid id, Student student);
        public Task<Student?> DeleteAsync(Guid id);
    }
}
