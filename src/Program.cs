using CommandLine;
using simple_rc4_cs;

Parser.Default.ParseArguments<Options>(args)
  .WithParsed(options =>
  {
    string key = options.Key!;
    string message = options.Message!;

    string encryptResult = RC4.Encrypt(message, key);
    string decryptResult = RC4.Decrypt(encryptResult, key);

    Console.WriteLine($"original: {message}");
    Console.WriteLine($"encrypt: {encryptResult}");
    Console.WriteLine($"decrypt: {decryptResult}");
  });

class Options
{
  [Option('k', "key", Required = true, HelpText = "暗号化キー")]
  public string? Key { get; set; }

  [Option('m', "message", Required = true, HelpText = "暗号化するメッセージ")]
  public string? Message { get; set; }
}
