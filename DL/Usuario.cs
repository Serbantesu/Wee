﻿using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public byte[]? Password { get; set; }

    public string? Telefono { get; set; }

    public string? Empresa { get; set; }
}
