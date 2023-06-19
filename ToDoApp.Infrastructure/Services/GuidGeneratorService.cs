using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Commons.Interfaces;

namespace ToDoApp.Infrastructure.Services
{
    public class GuidGeneratorService : IGuidGenerator
    {
        public Guid Guid => Guid.NewGuid();
    }
}
