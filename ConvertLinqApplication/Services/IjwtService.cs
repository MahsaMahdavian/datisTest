using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertLinqApplication.Services
{
    public interface IjwtService
    {
         Task<string> GenerateToken();
    }
}
