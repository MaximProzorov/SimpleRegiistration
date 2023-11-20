using Microsoft.EntityFrameworkCore;
using SimpleRegistration.Api.Models;

namespace SimpleRegistration.Api.Repository;
public interface IUserRepository
{
    Task<int> AddUser(User user);
    Task<User> GetUser(string login);
    Task<int> UpdateUser(Guid userId, UpdateModel model);
}
public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<int> AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        return await _context.SaveChangesAsync();
    }

    public async Task<User> GetUser(string login)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
    }

    public async Task<int> UpdateUser(Guid userId, UpdateModel model)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        if (user is not null)
        {
            user.ProvinceId = model.ProvinceId;
            return await _context.SaveChangesAsync();
        }

        return 0;
    }
}
