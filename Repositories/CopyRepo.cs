using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiblioHon.Models;
using Microsoft.EntityFrameworkCore;

namespace BiblioHon.Repositories;

public class CopyRepo(BibliohonDbContext context)
{
    public async Task<Copy> SaveCopyAsync(Copy copy)
    {
        context.Copies.Add(copy);
        await context.SaveChangesAsync();
        return copy;
    }

    public Task<List<Copy>> ListAllCopiesAsync() =>
        context.Copies.AsNoTracking().OrderBy(copy => copy.Id).ToListAsync();

    public async Task<bool> UpdateAsync(Copy copy)
    {
        if (!await context.Copies.AnyAsync(existing => existing.Id == copy.Id))
        {
            Console.WriteLine("None copy to update");
            return false;
        }

        context.Copies.Update(copy);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(long? id)
    {
        var copy = await context.Copies.FindAsync(id);
        if (copy is null)
            return false;

        context.Copies.Remove(copy);
        await context.SaveChangesAsync();
        return true;
    }

}
