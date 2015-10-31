﻿using Cirrious.MvvmCross.ViewModels;
using QRyptoWire.Core.Enums;
using QRyptoWire.Core.Services;

namespace QRyptoWire.Core.ViewModels
{
	public class LoginViewModel : QryptoViewModel
	{
		private readonly IStorageService _storageService;
		private readonly IUserService _userService;
		private bool _registering;
		private string _password;
		private string _errorMessage;

		public LoginViewModel(IStorageService storageService, IUserService userService)
		{
			_storageService = storageService;
			_userService = userService;

			if (!_storageService.PublicKeyExists())
				Registering = true;
			Menu = new MenuViewModel(MenuMode.AtHome);
			ProceedCommand = new MvxCommand(ProceedCommandAction, ValidatePassword);
		}

		public MenuViewModel Menu { get; set; }

		public bool Registering
		{
			get { return _registering; }
			set
			{
				_registering = value; 
				RaisePropertyChanged();
			}
		}

		public string Password
		{
			get { return _password; }
			set
			{
				_password = value; 
				ProceedCommand.RaiseCanExecuteChanged();
			}
		}

		private bool ValidatePassword()
		{
			if (string.IsNullOrWhiteSpace(Password) || Password.Length < 8)
				return false;
			return true;
		}

		public string ErrorMessage
		{
			get { return _errorMessage; }
			set
			{
				_errorMessage = value;
				RaisePropertyChanged();
			}
		}

		public IMvxCommand ProceedCommand { get; private set; }
		private void ProceedCommandAction()
		{
			if (Registering)
				MakeApiCallAsync(() => _userService.Register(Password), b =>
				{
					if (b)
						ShowViewModel<RegistrationViewModel>();
				});
			else
				MakeApiCallAsync(() => _userService.Login(Password), b =>
				{
					if (b)
						ShowViewModel<HomeViewModel>();
					else
						ErrorMessage = "Invalid password";
				});
		}
	}
}
