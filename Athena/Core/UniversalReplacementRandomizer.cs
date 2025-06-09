using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Core;

public static class ListRandomizationExtensions
{
    // FisherYates shuffle is a uniformly random shuffle algorithm: any permutation is equally likely
    public static void FisherYatesShuffle<T>(this IList<T> list, Random rng)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);                 // choose a random index to replace the value at the current position of the array
            (list[i], list[j]) = (list[j], list[i]); // swap the values
        }
    }

    // same thing, but start from the 0-index of the array instead of the other end.
    public static void ReverseFisherYatesShuffle<T>(this IList<T> list, Random rng)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            int j = rng.Next(i, list.Count);         // choose a random index to replace the value at the current position of the array
            (list[i], list[j]) = (list[j], list[i]); // swap the values
        }
    }

    // a generator that performs the FisherYates shuffle one step at a time.
    public static IEnumerable<(int, T)> LazyFisherYatesShuffle<T>(this IList<T> list, Random rng)
    {
        // the last value is implicitly chosen (i > 0)
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);                 // choose a random index to replace the value at the current position of the array
            (list[i], list[j]) = (list[j], list[i]); // swap the values
            yield return (i, list[i]);               // yield the current index and its finalized replacement
        }
        yield return (0, list[0]);                   // yield the final index and its finalized replacement
    }

    // a generator that performs the FisherYates shuffle one step at a time, in reverse.
    public static IEnumerable<(int, T)> LazyReverseFisherYatesShuffle<T>(this IList<T> list, Random rng)
    {
        // the last value is implicitly chosen (i < list.Count - 1)
        for (int i = 0; i < list.Count - 1; i++)
        {
            int j = rng.Next(i, list.Count);         // choose a random index to replace the value at the current position of the array
            (list[i], list[j]) = (list[j], list[i]); // swap the values
            yield return (i, list[i]);               // yield the current index and its finalized replacement
        }
        yield return (list.Count - 1, list[list.Count - 1]); // yield the final index and its finalized replacement
    }
}

public interface IReplacementValidator
{
    public bool Validate(int target, int replacement);
}

public class RandomizationGroup
{
    private List<int> Targets;      // integers to be replaced
    private List<int> Replacements; // integers that can potentially replace any location in the targets array
    
    private readonly IReplacementValidator? ReplacementValidator;

    public RandomizationGroup(List<int> targets, List<int> replacements, IReplacementValidator? replacementValidator = null)
    {
        Targets = targets;
        Replacements = replacements;
        ReplacementValidator = replacementValidator;
    }

    public Dictionary<int, int> Randomize(Random rng)
    {
        // FY shuffles arrays in-place. copy the replacements before randomizing.
        List<int> replacements = new(Replacements);
        replacements.FisherYatesShuffle(rng);

        // format results as a dictionary mapping target => replacement
        Dictionary<int, int> targetsToReplacements = new();
        for (int i = 0; i < Targets.Count; i++)
        {
            targetsToReplacements[Targets[i]] = replacements[i % replacements.Count];
        }
        return targetsToReplacements;
    }
    
    public Dictionary<int, int> ValidatedRandomize(Random rng)
    {
        if (ReplacementValidator == null)
            throw new Exception("ReplacementValidator not implemented!");
        
        // FY shuffles arrays in-place. copy the replacements before randomizing.
        List<int> replacements = new(Replacements);

        // iterate through the replacements, validing after each finalized replacement.
        foreach ((int i, int replacement) in replacements.LazyReverseFisherYatesShuffle(rng))
        {
            if (i >= Targets.Count)
                break; // finished generating the replacements. they were all valid.
            if (!ReplacementValidator.Validate(Targets[i], replacement))
                throw new Exception("Randomization failed to generate a valid result.");
        }

        // there will be duplicates in this case. check that the duplicates are also valid.
        if (replacements.Count < Targets.Count)
        {
            for (int i = replacements.Count; i < Targets.Count; i++)
            {
                if (!ReplacementValidator.Validate(Targets[i], replacements[i % replacements.Count]))
                    throw new Exception("Randomization failed to generate a valid result.");
            }
        }

        // format results as a dictionary mapping target => replacement
        Dictionary<int, int> targetsToReplacements = new Dictionary<int, int>();
        for (int i = 0; i < Targets.Count; i++)
        {
            targetsToReplacements[Targets[i]] = replacements[i % replacements.Count];
        }
        return targetsToReplacements;
    }

