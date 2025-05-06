using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Athena.Core
{
    /// <summary>
    /// The purpose of the seed manager is to namespace the seeds for each randomized group.
    /// This allows us to do thread-safe, concurrent randomization. Furthermore, given the same
    /// weapons, drops and a given seed, the randomization routine will be backwards compatible
    /// for all versions of the randomizer.
    /// </summary>
    public class SeedManager
    {
        private readonly int _baseSeed;
        private readonly ConcurrentDictionary<string, Random> _namespaceRngs = new();

        public SeedManager(int? customBaseSeed = null)
        {
            _baseSeed = customBaseSeed ?? GenerateSecureSeed();
        }

        public int GetBaseSeed() { return _baseSeed; }

        public Random GetRandom(string namespaceKey)
        {
            return _namespaceRngs.GetOrAdd(namespaceKey, ns =>
            {
                int derivedSeed = DeriveSeed(_baseSeed, ns);
                return new Random(derivedSeed);
            });
        }

        private static int GenerateSecureSeed()
        {
            byte[] bytes = new byte[4];
            RandomNumberGenerator.Fill(bytes);
            return BitConverter.ToInt32(bytes, 0) & int.MaxValue;
        }

        private static int DeriveSeed(int baseSeed, string context)
        {
            using var sha256 = SHA256.Create();
            byte[] baseBytes = BitConverter.GetBytes(baseSeed);
            byte[] contextBytes = Encoding.UTF8.GetBytes(context);
            byte[] combined = baseBytes.Concat(contextBytes).ToArray();
            byte[] hash = sha256.ComputeHash(combined);

            return BitConverter.ToInt32(hash, 0) & int.MaxValue;
        }
    }
}
