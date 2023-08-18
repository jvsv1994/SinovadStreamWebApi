using Firebase.Auth;
using Firebase.Auth.Providers;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Infrastructure;

namespace SinovadDemo.Infrastructure.Firebase
{
    public class FirebaseAuthService : IFirebaseAuthService
    {
        private readonly FirebaseAuthClient _firebaseAuth;
        public FirebaseAuthService(FirebaseAuthClient firebaseAuth)
        {
            _firebaseAuth = firebaseAuth;
        }

        public async Task<UserDto> ValidateGoogleCredentials(string accessToken)
        {
            var credential = GoogleProvider.GetCredential(accessToken);
            var res= await _firebaseAuth.SignInWithCredentialAsync(credential);
            if(res.User!=null && res.User.Info!=null)
            {
                var userInfo = res.User.Info;
                var userDto = new UserDto();
                userDto.Email = userInfo.Email;
                userDto.FirstName = userInfo.FirstName;
                userDto.LastName = userInfo.LastName;
                return userDto;
            }else
            {
                return null;
            }
        }

    }
}
