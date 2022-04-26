using System;
using System.Collections.Generic;

#nullable disable

namespace CK.DataAccess.Models
{
    public partial class CkPerfil
    {
        public CkPerfil()
        {
            CkUsers = new HashSet<CkUser>();
        }

        public string Codperf { get; set; }
        public string Dscperf { get; set; }
        public string Usrcre { get; set; }
        public string Wkscre { get; set; }
        public DateTime Fchcre { get; set; }
        public string Usrmod { get; set; }
        public string Wksmod { get; set; }
        public DateTime? Fchmod { get; set; }
        public string Flgeli { get; set; }

        public virtual ICollection<CkUser> CkUsers { get; set; }
    }
}
