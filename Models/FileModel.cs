using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EDDll_L1_AFPE_DAVH
{
    public class FileModel
    {        
        public IFormFile File { get; set; }
    }
}