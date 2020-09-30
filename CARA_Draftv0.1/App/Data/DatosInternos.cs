using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CARA_Draftv0._1.App.Data
{
    public class DatosInternos
    {
        public int PK_Paciente;
        public int FK_Centro;
        public string NB_Centro;
        public DateTime FE_Nacimiento;
        public int FK_GrupoEtnico;
        public string DE_GrupoEtnico;
        public string NR_Expediente;
        public int FK_Genero;
        public string DE_Genero;

    }

    public enum frmAccion { Crear = 0, Leer = 1, Actualizar = 2, Eliminar = 3 };

    public enum frmCentro { Crear = 0, Leer = 1};
}