﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace shareWithLove.Models.Response
{
    public class UsuarioResponse
    {
        public string Id { get; set; } = null!;
        public string Rol { get; set; } = string.Empty;
        public string Username { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string? Token { get; set; }

    }
}
