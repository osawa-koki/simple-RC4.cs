using System.Text;

namespace simple_rc4_cs
{
  public static class RC4
  {
    public static byte[] KSA(byte[] key)
    {
      byte[] S = Enumerable.Range(0, 256).Select(i => (byte)i).ToArray();
      byte j = 0;
      for (int i = 0; i < 256; i++)
      {
        j = (byte)((j + S[i] + key[i % key.Length]) % 256);
        (S[i], S[j]) = (S[j], S[i]);
      }
      return S;
    }

    public static byte[] PRGA(byte[] S)
    {
      byte[] K = new byte[256];
      byte i = 0, j = 0;
      for (int idx = 0; idx < 256; idx++)
      {
        i = (byte)((i + 1) % 256);
        j = (byte)((j + S[i]) % 256);
        (S[i], S[j]) = (S[j], S[i]);
        K[idx] = S[(S[i] + S[j]) % 256];
      }
      return K;
    }

    public static string Encrypt(string data, string key)
    {
      byte[] _data = Encoding.UTF8.GetBytes(data);
      byte[] _key = Encoding.UTF8.GetBytes(key);
      byte[] S = KSA(_key);
      byte[] gen = PRGA(S);
      byte[] result = new byte[_data.Length];
      for (int i = 0; i < _data.Length; i++)
      {
        result[i] = (byte)(_data[i] ^ gen[i]);
      }
      return Convert.ToBase64String(result);
    }

    public static string Decrypt(string data, string key)
    {
      byte[] _data = Convert.FromBase64String(data);
      byte[] _key = Encoding.UTF8.GetBytes(key);
      byte[] S = KSA(_key);
      byte[] gen = PRGA(S);
      byte[] result = new byte[_data.Length];
      for (int i = 0; i < _data.Length; i++)
      {
        result[i] = (byte)(_data[i] ^ gen[i]);
      }
      return Encoding.UTF8.GetString(result);
    }
  }

}
