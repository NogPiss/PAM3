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
<<<<<<< HEAD
            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt)){
                var comutedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < comutedHash.Length; i++){
                    if (comutedHash[i] != hash[i]){
=======
            using(var hmac = new System.Security.Cryptography.HMACSHA512(salt)){
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++){
                    if (computedHash[i] != hash[i]){
>>>>>>> 5c5b0177ccc0c60ad2b4b363305aa6f1a3fe5b3f
                        return false;
                    }
                }
                return true;
            }
        }
<<<<<<< HEAD

=======
>>>>>>> 5c5b0177ccc0c60ad2b4b363305aa6f1a3fe5b3f
    }
}