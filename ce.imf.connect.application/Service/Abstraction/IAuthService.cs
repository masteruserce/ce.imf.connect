using ce.imf.connect.comon.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IAuthService
    {
        public Task<ImfResponse<AuthResponse>> AuthenticateAsync(AuthRequest request);
    }
}
