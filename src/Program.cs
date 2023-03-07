Console.Write("Key: ");
string key = Console.ReadLine()!;
Console.Write("Message: ");
string message = Console.ReadLine()!;

Console.WriteLine($"key: {key}");
Console.WriteLine($"message: {message}");

Console.Clear();

string encryptResult = RC4.Encrypt(message, key);
string decryptResult = RC4.Decrypt(encryptResult, key);

Console.WriteLine($"original: {message}");
Console.WriteLine($"encrypt: {encryptResult}");
Console.WriteLine($"decrypt: {decryptResult}");
