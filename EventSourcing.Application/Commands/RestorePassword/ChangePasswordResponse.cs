﻿namespace EventSourcing.Application.Commands.RestorePassword
{
    public class ChangePasswordResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
