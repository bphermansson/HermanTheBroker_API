// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");
var password = "password";

if (password == null)
{
    throw new ArgumentNullException("password");
}

const int Pbkdf2Iterations = 1000;


var pwh = Convert.ToBase64String(HashPasswordV3(password, RandomNumberGenerator.Create()
            , prf: KeyDerivationPrf.HMACSHA512, iterCount: Pbkdf2Iterations, saltSize: 128 / 8
            , numBytesRequested: 256 / 8));


Console.WriteLine(pwh);

static byte[] HashPasswordV3(string password, RandomNumberGenerator rng, KeyDerivationPrf prf, int iterCount, int saltSize, int numBytesRequested)
{
    byte[] salt = new byte[saltSize];
    rng.GetBytes(salt);
    byte[] subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);
    var outputBytes = new byte[13 + salt.Length + subkey.Length];
    outputBytes[0] = 0x01; // format marker
    WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
    WriteNetworkByteOrder(outputBytes, 5, (uint)iterCount);
    WriteNetworkByteOrder(outputBytes, 9, (uint)saltSize);
    Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
    Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
    return outputBytes;
}

static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
{
    buffer[offset + 0] = (byte)(value >> 24);
    buffer[offset + 1] = (byte)(value >> 16);
    buffer[offset + 2] = (byte)(value >> 8);
    buffer[offset + 3] = (byte)(value >> 0);
}

static uint ReadNetworkByteOrder(byte[] buffer, int offset)
{
    return ((uint)(buffer[offset + 0]) << 24)
        | ((uint)(buffer[offset + 1]) << 16)
        | ((uint)(buffer[offset + 2]) << 8)
        | ((uint)(buffer[offset + 3]));
}