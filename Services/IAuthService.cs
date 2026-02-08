using SecureApiWithJwt.Models;

namespace SecureApiWithJwt.Services;

public interface IAuthService
{
    Task<AuthModel> Register(RegisterModel model);

}
