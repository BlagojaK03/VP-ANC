using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace VP_ANC
{

	// Throw this exception when the user presses 5 on their keyboard. The message argument should be the following:
	// TODO: What message?
	/*
	 * 
	 */
	internal class FiveOnKeyboardPressedException : Exception
	{
		public FiveOnKeyboardPressedException() { }
		public FiveOnKeyboardPressedException(string message) : base(message) { }
		public FiveOnKeyboardPressedException(string message, Exception inner) : base(message, inner) { }
	}

	internal class ANC_Logic
	{
		public string Addition(string arg1, string arg2)
		{
			return arg1 + arg2;
		}

		//TODO: Add logic to methods
		public void Subtraction() { }
		public void Multiplication() { }
		public void Divide() { }
		public void Modulo() { }
		public void Factorial() { }
		public void Power() { }
		public void Root() { }
	}
}