    public Dictionary<int, int> RetryingValidatedRandomize(Random rng, int? maxAttempts = 100)
    {
        if (ReplacementValidator == null)
            throw new Exception("ReplacementValidator not implemented!");

        // track attempts
        int iterations = 0;

    Retry:
        while (iterations++ < maxAttempts)
        {
            List<int> replacements = new(Replacements);

            foreach ((int i, int replacement) in replacements.LazyReverseFisherYatesShuffle(rng))
            {
                if (i >= Targets.Count)
                    break;      // finished generating the replacements. they were all valid.
                if (!ReplacementValidator.Validate(Targets[i], replacement))
                    goto Retry; // invalid replacement encountered, go to next loop
            }

            // there will be duplicates in this case. check that the duplicates are also valid. unfortunately, there's some efficiency loss with how this is coded.
            if (replacements.Count < Targets.Count)
            {
                for (int i = replacements.Count; i < Targets.Count; i++)
                {
                    if (!ReplacementValidator.Validate(Targets[i], replacements[i % replacements.Count]))
                        goto Retry; // invalid replacement encountered, go to next loop
                }
            }

            // format results as a dictionary mapping target => replacement
            Dictionary<int, int> targetsToReplacements = new Dictionary<int, int>();
            for (int i = 0; i < Targets.Count; i++)
            {
                targetsToReplacements[Targets[i]] = replacements[i % replacements.Count];
            }
            return targetsToReplacements;
        }
        throw new Exception($"Randomization failed to generate a valid result after {maxAttempts} attempts.");
    }
}



public class UniversalReplacementRandomizer
{
    private readonly SeedManager SeedManager;
    private readonly Dictionary<string, RandomizationGroup> Groups; // SeedManager key => RandomizationGroup
        
    public int GetBaseSeed() { return SeedManager.GetBaseSeed(); } // necessary for deterministic randomization

    public UniversalReplacementRandomizer(int? baseSeed = null)
    {
        Groups = new Dictionary<string, RandomizationGroup>();
        SeedManager = new SeedManager(baseSeed);
    }

    public Dictionary<string, Dictionary<int, int>> RandomizeAllGroups()
    {
        // shuffle every group in the Groups dictionary by iterating through all keys present
        List<string> keys = Groups.Keys.ToList();

        // format results as a dictionary of dictionaries mapping key => replacementsDictionary
        Dictionary<string, Dictionary<int, int>> result = new();

        foreach (string key in keys)
        {
            Random rng = SeedManager.GetRandomByKey(key);  // retrieve the namespaced randomness generator
            result[key] = Groups[key].Randomize(rng); // direct access by key, since it's generated from the dictionary
        }

        return result;
    }

    public Dictionary<int, int> RandomizeGroup(string key)
    {
        Random rng = SeedManager.GetRandomByKey(key);
        if (!Groups.TryGetValue(key, out RandomizationGroup? group))
        {
            throw new Exception("Unrecognized key");
        }
        return group.Randomize(rng);
    }

    public Dictionary<int, int> RetryingRandomizeGroup(string key, int? maxAttempts = null)
    {
        Random rng = SeedManager.GetRandomByKey(key);
        if (!Groups.TryGetValue(key, out RandomizationGroup? group))
        {
            throw new Exception("Unrecognized key");
        }

        return group.RetryingValidatedRandomize(rng, maxAttempts);
    }

    public void AddGroup(string key, RandomizationGroup group)
    {
        // add a new randomization group
        if (Groups.ContainsKey(key))
        {
            throw new Exception($"Dictionary {nameof(Groups)} already contains key: {key}");
        }
        Groups.Add(key, group);
    }
}

public class EncodedBitmapValidator : IReplacementValidator
{
    private readonly Dictionary<int, int> TargetEncodedBitmaps;
    private readonly Dictionary<int, int> ReplacementEncodedBitmaps;

    public Dictionary<string, Func<int, int, bool>>? ValidatorsByKey { get; set; }

    public EncodedBitmapValidator(Dictionary<int, int> targetEncodedBitmaps, Dictionary<int, int> replacementEncodedBitmaps)
    {
        TargetEncodedBitmaps = targetEncodedBitmaps;
        ReplacementEncodedBitmaps = replacementEncodedBitmaps;
    }

    public bool Validate(int target, int replacement)
    {
        if (!TargetEncodedBitmaps.TryGetValue(target, out int targetEncodedBitmap))
            return true;                                              // the target doesn't have any conflicts
        if (!ReplacementEncodedBitmaps.TryGetValue(replacement, out int replacementEncodedBitmap))
            return true;                                              // the replacement doesn't have any conflicts
        return (targetEncodedBitmap & replacementEncodedBitmap) == 0; // we have to check for conflicts between the two
    }
}
