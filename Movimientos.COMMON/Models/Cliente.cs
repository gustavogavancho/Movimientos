﻿namespace Movimientos.COMMON.Models;

public class Cliente : Persona
{
    public string Contraseña { get; set; }
    public bool Estado { get; set; }
}