using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace QuincyGameEnginePractice.GameScripts
{
	public class InputHandler : GameObject
	{
		static KeyboardState currentKeyboard;
		static KeyboardState previousKeyboard;

		static MouseState currentMouse;
		static MouseState previousMouse;

		static GamePadState[] currentPadState;
		static GamePadState[] previousPadState;

		public static KeyboardState CurrentKeyboard
		{
			get { return currentKeyboard; }
		}

		public static KeyboardState PreviousKeyboard
		{
			get { return previousKeyboard; }
		}

		public static MouseState CurrentMouse
		{
			get { return currentMouse; }
		}

		public static MouseState PreviousMouse
		{
			get { return previousMouse; }
		}

		public static GamePadState[] CurrentPadState
		{
			get { return currentPadState; }
		}

		public static GamePadState[] PreviousPadState
		{
			get { return previousPadState; }
		}

		public InputHandler() : base(true)
		{
			IsEnabled = true;
			currentKeyboard = Keyboard.GetState();
			currentMouse = Mouse.GetState();
			currentPadState = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];

			foreach(PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
				currentPadState[(int)index] = GamePad.GetState(index);
		}

		public override void Update(GameTime gameTime)
		{
			previousKeyboard = currentKeyboard;
			currentKeyboard = Keyboard.GetState();

			previousMouse = currentMouse;
			currentMouse = Mouse.GetState();

			previousPadState = (GamePadState[])currentPadState.Clone();
			foreach(PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
				currentPadState[(int)index] = GamePad.GetState(index);
		}

		public static void Flush()
		{
			previousKeyboard = currentKeyboard;
			previousMouse = currentMouse;
			previousPadState = currentPadState;
		}

		public static bool KeyReleased(Keys k)
		{
			return currentKeyboard.IsKeyUp(k) && previousKeyboard.IsKeyDown(k);
		}

		public static bool KeyPressed(Keys k)
		{
			return currentKeyboard.IsKeyDown(k) && previousKeyboard.IsKeyUp(k);
		}

		public static bool KeyDown(Keys k)
		{
			return currentKeyboard.IsKeyDown(k);
		}

		public static bool MouseLeftClicked()
		{
			return currentMouse.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released;
		}

		public static bool MouseLeftHeld()
		{
			return currentMouse.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Pressed;
		}

		public static bool MouseLeftReleased(Keys k)
		{
			return currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed;
		}

		public static bool MouseRightClicked()
		{
			return currentMouse.RightButton == ButtonState.Pressed && previousMouse.RightButton == ButtonState.Released;
		}

		public static bool MouseRightHeld()
		{
			return currentMouse.RightButton == ButtonState.Pressed && previousMouse.RightButton == ButtonState.Pressed;
		}

		public static bool MouseRightReleased(Keys k)
		{
			return currentMouse.RightButton == ButtonState.Released && previousMouse.RightButton == ButtonState.Pressed;
		}

		public static bool MouseStateChanged()
		{
			if(currentMouse != previousMouse)
				return true;
			return false;
		}

		public static bool ScrollWheelUp()
		{
			if(currentMouse.ScrollWheelValue > previousMouse.ScrollWheelValue)
				return true;
			return false;
		}

		public static bool ScrollWheelDown()
		{
			if(currentMouse.ScrollWheelValue < previousMouse.ScrollWheelValue)
				return true;
			return false;
		}

		/// <summary>
		/// No love for gamepads
		/// </summary>
		/// <param name="button"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static bool ButtonReleased(Buttons button, PlayerIndex index)
		{
			return currentPadState[(int)index].IsButtonUp(button) && previousPadState[(int)index].IsButtonDown(button);
		}
		public static bool ButtonPressed(Buttons button, PlayerIndex index)
		{
			return currentPadState[(int)index].IsButtonDown(button) && previousPadState[(int)index].IsButtonUp(button);
		}
		public static bool ButtonDown(Buttons button, PlayerIndex index)
		{
			return currentPadState[(int)index].IsButtonDown(button);
		}
	}
}

