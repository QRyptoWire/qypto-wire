﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRyptoWire.Core.Services.Stubs
{
    class EncryptionServiceStub : IEncryptionService
    {
        public bool IsLazyMotherfucker()
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string message, int recieverUUID)
        {
            throw new NotImplementedException();
        }

        public string Decrypt(string message, int senderUUID)
        {
            throw new NotImplementedException();
        }

        public bool ComposePublicKey(string modulus, string exponent, out string publicKey)
        {
            publicKey = String.Empty;
            return true;
        }
    }
}
