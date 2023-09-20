using SinovadDemo.Application.DTO.SignUp;
using SinovadDemo.Domain.Enums;

namespace SinovadDemo.Application.Interface.Infrastructure
{
    public interface IFirebaseAuthService
    {
        Task<RegisterUserFromProviderDto> ValidateCredentials(string accessToken, LinkedAccountProvider LinkedAccountProviderCatalogDetailId);

    }
}
