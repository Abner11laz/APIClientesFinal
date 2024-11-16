using System;
using System.Collections.Generic;

namespace APIClientesFinal.Models;

public partial class Informaciongeneral
{
    public int Id { get; set; }

    public int? Clienteid { get; set; }

    public string Tipoinformacion { get; set; } = null!;

    public DateTime? Fechacreacion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public string? Usuariocreador { get; set; }

    public string? Estadoinformacion { get; set; }

    public virtual Cliente? Cliente { get; set; }
}
