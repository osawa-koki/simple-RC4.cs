using System.Security.Cryptography;

namespace simple_rc4_cs
{
  public class RC4Tests
  {
    private string GenerateRandomString(int length)
    {
      const string charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      return new string(Enumerable.Range(0, length).Select(i => charset[RandomNumberGenerator.GetInt32(charset.Length)]).ToArray());
    }

    [Fact]
    public void ShouldEncryptAndDecryptMessageWithTheSameKey()
    {
      for (int i = 0; i < 100; i++)
      {
        string message = GenerateRandomString(20);
        string key = GenerateRandomString(10);
        string encryptedMessage = RC4.Encrypt(message, key);
        string decryptedMessage = RC4.Decrypt(encryptedMessage, key);

        Assert.Equal(message, decryptedMessage);
      }
    }

    [Fact]
    public void ShouldNotDecryptMessageWithDifferentKey()
    {
      for (int i = 0; i < 100; i++)
      {
        string message = GenerateRandomString(20);
        string key = GenerateRandomString(10);
        string encryptedMessage = RC4.Encrypt(message, key);
        string differentKey = GenerateRandomString(10);
        if (differentKey == key)
        {
          continue;
        }
        string decryptedMessage = RC4.Decrypt(encryptedMessage, differentKey);

        Assert.NotEqual(message, decryptedMessage);
      }
    }
  }

}
