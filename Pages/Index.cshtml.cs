using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Plass_sessionDemo.Services;
namespace Plass_sessionDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SessionStorage _ss;
        public Random rnd;
        public int rand;
        [BindProperty]
        public int Min { get; set; }
        [BindProperty]
        public int Max { get; set; }
        public int SecretNumber { get; set; }
        public bool isSetSecret { get; set; }
        public IndexModel(SessionStorage ss)
        {
            _ss = ss;
        }

        public void OnGet()
        {

            
            SecretNumber = _ss.GetSecretNumber();
            isSetSecret = _ss.IsSetSecret;
        }
        public void OnPost()
        {
            rand = _ss.SetMinMax(Min, Max);
            SecretNumber = rand;
           
        }
    }
}
