using SecureApiWithJwt.Models;

namespace SecureApiWithJwt.Services;

public interface IAuthService
{
    Task<AuthModel> RegisterAsync(RegisterModel model);

}
