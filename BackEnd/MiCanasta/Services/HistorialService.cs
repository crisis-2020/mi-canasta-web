using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services
{
    public interface HistorialService
    {
        HistorialCreateDto Create(HistorialCreateDto HistorialCreateDto);
    }
}
