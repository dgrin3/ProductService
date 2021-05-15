using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Exception, wenn eine Entität nicht gefunden ist
        /// </summary>
        /// <param name="entityName">Entität</param>
        /// <param name="searchCondition">Suchkriterien</param>
        /// <param name="innerException">Inner exception, weiterzuleiten</param>
        public NotFoundException(string entityName, string searchCondition, Exception innerException = null)
            : base($"{entityName} nicht gefunden. Suchkriterien: {searchCondition}", innerException)
        {
        }
    }
}
