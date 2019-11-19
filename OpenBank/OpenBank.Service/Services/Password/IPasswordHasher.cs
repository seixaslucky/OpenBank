namespace OpenBank.Service.Services.Password {
    public interface IPasswordHasher {
        string Hash (string password);
        (bool Verified, bool NeedsUpgrade) Check (string hash, string password);
    }
}