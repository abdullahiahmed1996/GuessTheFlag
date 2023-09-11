using GuessTheFlag.Shared.Models;
using System;
using Microsoft.EntityFrameworkCore;


public class NicknameService : INicknameService
{
    private readonly AppDbContext _context;

    public NicknameService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveNicknameAsync(string nickname)
    {
        var model = new UserModel { Username = nickname };
        _context.Nicknames.Add(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }
}
