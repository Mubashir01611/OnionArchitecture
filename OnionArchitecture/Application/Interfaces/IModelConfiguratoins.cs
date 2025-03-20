using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IModelConfiguratoins
    {
        void ConfigureModel(ModelBuilder modelBuilder);

    }
}
