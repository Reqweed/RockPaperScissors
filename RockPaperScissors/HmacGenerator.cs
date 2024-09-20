using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissors;

public class HmacGenerator
{
    public string Key { get; } = GenerateKey();
    
    public string GenerateHmac(string message)
    {
        var messageBytes = Encoding.UTF8.GetBytes(message);
        var keyBytes = Encoding.UTF8.GetBytes(Key);
        
        using var hmac = new HMACSHA256(keyBytes);
        var hash = hmac.ComputeHash(messageBytes);
        return BitConverter.ToString(hash).Replace("-", "");
    }
    
    private static string GenerateKey()
    {
        var key = new byte[32]; 
        RandomNumberGenerator.Fill(key);
        return BitConverter.ToString(key).Replace("-", "");;
    }
}