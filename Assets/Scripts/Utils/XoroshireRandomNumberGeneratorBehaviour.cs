using System;
using UnityEngine;

namespace Scripts.Utils
{
	public class XoroshireRandomNumberGeneratorBehaviour : MonoBehaviour, IRandomNumberGenerator
	{
		IRandomNumberGenerator _rng;

		public ulong RNGMaximum
		{
			get
			{
				return _rng.RNGMaximum;
			}
		}

		void Awake()
		{
			_rng = new XoroshiroRandomNumberGenerator();
		}

		public float NextFloat()
		{
			return _rng.NextFloat();
		}

		public ulong NextRandom()
		{
			return _rng.NextRandom();
		}

		public ulong RandomDice(ulong sides, ulong addon = 1)
		{
			return _rng.RandomDice(sides, addon);
		}

		public void UpdateSeed()
		{
			_rng.UpdateSeed();
		}
	}
}
