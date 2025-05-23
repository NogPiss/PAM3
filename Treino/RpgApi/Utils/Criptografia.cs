using System.Security.Cryptography;

namespace RpgApi.Utils
{
    public class Criptografia
    {
        public static void CriarPasswordHash(string password, out byte[] hash, out byte[] salt){
            using (var hmac = new System.Security.Cryptography.HMACSHA512()){
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerificaPasswordHash(string password, byte[] hash, byte[] salt){
            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt)){
                var comutedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < comutedHash.Length; i++){
                    if (comutedHash[i] != hash[i]){
                        return false;
                    }
                }
                return true;
            }
        }
    }
}