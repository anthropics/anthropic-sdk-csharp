using Anthropic.Helpers.Fallbacks;

namespace Anthropic.Tests.Helpers.Fallbacks;

public class ChainPolicyTest
{
    static ChainPolicy Buffered(int entryCount, int initialIndex = -1, bool[]? overrides = null) =>
        new(ChainPolicy.Mode.Buffered, entryCount, overrides ?? new bool[entryCount], initialIndex);

    static ChainPolicy Spliced(int entryCount, int initialIndex = -1) =>
        new(ChainPolicy.Mode.Spliced, entryCount, new bool[entryCount], initialIndex);

    [Fact]
    public void RefusalChainsToTheNextEntryAndCarriesTheToken()
    {
        var policy = Buffered(entryCount: 2);

        var directive = policy.OnRefusal(token: "token-1", category: "safety", prefillClaim: false);

        Assert.Equal(ChainPolicy.Directive.SendEntry, directive);
        Assert.Equal(0, policy.CurrentIndex);
        Assert.Equal("token-1", policy.CarriedToken);
        Assert.Equal("safety", policy.CarriedCategory);
        var refusal = Assert.Single(policy.Refusals);
        Assert.Equal(new ChainPolicy.RefusalRecord(-1, "safety"), refusal);
    }

    [Fact]
    public void RefusalAtTheLastEntryDelivers()
    {
        var policy = Buffered(entryCount: 1, initialIndex: 0);

        Assert.Equal(
            ChainPolicy.Directive.Deliver,
            policy.OnRefusal("token", "safety", prefillClaim: false)
        );
        Assert.Empty(policy.Refusals);
    }

    [Fact]
    public void BufferedModeChainsTokenlessRefusals()
    {
        var policy = Buffered(entryCount: 2);

        Assert.Equal(
            ChainPolicy.Directive.SendEntry,
            policy.OnRefusal(token: null, category: null, prefillClaim: false)
        );
        Assert.Null(policy.CarriedToken);
        Assert.False(policy.TokenSeen);
    }

    [Fact]
    public void SplicedModeCannotChainTokenlessRefusals()
    {
        var policy = Spliced(entryCount: 2);

        Assert.Equal(
            ChainPolicy.Directive.Deliver,
            policy.OnRefusal(token: null, category: null, prefillClaim: false)
        );
    }

    [Fact]
    public void RefusalWithTokenMarksTokenSeenEvenWhenNotChainable()
    {
        var policy = Spliced(entryCount: 1, initialIndex: 0);

        policy.OnRefusal("token", null, prefillClaim: false);

        Assert.True(policy.TokenSeen);
    }

    [Fact]
    public void ChainWalksEveryEntryThenDelivers()
    {
        var policy = Buffered(entryCount: 3);

        Assert.Equal(ChainPolicy.Directive.SendEntry, policy.OnRefusal("t1", "c1", false));
        Assert.Equal(0, policy.CurrentIndex);
        Assert.Equal(ChainPolicy.Directive.SendEntry, policy.OnRefusal("t2", "c2", false));
        Assert.Equal(1, policy.CurrentIndex);
        Assert.Equal(ChainPolicy.Directive.SendEntry, policy.OnRefusal("t3", "c3", false));
        Assert.Equal(2, policy.CurrentIndex);
        Assert.Equal(ChainPolicy.Directive.Deliver, policy.OnRefusal("t4", "c4", false));

        Assert.Equal(
            [
                new ChainPolicy.RefusalRecord(-1, "c1"),
                new ChainPolicy.RefusalRecord(0, "c2"),
                new ChainPolicy.RefusalRecord(1, "c3"),
            ],
            policy.Refusals
        );
        Assert.Equal("t3", policy.CarriedToken);
        Assert.Equal("c3", policy.CarriedCategory);
    }

    [Fact]
    public void CarriedPrefillClaimTracksTheLatestRefusal()
    {
        var policy = Spliced(entryCount: 3);

        policy.OnRefusal("t1", null, prefillClaim: true);
        Assert.True(policy.CarriedPrefillClaim);
        policy.OnRefusal("t2", null, prefillClaim: false);
        Assert.False(policy.CarriedPrefillClaim);
    }

    [Fact]
    public void FirstResponseErrorDeliversWithoutChaining()
    {
        var policy = Buffered(entryCount: 3);

        Assert.Equal(
            ChainPolicy.Directive.Deliver,
            policy.OnHopError(badRequest: false, extraIncluded: false)
        );
        Assert.Equal(-1, policy.CurrentIndex);
    }

    [Fact]
    public void HopErrorMidChainSkipsToTheNextEntry()
    {
        var policy = Buffered(entryCount: 3);
        policy.OnRefusal("token", null, false);

        var directive = policy.OnHopError(badRequest: false, extraIncluded: true);

        Assert.Equal(ChainPolicy.Directive.SendEntry, directive);
        Assert.Equal(1, policy.CurrentIndex);
        Assert.Equal("token", policy.CarriedToken);
    }

    [Fact]
    public void HopErrorOnTheLastEntryDeliversInBufferedMode()
    {
        var policy = Buffered(entryCount: 1);
        policy.OnRefusal("token", null, false);

        Assert.Equal(
            ChainPolicy.Directive.Deliver,
            policy.OnHopError(badRequest: false, extraIncluded: true)
        );
    }

    [Fact]
    public void HopErrorOnTheLastEntryDegradesInSplicedMode()
    {
        var policy = Spliced(entryCount: 1);
        policy.OnRefusal("token", null, false);

        Assert.Equal(
            ChainPolicy.Directive.DegradedClose,
            policy.OnHopError(badRequest: false, extraIncluded: true)
        );
    }

