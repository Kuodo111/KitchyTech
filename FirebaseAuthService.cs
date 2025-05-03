using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;

namespace KitchyTech.Services
{
    public class FirebaseAuthService
    {
        private const string ApiKey = "AIzaSyDPJUXD0CY2fdjwvqdnHbkw7VSqhlHqUQU";
        private readonly FirebaseAuthProvider authProvider;

        public FirebaseAuthService()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
        }

        public async Task<FirebaseAuthLink> SignUp(string email, string password, string displayName)
        {
            try
            {
                // Log input parameters
                Console.WriteLine($"SignUp called with Email: {email}, DisplayName: {displayName}");

                // Perform sign-up logic
                var authLink = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password, displayName, true);

                // Log success
                Console.WriteLine("SignUp successful.");
                return authLink;
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"SignUp failed: {ex.Message}");
                throw;
            }
        }

        public async Task<FirebaseAuthLink> SignIn(string email, string password)
        {
            return await authProvider.SignInWithEmailAndPasswordAsync(email, password);
        }

        public static async Task<string> GetFreshToken(FirebaseAuthLink authLink)
        {
            await authLink.GetFreshAuthAsync();
            return authLink.FirebaseToken;
        }
    }
}