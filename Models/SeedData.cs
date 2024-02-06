using Microsoft.EntityFrameworkCore;
using scoreGr03.Data;

namespace scoreGr03.Models;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new scoreGr03Context(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<scoreGr03Context>>()))
        {
            
}

    }
}


