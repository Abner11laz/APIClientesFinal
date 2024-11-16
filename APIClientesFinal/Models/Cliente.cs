using System;
using System.Collections.Generic;

namespace APIClientesFinal.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Genero { get; set; }

    public DateOnly? Fechanacimiento { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Informaciongeneral> Informaciongenerals { get; } = new List<Informaciongeneral>();
}
