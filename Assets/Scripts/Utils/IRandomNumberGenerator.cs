namespace Scripts.Utils
{
	public interface IRandomNumberGenerator
	{
		ulong RNGMaximum { get; }

		ulong NextRandom();
		ulong RandomDice(ulong sides, ulong addon = 1);
		float NextFloat();

		void UpdateSeed();
	}
}