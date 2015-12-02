﻿using System.Collections.Generic;
using QRyptoWire.Core.Objects;
using QRyptoWire.Shared.Dto;

namespace QRyptoWire.Core.Services
{
	public interface IMessageService
	{
		void SendMessage(Message message);
		void FetchMessages();
		void AddContact(QrContact contact);
		void FetchContacts();
	}
}
