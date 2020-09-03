using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plass_sessionDemo.Services;

namespace Plass_sessionDemo.Services
{
    public class SessionStorage
    {
        readonly ISession _session;
        
        const string SECRETKEY = "TotoJeTajneCislo";

        private int _secretNumber;

        private int Minimum;
        private int Maximum;
        public bool IsSetSecret { get; }

        public SessionStorage(IHttpContextAccessor hca)
        {
            _session = hca.HttpContext.Session;

            int? cislo = _session.GetInt32(SECRETKEY);

            if (cislo != default)
            {
                _secretNumber = (int)cislo;
                IsSetSecret = true;
            }
            else IsSetSecret = false;
        }

        ///
        public void SetSecretNumber(int number)
        {
            _session.SetInt32(SECRETKEY, number);
            _secretNumber = number;
        }
        private void ClearSecretNumber()
        {
            _session.SetString(SECRETKEY, null);

        }
        public int GetSecretNumber()
        {
            return _secretNumber;
        }
        public int SetMinMax(int min, int max)
        {
            Minimum = min;
            Maximum = max;
            Random r = new Random();
            return r.Next(Minimum, Maximum);
            
        }
    }
}
