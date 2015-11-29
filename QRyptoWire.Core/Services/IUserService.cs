﻿namespace QRyptoWire.Core.Services
{
	public interface IUserService
	{
		bool Login(string password);
		bool Register(string password);
		bool GetPushSettings();
		void SetPushSettings(bool pushesAllowed);
	}
}
