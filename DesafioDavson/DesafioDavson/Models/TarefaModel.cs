﻿using DesafioDavson.Enums;

namespace DesafioDavson.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
    }
}
