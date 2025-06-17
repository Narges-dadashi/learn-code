using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces;

public interface IMemberRepository
{
    public Task<List<AppUser>?> GetAllAsync(CancellationToken CancellationToken);
}