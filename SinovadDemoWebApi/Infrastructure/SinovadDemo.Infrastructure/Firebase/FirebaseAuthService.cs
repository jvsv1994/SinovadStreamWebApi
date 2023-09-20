using Firebase.Auth;
using Firebase.Auth.Providers;
using SinovadDemo.Application.DTO.User;
using SinovadDemo.Application.Interface.Infrastructure;
using SinovadDemo.Domain.Enums;

namespace SinovadDemo.Infrastructure.Firebase
{
    public class FirebaseAuthService : IFirebaseAuthService
    {
        private readonly FirebaseAuthClient _firebaseAuth;
        public FirebaseAuthService(FirebaseAuthClient firebaseAuth)
        {
            _firebaseAuth = firebaseAuth;
        }

        public async Task<RegisterUserFromProviderDto> ValidateCredentials(string accessToken, LinkedAccountProvider LinkedAccountProviderCatalogDetailId)
        {
           if(LinkedAccountProviderCatalogDetailId== LinkedAccountProvider.Google)
           {
                var registerUserFromProviderDto= await ValidateGoogleCredentials(accessToken);
                registerUserFromProviderDto.AccessToken= accessToken;
                registerUserFromProviderDto.LinkedAccountProviderCatalogDetailId= LinkedAccountProviderCatalogDetailId;
                return registerUserFromProviderDto;
           }
           return null;
        }

        private async Task<RegisterUserFromProviderDto> ValidateGoogleCredentials(string accessToken)
        {
            var credential = GoogleProvider.GetCredential(accessToken);
            var res = await _firebaseAuth.SignInWithCredentialAsync(credential);
            if (res.User != null && res.User.Info != null)
            {
                var userInfo = res.User.Info;
                var registerUserFromProviderDto = new RegisterUserFromProviderDto();
                registerUserFromProviderDto.Email = userInfo.Email;
                registerUserFromProviderDto.FirstName = userInfo.FirstName;
                registerUserFromProviderDto.LastName = userInfo.LastName;
                return registerUserFromProviderDto;
            }
            return null;
        }

    }
}
