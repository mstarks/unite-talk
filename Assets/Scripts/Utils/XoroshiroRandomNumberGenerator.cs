using System;

namespace Scripts.Utils
{
	public class XoroshiroRandomNumberGenerator : IRandomNumberGenerator
	{
		// From http://xorshift.di.unimi.it/ - some other variants available there also.
		// Originally written in 2016 by David Blackman and Sebastiano Vigna (vigna@acm.org)
		// See <http://creativecommons.org/publicdomain/zero/1.0/>.
		// This is the successor to xorshift128+. It is the fastest full-period
		// generator passing BigCrush without systematic failures, but due to the
		// relatively short period it is acceptable only for applications with a
		// mild amount of parallelism.

		public ulong RNGMaximum { get; private set; }

		ulong[] _seed;

		public XoroshiroRandomNumberGenerator() : this((ulong)DateTime.Now.Ticks, (ulong)DateTime.Now.Ticks) { }

		public XoroshiroRandomNumberGenerator(ulong seedLow, ulong seedHigh)
		{
			RNGMaximum = ulong.MaxValue;
			_seed = new ulong[2] { seedLow, seedHigh };
		}

		ulong rotateLeft(ulong x, int k)
		{
			return (x << k) | (x >> (64 - k));
		}

		public ulong NextRandom()
		{
			ulong s0 = _seed[0];
			ulong s1 = _seed[1];
			ulong result = s0 + s1;

			s1 ^= s0;
			_seed[0] = rotateLeft(s0, 55) ^ s1 ^ (s1 << 14); // a, b
			_seed[1] = rotateLeft(s1, 36); // c

			return result;
		}

		public float NextFloat()
		{
			float xorRN = (float)NextRandom();
			return (xorRN / (float)ulong.MaxValue);
		}

		public ulong RandomDice(ulong sides, ulong addon = 1)
		{
			ulong roll = 0;
			ulong fullRanges = RNGMaximum / sides; // integer divide, fraction truncated
			ulong maxRoll = sides * fullRanges;

			do
			{
				roll = NextRandom();
				// from Dr. Cat: roll = NextRandomNumber() % sides;
			}
			while (roll > maxRoll);

			return ((roll % sides) + addon);
		}

		public void UpdateSeed()
		{
			ulong seedLow = (ulong)DateTime.Now.Ticks;
			ulong seedHigh = (ulong)DateTime.Now.Ticks;
			_seed = new ulong[2] { seedLow, seedHigh };
		}



		// TODO: Implement the jump function if ever needed for parallelism.
	}

}