using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneradorArchivosRollos.Clases
{
    public class Utilitarios
    {
        /// <summary>
        /// Método que valida la existencia de datos duplicados en una lista de enteros.
        /// </summary>
        /// <param name="lst">Lista de enteros a validar.</param>
        /// <returns>Devuelve true si encuentra datos duplicados, o false en caso contrario.</returns>
        public static bool ValidateValuesDuplicates(List<int> lst)
        {
            var duplicates = lst.GroupBy(s => s)
                .SelectMany(grp => grp.Skip(1)).ToList();
            if (duplicates.Count != 0)
            {
                return true;
            }
            return false;
        }
    }
}
