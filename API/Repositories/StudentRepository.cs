using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentAdminDbContext _context;
        public StudentRepository(StudentAdminDbContext context)
        {
            this._context = context;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> DeleteAsync(Guid id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
                return null;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.Include("Address").Include("Gender").ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _context.Students.Include("Address").Include("Gender").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student?> UpdateAsync(Guid id, Student student)
        {
            var item = await _context.Students.Include("Address").Include("Gender").FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return null;
            item.FirstName = student.FirstName;
            item.LastName = student.LastName;
            item.Address = student.Address;
            item.Gender = student.Gender;
            item.Email = student.Email;
            item.Phone = student.Phone;
            item.DateOfBirth = student.DateOfBirth;
            item.ProfileImageUrl = student.ProfileImageUrl;
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
