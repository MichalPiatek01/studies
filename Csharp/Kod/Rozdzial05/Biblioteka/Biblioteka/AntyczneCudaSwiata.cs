using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS7
{
    [System.Flags]
    public enum AntyczneCudaSwiata : byte
    {
        Brak = 0,
        PiramidaCheopsa = 1,
        WiszaceOgrodyBabilonu = 1 << 1, // lub 2
        PosagZeusaWOlimpii = 1 << 2, // lub 4
        SwiatyniaArtemidyWEfezie = 1 << 3, // lub 8
        MauzoleumWHalikarnasie = 1 << 4, // lub 16
        KolosRodyjski = 1 << 5, // lub 32
        LatarniaMorskaNaFaros = 1 << 6 // lub 64
    }
}
