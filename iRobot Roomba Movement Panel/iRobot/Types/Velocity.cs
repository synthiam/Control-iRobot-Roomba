namespace Create2OI.Types
{
	/// <summary>
	/// This structure is used to read and set Roomba's velocity. This structure is designed to be used as a variable.
	/// This structure also serves to keep any assigned variables within the limits of the OI spec
	/// The limits are: -500mm/s - 500 mm/s
	/// 
	/// </summary>
	/// <example>
	/// Velocity x = 250; // if the user sets this to a value > 500, then x will automatically set itself to 500
	/// Radius y = -400;
	/// this.CurrentCreate.Drive(x, y);
	/// </example>
	public struct Velocity
	{
		private readonly int _value;

		public const int MAXIMUM_FORWARD = 500;
		public const int MAXIMUM_REVERSE = -500;

		public static implicit operator Velocity(int iValue)
		{
			return new Velocity(iValue);
		}
		public Velocity(int iSpeed)
		{
			if (iSpeed > MAXIMUM_FORWARD) { iSpeed = MAXIMUM_FORWARD; }
			if (iSpeed < MAXIMUM_REVERSE) { iSpeed = MAXIMUM_REVERSE; }

			_value = iSpeed;
		}
		public int ToInt
		{
			get
			{
				return _value;
			}
		}
	}
}
