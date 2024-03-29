﻿#nullable enable

namespace CK.Services
{
    public class ResponseService<T>
    {
        public ResponseService()
        {
            Status = 200;
        }

        public T? Objeto { get; set; }
        public string? Error { get; set; }
        public int Status { get; set; }
        public bool Exito { get; set; }

        public void AgregarBadRequest(string mensaje)
        {
            Status = 400;
            Error = mensaje;
        }

        public void AgregarInternalServerError(string mensaje)
        {
            Status = 500;
            Error = mensaje;
        }
    }
}
