using System;
using System.Collections.Generic;

#nullable disable

namespace CK.DataAccess.Models
{
    public partial class CkUser
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Usrcre { get; set; }
        public string Wkscre { get; set; }
        public DateTime? Fchcre { get; set; }
        public string Usrmod { get; set; }
        public string Wksmod { get; set; }
        public DateTime? Fchmod { get; set; }
        public string Flgeli { get; set; }
        public string Codperf { get; set; }
        public string Nombres { get; set; }
        public string Observacion { get; set; }
        public string Clave { get; set; }
        public string Flgval { get; set; }
        public string Iso1 { get; set; }
        public string Iso2 { get; set; }
        public decimal? CodEmpresa { get; set; }
        public decimal? CodFuncionario { get; set; }
        public string Flgiso { get; set; }
        public string Appversion { get; set; }
        public DateTime? FecAcceso { get; set; }
        public int? ClaveAlt { get; set; }
        public int? SessionNumber { get; set; }
        public int? ClaveApp { get; set; }

        public virtual CkPerfil CodperfNavigation { get; set; }
    }
}
