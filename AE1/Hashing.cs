using Isopoh.Cryptography.Argon2;


namespace hash{
    public static class Hash
    {
        //Argon2id hash
        public static string HashPassword(string password) => Argon2.Hash(password);
        public static bool VerifyPassword(string hash, string password) => Argon2.Verify(hash, password);
    }
}