    [Fact]
    public void SplicedBadRequestWithPrefillRetriesOnceWithoutIt()
    {
        var policy = Spliced(entryCount: 2);
        policy.OnRefusal("token", null, prefillClaim: true);

        Assert.Equal(
            ChainPolicy.Directive.ResendWithoutExtra,
            policy.OnHopError(badRequest: true, extraIncluded: true)
        );
        Assert.Equal(0, policy.CurrentIndex);

        // When the reduced retry also fails, the chain moves on instead of retrying again.
        Assert.Equal(
            ChainPolicy.Directive.SendEntry,
            policy.OnHopError(badRequest: true, extraIncluded: false)
        );
        Assert.Equal(1, policy.CurrentIndex);
    }

    [Fact]
    public void SplicedBadRequestWithoutPrefillSkipsInsteadOfRetrying()
    {
        var policy = Spliced(entryCount: 2);
        policy.OnRefusal("token", null, prefillClaim: false);

        Assert.Equal(
            ChainPolicy.Directive.SendEntry,
            policy.OnHopError(badRequest: true, extraIncluded: false)
        );
    }

    [Fact]
    public void BufferedBadRequestRetriesWithoutTokenWhenAttemptedEntryHasOverrides()
    {
        var policy = Buffered(entryCount: 2, overrides: [false, true]);
        policy.OnRefusal("token", null, false); // -> entry 0
        policy.OnHopError(badRequest: false, extraIncluded: true); // 0 errors -> entry 1

        Assert.Equal(1, policy.CurrentIndex);
        Assert.Equal(
            ChainPolicy.Directive.ResendWithoutExtra,
            policy.OnHopError(badRequest: true, extraIncluded: true)
        );
    }

    [Fact]
    public void BufferedBadRequestRetriesWithoutTokenWhenMintedEntryHadOverrides()
    {
        // The token was minted against entry 0's overridden body; entry 1 is model-only.
        var policy = Buffered(entryCount: 2, initialIndex: 0, overrides: [true, false]);
        policy.OnRefusal("token", null, false); // refused at 0 (minted), advances to 1

        Assert.Equal(
            ChainPolicy.Directive.ResendWithoutExtra,
            policy.OnHopError(badRequest: true, extraIncluded: true)
        );
    }

    [Fact]
    public void BufferedBadRequestWithModelOnlyEntriesDoesNotRetry()
    {
        var policy = Buffered(entryCount: 3, overrides: [false, false, false]);
        policy.OnRefusal("token", null, false); // -> entry 0

        Assert.Equal(
            ChainPolicy.Directive.SendEntry,
            policy.OnHopError(badRequest: true, extraIncluded: true)
        );
    }

    [Fact]
    public void BufferedBadRequestWithoutTokenDoesNotRetry()
    {
        var policy = Buffered(entryCount: 3, overrides: [true, true, true]);
        policy.OnRefusal(token: null, category: null, prefillClaim: false); // tokenless chain

        // No token attached, so a 400 can't be a token conflict.
        Assert.Equal(
            ChainPolicy.Directive.SendEntry,
            policy.OnHopError(badRequest: true, extraIncluded: false)
        );
    }

    [Fact]
    public void BadRequestRetryHappensBeforeExhaustionOnTheLastEntry()
    {
        var policy = Buffered(entryCount: 1, overrides: [true]);
        policy.OnRefusal("token", null, false); // -> entry 0, the last

        Assert.Equal(
            ChainPolicy.Directive.ResendWithoutExtra,
            policy.OnHopError(badRequest: true, extraIncluded: true)
        );
        // Once the reduced retry also fails, the last entry's error is delivered.
        Assert.Equal(
            ChainPolicy.Directive.Deliver,
            policy.OnHopError(badRequest: true, extraIncluded: false)
        );
    }

    [Fact]
    public void RetryBudgetResetsPerEntry()
    {
        var policy = Buffered(entryCount: 3, overrides: [true, true, true]);
        policy.OnRefusal("token", null, false); // -> entry 0

        Assert.Equal(
            ChainPolicy.Directive.ResendWithoutExtra,
            policy.OnHopError(badRequest: true, extraIncluded: true)
        );
        Assert.Equal(
            ChainPolicy.Directive.SendEntry,
            policy.OnHopError(badRequest: true, extraIncluded: false)
        );
        // Entry 1 gets its own retry.
        Assert.Equal(
            ChainPolicy.Directive.ResendWithoutExtra,
            policy.OnHopError(badRequest: true, extraIncluded: true)
        );
    }

    [Fact]
    public void ServedWithoutAnyRefusalPinsNothing()
    {
        var policy = Buffered(entryCount: 3, initialIndex: 1);

        Assert.Null(policy.OnServed());
    }

    [Fact]
    public void ServedAfterARefusalPinsTheServingEntry()
    {
        var policy = Buffered(entryCount: 3);
        policy.OnRefusal("token", null, false); // -> entry 0
        policy.OnHopError(badRequest: false, extraIncluded: true); // 0 errors -> entry 1

        Assert.Equal(1, policy.OnServed());
    }

    [Fact]
    public void PinnedStartRefusalRecordsThePinnedIndex()
    {
        var policy = Buffered(entryCount: 3, initialIndex: 1);

        policy.OnRefusal("token", "cat", false);

        Assert.Equal(new ChainPolicy.RefusalRecord(1, "cat"), Assert.Single(policy.Refusals));
        Assert.Equal(2, policy.CurrentIndex);
    }
}
