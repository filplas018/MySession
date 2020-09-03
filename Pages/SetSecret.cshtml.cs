using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plass_sessionDemo.Services;

namespace Plass_sessionDemo.Pages
{
    public class SetSecretModel : PageModel
    {
        //localhost/SetSecret?handler=SetNumber&number=21
        private readonly SessionStorage _ss;
        public bool InSet { get; set; }
        public SetSecretModel( SessionStorage ss)
        {
            _ss = ss;
        }
        public void OnGet()
        {

        }
        public void OnGetSetNumber(int number)
        {
            _ss.SetSecretNumber(number);
            InSet = true;
        }
    }
}